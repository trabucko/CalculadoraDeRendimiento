namespace CalculadoraDeRendimiento
{
    partial class FormBuldozer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbox_Eficacia = new System.Windows.Forms.TextBox();
            this.buttom_material = new System.Windows.Forms.RadioButton();
            this.buttom_factor = new System.Windows.Forms.RadioButton();
            this.txtVelocidadAvance = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVelocidadRetorno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDistanciaDelProyecto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.group_modelo = new System.Windows.Forms.GroupBox();
            this.buttom_Angulable = new System.Windows.Forms.RadioButton();
            this.buttom_Recta = new System.Windows.Forms.RadioButton();
            this.box_modelos = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.group_material_factor = new System.Windows.Forms.GroupBox();
            this.group_material = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.box_material = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttom_estado_Abundamiento = new System.Windows.Forms.RadioButton();
            this.buttom_estado_Enjuntamiento = new System.Windows.Forms.RadioButton();
            this.group_factor = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbox_factor_Especifo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.group_eficacia = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbltiempoCiclo = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.group_modelo.SuspendLayout();
            this.group_material_factor.SuspendLayout();
            this.group_material.SuspendLayout();
            this.group_factor.SuspendLayout();
            this.group_eficacia.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CalculadoraDeRendimiento.Properties.Resources.Buldozer;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 235);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buldozer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Eficacia:";
            // 
            // txtbox_Eficacia
            // 
            this.txtbox_Eficacia.Location = new System.Drawing.Point(92, 25);
            this.txtbox_Eficacia.Name = "txtbox_Eficacia";
            this.txtbox_Eficacia.Size = new System.Drawing.Size(198, 20);
            this.txtbox_Eficacia.TabIndex = 14;
            // 
            // buttom_material
            // 
            this.buttom_material.AutoSize = true;
            this.buttom_material.Location = new System.Drawing.Point(37, 19);
            this.buttom_material.Name = "buttom_material";
            this.buttom_material.Size = new System.Drawing.Size(451, 17);
            this.buttom_material.TabIndex = 17;
            this.buttom_material.TabStop = true;
            this.buttom_material.Text = "Selecciona esta Opcion si no sabes el Factor Especifico de Abundamiento | Enjunta" +
    "miento";
            this.buttom_material.UseVisualStyleBackColor = true;
            this.buttom_material.CheckedChanged += new System.EventHandler(this.buttom_material_CheckedChanged);
            // 
            // buttom_factor
            // 
            this.buttom_factor.AutoSize = true;
            this.buttom_factor.Location = new System.Drawing.Point(34, 169);
            this.buttom_factor.Name = "buttom_factor";
            this.buttom_factor.Size = new System.Drawing.Size(275, 17);
            this.buttom_factor.TabIndex = 18;
            this.buttom_factor.TabStop = true;
            this.buttom_factor.Text = "Selecciona esta Opcion si sabes el Factor Especifico";
            this.buttom_factor.UseVisualStyleBackColor = true;
            this.buttom_factor.CheckedChanged += new System.EventHandler(this.buttom_material_CheckedChanged);
            // 
            // txtVelocidadAvance
            // 
            this.txtVelocidadAvance.Location = new System.Drawing.Point(9, 71);
            this.txtVelocidadAvance.Name = "txtVelocidadAvance";
            this.txtVelocidadAvance.Size = new System.Drawing.Size(173, 20);
            this.txtVelocidadAvance.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Velocidad de Avance:";
            // 
            // txtVelocidadRetorno
            // 
            this.txtVelocidadRetorno.Location = new System.Drawing.Point(9, 124);
            this.txtVelocidadRetorno.Name = "txtVelocidadRetorno";
            this.txtVelocidadRetorno.Size = new System.Drawing.Size(173, 20);
            this.txtVelocidadRetorno.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Velocidad de Retorno:";
            // 
            // txtDistanciaDelProyecto
            // 
            this.txtDistanciaDelProyecto.Location = new System.Drawing.Point(10, 183);
            this.txtDistanciaDelProyecto.Name = "txtDistanciaDelProyecto";
            this.txtDistanciaDelProyecto.Size = new System.Drawing.Size(172, 20);
            this.txtDistanciaDelProyecto.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Distancia del Proyecto:";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(281, 638);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(504, 38);
            this.btnCalcular.TabIndex = 25;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(858, 552);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 46);
            this.label11.TabIndex = 26;
            this.label11.Text = "label11";
            // 
            // group_modelo
            // 
            this.group_modelo.Controls.Add(this.label2);
            this.group_modelo.Controls.Add(this.buttom_Angulable);
            this.group_modelo.Controls.Add(this.box_modelos);
            this.group_modelo.Controls.Add(this.buttom_Recta);
            this.group_modelo.Controls.Add(this.label13);
            this.group_modelo.Controls.Add(this.label12);
            this.group_modelo.Location = new System.Drawing.Point(281, 40);
            this.group_modelo.Name = "group_modelo";
            this.group_modelo.Size = new System.Drawing.Size(504, 124);
            this.group_modelo.TabIndex = 27;
            this.group_modelo.TabStop = false;
            this.group_modelo.Text = "Modelo Buldozer";
            // 
            // buttom_Angulable
            // 
            this.buttom_Angulable.AutoSize = true;
            this.buttom_Angulable.Location = new System.Drawing.Point(209, 74);
            this.buttom_Angulable.Name = "buttom_Angulable";
            this.buttom_Angulable.Size = new System.Drawing.Size(72, 17);
            this.buttom_Angulable.TabIndex = 32;
            this.buttom_Angulable.TabStop = true;
            this.buttom_Angulable.Text = "Angulable";
            this.buttom_Angulable.UseVisualStyleBackColor = true;
            // 
            // buttom_Recta
            // 
            this.buttom_Recta.AutoSize = true;
            this.buttom_Recta.Location = new System.Drawing.Point(110, 72);
            this.buttom_Recta.Name = "buttom_Recta";
            this.buttom_Recta.Size = new System.Drawing.Size(54, 17);
            this.buttom_Recta.TabIndex = 31;
            this.buttom_Recta.TabStop = true;
            this.buttom_Recta.Text = "Recta";
            this.buttom_Recta.UseVisualStyleBackColor = true;
            // 
            // box_modelos
            // 
            this.box_modelos.FormattingEnabled = true;
            this.box_modelos.Location = new System.Drawing.Point(82, 37);
            this.box_modelos.Name = "box_modelos";
            this.box_modelos.Size = new System.Drawing.Size(199, 21);
            this.box_modelos.TabIndex = 30;
            this.box_modelos.SelectedIndexChanged += new System.EventHandler(this.box_modelos_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Tipo de Hoja:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(31, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Modelo:";
            // 
            // group_material_factor
            // 
            this.group_material_factor.Controls.Add(this.textBox2);
            this.group_material_factor.Controls.Add(this.textBox1);
            this.group_material_factor.Controls.Add(this.label17);
            this.group_material_factor.Controls.Add(this.label16);
            this.group_material_factor.Controls.Add(this.radioButton1);
            this.group_material_factor.Controls.Add(this.group_factor);
            this.group_material_factor.Controls.Add(this.group_material);
            this.group_material_factor.Controls.Add(this.buttom_material);
            this.group_material_factor.Controls.Add(this.buttom_factor);
            this.group_material_factor.Location = new System.Drawing.Point(281, 170);
            this.group_material_factor.Name = "group_material_factor";
            this.group_material_factor.Size = new System.Drawing.Size(504, 372);
            this.group_material_factor.TabIndex = 28;
            this.group_material_factor.TabStop = false;
            this.group_material_factor.Text = "Material | Factor Especifico";
            // 
            // group_material
            // 
            this.group_material.Controls.Add(this.label3);
            this.group_material.Controls.Add(this.box_material);
            this.group_material.Controls.Add(this.label5);
            this.group_material.Controls.Add(this.buttom_estado_Abundamiento);
            this.group_material.Controls.Add(this.buttom_estado_Enjuntamiento);
            this.group_material.Location = new System.Drawing.Point(34, 42);
            this.group_material.Name = "group_material";
            this.group_material.Size = new System.Drawing.Size(437, 109);
            this.group_material.TabIndex = 19;
            this.group_material.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Material:";
            // 
            // box_material
            // 
            this.box_material.FormattingEnabled = true;
            this.box_material.Location = new System.Drawing.Point(57, 25);
            this.box_material.Name = "box_material";
            this.box_material.Size = new System.Drawing.Size(199, 21);
            this.box_material.TabIndex = 14;
            this.box_material.SelectedIndexChanged += new System.EventHandler(this.box_material_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Estado:";
            // 
            // buttom_estado_Abundamiento
            // 
            this.buttom_estado_Abundamiento.AutoSize = true;
            this.buttom_estado_Abundamiento.Location = new System.Drawing.Point(58, 65);
            this.buttom_estado_Abundamiento.Name = "buttom_estado_Abundamiento";
            this.buttom_estado_Abundamiento.Size = new System.Drawing.Size(93, 17);
            this.buttom_estado_Abundamiento.TabIndex = 16;
            this.buttom_estado_Abundamiento.TabStop = true;
            this.buttom_estado_Abundamiento.Text = "Abundamiento";
            this.buttom_estado_Abundamiento.UseVisualStyleBackColor = true;
            // 
            // buttom_estado_Enjuntamiento
            // 
            this.buttom_estado_Enjuntamiento.AutoSize = true;
            this.buttom_estado_Enjuntamiento.Location = new System.Drawing.Point(167, 65);
            this.buttom_estado_Enjuntamiento.Name = "buttom_estado_Enjuntamiento";
            this.buttom_estado_Enjuntamiento.Size = new System.Drawing.Size(92, 17);
            this.buttom_estado_Enjuntamiento.TabIndex = 17;
            this.buttom_estado_Enjuntamiento.TabStop = true;
            this.buttom_estado_Enjuntamiento.Text = "Enjuntamiento";
            this.buttom_estado_Enjuntamiento.UseVisualStyleBackColor = true;
            // 
            // group_factor
            // 
            this.group_factor.Controls.Add(this.label7);
            this.group_factor.Controls.Add(this.txtbox_factor_Especifo);
            this.group_factor.Location = new System.Drawing.Point(34, 192);
            this.group_factor.Name = "group_factor";
            this.group_factor.Size = new System.Drawing.Size(437, 67);
            this.group_factor.TabIndex = 20;
            this.group_factor.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Factor Especifico:";
            // 
            // txtbox_factor_Especifo
            // 
            this.txtbox_factor_Especifo.Location = new System.Drawing.Point(102, 27);
            this.txtbox_factor_Especifo.Name = "txtbox_factor_Especifo";
            this.txtbox_factor_Especifo.Size = new System.Drawing.Size(154, 20);
            this.txtbox_factor_Especifo.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "___________________________";
            // 
            // group_eficacia
            // 
            this.group_eficacia.Controls.Add(this.txtbox_Eficacia);
            this.group_eficacia.Controls.Add(this.label6);
            this.group_eficacia.Location = new System.Drawing.Point(281, 548);
            this.group_eficacia.Name = "group_eficacia";
            this.group_eficacia.Size = new System.Drawing.Size(504, 72);
            this.group_eficacia.TabIndex = 29;
            this.group_eficacia.TabStop = false;
            this.group_eficacia.Text = "Inserte Eficacia";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbltiempoCiclo);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.txtVelocidadAvance);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.txtVelocidadRetorno);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.txtDistanciaDelProyecto);
            this.groupBox6.Location = new System.Drawing.Point(12, 291);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(248, 358);
            this.groupBox6.TabIndex = 30;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Datos Buldozer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "km/h";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(188, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "km/h";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(188, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "m";
            // 
            // lbltiempoCiclo
            // 
            this.lbltiempoCiclo.AutoSize = true;
            this.lbltiempoCiclo.Location = new System.Drawing.Point(11, 230);
            this.lbltiempoCiclo.Name = "lbltiempoCiclo";
            this.lbltiempoCiclo.Size = new System.Drawing.Size(81, 13);
            this.lbltiempoCiclo.TabIndex = 29;
            this.lbltiempoCiclo.Text = "tiempo de ciclo:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(34, 288);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(266, 17);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Selecciona esta Opcion para calcular por densidad";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 329);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Banco:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(218, 332);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Suelto:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 326);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 24;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(264, 326);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 25;
            // 
            // FormBuldozer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1155, 688);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.group_eficacia);
            this.Controls.Add(this.group_material_factor);
            this.Controls.Add(this.group_modelo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormBuldozer";
            this.Text = "FormBuldozer";
            this.Load += new System.EventHandler(this.FormBuldozer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.group_modelo.ResumeLayout(false);
            this.group_modelo.PerformLayout();
            this.group_material_factor.ResumeLayout(false);
            this.group_material_factor.PerformLayout();
            this.group_material.ResumeLayout(false);
            this.group_material.PerformLayout();
            this.group_factor.ResumeLayout(false);
            this.group_factor.PerformLayout();
            this.group_eficacia.ResumeLayout(false);
            this.group_eficacia.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbox_Eficacia;
        private System.Windows.Forms.RadioButton buttom_material;
        private System.Windows.Forms.RadioButton buttom_factor;
        private System.Windows.Forms.TextBox txtVelocidadAvance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVelocidadRetorno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDistanciaDelProyecto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox group_modelo;
        private System.Windows.Forms.RadioButton buttom_Angulable;
        private System.Windows.Forms.ComboBox box_modelos;
        private System.Windows.Forms.RadioButton buttom_Recta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox group_material_factor;
        private System.Windows.Forms.GroupBox group_material;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox box_material;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton buttom_estado_Abundamiento;
        private System.Windows.Forms.RadioButton buttom_estado_Enjuntamiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox group_factor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbox_factor_Especifo;
        private System.Windows.Forms.GroupBox group_eficacia;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltiempoCiclo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}