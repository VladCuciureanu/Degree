using FluentValidation;

namespace AudioStreaming.Application.Tracks.Commands.UploadTrack;

public class UploadTrackCommandValidator : AbstractValidator<UploadTrackCommand>
{
    public UploadTrackCommandValidator()
    {
        RuleFor(v => v.Payload);
    }
}