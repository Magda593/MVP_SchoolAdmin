using MVP_Tema3.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace MVP_Tema3.Convertors
{
    class StudentConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null)
            {
                return new Student()
                {
                    CNP = values[0].ToString(),
                    Sex = values[1].ToString(),
                    Nume = values[2].ToString(),
                    Prenume = values[3].ToString(),
                    Clasa = values[4].ToString(),
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
