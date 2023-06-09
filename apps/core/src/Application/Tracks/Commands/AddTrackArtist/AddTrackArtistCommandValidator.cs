using FluentValidation;

namespace AudioStreaming.Application.Tracks.Commands.AddTrackArtist;

public class AddTrackArtistCommandValidator : AbstractValidator<AddTrackArtistCommand>
{
    public AddTrackArtistCommandValidator()
    {
        RuleFor(v => v.ArtistId)
            .GreaterThan(0);

        RuleFor(v => v.TrackId)
            .GreaterThan(0);
    }
}