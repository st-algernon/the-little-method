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
    public partial class Form1 : Form
    {
        private Tree tree;
        private int dimension;
        private TableLayoutPanel tableLayoutPanel1;
        private Control[,] fieldsForMatrix;
        private Dictionary<string, Dictionary<string, double>> matrix;
        private List<string> Cities;

        public Form1()
        {
            InitializeComponent();
            Cities = new List<string>();
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            ReadDistanceMatrix();

            tree = new Tree(new TreeNode(matrix));

            TreeForm solutionForm = new TreeForm(tree.Way, tree.M);
            solutionForm.Show();
        }

        public void GenerateFieldsForMatrix()
        {
            if (tableLayoutPanel1 != null)
                tableLayoutPanel1.Dispose();

            tableLayoutPanel1 = new TableLayoutPanel
            {
                ColumnCount = dimension,
                RowCount = dimension,
                Location = new Point(100, 100),
                Name = "tableLayoutPanel1",
                Size = new Size(40 * dimension, 40 * dimension),
                Margin = new Padding(0, 0, 0, 50),
                TabIndex = 4
            };

            float widthInPercent = (float)100 / dimension;
            float heightInPercent = (float)100 / dimension;

            for (int i = 0; i < dimension; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, widthInPercent));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, heightInPercent));
            }

            fieldsForMatrix = new Control[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        if (i == 0)
                        {
                            fieldsForMatrix[i, j] = new Label
                            {
                                Dock = DockStyle.Fill,
                                Name = "textBox" + i * dimension + j,
                                TabIndex = i * dimension + j,
                                TextAlign = ContentAlignment.BottomCenter,
                                Font = new Font("Microsoft Sans Serif", 12F),
                                Text = Cities[j]
                            };

                            if (cityNameCheckBox.Checked)
                            {
                                fieldsForMatrix[i, j].Font = new Font("Microsoft Sans Serif", 8F);
                            }
                        }
                        else if (j == 0)
                        {
                            fieldsForMatrix[i, j] = new Label
                            {
                                Dock = DockStyle.Fill,
                                Name = "textBox" + i * dimension + j,
                                TabIndex = i * dimension + j,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Font = new Font("Microsoft Sans Serif", 12F),
                                Text = Cities[i]
                            };

                            if (cityNameCheckBox.Checked)
                            {
                                fieldsForMatrix[i, j].Font = new Font("Microsoft Sans Serif", 8F);
                            }
                        }
                        else
                        {

                            fieldsForMatrix[i, j] = new TextBox
                            {
                                Dock = DockStyle.Fill,
                                TabIndex = i * dimension + j,
                                Name = "textBox" + i * dimension + j,
                                TextAlign = HorizontalAlignment.Center,
                                Multiline = true,
                                Font = new Font("Microsoft Sans Serif", 16F)
                            };

                            if (i == j)
                            {
                                fieldsForMatrix[i, j].Text = double.PositiveInfinity.ToString();
                                fieldsForMatrix[i, j].Enabled = false;
                            }
                        }

                        tableLayoutPanel1.Controls.Add(fieldsForMatrix[i, j], j, i);
                    }
                }
            }

            Controls.Add(tableLayoutPanel1);
        }

        public void ReadDistanceMatrix()
        {
            matrix = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 1; i < dimension; i++)
            {
                matrix[Cities[i]] = new Dictionary<string, double>();

                for (int j = 1; j < dimension; j++)
                {
                    if (fieldsForMatrix[i, j].GetType() == typeof(TextBox))
                    {
                        matrix[Cities[i]][Cities[j]] = Convert.ToDouble(fieldsForMatrix[i, j].Text);
                    }
                }
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = cityNameCheckBox.Checked;
            dimension = Convert.ToInt32(citiesNumberUpDown.Value + 1);

            if (cityNameCheckBox.Checked == false)
            {
                Cities.Clear();

                for (int i = 0; i < dimension; i++)
                    Cities.Add(i.ToString());

                calcBtn.Visible = true;
                GenerateFieldsForMatrix();
            }
            else if (Cities.Count == dimension - 1)
            {
                Cities.Insert(0, null);
                panel1.Visible = false;
                calcBtn.Visible = true;

                GenerateFieldsForMatrix();
            }
        }

        private void nextCityNameBtn_Click(object sender, EventArgs e)
        {
            Cities.Add(cityNameBox.Text);
            cityNameBox.Text = string.Empty;

            nextBtn.PerformClick();
        }

        private void citiesNumberUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                nextBtn.PerformClick();
        }

        private void cityNameBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                nextCityNameBtn.PerformClick();
        }
    }
}
