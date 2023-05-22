using FluentValidation;

namespace AudioStreaming.Application.Tracks.Commands.UpdateTrack;

public class UpdateTrackCommandValidator : AbstractValidator<UpdateTrackCommand>
{
    public UpdateTrackCommandValidator()
    {
        RuleFor(v => v.Title)
    .MaximumLength(128).WithMessage("Title must not exceed 128 characters.");
    }
}
