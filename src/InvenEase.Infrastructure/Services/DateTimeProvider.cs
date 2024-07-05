using InvenEase.Application.Common.Interfaces.Services;

namespace InvenEase.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
