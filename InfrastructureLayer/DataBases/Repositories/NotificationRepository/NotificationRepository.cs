using Microsoft.EntityFrameworkCore;
using Posts_graphql.Domain.Models;
using Posts_graphql.Infrastructure.Context;

namespace Posts_graphql.Infrastructure.Repository;
public class NotificationRepository : INotificationRepository
{
    protected readonly IDbContextFactory<PostGrapghQlDbContext> _contextFactory;
    protected readonly PostGrapghQlDbContext dbContext;

    public NotificationRepository(IDbContextFactory<PostGrapghQlDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
        dbContext = contextFactory.CreateDbContext();
    }

    public async Task<List<Notification>> GetNotification(int? NotificationId)
    {
        try
        {
            if (NotificationId == null)
            {
                return await dbContext.Notification.Where(p => p.FlgDelete == false).ToListAsync();
            }
            else
            {
                return await dbContext.Notification.Where(p => p.FlgDelete == false && p.Id == NotificationId).ToListAsync();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while logging in: {ex.Message}");
            return null;
        }
    }
    public async Task<Notification> AddEditNotification(Notification newNotification)
    {
        try
        {
            if (newNotification.Id == null)
            {
                dbContext.Notification.Add(newNotification);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                var existingNotification = await dbContext.Notification.FirstOrDefaultAsync(n => n.Id == newNotification.Id && n.FlgDelete == false);
                newNotification.AddedBy = existingNotification.AddedBy;
                newNotification.AddedDateTime = existingNotification.AddedDateTime;
                 if(newNotification.FlgDelete == null){
                    newNotification.FlgDelete = false;
                }
                dbContext.Entry(existingNotification).CurrentValues.SetValues(newNotification);
                await dbContext.SaveChangesAsync();
            }
            return newNotification;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while logging in: {ex.Message}");
            return null;
        }
    }


}
