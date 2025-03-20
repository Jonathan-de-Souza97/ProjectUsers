using application.Interfaces;
using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using core.ValueObjects;
namespace ProjectUsers.tests
{
    [Trait("Category", "IntegrationTests")]
    public class AddUserUseCaseTest
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAddUserUseCase _useCase;

        public AddUserUseCaseTest(IUserRepository repository, IMapper mapper, IAddUserUseCase useCase)
        {
            _repository = repository;
            _mapper = mapper;
            _useCase = useCase;
        }

        [Trait("Item", "AddUserUseCase")]
        [Fact]
        public async void AddUserValid()
        {
            //Arrange
            var telephone = new TelephoneDTO { DDD = "11", PhoneNumber = "971234567" };
            var user = new AddUserCommand
            {
                Nome = "Jonathan de Souza",
                Email = "jonathan@gmail.com",
                Password = "ValidPassword@",
                Telephone = telephone
            };

            //Act
            var act = await _useCase.AddUserAsync(user);

            //Assert
            Assert.True(act.SucessResponse);            
        }

    }
}