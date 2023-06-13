using System;
using MVP_Tema3.Models.EntityLayer;
using System.Windows.Data;


namespace MVP_Tema3.Convertors
{
    class AbsentaStudentConvert: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null)
            {
                return new Absenta()
                {
                    
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
