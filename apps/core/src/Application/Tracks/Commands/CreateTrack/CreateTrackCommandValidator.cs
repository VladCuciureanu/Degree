using FluentValidation;

namespace AudioStreaming.Application.Tracks.Commands.CreateTrack;

public class CreateTrackCommandValidator : AbstractValidator<CreateTrackCommand>
{
    public CreateTrackCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(128).WithMessage("Name must not exceed 128 characters.");

        RuleFor(v => v.Number)
            .NotEmpty().WithMessage("Track number is required.")
            .GreaterThan(0);

        RuleFor(v => v.AlbumId)
        .NotEmpty().WithMessage("Track must be linked to an album.")
        .GreaterThan(0);
    }
}