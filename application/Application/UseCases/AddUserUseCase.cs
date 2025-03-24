using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using core.Entity;
using core.ValueObjects;
using Infrastructure.Interfaces;

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

            var user = new User(command.Name, command.Email, command.Password, telephone);

            var userExist = await _repository.GetByEmail(command.Email);

            var userDTO = _mapper.Map<UserDTO>(user);

            if (userExist.SucessResult && userExist.Data != null)
                return BaseResponse<UserDTO>.Error("User already.");

            if(!userExist.SucessResult)
                return BaseResponse<UserDTO>.Error(userExist.Message);

            var result = await _repository.AddAsync(user);

            if (!result.SucessResult)
                return BaseResponse<UserDTO>.Error(result.Message);

            return BaseResponse<UserDTO>.Success(userDTO);
        }
    }
}