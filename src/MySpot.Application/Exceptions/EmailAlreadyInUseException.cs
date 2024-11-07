using MySpot.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpot.Application.Exceptions
{
    public sealed class EmailAlreadyInUseException : CustomException
    {
        public string Email { get; }

        public EmailAlreadyInUseException(string email) : base($"Email: '{email}' is already in use.")
        {
            Email = email;
        }
    }
}
