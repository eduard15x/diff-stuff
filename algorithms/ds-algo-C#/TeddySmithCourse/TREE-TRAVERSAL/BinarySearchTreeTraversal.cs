namespace TeddySmithCourse
{
    internal class BinarySearchTreeTraversal
    // !CODE MUST BE COMPLETED WITH METHODS FROM BinarySearchTree.cs
    {
        public TreeNodeTraversal Root { get; set; } = null;

        // how to move thru trees
        // 2 ways to traverse trees
            // Breadth First -> very unknown (not used in interviews)
            // Depth First -> we work on it

        // Depth first
        // * TRAVERSAL
            // Level - visit nodes on each tree
            // Pre-Order -> visit root of each subtree first
            // Post-Order -> visit the root of each subtree last
            // In-Order -> visit left child, then root, then right child

        // * InOrder(L, Node, R)
        public void PrintInOrderTraversal()
        {
            InOrderTraversal(Root);
        }

        private void InOrderTraversal(TreeNodeTraversal node)
        {
            if (node != null)
            {
                InOrderTraversal(node.LeftChild);
                Console.WriteLine(node.Key + " " + node.Value);
                InOrderTraversal(node.RightChild);
            }
        }



        // * PreOrder(Node, L, R)
        public void PrintPreOrderTraversal()
        {
            PreOrderTraversal(Root);
        }

        private void PreOrderTraversal(TreeNodeTraversal node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Key + " " + node.Value);
                PreOrderTraversal(node.LeftChild);
                PreOrderTraversal(node.RightChild);
            }
        }



        // * PostOrder(L, R, Node)
        public void PrintPostOrderTraversal()
        {
            PostOrderTraversal(Root);
        }

        private void PostOrderTraversal(TreeNodeTraversal node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.LeftChild);
                PostOrderTraversal(node.RightChild);
                Console.WriteLine(node.Key + " " + node.Value);
            }
        }



    }
}