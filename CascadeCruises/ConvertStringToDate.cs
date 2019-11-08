using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace CascadeCruises
{
    class ConvertStringToDate : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
              var text = (string)value;
            if(DateTime.TryParse(text,out DateTime result))
            {
                return result;
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = (string)value;
            if (DateTime.TryParse(text, out DateTime result))
            {
                return result;
            }
            return Binding.DoNothing;
        }
    }
}
