using Application.Commands;
using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces
{
    public interface IAddUserUseCase
    {
        Task<BaseResponse<UserDTO>> AddUserAsync(AddUserCommand command);
    }
}
