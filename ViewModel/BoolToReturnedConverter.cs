using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace ViewModel
{
    public class BoolToReturnedConverter : IValueConverter
    {
        const string returned = "Book is returned";
        const string notReturned = "Book is still borrowed";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = (bool)value;
            if (b)
                return returned;
            else
                return notReturned;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            if (strValue.Equals(returned)) return true;
            else return false;
        }
    }
}
