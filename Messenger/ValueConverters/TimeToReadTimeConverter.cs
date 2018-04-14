using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Messenger
{
    public class TimeToReadTimeConverter : BaseValueConverter<TimeToReadTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;

            if (time == DateTimeOffset.MinValue)
                return string.Empty;

            //If it is today...
            if (time.Date == DateTimeOffset.UtcNow.Date)
                // Return just time
                return $"Read {time.ToLocalTime().ToString("HH:mm")}";

            // Otherwise, return a full date
            return $"Read {time.ToLocalTime().ToString("HH:mm, MMM yyyy")}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
