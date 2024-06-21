using Mapster;
using rising_developer_interview.Contracts.Repositories;
using rising_developer_interview.Contracts.Services;
using rising_developer_interview.Dtos;
using rising_developer_interview.Entities;

namespace rising_developer_interview.Implementations.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse> CreateAsync(CreateUserRequestModel request)
    {
        var user = request.Adapt<User>();
        await _userRepository.CreateAsync(user);
        await _unitOfWork.SaveChangesAsync();
        return new BaseResponse
        {
            Message = "User created successfully",
            IsSuccessful = true,
        };
    }

    public async Task<GetUserResponseModel?> GetAsync(Guid id)
    {
        var user = await _userRepository.GetAsync(id);
        return user?.Adapt<GetUserResponseModel>();
    }
}