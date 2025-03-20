using application.Interfaces;
using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using core.Entity;
using core.ValueObjects;

namespace Application.UseCases
{
    public class AddUserUseCase : IAddUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public AddUserUseCase(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BaseResponse<UserDTO>> AddUserAsync(AddUserCommand command)
        {
            var telephone = _mapper.Map<Telephone>(command.Telephone);
            var user = new User(command.Nome, command.Email, command.Password, telephone);

            var result = await _repository.AddAsync(user);

            if(!result.Sucess)
                return BaseResponse<UserDTO>.Error(result.Message);


            var userDTO = _mapper.Map<UserDTO>(user);
            return BaseResponse<UserDTO>.Success(userDTO);
        }
    }
}