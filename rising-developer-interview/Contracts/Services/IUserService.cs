using rising_developer_interview.Dtos;

namespace rising_developer_interview.Contracts.Services;

public interface IUserService
{
    Task<BaseResponse> CreateAsync(CreateUserRequestModel request);
    Task<GetUserResponseModel?> GetAsync(Guid id);
}