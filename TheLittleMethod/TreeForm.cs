using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheLittleMethod
{
    public partial class TreeForm : Form
    {
        public TreeForm(List<string> way, double length)
        {
            InitializeComponent();
            Print(way, length);
        }

        public void Print(List<string> way, double length)
        {
            string _way = string.Empty;

            for (int i = 0; i < way.Count; i++)
            {
                _way = _way + " - " + way[i];

                if (i == 0)
                    _way = way[i];
            }

            label1.Text = "Маршрут: " + _way;

            label2.Text = "Довжина маршруту: " + length.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //public TableLayoutPanel GetGeneratedTable(int colsNum, int rowsNum)
        //{
        //    TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel
        //    {
        //        ColumnCount = colsNum,
        //        RowCount = rowsNum,
        //        Location = new Point(100, 100),
        //        Size = new Size(40 * colsNum, 40 * rowsNum),
        //        Margin = new Padding(0, 0, 0, 50),
        //    };

        //    float widthInPercent = (float)100 / colsNum;
        //    float heightInPercent = (float)100 / rowsNum;

        //    for (int i = 0; i < colsNum; i++)
        //    {
        //        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, widthInPercent));
        //    }

        //    for (int i = 0; i < rowsNum; i++)
        //    {
        //        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, heightInPercent));
        //    }

        //    Label[,] fieldsForMatrix = new Label[colsNum, rowsNum];

        //    for (int i = 0; i < rowsNum; i++)
        //    {
        //        for (int j = 0; j < colsNum; j++)
        //        {
        //            fieldsForMatrix[i, j] = new Label
        //            {
        //                Dock = DockStyle.Fill,
        //                TabIndex = i * rowsNum + j,
        //                Name = "label" + i * rowsNum + j,
        //                TextAlign = ContentAlignment.MiddleCenter,
        //                BackColor = Color.White,
        //                Font = new Font("Microsoft Sans Serif", 16F)
        //            };

        //            tableLayoutPanel1.Controls.Add(fieldsForMatrix[i, j], j, i);
        //        }
        //    }

        //    return tableLayoutPanel1;
        //}

        //public void PrintTable()
        //{
        //    Dictionary<string, Dictionary<string, double>> matrix = tree.RootNode.Matrix;
        //    TableLayoutPanel panel = GetGeneratedTable(matrix.Count + 1, matrix.Count + 1);
        //    int i = 0, j = 0;

        //    foreach (var row in matrix)
        //    {
        //        foreach (var col in row.Value)
        //        {
        //            Label cell = (Label) panel.GetControlFromPosition(j, i);
        //            cell.Text = col.Value.ToString();

        //            if (i == 0)
        //            {
        //                cell.Text = col.Key;
        //            }

        //            if (j == 0)
        //            {
        //                cell.Text = row.Key;
        //            }

        //            j++;
        //        }

        //        j = 0;
        //        i++;
        //    }

        //    Controls.Add(panel);
        //}
    }
}
