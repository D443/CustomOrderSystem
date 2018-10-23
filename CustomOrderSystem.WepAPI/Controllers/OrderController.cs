using CustomOrderSystem.Manager;
using CustomOrderSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomOrderSystem.WepAPI.Controllers
{
    [RoutePrefix("Order")]
    public class OrderController : BaseController
    {
        CustomerOrderManager _customerOrderManager;
        OrderManager _orderManager;
        public OrderController()
        {
            _customerOrderManager = new CustomerOrderManager();
            _orderManager = new OrderManager();
        }

        [HttpPost]
        [Route("CreateCustomerOrders")]
        public HttpResponseMessage CreateCustomerOrders(CustomAllOrderModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateErrorResponse(statusCode: HttpStatusCode.NotFound, message: "Sipariş listesi boş olamaz");
                
              var insertCustomOrder=_customerOrderManager.InsertAllCustomerOrders(model: model);
              if(insertCustomOrder)
                    return Request.CreateResponse(HttpStatusCode.OK);
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {

                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteCustomerOrders/{userId}")]
        public HttpResponseMessage DeleteCustomerOrder(int userId)
        {
            try
            {

                _customerOrderManager.DeleteCusomerOrderUserBy(userId: userId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateCustomerOrder")]
        public HttpResponseMessage OrderProductQuantity(CustomerOrderModel model) {
          
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateErrorResponse(statusCode: HttpStatusCode.NotFound, message: "Müşteri Sipariş Modeliniz Boş Geçilemez");
                return Request.CreateResponse(HttpStatusCode.OK, _customerOrderManager.UpdateCustomerOrderModel(model));
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpPost]
        [Route("AddCustomerOrders")]
        public HttpResponseMessage AddCustomerOrderPruduct(CustomerOrderModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateErrorResponse(statusCode: HttpStatusCode.NotFound, message: "Müşteri Sipariş Modeliniz Boş Geçilemez");
                _customerOrderManager.InsertCustomOrder(model);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpGet]
        [Route("GetCustomerOrders/{id}")]
        public HttpResponseMessage GetAllOrdersCustomer(int id)
        {
            try
            {
                if (!ModelState.IsValid)
               return Request.CreateResponse(HttpStatusCode.OK,_customerOrderManager.GetAllCustomerOrders(id));
              return CreateRawStringResponse(HttpStatusCode.BadRequest,"Siparişler listesi getirilemiyor");
            }
            catch (Exception ex)
            {

                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
      
    }
}
