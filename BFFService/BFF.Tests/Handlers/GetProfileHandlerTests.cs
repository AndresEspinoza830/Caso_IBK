
using BFF.Application.Handlers.Queries.UserController;
using BFF.Application.Interfaces;
using BFF.Application.Models;
using Moq;

namespace BFF.Tests.Handlers
{
    public class GetProfileHandlerTests
    {
        [Fact]
        public async Task Should_Return_Profile_When_User_And_Photo_Exist()
        {
            var repositoryMock = new Mock<IProfileRepository>();

            repositoryMock.Setup(x => x.GetUser(1))
                .ReturnsAsync(new UserResponse
                {
                    Id = 1,
                    Name = "George",
                    Avatar = "avatar.png"
                });

            repositoryMock.Setup(x => x.GetPhoto(1))
                .ReturnsAsync(new PhotoResponse
                {
                    Image = "base64image"
                });

            var handler = new GetProfileHandler(repositoryMock.Object);

            var request = new GetProfileRequest { IdUser = 1 };

            var result = await handler.Handle(request, default);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("George", result.Name);
            Assert.Equal("base64image", result.Photo);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_User_Not_Found()
        {
            var repositoryMock = new Mock<IProfileRepository>();

            repositoryMock.Setup(x => x.GetUser(1))
                .ThrowsAsync(new Exception("User not found"));

            var handler = new GetProfileHandler(repositoryMock.Object);

            var request = new GetProfileRequest { IdUser = 1 };

            await Assert.ThrowsAsync<Exception>(() =>
                handler.Handle(request, default));
        }
    }
}
