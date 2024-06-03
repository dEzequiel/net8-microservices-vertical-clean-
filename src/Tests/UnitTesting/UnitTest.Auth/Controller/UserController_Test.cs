using Auth.Service.Controller;
using Auth.Service.Data;
using Auth.Service.DTOs;
using AutoFixture.Xunit2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Catalog.Config;

namespace UnitTest.Auth.Controller
{
    public class UserController_Test
    {
        private readonly Mock<IApplicationUserRepository> _repositoryMock;

        public UserController_Test()
        {
            _repositoryMock = new();
        }

        [Theory]
        [AutoMoqData]
        public async Task LoginApplicationUser_GeneratesValidJWTToken_Test(
            [Frozen] LoginApplicationUserResponse loginResponse,
            [Frozen] LoginApplicationUserDTO loginDTO)
        {
            // Arrange
            _repositoryMock.Setup(x => x.LoginApplicationUserAsync(It.IsAny<LoginApplicationUserDTO>())).ReturnsAsync(loginResponse);
            var sut = new UserController(_repositoryMock.Object);

            // Act
            var result = await sut.LoginApplicationUser(loginDTO);

            // Assert
            Assert.NotNull(result);
        }
    }
}
