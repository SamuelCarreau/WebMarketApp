using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebMarket.Data.Entities.Security;
using WebMarket.Models.Security;

namespace WebMarket.Data.Repositories.Security
{
    public interface IUserRepository
    {
        User GetUserById(Guid id);
        IEnumerable<User> GetUsers(bool? isActive);
        void Update(User user);
        void Insert(User user);
        void Delete(Guid id);
    }

    public class UserRepository : IUserRepository
    {
        protected readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetUserById(Guid id)
        {
            return (User)_context.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetUsers(bool? isActive)
        {
            return (isActive == null) 
                ? _context.Users.Select(x => (User)x).ToList() 
                : _context.Users.Where(x => x.IsActive == isActive).Select(x => (User)x).ToList() ;
        }
        public void Insert(User user)
        {
            user.CreationDate = DateTime.Now;

            _context.Users.Add((UserDB)user);
            _context.SaveChanges();
        }
        public void Update(User user)
        {
            var userDb = _context.Users.First(x => x.Id == user.Id);

            userDb.UserName = user.UserName;
            userDb.Email = user.Email;
            userDb.IsActive = user.IsActive;

            user.UpdateTime = DateTime.Now;

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var userDb = _context.Users.First(x => x.Id == id);

            _context.Users.Remove(userDb);
            _context.SaveChanges();

        }
    }
}
