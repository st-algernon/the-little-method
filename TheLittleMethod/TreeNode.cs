using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheLittleMethod
{
    public class TreeNode
    {
        public TreeNode(Dictionary<string, Dictionary<string, double>> data, TreeNode parentNode = null)
        {
            Matrix = new Dictionary<string, Dictionary<string, double>>(data);
            ParentNode = parentNode;
            ConsolidatedMatrix = GetConsolidatedMatrix(data);
            Rating = GetRating();
        }

        public Dictionary<string, Dictionary<string, double>> Matrix { get; set; }
        public Dictionary<string, Dictionary<string, double>> ConsolidatedMatrix { get; set; }
        public double Rating { get; set; }
        public double[] h { get; set; }
        public double[] q { get; set; }
        public Dictionary<string, Dictionary<string, double>> Theta { get; set; }
        public string[] Pair { get; set; }
        public List<string> Way { get; set; }
        public bool IsProbed { get; set; }
        public TreeNode LeftNode { get; set; }

        public TreeNode RightNode { get; set; }

        public TreeNode ParentNode { get; set; }

        public void BranchOut()
        {
            Pair = GetPairOfBranching(ConsolidatedMatrix);
            CreateLeftNode(GetFirstTypeMatrix(ConsolidatedMatrix));
            CreateRightNode(GetSecondTypeMatrix(ConsolidatedMatrix));
        }

        private void CreateLeftNode(Dictionary<string, Dictionary<string, double>> data)
        {
            TreeNode leftNode = new TreeNode(data, this);
            LeftNode = leftNode;
        }

        private void CreateRightNode(Dictionary<string, Dictionary<string, double>> data)
        {
            TreeNode rightNode = new TreeNode(data, this);
            RightNode = rightNode;
        }

        /// <summary>
        /// Отримати мінімальні значення по рядках
        /// </summary>
        /// <param name="matrix">Матриця дистанцій</param>
        /// <returns>Масив мінімальних значень</returns>
        private double[] GetMinValuesByRows(Dictionary<string, Dictionary<string, double>> matrix)
        {
            double[] min = new double[matrix.Count];
            int i = 0;

            foreach (var row in matrix)
            {
                min[i] = row.Value.Values.Min();
                i++;
            }

            return min;
        }

        /// <summary>
        /// Отримати інвертовану матрицю
        /// </summary>
        /// <param name="matrix">Початкова матриця</param>
        /// <returns>Інвертована матриця</returns>
        private Dictionary<string, Dictionary<string, double>> GetInvMatrix(Dictionary<string, Dictionary<string, double>> matrix)
        {
            double[][] invMatrix = new double[matrix.Count][];
            double[][] _matrix = ToDouble2D(matrix);

            for (int i = 0; i < _matrix.Length; i++)
            {
                invMatrix[i] = new double[_matrix[i].Length];

                for (int j = 0; j < _matrix[i].Length; j++)
                    invMatrix[i][j] = _matrix[j][i];
            }

            return ToDictionary2D(invMatrix, matrix.First().Value.Keys.ToArray(), matrix.Keys.ToArray());
        }

        private double[][] ToDouble2D(Dictionary<string, Dictionary<string, double>> matrix)
        {
            double[][] _matrix = new double[matrix.Count][];
            int i = 0, j = 0;

            foreach (var row in matrix)
            {
                _matrix[i] = new double[row.Value.Count];

                foreach (var col in row.Value)
                {
                    _matrix[i][j] = matrix[row.Key][col.Key];
                     j++;
                }

                j = 0;
                i++;
            }

            return _matrix;
        }

        private Dictionary<string, Dictionary<string, double>> ToDictionary2D(double[][] matrix, string[] rowKeys, string[] colKeys)
        {
            Dictionary<string, Dictionary<string, double>> _matrix = new Dictionary<string, Dictionary<string, double>>();
            int i = 0, j = 0;

            foreach (var row in rowKeys)
            {
                _matrix[row] = new Dictionary<string, double>();

                foreach (var col in colKeys)
                {
                    _matrix[row][col] = matrix[i][j];
                    j++;
                }

                j = 0;
                i++;
            }

            return _matrix;
        }

        /// <summary>
        /// Звестри матрицю
        /// </summary>
        /// <param name="matrix">Початкова матриця</param>
        /// <returns>Зведена матриця</returns>
        private Dictionary<string, Dictionary<string, double>> GetConsolidatedMatrix(Dictionary<string, Dictionary<string, double>> matrix)
        {
            int i = 0;
            h = GetMinValuesByRows(matrix);
            Dictionary<string, Dictionary<string, double>> consolidatedMatrix = new Dictionary<string, Dictionary<string, double>>();

            foreach (var row in matrix)
            {
                consolidatedMatrix[row.Key] = new Dictionary<string, double>();

                foreach (var col in row.Value)
                    consolidatedMatrix[row.Key][col.Key] = matrix[row.Key][col.Key] - h[i];

                i++;
            }

            int j = 0;
            q = GetMinValuesByRows(GetInvMatrix(consolidatedMatrix));

            foreach (var row in matrix)
            {
                foreach (var col in row.Value)
                {
                    consolidatedMatrix[row.Key][col.Key] -= q[j];
                    j++;
                }

                j = 0;
            }

            return consolidatedMatrix;
        }

        /// <summary>
        /// Отримати оцінку поточної вершини
        /// </summary>
        /// <returns>Оцінка</returns>
        private double GetRating()
        {
            double d = h.Sum() + q.Sum();

            return ParentNode == null ? d : ParentNode.Rating + d;
        }

        /// <summary>
        /// Для кожного нульового елемента матриці знаходимо мінімальне значення в рядку, де знаходиться нульовий елемент.
        /// Отримуємо матрицю таких мінімальний значенней.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private Dictionary<string, Dictionary<string, double>> GetPartOfTheta(Dictionary<string, Dictionary<string, double>> matrix)
        {
            Dictionary<string, Dictionary<string, double>> clone = new Dictionary<string, Dictionary<string, double>>();
            Dictionary<string, Dictionary<string, double>> partOfTheta = new Dictionary<string, Dictionary<string, double>>();

            foreach (var row in matrix)
            {
                partOfTheta[row.Key] = new Dictionary<string, double>();
                clone[row.Key] = new Dictionary<string, double>(matrix[row.Key]);

                foreach (var col in row.Value) {
                    if (matrix[row.Key][col.Key] == 0)
                    {
                        clone[row.Key][col.Key] = double.PositiveInfinity;
                        partOfTheta[row.Key][col.Key] = clone[row.Key].Values.Min();
                        clone[row.Key][col.Key] = 0;
                    }
                    else
                    {
                        partOfTheta[row.Key][col.Key] = double.NegativeInfinity;
                    }
                }
            }

            return partOfTheta;
        }
        
        /// <summary>
        /// Отримуємо пару, що ініціює розгалуження.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private string[] GetPairOfBranching(Dictionary<string, Dictionary<string, double>> matrix)
        {
            Dictionary<string, Dictionary<string, double>> theta1 = GetPartOfTheta(matrix);
            Dictionary<string, Dictionary<string, double>> theta2 = GetInvMatrix(GetPartOfTheta(GetInvMatrix(matrix)));
            Dictionary<string, Dictionary<string, double>> theta = new Dictionary<string, Dictionary<string, double>>();

            double max = double.NegativeInfinity;
            string[] pair = new string[2];

            foreach (var row in matrix)
            {
                theta[row.Key] = new Dictionary<string, double>();

                foreach (var col in row.Value)
                {
                    theta[row.Key][col.Key] = theta1[row.Key][col.Key] + theta2[row.Key][col.Key];
                }

                if (max < theta[row.Key].Values.Max())
                {
                    max = theta[row.Key].Values.Max();
                    pair[0] = row.Key;
                    pair[1] = theta[row.Key].FirstOrDefault(x => x.Value == max).Key;
                }
            }

            Theta = theta;

            return pair;
        }

        private Dictionary<string, Dictionary<string, double>> GetFirstTypeMatrix(Dictionary<string, Dictionary<string, double>> matrix)
        {
            Dictionary<string, Dictionary<string, double>> tempMatrix = new Dictionary<string, Dictionary<string, double>>();
            Dictionary<string, Dictionary<string, double>> firstTypeMatrix = new Dictionary<string, Dictionary<string, double>>();
          
            foreach (var row in matrix)
            {
                Dictionary<string, double> firstTypeRow = new Dictionary<string, double>();

                foreach (var col in row.Value)
                {
                    if (col.Key != Pair[1])
                    {
                        firstTypeRow[col.Key] = matrix[row.Key][col.Key];
                    }
                }

                if (row.Key != Pair[0])
                {
                    firstTypeMatrix[row.Key] = firstTypeRow;
                }
            }

            string[] pairFormingSubcycle = GetPairsFormingSubcycle();
            firstTypeMatrix[pairFormingSubcycle[0]][pairFormingSubcycle[1]] = double.PositiveInfinity;

            return firstTypeMatrix;
        }

        /// <summary>
        /// Отримати пару міст, що утворюють підцикл
        /// </summary>
        /// <param name="way">Шлях</param>
        /// <returns>Пара міст</returns>
        private string[] GetPairsFormingSubcycle()
        {
            List<string[]> pairs = new List<string[]>();
            List<string> way = new List<string>();

            pairs = GetAllThePairs(this, pairs);
            way = GetOrderlyWay(pairs);

            string[] pair = new string[2];

            pair[0] = way.Last();
            pair[1] = way.First();

            return pair;
        }

        /// <summary>
        /// Отримати всі пари, що ініціювали розгалуження
        /// </summary>
        /// <param name="node">Вершина</param>
        /// <param name="pairs">Масив, в який записуються пари</param>
        /// <returns></returns>
        public List<string[]> GetAllThePairs(TreeNode node, List<string[]> pairs)
        {
            if (node.ParentNode != null)
            {
                GetAllThePairs(node.ParentNode, pairs);

                if (node.Pair != null)
                {
                    pairs.Add(node.Pair);
                }

            }

            if (node.ParentNode == null)
            {
                pairs.Add(node.Pair);
            }

            return pairs;
        }

        /// <summary>
        /// Отримати впорядкований шлях
        /// </summary>
        /// <param name="pairs">Масив пар, що ініціювали розгалуження</param>
        /// <returns>Впорядкований шлях</returns>
        public List<string> GetOrderlyWay(List<string[]> pairs)
        {
            List<string> way = new List<string>();
            List<string> wayFrom = new List<string>();
            List<string> wayTo = new List<string>();

            From(wayFrom, pairs, pairs[0][0]);
            To(wayTo, pairs, pairs[0][0]);

            wayFrom.RemoveAt(0);
            wayTo.Reverse();

            way.AddRange(wayTo);
            way.AddRange(wayFrom);

            Way = new List<string>(way);

            return way;
        }

        /// <summary>
        /// Відшукує маршрут, що починається з заданого міста
        /// </summary>
        /// <param name="way">Маршрут, що йде починається з заданого міста</param>
        /// <param name="pairs">Масив пар, що ініціювали розгалуження</param>
        /// <param name="city">Місто</param>
        private void From(List<string> way, List<string[]> pairs, string city)
        {
            way.Add(city);

            for (int j = 0; j < pairs.Count; j++)
            {
                if (city == pairs[j][0])
                {
                    From(way, pairs, pairs[j][1]);
                }
            }
        }

        /// <summary>
        /// Відшукує маршрут, що приведе до заданого міста
        /// </summary>
        /// <param name="way">Маршрут, що веде до заданого міста</param>
        /// <param name="pairs">Масив пар, що ініціювали розгалуження</param>
        /// <param name="city">Місто</param>
        private void To(List<string> way, List<string[]> pairs, string city)
        {
            way.Add(city);

            for (int j = 0; j < pairs.Count; j++)
            {
                if (city == pairs[j][1])
                {
                    To(way, pairs, pairs[j][0]);
                }
            }
        }

        private Dictionary<string, Dictionary<string, double>> GetSecondTypeMatrix(Dictionary<string, Dictionary<string, double>> matrix)
        {
            Dictionary<string, Dictionary<string, double>> secondTypeMatrix = new Dictionary<string, Dictionary<string, double>>(matrix);

            secondTypeMatrix[Pair[0]][Pair[1]] = double.PositiveInfinity;

            return secondTypeMatrix;
        }
    }
}
