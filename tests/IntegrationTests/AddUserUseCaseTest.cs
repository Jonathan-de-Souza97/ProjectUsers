using AutoMapper;
using core.DTOs;
using core.Mappings;
using core.UseCases;
using core.ValueObjects;
namespace IntegrationTests
{
    [Trait("Category", "IntegrationTest")]
    public class AddUserUseCaseTest
    {
        private readonly AddUserUseCase _usecase;
        private readonly IMapper _mapper;

        public AddUserUseCaseTest()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
            });

            _mapper = mapperConfig.CreateMapper();

            _usecase = new AddUserUseCase(_mapper);
        }

        [Trait("Item", "User")]
        [Fact]
        public void MustAddUserUseCase()
        {
            //Arrange
            var telephone = new Telephone("11", "944123456");
            var userDTO = new AddUserDTO(
                "Jonathan de Souza", "Jonathan@gmail.com", "PasswordValid", telephone);
        }
    }
}