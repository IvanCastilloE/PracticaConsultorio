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
        }
    }
}
