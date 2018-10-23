using CustomOrderSystem.Entity;
using CustomOrderSystem.Reository.Base;
using CustomOrderSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutomOrderSystem.Reository
{
  public  class ProductRepository: EntityRepositoryBase<Product>, IProductRepository
    {
    }
}
