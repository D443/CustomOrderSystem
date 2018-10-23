using CustomOrderSystem.Entity;
using CustomOrderSystem.Mapper;
using CustomOrderSystem.Model;
using CustomOrderSystem.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CustomOrderSystem.Manager
{
    public class CustomerOrderManager
    {
        readonly CustomOrderOperation _customOrderOperation;
        readonly OrderOperation _orderOperation;
        readonly OrderManager _orderManager;
        readonly UserOperation _userOperation;
        public CustomerOrderManager()
        {
            _customOrderOperation = new CustomOrderOperation();
            _userOperation=new UserOperation();
            _orderOperation = new OrderOperation();
            _orderManager = new OrderManager();
        }


        public bool InsertAllCustomerOrders(CustomAllOrderModel model)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {

                    bool result = false;
                    if (_userOperation.GetUserById(model.UserId) != null)
                    {
                        foreach (var item in model.Orders)
                        {
                            var insertedOrder = _orderManager.InsertOrder(item);
                            if (insertedOrder != null)
                            {
                                var _customerOrder = _customOrderOperation.InsertCustomerOrder(new CustomerOrder
                                {
                                    CustomerId = model.UserId,
                                    OrderId = insertedOrder.ID
                                });

                                if (_customerOrder != null)
                                    result = true;
                                else
                                    result = false;
                            }
                            else
                                result = false;
                        }
                    }
                    transaction.Complete();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DeleteCusomerOrderUserBy(int userId)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {


                    var customerOrderList = _customOrderOperation.GetCustomerOrderBy(x => x.CustomerId == userId);
                    if (customerOrderList != null)
                    {
                        foreach (var item in customerOrderList)
                        {
                            _customOrderOperation.DeleteCustomerOrderById(item.CustomerOrderId);
                        }
                        foreach (var item in customerOrderList)
                        {
                            _orderOperation.DeleteOrderById(item.OrderId);
                        }
                    }

                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }    
        public CustomerOrderModel UpdateCustomerOrderModel(CustomerOrderModel _order)
        {
            try
            {
                if (_userOperation.GetUserById(_order.UserId) != null)
                {
                    _order.Order=_orderManager.UpdateOrderModel(_order.Order);
                    return _order;
                }
                throw new Exception("Böyle bir kullanıcı mevcut değil");                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CustomAllOrderModel GetAllCustomerOrders(int _userId)
        {
            try
            {

                List<OrderModel> orders = new List<OrderModel>();
                if (_userOperation.GetUserById(_userId) != null)
                {
                    var customerOrderList = _customOrderOperation.GetCustomerOrderBy(x => x.CustomerId == _userId);
                    if (customerOrderList != null)
                    {
                        foreach (var item in customerOrderList)
                        {
                            orders.Add(_orderManager.GetOrderById(item.OrderId));
                        }
                        return new CustomAllOrderModel
                        {
                            UserId = _userId,
                            Orders = orders
                        };
                    }
                    throw new Exception("Kullanıcının siparişi bulunmamaktadır");                      
                }
                throw new Exception("Böyle bir kullanıcı mevcut değil");
                   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public void DeleteOrder(CustomerOrderModel _customerOrderModel)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    if (_userOperation.GetUserById(_customerOrderModel.UserId) != null)
                    {
                        _customOrderOperation.DeleteCustomOrder(CustomerOrderMapper.MapToEntity(_customerOrderModel));
                        _orderManager.DeleteOrder(_customerOrderModel.Order);
                        transaction.Complete();
                    }
                    throw new Exception("Kullanıcı bulunamadi");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void DeleteOrdertById(int id)
        {
            try
            {
                _customOrderOperation.DeleteCustomerOrderById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CustomerOrderModel InsertCustomOrder(CustomerOrderModel _orderModel)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    if (_userOperation.GetUserById(_orderModel.UserId) != null)
                    {
                        var insertedOrder = _orderManager.InsertOrder(_orderModel.Order);
                        if (insertedOrder != null)
                        {
                            var entityCustomOrder = _customOrderOperation.InsertCustomerOrder(CustomerOrderMapper.MapToEntity(_orderModel));
                            transaction.Complete();
                            return CustomerOrderMapper.MapToWM(entityCustomOrder, insertedOrder);

                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        

    }
}
