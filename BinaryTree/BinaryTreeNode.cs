using System;

namespace BinaryTree
{
    /// <summary>
    /// Defines a generic binary tree node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T> 
        where T : IComparable, IComparable<T>
    {
        /// <summary>
        /// Default ctor that inits a tree node.
        /// </summary>
        /// <param name="data"></param>
        public BinaryTreeNode(T data)
        {
            this.Data = data;
            this.height = 1;
        }

        /// <summary>
        /// Subtree height.
        /// </summary>
        private int height;

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
        /// Balancing factor for the current node.
        /// </summary>
        public int BalanceFactor
        {
            get
            {
                return RightNode.height - LeftNode.height;
            }
        }
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
        /// Recalculates the height for the current node.
        /// </summary>
        public static void ReCalcHeight(BinaryTreeNode<T> node)
        {
            var hLeft = node.LeftNode.height;
            var hRight = node.RightNode.height;
            node.height = ((hLeft > hRight) ? hLeft : hRight) + 1;
        }

        /// <summary>
        /// Balance the current node.
        /// </summary>
        /// <returns></returns>
        public BinaryTreeNode<T> Balance()
        {
            ReCalcHeight(this);

            if (this.BalanceFactor == 2)
            {
                if (this.RightNode.BalanceFactor < 0)
                    this.RightNode = this.RightNode.RotateRight();
                return this.RotateLeft();
            }

            if (this.BalanceFactor == -2)
            {
                if (this.LeftNode.BalanceFactor > 0)
                    this.LeftNode = this.LeftNode.RotateLeft();
                return this.RotateRight();
            }

            // If balancing is not needed.
            return this;
        }

        /// <summary>
        /// Rotate right around the current node.
        /// </summary>
        /// <returns></returns>
        private BinaryTreeNode<T> RotateRight()
        {
            var tmpNode = this.LeftNode;
            this.LeftNode = tmpNode.RightNode;
            tmpNode.RightNode = this;

            ReCalcHeight(this);
            ReCalcHeight(tmpNode);

            return tmpNode;
        }

        /// <summary>
        /// Rotate left around the current node.
        /// </summary>
        /// <returns></returns>
        private BinaryTreeNode<T> RotateLeft()
        {
            var tmpNode = this.RightNode;
            this.RightNode = tmpNode.LeftNode;
            tmpNode.LeftNode = this;

            ReCalcHeight(this);
            ReCalcHeight(tmpNode);

            return tmpNode;
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
