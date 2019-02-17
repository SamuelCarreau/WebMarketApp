using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using WebMarket.Models;
using WebMarket.Models.Security;

namespace WebMarket.Data.Entities.Security
{
    public class UserDB : IEntity
    {

        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public ICollection<RoleDB> Roles { get; set; }

        public static explicit operator UserDB(User user)
        {
            return new UserDB
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                PasswordSalt = user.PasswordSalt,
                IsActive = user.IsActive,
                CreationDate = user.CreationDate,
                UpdateTime = user.UpdateTime,
                Roles = user.Roles.Select(x => (RoleDB)x).ToList()
                
            };
        }

        public static explicit operator User(UserDB userBd)
        {
            return new User
            {
                Id = userBd.Id,
                UserName = userBd.UserName,
                Email = userBd.Email,
                Password = userBd.Password,
                PasswordSalt = userBd.PasswordSalt,
                IsActive = userBd.IsActive,
                CreationDate = userBd.CreationDate,
                UpdateTime = userBd.UpdateTime,
                Roles = userBd.Roles.Select(x => (Role)x).ToList()
            };
        }
    }
}
