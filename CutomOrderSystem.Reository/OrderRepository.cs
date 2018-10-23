using CustomOrderSystem.Entity;
using CustomOrderSystem.Reository.Base;
using CustomOrderSystem.Repository;
using System.Text;
using System.Threading.Tasks;

namespace CutomOrderSystem.Reository
{
   public class OrderRepository: EntityRepositoryBase<Order>, IOrderRepository
    {
    }
}
