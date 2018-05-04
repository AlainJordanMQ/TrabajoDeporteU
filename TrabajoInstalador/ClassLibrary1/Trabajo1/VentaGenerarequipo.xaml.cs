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
    /// Lógica de interacción para VentaGenerarequipo.xaml
    /// </summary>
    public partial class VentaGenerarequipo : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        
        IManejadorEquipo manejadorEquipo;
        IManejadorDeporte manejadorDeporte;
        accion accionEquipo;
        public VentaGenerarequipo()
        {
            InitializeComponent();
            manejadorEquipo = new ManejadorEquipo(new RepositorioGenerico<Equipo>());
            manejadorDeporte = new ManejadorDeporte(new RepositorioGenerico<Deporte>());
            PonerBotonesEquipoEnEdicion(false);
            LimpiarCamposDeEquipo();
            ActualizarTablaEquipo();
            ActualizarCombos();
        }

        private void ActualizarCombos()
        {
            cmbNuevoDeporte.ItemsSource = null;
            cmbNuevoDeporte.ItemsSource = manejadorDeporte.Listar;
        }

        private void ActualizarTablaEquipo()
        {
            dtgEquipo.ItemsSource = null;
            dtgEquipo.ItemsSource = manejadorEquipo.Listar;
        }

        private void LimpiarCamposDeEquipo()
        {
            txbCantidadIntegrantes.Clear();
            txbNombreEquipo.Clear();
            //cmbNuevoDeporte = null;
        }

        private void PonerBotonesEquipoEnEdicion(bool value)
        {
            btnCancelar.IsEnabled = value;
            btnEditar.IsEnabled = !value;
            btnEliminar.IsEnabled = !value;
            btnGuardar.IsEnabled = value;
            btnNuevo.IsEnabled = !value;
            cmbNuevoDeporte.IsEditable = value;
            txbCantidadIntegrantes.IsEnabled = value;
            txbNombreEquipo.IsEnabled = value;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEquipo();
            PonerBotonesEquipoEnEdicion(true);
            accionEquipo = accion.Nuevo;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Equipo equi = dtgEquipo.SelectedItem as Equipo;
            if(equi != null)
            {
                txbCantidadIntegrantes.Text = equi.CantidadDeIntegrantes;
                txbNombreEquipo.Text = equi.Nombre;
                cmbNuevoDeporte.Text = equi.Deporte;
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(accionEquipo == accion.Nuevo)
            {
                if (Esnumero())
                {
                    Equipo equi = new Equipo()
                    {

                        Nombre = txbNombreEquipo.Text,
                        CantidadDeIntegrantes = txbCantidadIntegrantes.Text,
                        Deporte = cmbNuevoDeporte.Text


                    };
                    if (manejadorEquipo.Agregar(equi))
                    {
                        MessageBox.Show("Equipo agregado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiarCamposDeEquipo();
                        ActualizarTablaEquipo();
                        PonerBotonesEquipoEnEdicion(true);
                    }
                    else
                    {
                        MessageBox.Show("El Equipo no se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {

                    MessageBox.Show("El Equipo no se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Equipo equi = dtgEquipo.SelectedItem as Equipo;
                equi.CantidadDeIntegrantes = txbCantidadIntegrantes.Text;
                equi.Nombre = txbNombreEquipo.Text;
                equi.Deporte = cmbNuevoDeporte.Text;
                if (manejadorEquipo.Modificar(equi))
                {
                    MessageBox.Show("Equipo modificado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEquipo();
                    ActualizarTablaEquipo();
                    PonerBotonesEquipoEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Equipo no se pudo actualizar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private bool Esnumero()
        {
            int i = 0;
            string s = txbCantidadIntegrantes.Text;
            bool result;
            //throw new NotImplementedException();
            return  result = int.TryParse(s, out i); //i now = 108  
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEquipo();
            PonerBotonesEquipoEnEdicion(false);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Equipo qui = dtgEquipo.SelectedItem as Equipo;
            if (qui != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este equipo?", "Trabajo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEquipo.Eliminar(qui.Id))
                    {
                        MessageBox.Show("Equipo eliminado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEquipo();

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
