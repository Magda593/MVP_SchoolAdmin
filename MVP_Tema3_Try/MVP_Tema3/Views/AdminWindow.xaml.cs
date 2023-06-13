using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVP_Tema3.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            StudentPageWindow student = new StudentPageWindow();
            student.Show();
        }

        private void Profesor_Click(object sender, RoutedEventArgs e)
        {
            PrpfesprPageWindow profesor = new PrpfesprPageWindow();
            profesor.Show();
        }

        private void Materie_Click(object sender, RoutedEventArgs e)
        {
            MaterieWindow materie = new MaterieWindow();
            materie.Show();
        }

        private void An_Studiu_Click(object sender, RoutedEventArgs e)
        {
            An_studiuWindow anStudiu = new An_studiuWindow();
            anStudiu.Show();
        }

        private void Specializare_Click(object sender, RoutedEventArgs e)
        {
            SpecializareWindow specializare = new SpecializareWindow();
            specializare.Show();
        }

        private void Clasa_Click(object sender, RoutedEventArgs e)
        {
            ClasaWindow clasa = new ClasaWindow();
            clasa.Show();
        }

        private void Medie_Click(object sender, RoutedEventArgs e)
        {
            MedieWindow medie = new MedieWindow();
            medie.Show();
        }

    }
}
