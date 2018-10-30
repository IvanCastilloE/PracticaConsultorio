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

namespace PracticaConsultorio
{
    /// <summary>
    /// Lógica de interacción para HistorialConsultasWindow.xaml
    /// </summary>
    public partial class HistorialConsultasWindow : Window
    {
        Paciente paciente;
        public HistorialConsultasWindow(Paciente paciente)
        {
            InitializeComponent();
            this.paciente = paciente;
        }
    }
}
