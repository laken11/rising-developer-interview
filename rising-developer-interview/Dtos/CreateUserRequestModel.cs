using FluentValidation;

namespace rising_developer_interview.Dtos;

public class CreateUserRequestModel
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int DiagnosticLevel { get; set; }
    public int CurrentLevel { get; set; }
    public DateTime FirstMessageTimestamp { get; set; }
    public DateTime LastMessageTimestamp { get; set; }
    public string[] MessageIds { get; set; }
}


public class CreateUserRequestModelValidator : AbstractValidator<CreateUserRequestModel>
{
    public CreateUserRequestModelValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(100);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^\+\d{11,15}$").WithMessage("Phone number must be in international format starting with '+' and contain 11 to 15 digits.");

        RuleFor(x => x.Email)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("Email must be valid.");

        RuleFor(x => x.DiagnosticLevel)
            .InclusiveBetween(0, 10).WithMessage("Diagnostic level must be between 0 and 10.");

        RuleFor(x => x.CurrentLevel)
            .InclusiveBetween(0, 10).WithMessage("Current level must be between 0 and 10.");

        RuleFor(x => x.FirstMessageTimestamp)
            .NotEmpty()
            .Must(BeAValidDate).WithMessage("First message timestamp must be a valid ISO format datetime.");

        RuleFor(x => x.LastMessageTimestamp)
            .NotEmpty()
            .Must(BeAValidDate).WithMessage("Last message timestamp must be a valid ISO format datetime.");

        RuleFor(x => x.MessageIds)
            .NotEmpty()
            .Must(ids => ids.Distinct().Count() == ids.Length).WithMessage("All message IDs must be unique.")
            .ForEach(id => id.NotEmpty().WithMessage("Message ID cannot be empty."));
    }

    private bool BeAValidDate(DateTime date)
    {
        return date != default(DateTime);
    }
}
