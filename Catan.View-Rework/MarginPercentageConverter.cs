using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Catan.View_Rework
{
    internal class MarginPercentageConverter : IValueConverter
    {
        PercentageConverter _converter = new();

        public object Convert(object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            string margin = System.Convert.ToString(parameter);

            var marginValuesTXT = margin.Split(' ').ToList();
            var marginValues = marginValuesTXT
                .Select(double.Parse)
                .Select(x => _converter.Convert(value, targetType, x, culture)).ToList();

            string result = string.Join(',', marginValues);

            return result;
        }

        public object ConvertBack(object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
