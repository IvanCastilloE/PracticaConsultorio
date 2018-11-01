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
    /// Lógica de interacción para ElementoConsultaControl.xaml
    /// </summary>
    public partial class ElementoConsultaControl : UserControl
    {
        Consulta consulta;
        public ElementoConsultaControl(Consulta consulta)
        {
            InitializeComponent();
            this.consulta = consulta;
            lblSintomas.Text = consulta.Sintomas;
            lblDiagnostico.Text = consulta.Diagnostico;
            lblReseta.Text = consulta.Receta;
            lblFecha.Text = consulta.fecha.ToString();

        }
    }
}
