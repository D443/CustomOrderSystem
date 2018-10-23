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
    public class UserManager
    {
        readonly UserOperation _userOperations;
        public UserManager()
        {
            _userOperations = new UserOperation();
        }
        public Customer UpdateUser(Customer user)
        {
            try
            {
                if(GetUserById(user.ID)!=null)
                return UserMapper.MapToWM(_userOperations.UpdateUser(UserMapper.MapToEntity(user)));
                throw new Exception("Kullanici bulunamadi");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Customer> GetAllUser()
        {
            try
            {
                return UserMapper.MapToWM(_userOperations.GetAllUser());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Customer GetUserById(int id)
        {
            try
            {
                return UserMapper.MapToWM(_userOperations.GetUserById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteUser(Customer user)
        {
            try
            {
                _userOperations.DeleteUser(UserMapper.MapToEntity(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Customer LoginUser(LoginModel loginmodel)
        {
            try
            {
                return (UserMapper.MapToWM(_userOperations.GetSingleUserBy(x => x.UserEmail == loginmodel.UserName && x.UserPassword == loginmodel.Password)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteUserById(int id)
        {
            try
            {
                _userOperations.DeleteUserById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Customer InsertUser(Customer user)
        {
            if (user == null)
            {
                throw new Exception("Kullanıcı Eklenemedi");
            }
            try
            {

                return UserMapper.MapToWM(_userOperations.InsertUser(UserMapper.MapToEntity(user)));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
