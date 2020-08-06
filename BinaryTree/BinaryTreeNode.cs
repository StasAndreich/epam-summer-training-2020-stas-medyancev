using System;

namespace BinaryTree
{
    /// <summary>
    /// Defines a generic binary tree node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T> where T : IComparable
    {
        /// <summary>
        /// Default ctor that inits a tree node.
        /// </summary>
        /// <param name="data"></param>
        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Node's data.
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Reference to a left node.
        /// </summary>
        public BinaryTreeNode<T> LeftNode { get; set; }
        /// <summary>
        /// Reference to a right node.
        /// </summary>
        public BinaryTreeNode<T> RightNode { get; set; }
        /// <summary>
        /// Reference to a parent node.
        /// </summary>
        public BinaryTreeNode<T> ParentNode { get; set; }

        /// <summary>
        /// Returns the location of a node relatively to the parent node.
        /// </summary>
        public Side? NodeSide
        {
            get
            {
                if (ParentNode == null)
                {
                    return null;
                }
                else
                {
                    if (ParentNode.LeftNode == this)
                        return Side.Left;
                    else
                        return Side.Right;
                }
            }
        }

        /// <summary>
        /// Returns a result of ToString() of the node data.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Data.ToString();

        /// <summary>
        /// Check the equality of this tree node
        /// instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var node = (BinaryTreeNode<T>)obj;

            return this.Data.Equals(node.Data);
        }

        /// <summary>
        /// Returns a hash-code for a tree node object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }
    }
}
