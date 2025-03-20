using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.Extensions.Configuration;

using Infrastructure.Interfaces;
using Infrastructure.Data;
using Application.UseCases;
namespace ProjectUsers.tests
{
    [Trait("Category", "IntegrationTests")]
    public class AddUserUseCaseTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAddUserUseCase _useCase;
        private readonly ContextBase _context;

        public AddUserUseCaseTest()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                { "ConnectionStrings:TestDB", "Host=localhost;Port=5432;Database=ProjectUsersTestDB;Username=test;Password=test" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _context = new ContextBase(configuration, "TestDB");

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
                cfg.AddProfile(new TelephoneMeppingProfile());
            });

            _mapper = mapperConfig.CreateMapper();

            _userRepository = new UserRepository(_context);

            _useCase = new AddUserUseCase(_mapper, _userRepository);
        }

        [Trait("Item", "AddUserUseCase")]
        [Fact]
        public async void AddUserValid()
        {
            //Arrange
            var telephone = new TelephoneDTO { DDD = "11", PhoneNumber = "971234567" };
            var user = new AddUserCommand
            {
                Name = "Jonathan de Souza",
                Email = "jonathan@gmail.com",
                Password = "ValidPassword@123",
                Telephone = telephone
            };

            //Act
            var act = await _useCase.AddUserAsync(user);

            //Assert
            Assert.True(act.SucessResponse);
            Assert.Equal(user.Name, act.Data.Name);
            Assert.Equal(user.Email, act.Data.Email);
            Assert.Equal(user.Telephone.DDD, act.Data.Telephone.DDD);
            Assert.Equal(user.Telephone.PhoneNumber, act.Data.Telephone.PhoneNumber);
        }
    }
}