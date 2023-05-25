using FluentValidation;

namespace AudioStreaming.Application.Artists.Commands.CreateArtist;

public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>
{
    public CreateArtistCommandValidator()
    {
        RuleFor(v => v.Name)
    .NotEmpty().WithMessage("Name is required.")
    .MaximumLength(128).WithMessage("Name must not exceed 128 characters.");
    }
}
