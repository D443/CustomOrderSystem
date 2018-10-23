using CustomOrderSystem.Entity;
using CustomOrderSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomOrderSystem.Mapper
{
    public static class CustomerOrderMapper
    {
        public static CustomerOrderModel MapToWM(CustomerOrder entity, OrderModel order)
        {
            return new CustomerOrderModel()
            {

                UserId = entity.CustomerId,
                Order = order

            };
        }

        public static List<CustomerOrderModel> MapToWM(List<CustomerOrder> entity)
        {
            return entity.Select(x => new CustomerOrderModel()
            {

                UserId = x.CustomerId,
                Order = OrderMapper.MapToWM(x.Order)
            }).ToList();
        }
        public static List<CustomerOrder> MapToEntity(List<CustomerOrderModel> entity)
        {
            return entity.Select(x => new CustomerOrder()
            {

                CustomerId = x.UserId,
                OrderId = x.Order.ID
            }).ToList();
        }
        public static CustomerOrder MapToEntity(CustomerOrderModel _cutometorder)
        {
            return new CustomerOrder()
            {
                CustomerId = _cutometorder.UserId,
                OrderId = _cutometorder.Order.ID
            };
        }

    }
}
