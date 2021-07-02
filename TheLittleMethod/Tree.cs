using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheLittleMethod
{
    public class Tree
    {
        public TreeNode RootNode { get; set; }
        public double M = double.PositiveInfinity;
        public List<string> Way { get; set; }
        public Tree(TreeNode rootNode)
        {
            RootNode = rootNode;
            Way = new List<string>();
            ToAnalyze();
        }

        public void ToAnalyze()
        {
            TreeNode nodeForBranching = GetNodeForBranching();
            nodeForBranching.BranchOut();
            
            TreeNode leftNode = nodeForBranching.LeftNode;

            if (leftNode.Matrix.Count == 2)
            {
                M = leftNode.Rating;
                Way = GetWay(leftNode);

                ProbeNodes(RootNode);
            }
            else {
                ToAnalyze();
            }
        }

        public List<string> GetWay(TreeNode node)
        {
            List<string[]> pairs = new List<string[]>();
            List<string> way = new List<string>();

            node.GetAllThePairs(node, pairs);
            pairs.Add(new string[2] { node.Matrix.First().Key, node.Matrix.First().Value.Keys.Last() });
            pairs.Add(new string[2] { node.Matrix.Last().Key, node.Matrix.Last().Value.Keys.First() });

            OrderlyWay(way, pairs, pairs[0][0]);

            return way;
        }
       
        public void OrderlyWay(List<string> way, List<string[]> pairs, string city)
        {
            way.Add(city);

            for (int j = 0; j < pairs.Count; j++)
            {
                if (city == pairs[j][0])
                {
                    if (way.Count <= pairs.Count)
                        OrderlyWay(way, pairs, pairs[j][1]);
                }
            }
        }

        public TreeNode GetNodeForBranching()
        {
            List<TreeNode> handingNodes = new List<TreeNode>();
            double min = double.PositiveInfinity;
            TreeNode nodeForBranching = null;

            FindHandingNodes(RootNode, handingNodes);

            foreach(var node in handingNodes)
            {
                if (node.Rating < min)
                {
                    min = node.Rating;
                    nodeForBranching = node;
                } else if (node.Rating == min) {
                    if (nodeForBranching.Matrix.Count > node.Matrix.Count)
                        nodeForBranching = node;
                }
            }

            return nodeForBranching;
        }

        /// <summary>
        /// Знайти всі вісячі вершини і записати їх в handingNodes
        /// </summary>
        /// <param name="node">Вершина з якої починається обхід дерева</param>
        /// <param name="handingNodes">Вихідний масив</param>
        private void FindHandingNodes(TreeNode node, List<TreeNode> handingNodes)
        {
            if (node != null)
            {
                if (node.LeftNode == null && node.RightNode == null)
                   handingNodes.Add(node); // запомнить текущее значение

                FindHandingNodes(node.LeftNode, handingNodes); // обойти левое поддерево

                FindHandingNodes(node.RightNode, handingNodes); // обойти правое поддерево
            }
        }

        /// <summary>
        /// Прозондувати вершини, оцінки яких більше дорівнюють рекорду
        /// </summary>
        /// <param name="node">Вершина з якої починається обхід дерева</param>
        private void ProbeNodes(TreeNode node)
        {
            if (node != null)
            {
                if (node.LeftNode == null && node.RightNode == null)
                {
                    if (node.Rating >= M)
                        node.IsProbed = true;

                    ProbeNodes(node.LeftNode);

                    ProbeNodes(node.RightNode);
                }
            }
        }
    }
}
