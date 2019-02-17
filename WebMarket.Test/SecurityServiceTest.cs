using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WebMarket.Data.Repositories.Security;
using WebMarket.Models.Security;
using WebMarket.Services;

namespace WebMarket.Test
{
    [TestClass]
    public class SecurityServiceTest
    {
        private Services.SecurityService _sut;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        [TestInitialize]
        public void Initialize()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _roleRepository = Substitute.For<IRoleRepository>();
            _sut = new SecurityService(_userRepository, _roleRepository);
        }

        [TestMethod]
        public void GetUser_Everytime_valid()
        {
            // Mock

            var user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = "John_Doe",
                Email = "john.doe@gmail.com"
            };

            user.Roles = new List<Role>();
            user.Roles.Add(new Role()
            {
                Id = Guid.NewGuid(),
                Name = "admin"
            });

            _userRepository.GetUser(Arg.Any<Guid>()).Returns(user);

            // Execute

            var result = _sut.GetUser(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Roles);
            Assert.AreSame(user.Email,"john.doe@gmail.com");
            Assert.AreNotEqual(0, result.Roles.Count);
            Assert.AreSame("admin", result.Roles.First().Name);

        }

    }
}
