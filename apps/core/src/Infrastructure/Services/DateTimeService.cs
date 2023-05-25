using AudioStreaming.Application.Common.Interfaces;

namespace AudioStreaming.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
