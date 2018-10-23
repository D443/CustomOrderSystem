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
   public class ProductManager
    {
         readonly ProductOperation _productOperations;
        public ProductManager()
        {
            _productOperations = new ProductOperation();
        }
        public ProductModel UpdateProduct(ProductModel product)
        {
            try
            {

                return ProductMapper.MapToWM(_productOperations.UpdateProduct(ProductMapper.MapToEntity(product)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ProductModel> GetAllProduct()
        {
            try
            {
                return ProductMapper.MapToWM(_productOperations.GetAllProduct());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductModel GetProductById(int id)
        {
            try
            {
                return ProductMapper.MapToWM(_productOperations.GetProductById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteProduct(ProductModel product)
        {
            try
            {
                _productOperations.DeleteProduct(ProductMapper.MapToEntity(product));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  
        public void DeleteProductById(int id)
        {
            try
            {
                _productOperations.DeleteProductById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductModel InsertProduct(ProductModel product)
        {
           
            try
            {

                return ProductMapper.MapToWM(_productOperations.InsertProduct(ProductMapper.MapToEntity(product)));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
