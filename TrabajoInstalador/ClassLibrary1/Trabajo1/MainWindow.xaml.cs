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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trabajo1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Nueva_Click(object sender, RoutedEventArgs e)
        {
            NuevoDeporte v = new NuevoDeporte();
            v.Show();
            
        }

        private void GenerarDatos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoEquipo_Click(object sender, RoutedEventArgs e)
        {
            VentaGenerarequipo v = new VentaGenerarequipo();
            v.Show();
        }

        private void btnGenerarEncuentro_Click(object sender, RoutedEventArgs e)
        {
            VentanaGenerarEncuentros v = new VentanaGenerarEncuentros();
            v.Show();
        }
    }
}
