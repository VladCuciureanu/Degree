using FluentValidation;

namespace AudioStreaming.Application.Tracks.Commands.UpdateTrack;

public class UpdateTrackCommandValidator : AbstractValidator<UpdateTrackCommand>
{
    public UpdateTrackCommandValidator()
    {
        RuleFor(v => v.Name)
    .MaximumLength(128).WithMessage("Name must not exceed 128 characters.");
    }
}