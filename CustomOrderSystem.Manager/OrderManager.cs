using CustomOrderSystem.Mapper;
using CustomOrderSystem.Model;
using CustomOrderSystem.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomOrderSystem.Manager
{
    public class OrderManager
    {
        readonly ProductOperation _productOperations;
        readonly OrderOperation _orderOperation;

        public OrderManager()
        {
            _productOperations = new ProductOperation();
            _orderOperation = new OrderOperation();
        }

        public OrderModel UpdateOrderModel(OrderModel order)
        {
            try
            {
             
             return GetOrderById(order.ID) ?? OrderMapper.MapToWM(_orderOperation.UpdateOrder(OrderMapper.MapToEntity(order)));
         
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<OrderModel> GetAllOrder()
        {
            try
            {
                return OrderMapper.MapToWM(_orderOperation.GetAllOrder());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderModel GetOrderById(int id)
        {
            try
            {
                var entityOrder = _orderOperation.GetOrderById(id);
                return OrderMapper.MapToWM(entityOrder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteOrder(OrderModel order)
        {
            try
            {
                _orderOperation.DeleteOrder(OrderMapper.MapToEntity(order));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteOrdertById(int id)
        {
            try
            {
                _orderOperation.DeleteOrderById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderModel InsertOrder(OrderModel order)
        {

            try
            {
                var entityOrder = _orderOperation.InsertOrder(OrderMapper.MapToEntity(order));
                return OrderMapper.MapToWM(entityOrder);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
