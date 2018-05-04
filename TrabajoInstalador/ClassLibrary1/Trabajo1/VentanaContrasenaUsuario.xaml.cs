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

namespace Trabajo1
{
    /// <summary>
    /// Lógica de interacción para VentanaContrasenaUsuario.xaml
    /// </summary>
    public partial class VentanaContrasenaUsuario : Window
    {
        public VentanaContrasenaUsuario()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Leer contrasena = new Leer();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Text;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena()&& usuarioIngresada == contrasena.usuario())
            {
                MainWindow v = new MainWindow();
                v.Show();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Erro usuario o contraseña incorrecta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                limpiarCampos();
            }

        }

        private void limpiarCampos()
        {
            txbContrasena.Clear();
            txbUsuario.Clear();
        }

        private void CambiarContrasena_Click(object sender, RoutedEventArgs e)
        {
            Leer contrasena = new Leer();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Text;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
            {
               NuevaContrasenaUsuario v = new NuevaContrasenaUsuario();
                v.Show();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Erro usuario o contraseña incorrecta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                limpiarCampos();
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
