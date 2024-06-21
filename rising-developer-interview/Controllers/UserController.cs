using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using rising_developer_interview.Contracts.Services;
using rising_developer_interview.Dtos;

namespace rising_developer_interview.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;
    private readonly IValidator<CreateUserRequestModel> _validator;

    public UserController(IUserService userService, IValidator<CreateUserRequestModel> validator)
    {
        _userService = userService;
        _validator = validator;
    }
    
    [Produces(typeof(BaseResponse))]
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequestModel request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        return Ok(await _userService.CreateAsync(request));
    }
    
    [Produces(typeof(GetUserResponseModel))]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _userService.GetAsync(id);
        if (result is null)
        {
            return NotFound();
        }
        return Ok(await _userService.GetAsync(id));
    }
}