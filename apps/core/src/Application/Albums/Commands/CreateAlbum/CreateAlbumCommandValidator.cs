using FluentValidation;

namespace AudioStreaming.Application.Albums.Commands.CreateAlbum;

public class CreateAlbumCommandValidator : AbstractValidator<CreateAlbumCommand>
{
    public CreateAlbumCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(128).WithMessage("Name must not exceed 128 characters.");

        RuleFor(v => v.ArtistId)
        .NotEmpty().WithMessage("Album must have a artist.")
        .GreaterThan(0);
    }
}