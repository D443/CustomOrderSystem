using CustomOrderSystem.Entity;
using CustomOrderSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomOrderSystem.Mapper
{
    public static class UserMapper
    {
        public static Customer MapToWM(User entity)
        {
            return new Customer()
            {
                ID = entity.UserId,
                Name = entity.UserName,
                Surname = entity.UserSurName,
                Adress = entity.UserAddress,
                Email = entity.UserEmail,
                Password = entity.UserPassword,


            };
        }

        public static List<Customer> MapToWM(List<User> entity)
        {
            return entity.Select(x => new Customer()
            {
                ID = x.UserId,
                Name = x.UserName,
                Surname = x.UserSurName,
                Email = x.UserEmail,
                Password = x.UserPassword,
                Adress = x.UserAddress,

            }).ToList();
        }

        public static User MapToEntity(Customer customer)
        {
            return new User()
            {
                UserId = customer.ID,
                UserAddress = customer.Adress,
                UserPassword = customer.Password,
                UserEmail = customer.Email,
                UserSurName = customer.Password,
                UserName = customer.Name,

            };
        }



    }
}
