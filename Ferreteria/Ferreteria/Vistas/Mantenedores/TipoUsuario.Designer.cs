namespace Ferreteria.Vistas.Mantenedores
{
    partial class TipoUsuario
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombreTipoUsuarioBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarTipoUsuario = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarTipoUsuario = new System.Windows.Forms.Button();
            this.btnEditarTipoUsuario = new System.Windows.Forms.Button();
            this.btnAgregarTipoUsuario = new System.Windows.Forms.Button();
            this.txtDescripcionTipoUsuario = new System.Windows.Forms.TextBox();
            this.txtNonbreTipoUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridTipoUsuario = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdTipoUsuario = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTipoUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombreTipoUsuarioBusqueda);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBuscarTipoUsuario);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Tipo Usuario";
            // 
            // txtNombreTipoUsuarioBusqueda
            // 
            this.txtNombreTipoUsuarioBusqueda.Location = new System.Drawing.Point(61, 30);
            this.txtNombreTipoUsuarioBusqueda.Name = "txtNombreTipoUsuarioBusqueda";
            this.txtNombreTipoUsuarioBusqueda.Size = new System.Drawing.Size(100, 20);
            this.txtNombreTipoUsuarioBusqueda.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // btnBuscarTipoUsuario
            // 
            this.btnBuscarTipoUsuario.Location = new System.Drawing.Point(167, 28);
            this.btnBuscarTipoUsuario.Name = "btnBuscarTipoUsuario";
            this.btnBuscarTipoUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarTipoUsuario.TabIndex = 0;
            this.btnBuscarTipoUsuario.Text = "Buscar";
            this.btnBuscarTipoUsuario.UseVisualStyleBackColor = true;
            this.btnBuscarTipoUsuario.Click += new System.EventHandler(this.btnBuscarTipoUsuario_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIdTipoUsuario);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnEliminarTipoUsuario);
            this.groupBox2.Controls.Add(this.btnEditarTipoUsuario);
            this.groupBox2.Controls.Add(this.btnAgregarTipoUsuario);
            this.groupBox2.Controls.Add(this.txtDescripcionTipoUsuario);
            this.groupBox2.Controls.Add(this.txtNonbreTipoUsuario);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 187);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Tipo Usuario";
            // 
            // btnEliminarTipoUsuario
            // 
            this.btnEliminarTipoUsuario.Location = new System.Drawing.Point(175, 158);
            this.btnEliminarTipoUsuario.Name = "btnEliminarTipoUsuario";
            this.btnEliminarTipoUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarTipoUsuario.TabIndex = 6;
            this.btnEliminarTipoUsuario.Text = "Eliminar";
            this.btnEliminarTipoUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarTipoUsuario.Click += new System.EventHandler(this.btnEliminarTipoUsuario_Click);
            // 
            // btnEditarTipoUsuario
            // 
            this.btnEditarTipoUsuario.Location = new System.Drawing.Point(94, 158);
            this.btnEditarTipoUsuario.Name = "btnEditarTipoUsuario";
            this.btnEditarTipoUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnEditarTipoUsuario.TabIndex = 5;
            this.btnEditarTipoUsuario.Text = "Editar";
            this.btnEditarTipoUsuario.UseVisualStyleBackColor = true;
            this.btnEditarTipoUsuario.Click += new System.EventHandler(this.btnEditarTipoUsuario_Click);
            // 
            // btnAgregarTipoUsuario
            // 
            this.btnAgregarTipoUsuario.Location = new System.Drawing.Point(13, 158);
            this.btnAgregarTipoUsuario.Name = "btnAgregarTipoUsuario";
            this.btnAgregarTipoUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarTipoUsuario.TabIndex = 4;
            this.btnAgregarTipoUsuario.Text = "Agregar";
            this.btnAgregarTipoUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarTipoUsuario.Click += new System.EventHandler(this.btnAgregarTipoUsuario_Click);
            // 
            // txtDescripcionTipoUsuario
            // 
            this.txtDescripcionTipoUsuario.Location = new System.Drawing.Point(79, 99);
            this.txtDescripcionTipoUsuario.Multiline = true;
            this.txtDescripcionTipoUsuario.Name = "txtDescripcionTipoUsuario";
            this.txtDescripcionTipoUsuario.Size = new System.Drawing.Size(148, 43);
            this.txtDescripcionTipoUsuario.TabIndex = 3;
            // 
            // txtNonbreTipoUsuario
            // 
            this.txtNonbreTipoUsuario.Location = new System.Drawing.Point(79, 64);
            this.txtNonbreTipoUsuario.Name = "txtNonbreTipoUsuario";
            this.txtNonbreTipoUsuario.Size = new System.Drawing.Size(148, 20);
            this.txtNonbreTipoUsuario.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridTipoUsuario);
            this.groupBox3.Location = new System.Drawing.Point(285, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(413, 237);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista de Tipos de Usuarios";
            // 
            // gridTipoUsuario
            // 
            this.gridTipoUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTipoUsuario.Location = new System.Drawing.Point(6, 19);
            this.gridTipoUsuario.Name = "gridTipoUsuario";
            this.gridTipoUsuario.Size = new System.Drawing.Size(401, 212);
            this.gridTipoUsuario.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ID";
            // 
            // txtIdTipoUsuario
            // 
            this.txtIdTipoUsuario.Enabled = false;
            this.txtIdTipoUsuario.Location = new System.Drawing.Point(79, 34);
            this.txtIdTipoUsuario.Name = "txtIdTipoUsuario";
            this.txtIdTipoUsuario.Size = new System.Drawing.Size(72, 20);
            this.txtIdTipoUsuario.TabIndex = 8;
            // 
            // TipoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 312);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TipoUsuario";
            this.Text = "TipoUsuario";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTipoUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombreTipoUsuarioBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarTipoUsuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAgregarTipoUsuario;
        private System.Windows.Forms.TextBox txtDescripcionTipoUsuario;
        private System.Windows.Forms.TextBox txtNonbreTipoUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminarTipoUsuario;
        private System.Windows.Forms.Button btnEditarTipoUsuario;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridTipoUsuario;
        private System.Windows.Forms.TextBox txtIdTipoUsuario;
        private System.Windows.Forms.Label label4;
    }
}