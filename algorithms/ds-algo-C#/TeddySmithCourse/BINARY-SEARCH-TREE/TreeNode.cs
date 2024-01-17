namespace TeddySmithCourse
{
    internal class TreeNode
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public TreeNode Child { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public TreeNode(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}