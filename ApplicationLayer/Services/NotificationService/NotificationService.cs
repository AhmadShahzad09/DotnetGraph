

using Posts_graphql.Domain.Models;
using Posts_graphql.Infrastructure.Repository;
namespace Posts_graphql.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationRepository _NotificationRepository;

        public NotificationService(NotificationRepository NotificationRepository)
        {
            _NotificationRepository = NotificationRepository;
        }
      
        public async Task<List<Notification>> GetNotification(int? NotificationId)
        {
            try
            {
                return await _NotificationRepository.GetNotification(NotificationId);
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
                    newNotification.FlgDelete = false;
                    newNotification.AddedDateTime = DateTime.Now;
                }
                else
                {
                    newNotification.UpdatedDateTime = DateTime.Now;
                }
                return await _NotificationRepository.AddEditNotification(newNotification);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging in: {ex.Message}");
                return null;
            }
        }


      
    }
}
