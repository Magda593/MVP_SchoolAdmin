using MVP_Tema3.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace MVP_Tema3.Convertors
{
    class NotaConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null)
            {
                return new Nota()
                {
                    StudentID = values[0].ToString(),
                    MaterieID = values[1].ToString(),
                    DataNota = values[2].ToString(),
                    Valoare = values[3].ToString(),
                    Teza = values[4].ToString()
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
