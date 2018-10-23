using CustomOrderSystem.Entity;
using CustomOrderSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomOrderSystem.Operation
{
    public class UserOperation
    {

        UserRepository _userRepository;
        public UserOperation()
        {
            _userRepository = new UserRepository();
        }
        public List<User> GetAllUser()
        {
            try
            {
                return _userRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        public User GetUserById(int id)
        {
            try
            {
                return _userRepository.GetById(id);
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
        }
        public void DeleteUserById(int userId)
        {
            try
            {
                _userRepository.DeleteById(userId);
            }
            catch (Exception ex)
            {
            
                throw ex;
            }
        }
        public User InsertUser(User user)
        {
            try
            {
               // user.UserId = GetAllUser().Max(x => x.UserId) + 1;
                return _userRepository.Insert(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User UpdateUser(User user)
        {
            try
            {
                return _userRepository.Update(user);
            }
            catch (Exception ex)
            {             
                throw ex;
            }
        }
        public void DeleteUser(User user)
        {
            try
            {
                _userRepository.Delete(user);
            }
            catch (Exception ex)
            {
                MethodBase methodBase = MethodBase.GetCurrentMethod();
              
                throw ex;
            }
        }
        public User GetSingleUserBy(Expression<Func<User, bool>> filter = null)
        {
            try
            {
                var user = _userRepository.GetSingleBy(filter);
                return user;
            }
            catch (Exception ex)
            {
                MethodBase methodBase = MethodBase.GetCurrentMethod();
            
                throw ex;
            }
        }

        public List<User> GetUserBy(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null)
        {
            try
            {
                return _userRepository.GetBy(filter, orderBy).ToList();
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
        }


    }
}
