using Ophelia.Application.Common.Interfaces;
using System;

namespace Ophelia.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
