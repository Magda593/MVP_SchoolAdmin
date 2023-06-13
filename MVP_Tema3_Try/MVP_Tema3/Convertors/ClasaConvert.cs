using MVP_Tema3.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace MVP_Tema3.Convertors
{
    class ClasaConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null)
            {
                return new Clasa()
                {
                    DiriginteID = values[0].ToString(),
                    AnStudiuID = values[1].ToString(),
                    SpecializareID = values[2].ToString(),
                    Nume = values[3].ToString()
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
