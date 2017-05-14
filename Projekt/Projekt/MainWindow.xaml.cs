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

namespace Projekt
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
        void Teams_Click(object sender, RoutedEventArgs e)
        {
            Teams window = new Teams();
            window.Show();
            
        }
        private void Players_Click(object sender, RoutedEventArgs e)
        {
            Players window = new Players();
            window.Show();
        }
        private void Matches_Click(object sender, RoutedEventArgs e)
        {
            Matches window = new Matches();
            window.Show();
        }
    }
}
