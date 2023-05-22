using FluentValidation;

namespace AudioStreaming.Application.Albums.Commands.UpdateAlbum;

public class UpdateAlbumCommandValidator : AbstractValidator<UpdateAlbumCommand>
{
    public UpdateAlbumCommandValidator()
    {
        RuleFor(v => v.Title)
    .MaximumLength(128).WithMessage("Title must not exceed 128 characters.");
    }
}
