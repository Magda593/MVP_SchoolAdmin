using System.Windows;

namespace MVP_Tema3.Views
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
        }

        private void Materie_Click(object sender, RoutedEventArgs e)
        {
            MaterieStudent materie = new MaterieStudent();
            materie.Show();
        }

        private void Absente_Click(object sender, RoutedEventArgs e)
        {
            AbsentaStudentWindow absenta = new AbsentaStudentWindow();
            absenta.Show();
        }

        private void Nota_Click(object sender, RoutedEventArgs e)
        {
            NotaStudentWindow nota = new NotaStudentWindow();
            nota.Show();
        }
    }
}
