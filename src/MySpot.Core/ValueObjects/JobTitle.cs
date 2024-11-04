﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpot.Core.ValueObjects
{
    public sealed record JobTitle
    {
        public string Value { get; }
        public const string Employee = nameof(Employee);
        public const string Manager = nameof(Manager);
        public const string Boss  = nameof(Boss);

        private JobTitle(string value)
            => Value = value;

        public static implicit operator string(JobTitle jobTitle) 
            => jobTitle.Value;

        public static implicit operator JobTitle(string value)
            => new(value);
    }
}
