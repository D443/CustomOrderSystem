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
    [RoutePrefix("User")]
    public class UserController : BaseController
    {
        UserManager _userManager;

        public UserController()
        {
            _userManager = new UserManager();
        }
        [HttpPost]
        [Route("LoginUser")]
        public HttpResponseMessage GetLogin(LoginModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateErrorResponse(statusCode: HttpStatusCode.NotFound, message: "Login Modeliniz Boş Geçilemez");
                Customer customer = _userManager.LoginUser(login);
                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.NotImplemented, ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateUser")]
        public HttpResponseMessage UpdateUser(Customer model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateErrorResponse(statusCode: HttpStatusCode.NotFound, message: "Müşteri Modeliniz Boş Geçilemez");
                return Request.CreateResponse(HttpStatusCode.OK, _userManager.UpdateUser(model));
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateUserPost")]
        public HttpResponseMessage CreateUser(Customer model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateErrorResponse(statusCode: HttpStatusCode.NotFound, message: "Müşteri Modeliniz Boş Geçilemez");
                return Request.CreateResponse(HttpStatusCode.Created, _userManager.InsertUser(model));
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public HttpResponseMessage DeleteUser(int userId)
        {
            try
            {
                _userManager.DeleteUserById(userId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
