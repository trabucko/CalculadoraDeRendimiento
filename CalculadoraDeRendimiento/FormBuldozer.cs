using CalculadoraDeRendimiento.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
            grupo_angulo.Enabled = false;


            // 1. Marca "Abundamiento" como la opción por defecto.
            radio_abundamiento.Checked = true;

            // 2. Deshabilita el TextBox "Compacto" inicialmente.
            txtboxCompacto.Enabled = false;

            // 3. (Opcional) Asegúrate de que el "Suelto" esté habilitado.
            txtboxSuelto.Enabled = true;

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
                grupo_densidad.Enabled = false;
            }
            else if(buttom_factor.Checked) // Si no, significa que la opción "Factor" está seleccionada.
            {
                // Hacemos lo contrario: deshabilitamos el de material y habilitamos el de factor.
                group_material.Enabled = false;
                group_factor.Enabled = true;
                grupo_densidad.Enabled = false;
            }
            else
            {
                group_factor.Enabled=false;
                group_material.Enabled = false;
                grupo_densidad.Enabled = true;
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
            else if (buttom__densidad.Checked)
            {
                // Primero, leemos los valores de los TextBox de densidad
                double banco, suelto, compacto;

                if (!double.TryParse(txtboxBanco.Text, out banco) || banco <= 0)
                {
                    MessageBox.Show("El valor 'banco' debe ser un número positivo.");
                    return;
                }
                // Leemos los otros dos, su validación se hará después
                double.TryParse(txtboxSuelto.Text, out suelto);
                double.TryParse(txtboxCompacto.Text, out compacto);

                // Ahora, dentro de la opción de Densidad, revisamos si es Abundamiento o Enjuntamiento
                if (radio_abundamiento.Checked)
                {
                    // Validamos para evitar división por cero
                    if (suelto <= 0)
                    {
                        MessageBox.Show("El valor 'Suelto' debe ser un número positivo para este cálculo.");
                        return;
                    }
                    // Calculamos el factor según la fórmula de Abundamiento
                    FactorAbundamiento = banco / suelto;
                }
                else if (radio_enjuntamiento.Checked)
                {
                    // Validamos para evitar división por cero
                    if (compacto <= 0)
                    {
                        MessageBox.Show("El valor 'Compacto' debe ser un número positivo para este cálculo.");
                        return;
                    }
                    // Calculamos el factor según la fórmula de Enjuntamiento
                    FactorAbundamiento = banco / compacto;
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un estado (Abundamiento o Enjuntamiento).");
                    return;
                }
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
            // Finalmente, ajustamos la capacidad con el factor de pendiente
            double Capacidad_Real=0;
            if (buttom_pendiente.Checked)
            {
                double valorPendiente;
                if (!double.TryParse(txtboxPendiente.Text, out valorPendiente) || valorPendiente < 0)
                {
                    MessageBox.Show("El valor de la pendiente debe ser un número positivo.");
                    return;
                }

                if (!check_positiva.Checked && !check_negativa.Checked)
                {
                    MessageBox.Show("Debe seleccionar si la pendiente es positiva o negativa.");
                    return;
                }

                double PerdidaPendiente = 0;
                
                double factorPendiente = 0;
                if (check_positiva.Checked)
                {
                    PerdidaPendiente = 3 * valorPendiente;
                    factorPendiente = 100 - PerdidaPendiente; // Restamos para pendiente positiva (100% - x)



                }
                else if (check_negativa.Checked)
                {
                   PerdidaPendiente = 6 * valorPendiente ;
                   factorPendiente = 100 + PerdidaPendiente; // Sumamos para pendiente negativa (100% + x)
                }

                // Aplicamos la regla de tres: x = (valor_ingresado * porcentaje_base) / 1
                double perdida_desplazamiento = distancia * (5.0 / 30.0);



                double factor_desplazamiento = 100 - perdida_desplazamiento;





               
                Capacidad_Real = Capacidad * (factorPendiente/100) * (factor_desplazamiento/100);



                


            }

            // --- 6. CÁLCULO FINAL DE 'R' (RENDIMIENTO) ---
            if (TiempoCiclo <= 0 || FactorAbundamiento <= 0)
            {
                MessageBox.Show("El Tiempo de Ciclo o el Factor de Abundamiento no pueden ser cero.");
                return;




            }



            if (buttom_pendiente.Checked==true)
            {
                double Rendimiento = (Capacidad_Real * Eficacia * 60) / (TiempoCiclo * FactorAbundamiento);
                // --- 7. MOSTRAR EL RESULTADO ---
                label11.Text = $"Rendimiento: {Rendimiento.ToString("F2")} m³/hr";
                label11.Visible = true;
            }
            else
            {
                double Rendimiento = (Capacidad * Eficacia * 60) / (TiempoCiclo * FactorAbundamiento);
                label11.Text = $"Rendimiento: {Rendimiento.ToString("F2")} m³/hr";
                label11.Visible = true;

            }



            lbltiempoCiclo.Text = $"Tiempo de Ciclo: {TiempoCiclo.ToString("F2")} min";

            

            
        }

        private void check_positiva_CheckedChanged(object sender, EventArgs e)
        {
            if (check_positiva.Checked)
            {
                check_negativa.Checked = false;
            }
        }

        private void check_negativa_CheckedChanged(object sender, EventArgs e)
        {
            if (check_negativa.Checked)
            {
                check_positiva.Checked = false;
            }
        }

        private void buttom_pendiente_CheckedChanged(object sender, EventArgs e)
        {
            if (grupo_angulo.Enabled == false)
            {
                grupo_angulo.Enabled = true;
            }
            else
            {
                grupo_angulo.Enabled = false;
            }
        }

        private void radio_abundamiento_CheckedChanged(object sender, EventArgs e)
        {
            // Revisa si la opción "Abundamiento" está marcada.
            if (radio_abundamiento.Checked)
            {
                // Si es así, habilita "Suelto" y deshabilita "Compacto".
                txtboxSuelto.Enabled = true;
                txtboxCompacto.Enabled = false;
            }
            else // Si no, significa que "Enjuntamiento" está marcada.
            {
                // Habilita "Compacto" y deshabilita "Suelto".
                txtboxSuelto.Enabled = false;
                txtboxCompacto.Enabled = true;
            }
        }
    }
}
