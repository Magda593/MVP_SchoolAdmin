using MVP_Tema3.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace MVP_Tema3.Convertors
{
    class MedieConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null)
            {
                return new Medie()
                {
                    StudentID = int.Parse(values[0].ToString()),
                    MaterieID = int.Parse(values[1].ToString()),
                    Valoare = int.Parse(values[2].ToString())
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
