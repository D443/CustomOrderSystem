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
    [RoutePrefix("Product")]
    public class ProductController : BaseController
    {
        ProductManager _productManager;
        public ProductController()
        {
            _productManager = new ProductManager();

        }
        [HttpPut]
        [Route("UpdateProduct")]
        public HttpResponseMessage UndateProduct(ProductModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateErrorResponse(statusCode: HttpStatusCode.NotFound, message: "Ürün Modeliniz Boş Geçilemez");
                return Request.CreateResponse(HttpStatusCode.OK, _productManager.UpdateProduct(model));
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllProduct")]
        public HttpResponseMessage GetAllProduct()
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, _productManager.GetAllProduct());
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetProduct/{productId}")]
        public HttpResponseMessage GetProduct(int productId)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, _productManager.GetProductById(productId));
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateProduct")]
        public HttpResponseMessage CreateProduct(ProductModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateErrorResponse(statusCode: HttpStatusCode.NotFound, message: "Ürün Modeliniz Boş Geçilemez");
                return Request.CreateResponse(HttpStatusCode.Created, _productManager.InsertProduct(model));
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteProduct/{productId}")]
        public HttpResponseMessage DeleteProduct(int productId)
        {
            try
            {
                _productManager.DeleteProductById(productId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CreateRawStringResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        
    }
}
