using System.ComponentModel.DataAnnotations;

namespace CMDKhakatonProject.Attributes
{
    public class PositiveNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int intValue)
            {
                return intValue > 0;
            }
            if (value is double doubleValue)
            {
                return doubleValue > 0;
            }
            if (value is decimal decimalValue)
            {
                return decimalValue > 0;
            }
            return false;
        }
    }
}
