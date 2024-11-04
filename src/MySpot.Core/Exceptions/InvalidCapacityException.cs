using MySpot.Api.Exceptions;
using MySpot.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MySpot.Core.Exceptions
{
    public sealed class InvalidCapacityException : CustomException
    {
        public readonly int Capacity;
        public InvalidCapacityException(int capacity) : base($"Capacity {capacity} is invalid.")
        {
            Capacity = capacity;
        }

    }
}
