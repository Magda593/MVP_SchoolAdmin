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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Administrator_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow a = new AdminWindow();
            a.Show();
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow s = new StudentWindow();
            s.Show();
        }
    }
}
