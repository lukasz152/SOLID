using MySpot.Api.Exceptions;

namespace MySpot.Api.ValueObjects
{
    public record LicencePlate
    {
        public string Value { get; }

        public LicencePlate(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyLicensePlateException();
            }

            if(value.Length is <5 or > 8)
            {
                throw new InvalidLicensePlateException(value);
            }

            Value = value;
        }

        public static implicit operator string(LicencePlate licensePlate) => licensePlate?.Value;

        public static implicit operator LicencePlate(string licensePlate) => new(licensePlate);
    }
}
