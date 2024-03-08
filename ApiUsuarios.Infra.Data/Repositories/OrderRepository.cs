using ApiUsuarios.Infra.Data.Repositories;
using Delivery.Notification.Domain.Interfaces.Repositories;
using Delivery.Notification.Domain.Models;

namespace Delivery.Notification.SqlData.Repositories
{
    public class OrderRepository : BaseRepository<Order, Guid>, IOrderRepository
    {

    }
}
