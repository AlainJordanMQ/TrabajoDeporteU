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
    /// Lógica de interacción para VentanaGenerarEncuentros.xaml
    /// </summary>
    public partial class VentanaGenerarEncuentros : Window
    {
        enum accion
        {
            Nuevo
        }
        enum accion2
        {
            Nuevo
        }
        IManejadorNombreGanador manejadorNombreGanador;
        IManejadorDeporte manejadorDeporte;
        IManejadorEquipo manejadorEquipo;
        IManejadorMarcadores manejadorMarcadores;
        IManejadorDeportesPunta manejadorDPunta;
        accion accionMarcadores;
        accion2 accionMarPun;
        public VentanaGenerarEncuentros()
        {
            InitializeComponent();

            manejadorDeporte = new ManejadorDeporte(new RepositorioGenerico<Deporte>());
            manejadorEquipo = new ManejadorEquipo(new RepositorioGenerico<Equipo>());
            manejadorMarcadores = new ManejadorMarcadores(new RepositorioGenerico<Marcadores>());
            manejadorDPunta = new ManejadorDeportePunta(new RepositorioGenerico<DeportePunta>());
            manejadorNombreGanador = new ManejadorNombreGanador(new RepositorioGenerico<NombreGanador>());
            ActualizarComboDeporte();

            ActualizarTablaMarcadores();

        }

        private void ActualizarTablaMarcadores()
        {
            dtgMarcador.ItemsSource = null;
            dtgMarcador.ItemsSource = manejadorMarcadores.Listar;
        }

        private void ActualizarComboDeporte()
        {
            cmbDeporte.ItemsSource = null;
            cmbDeporte.ItemsSource = manejadorDeporte.Listar;


        }
        string[] equipo = new string[50];
        int contador = 0;
        private void btnAceptarDeporte_Click(object sender, RoutedEventArgs e)
        {

            string d = cmbDeporte.Text;
            manejadorEquipo.Deporte(d);
            cmbEquipo.ItemsSource = null;
            cmbEquipo.ItemsSource = manejadorEquipo.Deporte(d);
            for (int i = 0; i < manejadorEquipo.Deporte(d).Count; i++)
            {
                equipo[i] = Convert.ToString(manejadorEquipo.Deporte(d)[i]);
                contador = contador + 1;
            }
        }
        int contadorMarcador = 0;
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            string local = cmbEquipo.SelectedItem.ToString();
            txbLocal.Text = local;
            aleatorio.Text = PosicionAleatorio().ToString();

            while (contadorMarcador < contador)
            {
                txbvisitante.Text = equipo[int.Parse(aleatorio.Text)];
                //txbvisitante.Text = equipo[vPosicion];
                txbvisitante.Text = equipo[numero];
                contadorVerificar = contadorVerificar + 1;
                break;
            }
            if (contadorMarcador == contador-1)
            {
                MessageBox.Show("Ya se relizaron todos los encuntros", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        int vPosicion;
        int numero;
        int[] verificar = new int[50];
        int contadorVerificar=0;
        int vandera=1;
        private int PosicionAleatorio()
        {
            Random rnd = new Random();

            string local = cmbEquipo.SelectedItem.ToString();
            for (int i = 0; i < 100; i++)
            {
                numero = rnd.Next(0, contador);
                for (int j= 0; j < 50; j++)
                {
                    prueba.Text = local;
                    prueba2.Text = equipo[numero];
                    vPosicion = i;
                    if (verificar[j]!=numero&&local!=equipo[numero])
                    {
                        vandera = 1;
                    }
                    else
                    {
                        vandera = 2;
                        break;
                    }
                }
                if (vandera== 1)
                {
                    verificar[contadorVerificar+1] = numero;
                    break;
                }

                
            }
            return numero;
        }
        private void Lugar()
        {
            
        }

        int puntajeF=0;
        string PuntajeFinal;
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (EsnumeroLocal()&&EsnumeroVisitante())
            {
                
                int numeroLocal= Convert.ToInt32(txbPuntajeLocal.Text);
                int numeroVisitante=Convert.ToInt32(txbPuntajeVisitante.Text);
                if (numeroLocal>numeroVisitante)
                {
                    PuntajeFinal = "3";
                    txbPuntajeFinal.Text = PuntajeFinal;
                }
                if (numeroLocal == numeroVisitante)
                {
                    PuntajeFinal = "2";
                    txbPuntajeFinal.Text = PuntajeFinal;
                }
                if (numeroLocal < numeroVisitante)
                {
                    PuntajeFinal = "1";
                    txbPuntajeFinal.Text = PuntajeFinal;
                }
                if (accionMarcadores == accion.Nuevo)
                {
                    puntajeF = puntajeF + int.Parse(PuntajeFinal);
                    Marcadores equi = new Marcadores()
                    {

                        EquipoLocal = txbLocal.Text,
                        PuntajeLocal = txbPuntajeLocal.Text,
                        EquipoVisitante = txbvisitante.Text,
                        PuntajeVisistante = txbPuntajeVisitante.Text,
                        DeporteM = cmbDeporte.Text,
                        PuntajeFinal = txbPuntajeFinal.Text,


                    };
                    
                    if (manejadorMarcadores.Agregar(equi))
                    {
                        MessageBox.Show("agregado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        contadorMarcador = contadorMarcador + 1;
                        ActualizarTablaMarcadores();

                    }
                    else
                    {
                        MessageBox.Show("El Equipo no se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("El Equipo no se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            /*
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
            }*/
        }
        private bool EsnumeroLocal()
        {
            int i = 0;
            string s = txbPuntajeLocal.Text;
            bool result;
            //throw new NotImplementedException();
            return result = int.TryParse(s, out i); //i now = 108  
        }
        private bool EsnumeroVisitante()
        {
            int i = 0;
            string s = txbPuntajeVisitante.Text;
            bool result;
            //throw new NotImplementedException();
            return result = int.TryParse(s, out i); //i now = 108  
        }
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Marcadores qui = dtgMarcador.SelectedItem as Marcadores;
            if (qui != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este Marcador?", "Trabajo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorMarcadores.Eliminar(qui.Id))
                    {
                        MessageBox.Show("Marcador eliminado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaMarcadores();

                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Marcador", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            if (accionMarPun == accion2.Nuevo)
            {

                DeportePunta equi = new DeportePunta()
                {
                    Deporte = cmbDeporte.Text,
                    Nombre = txbLocal.Text,
                    PuntajeFinal = puntajeF.ToString(),


                };
                NombreGanador nom = new NombreGanador()
                {
                    Deporte = cmbDeporte.Text,
                    Nombre = txbLocal.Text,
                    PuntajeFinal = puntajeF.ToString(),
                };
                if (manejadorDPunta.Agregar(equi) && manejadorNombreGanador.Agregar(nom))
                {
                    MessageBox.Show("agregado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    contadorMarcador = contadorMarcador + 1;
                    ActualizarTablaMarcadores();

                }
                else
                {
                    MessageBox.Show("El Equipo no se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            }
        }
}
