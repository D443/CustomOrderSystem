using CustomOrderSystem.Entity;
using CutomOrderSystem.Reository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CustomOrderSystem.Operation
{
    public  class OrderOperation
    {
        OrderRepository _orderRepository;
        public OrderOperation()
        {
            _orderRepository = new OrderRepository();       
        }
        public List<Order> GetAllOrder()
        {
            try
            {
                return _orderRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                return _orderRepository.GetById(id);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public void DeleteOrder(Order order)
        {
            try
            {
                _orderRepository.Delete(order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteOrderById(int id)
        {
            try
            {
                _orderRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Order InsertOrder(Order order)
        {
            try
            {
               
                return _orderRepository.Insert(order);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Order UpdateOrder(Order order)
        {
            try
            {

                return _orderRepository.Update(order);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Order GetSingleOrderBy(Expression<Func<Order, bool>> filter = null)
        {
            try
            {
                return _orderRepository.GetSingleBy(filter);
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
        }

        public List<Order> GetOrderBy(Expression<Func<Order, bool>> filter = null, Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null)
        {
            try
            {
                return (_orderRepository.GetBy(filter, orderBy).ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
