using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RLab.Core.Entities;
using RLab.DTO.Common;
using RLab.Interface;
using RLab.UserAPI.Controller.V1;

namespace RLab.UnitTest
{
    [TestFixture]
    public class ExternalUserControllerTest
    {
        private ExternalUserController _controller;
        private Mock<IExternalUserService> _userServiceMock;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IExternalUserService>();
            _controller = new ExternalUserController(_userServiceMock.Object);
        }

        [Test]
        public async Task GetUserById_ReturnsExpectedUser()
        {
            // Arrange
            var expectedUser = new User { Id = 2, FirstName = "Alice", LastName = "Smith" };

            _userServiceMock
                .Setup(s => s.GetUserById(2))
                .ReturnsAsync(ApiResponse<User?>.SuccessResponse(expectedUser));

            // Act
            var response = await _controller.GetUser(2) as JsonResult;

            // Assert
            response.Should().NotBeNull();
            var result = response!.Value as ApiResponse<User>;
            result.Should().NotBeNull();
            result!.Data.Should().BeEquivalentTo(expectedUser);
        }
    }
}