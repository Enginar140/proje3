using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje3
{
    internal class SubTree
    {
        public SubTreeNode Root;

        public SubTree()
        {
            Root = null;
        }

        public void Insert(string word)
        {
            if (Root == null)
            {
                Root = new SubTreeNode(word);
            }
            else
            {
                Insert(Root, word);
            }
        }

        private void Insert(SubTreeNode node, string word)
        {
            if (string.Compare(word, node.Word) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new SubTreeNode(word);
                }
                else
                {
                    Insert(node.Left, word);
                }
            }
            else if (string.Compare(word, node.Word) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new SubTreeNode(word);
                }
                else
                {
                    Insert(node.Right, word);
                }
            }
        }
        public void PrintSubTree(SubTreeNode node)
        {
            if (node != null)
            {
                // Sol alt ağacı yazdır
                PrintSubTree(node.Left);

                // Kelimeyi yazdır
                Console.WriteLine($"  - {node.Word}");

                // Sağ alt ağacı yazdır
                PrintSubTree(node.Right);
            }
        }
        // Alt ağacın derinliğini hesaplar
        public int GetDepth()
        {
            return GetDepth(Root);
        }

        private int GetDepth(SubTreeNode node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(GetDepth(node.Left), GetDepth(node.Right));
        }
    }
}
