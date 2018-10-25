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

namespace PracticaConsultorio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime fechaInicioConsulta;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGuardarNuevoPaciente_Click(object sender, RoutedEventArgs e)
        {
            Paciente nuevoPaciente = new Paciente();
            nuevoPaciente.Nombre = txtNombre.Text;
            nuevoPaciente.Direccion = txtDireccion.Text;
            nuevoPaciente.Telefono = txtTelefono.Text;
            nuevoPaciente.Edad = int.Parse(txtEdad.Text);
            nuevoPaciente.Altura = float.Parse(txtAltura.Text);
            nuevoPaciente.Peso = float.Parse(txtPeso.Text);
            nuevoPaciente.EnfermedadesCronicas = txtEmfermedadesCronicas.Text;

            Datos.pacientes.Add(nuevoPaciente);
            actualizarListaPacientes();
            txtNombre.Text = string.Empty;
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEdad.Text = "";
            txtAltura.Text = "";
            txtPeso.Text = "";
            txtEmfermedadesCronicas.Text = "";
            gridNuevoPaciente.Visibility = Visibility.Collapsed;
        }
        private void actualizarListaPacientes()
        {
            lstPacientes.Items.Clear();
            foreach(Paciente paciente in Datos.pacientes)
            {
                lstPacientes.Items.Add(new ListBoxItem()
                {
                    Content = paciente.Nombre
                }
                );
            }
        }

        private void btnCrearNuevoPaciente_Click(object sender, RoutedEventArgs e)
        {
            gridNuevoPaciente.Visibility = Visibility.Visible;
            gridFormularioConsulta.Visibility = Visibility.Collapsed;
        }

        private void lstPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstPacientes.SelectedIndex != -1)
            {
                btnNuevaConsulta.IsEnabled = true;
            }
            else
            {
                btnNuevaConsulta.IsEnabled = false;
            }
        }

        private void btnNuevaConsulta_Click(object sender, RoutedEventArgs e)
        {
            Paciente paciente = Datos.pacientes[lstPacientes.SelectedIndex];
            gridNuevoPaciente.Visibility = Visibility.Collapsed;
            gridFormularioConsulta.Visibility = Visibility.Visible;
            txtNombrePacienteConsulta.Text = paciente.Nombre;
            txtEdadPacienteConsulta.Text = paciente.Edad.ToString();
            txtAlturaPacienteConsulta.Text = paciente.Altura.ToString();
            txtPesoPacienteConsulta.Text = paciente.Peso.ToString();
            txtEmfermedadesPacienteConsulta.Text = paciente.EnfermedadesCronicas;
            fechaInicioConsulta = DateTime.Now;
            txtFechaConsulta.Text = fechaInicioConsulta.ToString();

        }

        private void btnGuardarConsulta_Click(object sender, RoutedEventArgs e)
        {
            Consulta nuevaConsulta = new Consulta();
            nuevaConsulta.pacienteActual = Datos.pacientes[lstPacientes.SelectedIndex];
            nuevaConsulta.Sintomas = txtSintomasConsulta.Text;
            nuevaConsulta.Diagnostico = txtDiagnosticoConsulta.Text;
            nuevaConsulta.Receta = txtResetaConsulta.Text;
            nuevaConsulta.fecha = fechaInicioConsulta;

            Datos.consultas.Add(nuevaConsulta);
            txtNombrePacienteConsulta.Text = "";
            txtEdadPacienteConsulta.Text = "";
            txtAlturaPacienteConsulta.Text = "";
            txtPesoPacienteConsulta.Text = "";
            txtEmfermedadesPacienteConsulta.Text = "";
            txtSintomasConsulta.Text = "";
            txtDiagnosticoConsulta.Text = "";
            txtResetaConsulta.Text = "";
            txtFechaConsulta.Text = "";
            gridFormularioConsulta.Visibility = Visibility.Collapsed;
        }
    }
}
