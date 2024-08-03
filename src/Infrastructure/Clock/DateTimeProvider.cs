﻿using SharedKernel;

namespace Infrastructure.Clock;
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
