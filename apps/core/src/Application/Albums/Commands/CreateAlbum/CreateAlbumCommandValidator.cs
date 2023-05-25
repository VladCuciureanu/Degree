using FluentValidation;

namespace AudioStreaming.Application.Albums.Commands.CreateAlbum;

public class CreateAlbumCommandValidator : AbstractValidator<CreateAlbumCommand>
{
    public CreateAlbumCommandValidator()
    {
        RuleFor(v => v.Title)
    .NotEmpty().WithMessage("Title is required.")
    .MaximumLength(128).WithMessage("Title must not exceed 128 characters.");
    }
}
