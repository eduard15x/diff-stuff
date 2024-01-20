namespace TeddySmithCourse
{
    internal class TreeNodeTraversal
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public TreeNodeTraversal Child { get; set; }
        public TreeNodeTraversal LeftChild { get; set; }
        public TreeNodeTraversal RightChild { get; set; }

        public TreeNodeTraversal(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}