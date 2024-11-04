using MySpot.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpot.Tests.Unit.Shared
{
    public class TestClock : IClock
    {
        public DateTime Current() => new(2024, 10, 28 , 11, 12, 0);
    }
}
