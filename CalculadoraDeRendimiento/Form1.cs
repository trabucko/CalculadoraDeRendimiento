using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraDeRendimiento
{
    public partial class Form1 : Form
    {
        private List<string> listaDeImagenes;
        private int imagenActualIndex = 0;
        private bool carruselPausado = false;
        private List<Button> indicadores = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarImagenes();
            MostrarImagenActual();
            ConfigurarInterfaz();
            timerAuto.Start();
        }

        private void CargarImagenes()
        {
            string rutaCarpeta = Path.Combine(Application.StartupPath, "Imagenes");
            listaDeImagenes = new List<string>();

            if (Directory.Exists(rutaCarpeta))
            {
                // Cargar múltiples formatos de imagen
                string[] formatos = { "*.png", "*.jpg", "*.jpeg", "*.bmp", "*.gif" };
                foreach (string formato in formatos)
                {
                    listaDeImagenes.AddRange(Directory.GetFiles(rutaCarpeta, formato));
                }
            }

            // Si no hay imágenes, mostrar mensaje
            if (listaDeImagenes.Count == 0)
            {
                MostrarImagenPlaceholder();
            }
        }

        private void MostrarImagenPlaceholder()
        {
            // Crear una imagen placeholder
            Bitmap placeholder = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(placeholder))
            {
                g.Clear(Color.LightGray);
                using (Font font = new Font("Arial", 16, FontStyle.Bold))
                using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.DrawString("No se encontraron imágenes\nen la carpeta 'Imagenes'",
                                font, Brushes.DarkGray,
                                new RectangleF(0, 0, placeholder.Width, placeholder.Height),
                                sf);
                }
            }
            pictureBox1.Image = placeholder;
        }

        private void MostrarImagenActual()
        {
            if (listaDeImagenes != null && listaDeImagenes.Count > 0)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(listaDeImagenes[imagenActualIndex]);
                    ActualizarContador();
                    ActualizarIndicadores();
                    ActualizarTituloImagen();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarInterfaz()
        {
            // Configurar botones de navegación
            btnAnterior.Visible = listaDeImagenes.Count > 1;
            btnSiguiente.Visible = listaDeImagenes.Count > 1;

            // Crear indicadores
            CrearIndicadores();
        }

        private void CrearIndicadores()
        {
            panelIndicadores.Controls.Clear();
            indicadores.Clear();

            if (listaDeImagenes.Count <= 1) return;

            int tamañoIndicador = 12;
            int espacio = 8;
            int totalWidth = (tamañoIndicador + espacio) * listaDeImagenes.Count - espacio;
            int startX = (panelIndicadores.Width - totalWidth) / 2;

            for (int i = 0; i < listaDeImagenes.Count; i++)
            {
                Button indicador = new Button();
                indicador.Size = new Size(tamañoIndicador, tamañoIndicador);
                indicador.Location = new Point(startX + i * (tamañoIndicador + espacio),
                                             (panelIndicadores.Height - tamañoIndicador) / 2);
                indicador.FlatStyle = FlatStyle.Flat;
                indicador.FlatAppearance.BorderSize = 0;
                indicador.BackColor = i == imagenActualIndex ? Color.SteelBlue : Color.LightGray;
                indicador.Enabled = false; // Solo para indicación, no clickeable

                indicadores.Add(indicador);
                panelIndicadores.Controls.Add(indicador);
            }
        }

        private void ActualizarIndicadores()
        {
            for (int i = 0; i < indicadores.Count; i++)
            {
                indicadores[i].BackColor = i == imagenActualIndex ? Color.SteelBlue : Color.LightGray;
            }
        }

        private void ActualizarContador()
        {
            lblContador.Text = $"Imagen {imagenActualIndex + 1} de {listaDeImagenes.Count}";
        }

        private void ActualizarTituloImagen()
        {
            if (listaDeImagenes.Count > 0)
            {
                string nombreArchivo = Path.GetFileNameWithoutExtension(listaDeImagenes[imagenActualIndex]);
                lblTitulo.Text = $"Seleccione su Equipo: {nombreArchivo}";
            }
        }

        private void timerAuto_Tick(object sender, EventArgs e)
        {
            if (!carruselPausado && listaDeImagenes.Count > 1)
            {
                AvanzarImagen();
            }
        }

        private void AvanzarImagen()
        {
            imagenActualIndex++;
            if (imagenActualIndex >= listaDeImagenes.Count)
            {
                imagenActualIndex = 0;
            }
            MostrarImagenActual();
        }

        private void RetrocederImagen()
        {
            imagenActualIndex--;
            if (imagenActualIndex < 0)
            {
                imagenActualIndex = listaDeImagenes.Count - 1;
            }
            MostrarImagenActual();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            AvanzarImagen();
            // Reiniciar timer al interactuar manualmente
            timerAuto.Stop();
            timerAuto.Start();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            RetrocederImagen();
            // Reiniciar timer al interactuar manualmente
            timerAuto.Stop();
            timerAuto.Start();
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            carruselPausado = !carruselPausado;
            btnPausa.Text = carruselPausado ? "▶" : "⏸";
            btnPausa.ForeColor = carruselPausado ? Color.Green : Color.SteelBlue;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (listaDeImagenes.Count == 0) return;

            string nombreArchivo = Path.GetFileName(listaDeImagenes[imagenActualIndex]).ToLower();

            // Comparamos el nombre del archivo para decidir qué formulario cargar
            if (nombreArchivo.Contains("buldozer"))
            {
                AbrirFormulario<FormBuldozer>();
            }
            else if (nombreArchivo.Contains("mototrailla"))
            {
                AbrirFormulario<FormMotoTrailla>();
            }
            else
            {
                MessageBox.Show($"No hay formulario específico para: {Path.GetFileNameWithoutExtension(nombreArchivo)}",
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AbrirFormulario<T>() where T : Form, new()
        {
            try
            {
                Form formulario = new T();
                formulario.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Liberar recursos de imágenes
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
        }

       
    }
}