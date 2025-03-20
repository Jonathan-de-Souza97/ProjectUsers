using AutoMapper;
using core.DTOs;
using core.Entity;
using core.Interfaces;

namespace core.UseCases
{
    public class AddUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public AddUserUseCase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async void ExecuteAsync(AddUserDTO dto)
        {
            var user = _mapper.Map<User>(dto);

            await _repository.AddUserAsync(user);
        }
    }
}