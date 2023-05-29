using FluentValidation;

namespace AudioStreaming.Application.Albums.Commands.UpdateAlbum;

public class UpdateAlbumCommandValidator : AbstractValidator<UpdateAlbumCommand>
{
    public UpdateAlbumCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(128).WithMessage("Name must not exceed 128 characters.");
    }
}