namespace MySpot.Api.Exceptions
{
    public class InvalidEntityIdException :CustomException
    {
        public InvalidEntityIdException(Guid value) :base($"Invalid entity Id{value}")
        {
            
        }
    }
}
