﻿using MySpot.Api.Exceptions;

namespace MySpot.Core.ValueObjects
{
    public sealed record UserId
    {
        public Guid Value { get; }
        private UserId(){}

        public UserId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static implicit operator Guid(UserId date) => date.Value;

        public static implicit operator UserId(Guid value) => new(value);
    }
}
