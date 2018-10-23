using CustomOrderSystem.Entity;
using CutomOrderSystem.Reository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomOrderSystem.Operation
{
   public class CustomOrderOperation
    {
        CustomOrderRepository _customOrderRepository;
        public CustomOrderOperation()
        {
            _customOrderRepository = new CustomOrderRepository();
        }
        public List<CustomerOrder> GetAllCustomerOrder()
        {
            try
            {
              
                return _customOrderRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public CustomerOrder GetCustomerOrderById(int id)
        {
            try
            {
                return _customOrderRepository.GetById(id);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        public void DeleteCustomOrder(CustomerOrder order)
        {
            try
            {
                _customOrderRepository.Delete(order);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public void DeleteCustomerOrderById(int id)
        {
            try
            {
                _customOrderRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public CustomerOrder InsertCustomerOrder(CustomerOrder order)
        {
            try
            {
             //   order.CustomerOrderId = GetAllCustomerOrder().Max(x => x.CustomerOrderId) + 1;
                return _customOrderRepository.Insert(order);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public CustomerOrder UpdateCustomerOrder(CustomerOrder order)
        {
            try
            {
                return _customOrderRepository.Update(order);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public CustomerOrder GetSingleCustomerOrderBy(Expression<Func<CustomerOrder, bool>> filter = null)
        {
            try
            {
                return _customOrderRepository.GetSingleBy(filter);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public List<CustomerOrder> GetCustomerOrderBy(Expression<Func<CustomerOrder, bool>> filter = null, Func<IQueryable<CustomerOrder>, IOrderedQueryable<CustomerOrder>> orderBy = null)
        {
            try
            {
                return (_customOrderRepository.GetBy(filter, orderBy).ToList());
            }
            catch (Exception ex)
            {
               
               
                throw ex;
            }
        }

    }
}
