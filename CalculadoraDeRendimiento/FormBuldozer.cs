using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CalculadoraDeRendimiento
{
    public partial class FormBuldozer : Form
    {
        public FormBuldozer()
        {
            InitializeComponent();
        }


        private void CargarDatosGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Logica.Instancia.Listar();
        }

        private void FormBuldozer_Load(object sender, EventArgs e)
        {
            CargarDatosGrid();

        }
    }
}
