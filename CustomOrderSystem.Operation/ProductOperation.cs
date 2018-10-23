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
   public  class ProductOperation
    {
        ProductRepository _productRepository;
        public ProductOperation()
        {
            _productRepository = new ProductRepository();       
        }
        public List<Product> GetAllProduct()
        {
            try
            {
                return _productRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetProductById(int id)
        {
            try
            {
                return _productRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                _productRepository.Delete(product);
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
                _productRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public Product InsertProduct(Product product)
        {
            try
            {
               
                return _productRepository.Insert(product);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public Product UpdateProduct(Product product)
        {
            try
            {
                return _productRepository.Update(product);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Product GetSingleProdcutBy(Expression<Func<Product, bool>> filter = null)
        {
            try
            {
                return _productRepository.GetSingleBy(filter);
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
        }

        public List<Product> GetOProductBy(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> productBy = null)
        {
            try
            {
                return (_productRepository.GetBy(filter, productBy).ToList());
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

    }
}
