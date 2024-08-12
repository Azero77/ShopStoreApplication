using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ShopApplication.ValidationRules
{
    public class PositiveIntegerValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int number;
            if (!int.TryParse(value.ToString(), out number))
                return new ValidationResult(false, "Field Must Be A number");
            if (number < 0)
                return new ValidationResult(false, "Field Must Be Positive");
            else
                return new ValidationResult(true, null);
        }
    }
}
