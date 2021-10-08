using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace InaccuracyCalculator
{
    public partial class Calc : Form
    {
        private Realty oks;
        private bool autoFloors;

        public Calc()
        {
            InitializeComponent();
            var shapeTypesArr = Enum.GetValues(typeof(ShapesTypes))
        .Cast<Enum>()
        .Select(value => new
        {
            (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
            value
        })
        .OrderBy(item => item.value)
        .ToList();
            DataGridViewComboBoxColumn comboBox = (DataGridViewComboBoxColumn)dataGridView1.Columns[2];
            comboBox.DataSource = shapeTypesArr;
            comboBox.DisplayMember = "Description";
            comboBox.ValueMember = "value";
            autoFloors = true;
            autoFloorsCheckBox.Checked = autoFloors;
        }

        private void DataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[2].Value = ShapesTypes.Прямоугольник;
        }

        private void addFloorButt_Click(object sender, EventArgs e)
        {
            List<int> numbers = new List<int>();

            foreach (TabPage tabpage in tabs.TabPages)
            {
                numbers.Add(Convert.ToInt32(tabpage.Tag));
            }
            TabPage newTab = new TabPage();
            DataGridView dataGrid = new DataGridView
            {
                Dock = DockStyle.Fill
            };
            DataGridViewColumn[] gridViewColumns = new DataGridViewColumn[5];
            dataGridView1.Columns.CopyTo(gridViewColumns, 0);

            foreach (DataGridViewColumn column in gridViewColumns)
            {
                dataGrid.Columns.Add((DataGridViewColumn)column.Clone());
            }

            if (numbers.Count < 1)
            {
                newTab.Tag = 1;
            }
            else
            {
                newTab.Tag = numbers.Max() + 1;
            }

            string floorName;
            if (autoFloors)
            {
                floorName = $"Этаж №{newTab.Tag}";
            }
            else
            {
                string manualFloor = "Введите номер этажа";
                if (InputDialog.ShowInputDialog(ref manualFloor) == DialogResult.OK)
                {
                    floorName = manualFloor;
                }
                else
                {
                    floorName = $"Этаж №{newTab.Tag}";
                }
            }
            newTab.Text = floorName;
            dataGrid.UserAddedRow += DataGridView1_UserAddedRow;
            dataGrid.CellEndEdit += dataGridView_CellEndEdit;
            dataGrid.Rows[0].Cells[2].Value = ShapesTypes.Прямоугольник;

            newTab.Controls.Add(dataGrid);
            newTab.ImageIndex = 1;

            tabs.TabPages.Add(newTab);

            removeFloorButt.Enabled = true;
            reloadButton.Enabled = true;
        }

        private void removeFloorButt_Click(object sender, EventArgs e)
        {
            TabPage tabPageToRemove = tabs.SelectedTab;
            tabs.TabPages.Remove(tabPageToRemove);

            if (tabs.TabPages.Count < 1)
            {
                reloadButton.Enabled = false;
                calcButton.Enabled = false;
                removeFloorButt.Enabled = false;
            }
        }

        private void autoFloorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            autoFloors = autoFloorsCheckBox.Checked;
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            double a, bh;
            try
            {
                a = Convert.ToDouble(dataGridView.Rows[e.RowIndex].Cells[0].Value);
            }
            catch
            {
                dataGridView.Rows[e.RowIndex].Cells[0].Value = null;
                return;
            }

            try
            {
                bh = Convert.ToDouble(dataGridView.Rows[e.RowIndex].Cells[1].Value);
            }
            catch
            {
                dataGridView.Rows[e.RowIndex].Cells[1].Value = null;
                return;
            }

            if (dataGridView.Rows[e.RowIndex].Cells[2].Value == null)
            {
                return;
            }

            if (a * bh == 0)
            {
                return;
            }

            Formula formula = DoFormula(dataGridView.Rows[e.RowIndex]);
            dataGridView.Rows[e.RowIndex].Cells[3].Value = formula.Ms(a >= bh ? a : bh);
            dataGridView.Rows[e.RowIndex].Cells[4].Value = $"{formula.FormulaPrefix} = {formula.FullFormula} = {formula.PartInaccuracy}";
            calcButton.Enabled = true;
        }

        private bool CheckRowDataValid(DataGridViewRow Row)
        {
            try
            {
                double a = Convert.ToDouble(Row.Cells[0].Value);
                double bh = Convert.ToDouble(Row.Cells[1].Value);
                if (a * bh == 0)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            if (Row.Cells[2].Value == null)
            {
                return false;
            }
            return true;
        }

        private Formula DoFormula(DataGridViewRow Row)
        {
            double a, bh;
            ShapesTypes shptype;

            shptype = (ShapesTypes)Row.Cells[2].Value;
            a = Convert.ToDouble(Row.Cells[0].Value);
            bh = Convert.ToDouble(Row.Cells[1].Value);

            switch (shptype)
            {
                case ShapesTypes.Прямоугольник:
                    {
                        Rectangle rectangle = new Rectangle(a, bh);
                        return rectangle;
                    }
                case ShapesTypes.Треугольник:
                    {
                        Triangle triangle = new Triangle(a, bh);
                        return triangle;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            tabs.TabPages.Clear();
            oks = null;
            oksFormulaBox.Text = null;

            calcButton.Enabled = false;
            removeFloorButt.Enabled = false;
            reloadButton.Enabled = false;
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            List<DataGridView> dataGridViews = new List<DataGridView>();

            foreach (TabPage tabPage in tabs.TabPages)
            {
                dataGridViews.Add((DataGridView)tabPage.Controls[0]);
            }

            List<Floor> floors = new List<Floor>();
            foreach (DataGridView data in dataGridViews)
            {
                IEnumerable<DataGridViewRow> rows = data.Rows.Cast<DataGridViewRow>().Where((x) => CheckRowDataValid(x) == true);

                IEnumerable<Formula> elements = rows.Select((x) => DoFormula(x));
                Floor floor = new Floor(elements);
                floors.Add(floor);
            }

            oks = new Realty(floors.AsEnumerable());

            oksFormulaBox.Text = oks.FinalCalculation;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            new AboutBoxX().ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }
    }

    public static class ControlExtensions
    {
        public static T Clone<T>(this T controlToClone)
            where T : Control
        {
            PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            T instance = Activator.CreateInstance<T>();

            foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {

                    if (propInfo.Name != "WindowTarget")
                    {
                        propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                    }
                }
            }

            return instance;
        }
    }
}
