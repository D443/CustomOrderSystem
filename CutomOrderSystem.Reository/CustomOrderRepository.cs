using CustomOrderSystem.Entity;
using CustomOrderSystem.Reository.Base;
using CustomOrderSystem.Repository;

namespace CutomOrderSystem.Reository
{
    public class CustomOrderRepository: EntityRepositoryBase<CustomerOrder>, ICustomOrderReository
    {
    }
}
