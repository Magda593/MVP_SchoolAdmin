using MVP_Tema3.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace MVP_Tema3.Convertors
{
    class MaterieConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
                return new Materie()
                {
                    Nume = values[0].ToString(),
                    ProfesorID = values[1].ToString()

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
