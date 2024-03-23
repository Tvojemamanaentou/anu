namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPen = new System.Windows.Forms.Button();
            this.buttonPencil = new System.Windows.Forms.Button();
            this.buttonEraser = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panelPlatno = new System.Windows.Forms.Panel();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonTriangle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPen
            // 
            this.buttonPen.Location = new System.Drawing.Point(930, 62);
            this.buttonPen.Name = "buttonPen";
            this.buttonPen.Size = new System.Drawing.Size(113, 44);
            this.buttonPen.TabIndex = 1;
            this.buttonPen.Text = "Pero";
            this.buttonPen.UseVisualStyleBackColor = true;
            this.buttonPen.Click += new System.EventHandler(this.buttonPen_Click);
            // 
            // buttonPencil
            // 
            this.buttonPencil.Location = new System.Drawing.Point(930, 112);
            this.buttonPencil.Name = "buttonPencil";
            this.buttonPencil.Size = new System.Drawing.Size(113, 44);
            this.buttonPencil.TabIndex = 2;
            this.buttonPencil.Text = "Tuzka";
            this.buttonPencil.UseVisualStyleBackColor = true;
            this.buttonPencil.Click += new System.EventHandler(this.buttonPencil_Click);
            // 
            // buttonEraser
            // 
            this.buttonEraser.Location = new System.Drawing.Point(930, 162);
            this.buttonEraser.Name = "buttonEraser";
            this.buttonEraser.Size = new System.Drawing.Size(113, 44);
            this.buttonEraser.TabIndex = 3;
            this.buttonEraser.Text = "Guma";
            this.buttonEraser.UseVisualStyleBackColor = true;
            this.buttonEraser.Click += new System.EventHandler(this.buttonEraser_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(1049, 588);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(113, 44);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.TabStop = false;
            this.buttonClear.Text = "Smazat";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(930, 588);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(113, 44);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Uložit";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.Color.Black;
            this.buttonColor.Location = new System.Drawing.Point(930, 12);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(113, 44);
            this.buttonColor.TabIndex = 6;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(930, 212);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(232, 69);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Tag = "";
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panelPlatno
            // 
            this.panelPlatno.BackColor = System.Drawing.Color.White;
            this.panelPlatno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlatno.Location = new System.Drawing.Point(12, 12);
            this.panelPlatno.Name = "panelPlatno";
            this.panelPlatno.Size = new System.Drawing.Size(900, 620);
            this.panelPlatno.TabIndex = 0;
            this.panelPlatno.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPlatno_Paint);
            this.panelPlatno.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPlatno_MouseClick);
            this.panelPlatno.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPlatno_MouseDown);
            this.panelPlatno.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPlatno_MouseMove);
            this.panelPlatno.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPlatno_MouseUp);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Location = new System.Drawing.Point(930, 259);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(113, 44);
            this.buttonCircle.TabIndex = 8;
            this.buttonCircle.Text = "Kolečko";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Location = new System.Drawing.Point(930, 309);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(113, 44);
            this.buttonRectangle.TabIndex = 9;
            this.buttonRectangle.Text = "Obdelník";
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.Location = new System.Drawing.Point(930, 359);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(113, 44);
            this.buttonTriangle.TabIndex = 10;
            this.buttonTriangle.Text = "Trojúhelník";
            this.buttonTriangle.UseVisualStyleBackColor = true;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1178, 644);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonEraser);
            this.Controls.Add(this.buttonPencil);
            this.Controls.Add(this.buttonPen);
            this.Controls.Add(this.panelPlatno);
            this.Name = "Form1";
            this.Text = "Kreslení";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPen;
        private System.Windows.Forms.Button buttonPencil;
        private System.Windows.Forms.Button buttonEraser;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panelPlatno;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonTriangle;
    }
}

