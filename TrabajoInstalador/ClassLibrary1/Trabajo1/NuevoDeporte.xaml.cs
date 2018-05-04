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
using Trabajo.BIZ;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;
using Trabajo.DAL;

namespace Trabajo1
{
    /// <summary>
    /// Lógica de interacción para NuevoDeporte.xaml
    /// </summary>
    public partial class NuevoDeporte : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        IManejadorDeporte manejadorDeporte;
        accion accionDeporte;
        public NuevoDeporte()
        {
            InitializeComponent();
            manejadorDeporte = new ManejadorDeporte(new RepositorioGenerico<Deporte>());
            PonerBotonesDeporteEnEdicion(false);
            LimpiarCamposDeDeporte();
            ActualizarTablaDeporte();
            
        }

       

        private void ActualizarTablaDeporte()
        {
            dtgDeporte.ItemsSource = null;
            dtgDeporte.ItemsSource = manejadorDeporte.Listar;
        }

        private void LimpiarCamposDeDeporte()
        {
            txbNombreDeporte.Clear();
            
        }

        private void PonerBotonesDeporteEnEdicion(bool value)
        {
            Cancelar.IsEnabled = value;
            Editar.IsEnabled = !value;
            Eliminar.IsEnabled = !value;
            Guardar.IsEnabled = value;
            Nuevo.IsEnabled = !value;
            txbNombreDeporte.IsEnabled = value;
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeDeporte();
            PonerBotonesDeporteEnEdicion(true);
            accionDeporte = accion.Nuevo;
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            Deporte equi = dtgDeporte.SelectedItem as Deporte;
            if (equi != null)
            {
                txbNombreDeporte.Text = equi.Nombre;
                
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionDeporte == accion.Nuevo)
            {
                Deporte equi = new Deporte()
                {
                    Nombre = txbNombreDeporte.Text,
                    
                };
                if (manejadorDeporte.Agregar(equi))
                {
                    MessageBox.Show("Deporte agregado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeDeporte();
                    ActualizarTablaDeporte();
                    PonerBotonesDeporteEnEdicion(true);
                }
                else
                {
                    MessageBox.Show("El Deporte no se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Deporte equi = dtgDeporte.SelectedItem as Deporte;
                equi.Nombre = txbNombreDeporte.Text;
                
                if (manejadorDeporte.Modificar(equi))
                {
                    MessageBox.Show("Deporte modificado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeDeporte();
                    ActualizarTablaDeporte();
                    PonerBotonesDeporteEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Deporte no se pudo actualizar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeDeporte();
            PonerBotonesDeporteEnEdicion(false);

        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Deporte qui = dtgDeporte.SelectedItem as Deporte;
            if (qui != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este Deporte?", "Trabajo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorDeporte.Eliminar(qui.Id))
                    {
                        MessageBox.Show("Equipo eliminado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaDeporte();

                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el equipo", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }

        }
    }
}
