using Posts_graphql.Domain.Models;

namespace Posts_graphql.Infrastructure.Repository;

public interface INotificationRepository
{
    Task<List<Notification>> GetNotification(int? id);
    Task<Notification> AddEditNotification(Notification newNotification);
   
}
