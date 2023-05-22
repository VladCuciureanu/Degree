using FluentValidation;

namespace AudioStreaming.Application.Tracks.Commands.CreateTrack;

public class CreateTrackCommandValidator : AbstractValidator<CreateTrackCommand>
{
    public CreateTrackCommandValidator()
    {
        RuleFor(v => v.Title)
    .NotEmpty().WithMessage("Title is required.")
    .MaximumLength(128).WithMessage("Title must not exceed 128 characters.");
    }
}
