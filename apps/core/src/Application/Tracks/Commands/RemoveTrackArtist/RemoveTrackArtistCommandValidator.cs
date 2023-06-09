using FluentValidation;

namespace AudioStreaming.Application.Tracks.Commands.RemoveTrackArtist;

public class RemoveTrackArtistCommandValidator : AbstractValidator<RemoveTrackArtistCommand>
{
    public RemoveTrackArtistCommandValidator()
    {
        RuleFor(v => v.ArtistId)
            .GreaterThan(0);

        RuleFor(v => v.TrackId)
            .GreaterThan(0);
    }
}