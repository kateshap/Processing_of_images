
namespace Processing_of_images
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalThresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.niblackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моделиШумовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saltPepperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exponentialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rayleighToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методыУдаленияШумаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geometricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilateralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(438, 402);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрыToolStripMenuItem,
            this.моделиШумовToolStripMenuItem,
            this.методыУдаленияШумаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayScaleToolStripMenuItem,
            this.autoToolStripMenuItem,
            this.averageToolStripMenuItem,
            this.globalThresholdToolStripMenuItem,
            this.niblackToolStripMenuItem,
            this.histogramToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.grayScaleToolStripMenuItem.Text = "GrayScale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.grayScaleToolStripMenuItem_Click);
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.autoToolStripMenuItem.Text = "Autocontrast";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.AutocontrastToolStripMenuItem_Click);
            // 
            // averageToolStripMenuItem
            // 
            this.averageToolStripMenuItem.Name = "averageToolStripMenuItem";
            this.averageToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.averageToolStripMenuItem.Text = "Average";
            this.averageToolStripMenuItem.Click += new System.EventHandler(this.averageToolStripMenuItem_Click);
            // 
            // globalThresholdToolStripMenuItem
            // 
            this.globalThresholdToolStripMenuItem.Name = "globalThresholdToolStripMenuItem";
            this.globalThresholdToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.globalThresholdToolStripMenuItem.Text = "GlobalThreshold";
            this.globalThresholdToolStripMenuItem.Click += new System.EventHandler(this.globalThresholdToolStripMenuItem_Click);
            // 
            // niblackToolStripMenuItem
            // 
            this.niblackToolStripMenuItem.Name = "niblackToolStripMenuItem";
            this.niblackToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.niblackToolStripMenuItem.Text = "Niblack";
            this.niblackToolStripMenuItem.Click += new System.EventHandler(this.niblackToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // моделиШумовToolStripMenuItem
            // 
            this.моделиШумовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saltPepperToolStripMenuItem,
            this.uniformToolStripMenuItem,
            this.gaussianToolStripMenuItem,
            this.gammaToolStripMenuItem,
            this.exponentialToolStripMenuItem,
            this.rayleighToolStripMenuItem});
            this.моделиШумовToolStripMenuItem.Name = "моделиШумовToolStripMenuItem";
            this.моделиШумовToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.моделиШумовToolStripMenuItem.Text = "Модели шумов";
            // 
            // saltPepperToolStripMenuItem
            // 
            this.saltPepperToolStripMenuItem.Name = "saltPepperToolStripMenuItem";
            this.saltPepperToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.saltPepperToolStripMenuItem.Text = "Salt&Pepper";
            this.saltPepperToolStripMenuItem.Click += new System.EventHandler(this.saltPepperToolStripMenuItem_Click);
            // 
            // uniformToolStripMenuItem
            // 
            this.uniformToolStripMenuItem.Name = "uniformToolStripMenuItem";
            this.uniformToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.uniformToolStripMenuItem.Text = "Uniform";
            this.uniformToolStripMenuItem.Click += new System.EventHandler(this.uniformToolStripMenuItem_Click);
            // 
            // gaussianToolStripMenuItem
            // 
            this.gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            this.gaussianToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.gaussianToolStripMenuItem.Text = "Gaussian";
            this.gaussianToolStripMenuItem.Click += new System.EventHandler(this.gaussianToolStripMenuItem_Click);
            // 
            // gammaToolStripMenuItem
            // 
            this.gammaToolStripMenuItem.Name = "gammaToolStripMenuItem";
            this.gammaToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.gammaToolStripMenuItem.Text = "Gamma";
            this.gammaToolStripMenuItem.Click += new System.EventHandler(this.gammaToolStripMenuItem_Click);
            // 
            // exponentialToolStripMenuItem
            // 
            this.exponentialToolStripMenuItem.Name = "exponentialToolStripMenuItem";
            this.exponentialToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.exponentialToolStripMenuItem.Text = "Exponential";
            this.exponentialToolStripMenuItem.Click += new System.EventHandler(this.exponentialToolStripMenuItem_Click);
            // 
            // rayleighToolStripMenuItem
            // 
            this.rayleighToolStripMenuItem.Name = "rayleighToolStripMenuItem";
            this.rayleighToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.rayleighToolStripMenuItem.Text = "Rayleigh";
            this.rayleighToolStripMenuItem.Click += new System.EventHandler(this.rayleighToolStripMenuItem_Click);
            // 
            // методыУдаленияШумаToolStripMenuItem
            // 
            this.методыУдаленияШумаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geometricToolStripMenuItem,
            this.bilateralToolStripMenuItem});
            this.методыУдаленияШумаToolStripMenuItem.Name = "методыУдаленияШумаToolStripMenuItem";
            this.методыУдаленияШумаToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.методыУдаленияШумаToolStripMenuItem.Text = "Методы удаления шума";
            // 
            // geometricToolStripMenuItem
            // 
            this.geometricToolStripMenuItem.Name = "geometricToolStripMenuItem";
            this.geometricToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.geometricToolStripMenuItem.Text = "Geometric mean";
            this.geometricToolStripMenuItem.Click += new System.EventHandler(this.geometricToolStripMenuItem_Click);
            // 
            // bilateralToolStripMenuItem
            // 
            this.bilateralToolStripMenuItem.Name = "bilateralToolStripMenuItem";
            this.bilateralToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.bilateralToolStripMenuItem.Text = "Bilateral";
            this.bilateralToolStripMenuItem.Click += new System.EventHandler(this.bilateralToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(786, 606);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(456, 46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(436, 402);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 514);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Рассчитать PSNR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 520);
            this.label1.MaximumSize = new System.Drawing.Size(200, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(500, 514);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "Посчитать SSIM";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(706, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 647);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalThresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem niblackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem моделиШумовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saltPepperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uniformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gammaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exponentialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rayleighToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методыУдаленияШумаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geometricToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilateralToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
    }
}

