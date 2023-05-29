using FluentValidation;

namespace AudioStreaming.Application.Artists.Commands.UpdateArtist;

public class UpdateArtistCommandValidator : AbstractValidator<UpdateArtistCommand>
{
    public UpdateArtistCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(128).WithMessage("Name must not exceed 128 characters.");
    }
}