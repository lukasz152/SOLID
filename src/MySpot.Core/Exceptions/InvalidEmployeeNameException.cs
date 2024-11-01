using System.ComponentModel;

namespace MySpot.Api.Exceptions
{
    public class InvalidEmployeeNameException :CustomException
    {
        public InvalidEmployeeNameException() : base($"Invalid Employee Name ")
        {
        }
    }
}
