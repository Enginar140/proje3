using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje3
{
    internal class BinaryTree
    {
        public TreeNode Root;
        public int totalDepth = 0;

        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(EgeDeniziB fish)
        {
            if (Root == null)
            {
                Root = new TreeNode(fish.balik_Adi, fish.bilgi);
            }
            else
            {
                Insert(Root, fish);
            }
        }

        private void Insert(TreeNode node, EgeDeniziB fish)
        {
            if (string.Compare(fish.balik_Adi, node.Name) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode(fish.balik_Adi, fish.bilgi);
                }
                else
                {
                    Insert(node.Left, fish);
                }
            }
            else if (string.Compare(fish.balik_Adi, node.Name) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode(fish.balik_Adi, fish.bilgi);
                }
                else
                {
                    Insert(node.Right, fish);
                }
            }
        }

        // In-order traversal ile ağacı yazdırma
        public void PrintTree()
        {
            PrintTree(Root);
        }

        private void PrintTree(TreeNode node)
        {
            if (node != null)
            {
                // Sol alt ağacı yazdır
                PrintTree(node.Left);

                // Balık ismini yazdır
                Console.WriteLine($"Balık Adı: {node.Name}");

                // Alt ağacı (kelimeleri) yazdır
                Console.WriteLine("Bilgi Metni Kelimeleri:");
                node.InfoTree.PrintSubTree(node.InfoTree.Root);

                // Alt ağacın detaylarını yazdır
                int subTreeNodeCount = node.InfoTree.GetNodeCount();
                int subTreeDepth = node.InfoTree.GetDepth();
                int subTreeBalancedDepth = node.InfoTree.GetBalancedTreeDepth();

                Console.WriteLine($"Alt Ağacın Düğüm Sayısı: {subTreeNodeCount}");
                Console.WriteLine($"Alt Ağacın Gerçek Derinliği: {subTreeDepth}");
                Console.WriteLine($"Dengeli Bir Alt Ağacın Derinliği: {subTreeBalancedDepth}");

                // Sağ alt ağacı yazdır
                PrintTree(node.Right);
            }
        }


        // Ana ağacın derinliğini hesaplar
        public int GetDepth()
        {
            return GetDepth(Root);
        }

        private int GetDepth(TreeNode node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(GetDepth(node.Left), GetDepth(node.Right));
        }

        // Düğüm sayısını hesaplayan metot
        public int GetNodeCount()
        {
            return CountNodes(Root);
        }

        private int CountNodes(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }

        // Dengeli bir ağaç olması durumunda derinliği hesaplayan metot
        public int GetBalancedTreeDepth()
        {
            int nodeCount = GetNodeCount();
            return (int)Math.Ceiling(Math.Log2(nodeCount + 1));
        }

        // Tüm alt ağaçların ortalama derinliğini hesaplayan metot
        public double GetAverageDepthOfAllSubTrees()
        {
            double totalAverageDepth = 0;
            int fishCount = 0;
            CalculateAverageDepth(Root, ref totalAverageDepth, ref fishCount);
            return fishCount == 0 ? 0 : totalAverageDepth / fishCount;
        }

        private void CalculateAverageDepth(TreeNode node, ref double totalAverageDepth, ref int fishCount)
        {
            if (node != null)
            {
                totalAverageDepth += node.InfoTree.GetAverageDepth();
                fishCount++;
                CalculateAverageDepth(node.Left, ref totalAverageDepth, ref fishCount);
                CalculateAverageDepth(node.Right, ref totalAverageDepth, ref fishCount);
            }
        }
    }
}
