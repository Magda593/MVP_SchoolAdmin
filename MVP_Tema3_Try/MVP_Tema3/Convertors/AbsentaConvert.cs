using System;
using MVP_Tema3.Models.EntityLayer;
using System.Windows.Data;

namespace MVP_Tema3.Convertors
{
    public class AbsentaConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null)
            {
                return new Absenta()
                {
                    StudentID = values[0].ToString(),
                    MaterieID = values[1].ToString(),
                    DataAbsenta = DateTime.Parse(values[2].ToString())
                };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
