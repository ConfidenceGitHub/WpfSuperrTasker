using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSuperrTasker.MVVM.Model;

namespace WpfSuperrTasker.Converters
{
    public class MyConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new UserTask()
            {
                Name = (string)values[0],
                Description = (string)values[1],
                Date = (DateTime)values[2],
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var v = value as UserTask;
            return new object[] { v.Name, v.Description, v.Date };
        }
    }
}
