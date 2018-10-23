using CustomOrderSystem.Entity;
using CustomOrderSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomOrderSystem.Mapper
{
  public static class OrderMapper
    {
        public static OrderModel MapToWM(Order entity)
        {
            return new OrderModel()
            {
                OrderAmount = entity.OrderAmount,
                OrderDescription = entity.OrderDescription,
                ID = entity.OrderId,
                ProductId= entity.ProductId

            };
        }
        public static List<OrderModel> MapToWM(List<Order> entity)
        {
            return entity.Select(x => new OrderModel()
            {
           
                OrderDescription = x.OrderDescription,
                OrderAmount = x.OrderAmount,
                ID=x.OrderId,
                ProductId=x.ProductId            
            }).ToList();
        }
        public static List<Order> MapToEntity(List<OrderModel> entity)
        {
            return entity.Select(x => new Order()
            {

                OrderDescription = x.OrderDescription,
                OrderAmount = x.OrderAmount,
                OrderId = x.ID,
                ProductId = x.ProductId
            }).ToList();
        }
        public static Order MapToEntity(OrderModel order)
        {
            return new Order()
            {
                OrderId = order.ID,
                OrderAmount = order.OrderAmount,
                ProductId = order.ProductId,
                OrderDescription = order.OrderDescription              
            };
        }
    }
}
