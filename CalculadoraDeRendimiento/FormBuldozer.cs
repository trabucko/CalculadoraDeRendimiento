using CalculadoraDeRendimiento.Modelo;
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
        private Material materialSeleccionado;

        public FormBuldozer()
        {
            InitializeComponent();
        }


        private void CargarDatosGrid()
        {
            //dataGridView1.DataSource = null;
            //dataGridView1.DataSource = Logica.Instancia.Listar();
        }

        private void FormBuldozer_Load(object sender, EventArgs e)
        {
            // Cargar Modelos de Buldócer
            List<string> modelos = Logica.Instancia.ListarModelosBulldozer();
            box_modelos.Items.Clear();
            foreach (string modelo in modelos)
            {
                box_modelos.Items.Add(modelo);
            }
            if (box_modelos.Items.Count > 0)
            {
                box_modelos.SelectedIndex = 0;
            }

            // --- MOVIDO AQUÍ: Cargar los Materiales ---
            List<string> materiales = Logica.Instancia.ListarMateriales();
            box_material.Items.Clear();
            foreach (string material in materiales)
            {
                box_material.Items.Add(material);
            }
            if (box_material.Items.Count > 0)
            {
                box_material.SelectedIndex = 0;
            }

            // Establecer el estado inicial de los GroupBox
            buttom_material.Checked = true;
            group_material.Enabled = true;
            group_factor.Enabled = false;
        }

        private void box_modelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (box_modelos.SelectedItem == null) return;

            string modeloSeleccionado = box_modelos.SelectedItem.ToString();
            List<string> tiposDeHoja = Logica.Instancia.ListarTiposDeHojaPorModelo(modeloSeleccionado);

            buttom_Recta.Checked = false;
            buttom_Angulable.Checked = false;

            // 5. Activamos o desactivamos cada RadioButton si su tipo de hoja existe en la lista.
            // La función .Contains() devuelve true si la lista contiene el texto.
            buttom_Recta.Enabled = tiposDeHoja.Contains("RECTA");
            buttom_Angulable.Enabled = tiposDeHoja.Contains("ANGULABLE");





            // --- NUEVO CÓDIGO PARA CARGAR LOS MATERIALES ---
            List<string> materiales = Logica.Instancia.ListarMateriales();
            box_material.Items.Clear(); // Asegúrate que tu ComboBox se llame 'box_material'
            foreach (string material in materiales)
            {
                box_material.Items.Add(material);
            }
            if (box_material.Items.Count > 0)
            {
                box_material.SelectedIndex = 0;
            }
        }

        private void box_material_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (box_material.SelectedItem == null) return;

            // Obtenemos el nombre del suelo seleccionado
            string nombreSuelo = box_material.SelectedItem.ToString();

            // Usamos nuestro nuevo método para traer todas sus propiedades
            // y las guardamos en nuestra variable de clase.
            materialSeleccionado = Logica.Instancia.ObtenerPropiedadesMaterial(nombreSuelo);

            // Opcional: Puedes mostrar un mensaje si algo sale mal
            if (materialSeleccionado == null)
            {
                MessageBox.Show("No se pudieron cargar las propiedades del material.", "Error");
            }
        }

  

        private void buttom_material_CheckedChanged(object sender, EventArgs e)
        {
            // Verificamos si la opción "Material" está seleccionada.
            if (buttom_material.Checked)
            {
                // Si es así, habilitamos el GroupBox de material y deshabilitamos el de factor.
                group_material.Enabled = true;
                group_factor.Enabled = false;
            }
            else // Si no, significa que la opción "Factor" está seleccionada.
            {
                // Hacemos lo contrario: deshabilitamos el de material y habilitamos el de factor.
                group_material.Enabled = false;
                group_factor.Enabled = true;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // --- 1. VALIDACIONES INICIALES DE SELECCIÓN ---
            if (box_modelos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un modelo.");
                return;
            }
            if (!buttom_Recta.Checked && !buttom_Angulable.Checked)
            {
                MessageBox.Show("Por favor, seleccione un tipo de hoja.");
                return;
            }

            // --- 2. RECOPILACIÓN Y VALIDACIÓN DE TODOS LOS TEXTBOX (UNA SOLA VEZ) ---
            double Eficacia, velocidadAvance, velocidadRetorno, distancia;

            if (!double.TryParse(txtbox_Eficacia.Text, out Eficacia) || Eficacia <= 0 || Eficacia > 1)
            {
                MessageBox.Show("La Eficiencia debe ser un número entre 0.01 y 1.0.");
                return;
            }
            // NOTA: Asegúrate de que tus TextBox se llamen así. Yo usaré los nombres del código que me pasaste.
            // Si se llaman textBox3, textBox4, etc., cámbialos aquí.
            if (!double.TryParse(txtVelocidadAvance.Text, out velocidadAvance) || velocidadAvance <= 0)
            {
                MessageBox.Show("La Velocidad de Avance debe ser un número positivo.");
                return;
            }
            if (!double.TryParse(txtVelocidadRetorno.Text, out velocidadRetorno) || velocidadRetorno <= 0)
            {
                MessageBox.Show("La Velocidad de Retorno debe ser un número positivo.");
                return;
            }
            if (!double.TryParse(txtDistanciaDelProyecto.Text, out distancia) || distancia <= 0)
            {
                MessageBox.Show("La Distancia del Proyecto debe ser un número positivo.");
                return;
            }

            // --- 3. CÁLCULO DE 'Fab' (FACTOR DE ABUNDAMIENTO / enjuntamiento) ---
            double FactorAbundamiento = 0;
            if (buttom_factor.Checked)
            {
                if (!double.TryParse(txtbox_factor_Especifo.Text, out FactorAbundamiento) || FactorAbundamiento <= 0)
                {
                    MessageBox.Show("El Factor Específico debe ser un número positivo.");
                    return;
                }
            }
            else if (buttom_material.Checked)
            {
                if (materialSeleccionado == null) { MessageBox.Show("Seleccione un material."); return; }

                if (buttom_estado_Abundamiento.Checked)
                    FactorAbundamiento = (materialSeleccionado.abundamiento_a + materialSeleccionado.abundamiento_b) / 2;
                else if (buttom_estado_Enjuntamiento.Checked)
                    FactorAbundamiento = (materialSeleccionado.enjuntamiento_a + materialSeleccionado.enjuntamiento_b) / 2;
                else { MessageBox.Show("Seleccione un estado para el material."); return; }
            }







            // --- 4. CÁLCULO DE 'Tc' (TIEMPO DE CICLO) en minutos ---
            double tiempoManiobra = 0.33; // Tiempo fijo en minutos
            double tiempoAcarreo_min = (distancia / 1000.0) / velocidadAvance * 60.0;
            double tiempoRetorno_min = (distancia / 1000.0) / velocidadRetorno * 60.0;


            double TiempoCiclo = tiempoAcarreo_min + tiempoRetorno_min + tiempoManiobra;


            
            // --- 5. OBTENER DATOS DE LA HOJA Y CALCULAR 'C' (CAPACIDAD) ---
            string modeloSeleccionado = box_modelos.SelectedItem.ToString();
            string tipoHojaSeleccionado = buttom_Recta.Checked ? "RECTA" : "ANGULABLE";

            // NOTA: Usa el nombre de la clase y método que definiste en tu Lógica.cs
            HojaBulldozer hoja = Logica.Instancia.ObtenerDatosHoja(modeloSeleccionado, tipoHojaSeleccionado);
            if (hoja == null)
            {
                MessageBox.Show($"No se encontraron datos de hoja para el modelo {modeloSeleccionado} con tipo {tipoHojaSeleccionado}.");
                return;
            }

            // Fórmula de capacidad simplificada C = longtiud* alto * factorpromedio
            double Capacidad = hoja.longitud_m * hoja.alto_m * 1.3;


            // --- 6. CÁLCULO FINAL DE 'R' (RENDIMIENTO) ---
            if (TiempoCiclo <= 0 || FactorAbundamiento <= 0)
            {
                MessageBox.Show("El Tiempo de Ciclo o el Factor de Abundamiento no pueden ser cero.");
                return;
            }
            double Rendimiento = (Capacidad * Eficacia * 60) / (TiempoCiclo * FactorAbundamiento);

            // --- 7. MOSTRAR EL RESULTADO ---
            label11.Text = $"Rendimiento: {Rendimiento.ToString("F2")} m³/hr";
            label11.Visible = true;

            lbltiempoCiclo.Text = $"Tiempo de Ciclo: {TiempoCiclo.ToString("F2")} min";
        }


    }
}
