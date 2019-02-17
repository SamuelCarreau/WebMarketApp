using System;
using System.Collections.Generic;
using System.Text;
using WebMarket.Data.Repositories.Security;
using WebMarket.Models.Security;

namespace WebMarket.Services
{
    public interface ISecurityService
    {
        // Users Services
        User GetUser(Guid id);
        IEnumerable<User> GetUsers(bool isActive);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);

        // Roles Services
        Role GetRole(Guid id);
        IEnumerable<Role> GetRoles(bool isActive);
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Guid id);
    }
    public class SecurityService : ISecurityService
    {

        protected readonly IUserRepository _userRepository;
        protected readonly IRoleRepository _roleRepository;

        public SecurityService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public User GetUser(Guid id)
        {
            var user = _userRepository.GetUser(id);

            if (user == null)
                return null;
            if (user.Roles == null || user.Roles.Count == 0)
                throw new Exception($"The user with Id : {id} have no role");

            return user;
        }

        public IEnumerable<User> GetUsers(bool isActive)
        {
            var users = _userRepository.GetUsers(isActive);
            return users;
        }

        public void CreateUser(User user)
        {

            if (_userRepository.GetUser(null, user.UserName) != null)
                throw new Exception($"An user with the name {user.UserName} allready exist");
            if (_userRepository.GetUser(null,null,user.Email) != null)
                throw new Exception($"An user with the email {user.Email} allready exist");

            //TODO encrypte password and get salt

            _userRepository.Insert(user);

        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(Guid id)
        {
            _userRepository.Delete(id);
        }
        public Role GetRole(Guid id)
        {
            var role = _roleRepository.GetRole(id);
            return role;
        }

        public IEnumerable<Role> GetRoles(bool isActive)
        {
            var roles = _roleRepository.GetRoles(isActive);
            return roles;
        }

        public void CreateRole(Role role)
        {
            if (_roleRepository.GetRole(null, role.Name) != null)
                throw new Exception($"a role whit the name {role.Name} already exist");

            _roleRepository.Insert(role);
        }

        public void UpdateRole(Role role)
        {
            _roleRepository.Update(role);
        }

        public void DeleteRole(Guid id)
        {
            _roleRepository.Delete(id);
        }
    }
}
