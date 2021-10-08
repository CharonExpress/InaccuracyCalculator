
namespace InaccuracyCalculator
{
    partial class Calc
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calc));
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabs = new System.Windows.Forms.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.addFloorButt = new System.Windows.Forms.Button();
            this.removeFloorButt = new System.Windows.Forms.Button();
            this.calcButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shapeType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autoFloorsCheckBox = new System.Windows.Forms.CheckBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.reloadButton = new System.Windows.Forms.Button();
            this.oksFormulaBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // x
            // 
            this.x.HeaderText = "Сторона или основание треугольника";
            this.x.Name = "x";
            // 
            // y
            // 
            this.y.HeaderText = "Сторона или высота треугольника";
            this.y.Name = "y";
            // 
            // tabs
            // 
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.ImageList = this.imageList1;
            this.tabs.Location = new System.Drawing.Point(3, 135);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(945, 523);
            this.tabs.TabIndex = 1;
            this.tabs.Tag = "";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "clipart3253198.png");
            this.imageList1.Images.SetKeyName(1, "exist.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabs, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.oksFormulaBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 661);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tableLayoutPanel2.Controls.Add(this.addFloorButt, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.removeFloorButt, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.calcButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.autoFloorsCheckBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.aboutButton, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.reloadButton, 4, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(945, 60);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // addFloorButt
            // 
            this.addFloorButt.Location = new System.Drawing.Point(3, 3);
            this.addFloorButt.Name = "addFloorButt";
            this.addFloorButt.Size = new System.Drawing.Size(230, 24);
            this.addFloorButt.TabIndex = 0;
            this.addFloorButt.Text = "Добавить этаж";
            this.addFloorButt.UseVisualStyleBackColor = true;
            this.addFloorButt.Click += new System.EventHandler(this.addFloorButt_Click);
            // 
            // removeFloorButt
            // 
            this.removeFloorButt.Enabled = false;
            this.removeFloorButt.Location = new System.Drawing.Point(3, 33);
            this.removeFloorButt.Name = "removeFloorButt";
            this.removeFloorButt.Size = new System.Drawing.Size(230, 24);
            this.removeFloorButt.TabIndex = 3;
            this.removeFloorButt.Text = "Удалить этаж";
            this.removeFloorButt.UseVisualStyleBackColor = true;
            this.removeFloorButt.Click += new System.EventHandler(this.removeFloorButt_Click);
            // 
            // calcButton
            // 
            this.calcButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calcButton.Enabled = false;
            this.calcButton.Location = new System.Drawing.Point(499, 3);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(143, 24);
            this.calcButton.TabIndex = 5;
            this.calcButton.Text = "Рассчитать";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.a,
            this.b,
            this.shapeType,
            this.ms,
            this.formula});
            this.dataGridView1.Location = new System.Drawing.Point(499, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(143, 24);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            // 
            // a
            // 
            this.a.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.a.HeaderText = "Сторона или основание треугольника";
            this.a.Name = "a";
            // 
            // b
            // 
            this.b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.b.HeaderText = "Сторона или высота треугольника";
            this.b.Name = "b";
            // 
            // shapeType
            // 
            this.shapeType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.shapeType.HeaderText = "Тип фигуры";
            this.shapeType.Name = "shapeType";
            this.shapeType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ms
            // 
            this.ms.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ms.HeaderText = "Погрешность измерений 𝑚ₛ";
            this.ms.Name = "ms";
            this.ms.ReadOnly = true;
            // 
            // formula
            // 
            this.formula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.formula.HeaderText = "Формула";
            this.formula.Name = "formula";
            this.formula.ReadOnly = true;
            // 
            // autoFloorsCheckBox
            // 
            this.autoFloorsCheckBox.AutoSize = true;
            this.autoFloorsCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoFloorsCheckBox.Location = new System.Drawing.Point(251, 3);
            this.autoFloorsCheckBox.Name = "autoFloorsCheckBox";
            this.tableLayoutPanel2.SetRowSpan(this.autoFloorsCheckBox, 2);
            this.autoFloorsCheckBox.Size = new System.Drawing.Size(242, 54);
            this.autoFloorsCheckBox.TabIndex = 4;
            this.autoFloorsCheckBox.Text = "Автоматические номера этажей";
            this.autoFloorsCheckBox.UseVisualStyleBackColor = true;
            this.autoFloorsCheckBox.CheckedChanged += new System.EventHandler(this.autoFloorsCheckBox_CheckedChanged);
            // 
            // aboutButton
            // 
            this.aboutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutButton.Location = new System.Drawing.Point(797, 3);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(145, 24);
            this.aboutButton.TabIndex = 8;
            this.aboutButton.Text = "О программе";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // reloadButton
            // 
            this.reloadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reloadButton.Enabled = false;
            this.reloadButton.Location = new System.Drawing.Point(797, 33);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(145, 24);
            this.reloadButton.TabIndex = 9;
            this.reloadButton.Text = "Сбросить всё";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // oksFormulaBox
            // 
            this.oksFormulaBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oksFormulaBox.Location = new System.Drawing.Point(3, 69);
            this.oksFormulaBox.Multiline = true;
            this.oksFormulaBox.Name = "oksFormulaBox";
            this.oksFormulaBox.Size = new System.Drawing.Size(945, 60);
            this.oksFormulaBox.TabIndex = 3;
            // 
            // Calc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calc";
            this.Text = "СКП калькулятор";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button addFloorButt;
        private System.Windows.Forms.Button removeFloorButt;
        private System.Windows.Forms.TextBox oksFormulaBox;
        private System.Windows.Forms.CheckBox autoFloorsCheckBox;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.DataGridViewComboBoxColumn shapeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ms;
        private System.Windows.Forms.DataGridViewTextBoxColumn formula;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button reloadButton;
    }
}

