using System;

namespace BinaryTree
{
    /// <summary>
    /// Defines a generic binary tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class BinaryTree<T>
        where T : IComparable, IComparable<T>
    {
        /// <summary>
        /// Reference to a root node of the binary-tree.
        /// </summary>
        public BinaryTreeNode<T> RootNode { get; set; }

        /// <summary>
        /// Adds a node into a specific subtree.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, T data)
        {
            if (RootNode == null)
                return RootNode = node;

            ////if (node != null) return new BinaryTreeNode<T>(data);
            if (data.CompareTo(node.Data) <= -1)
                node.LeftNode = Add(node.LeftNode, data);
            else
                node.RightNode = Add(node.RightNode, data);

            return node.Balance();
        }

        /// <summary>
        /// Adds data to a whole binary tree (from the root).
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> Add(T data)
        {
            if (RootNode != null)
                return Add(RootNode, data);
            else
                return Add(new BinaryTreeNode<T>(data), data);
        }

        /// <summary>
        /// Finds the minimum node in a specific subtree.
        /// </summary>
        /// <param name="subtreeRoot"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> FindMinNode(BinaryTreeNode<T> subtreeRoot)
        {
            return (subtreeRoot.LeftNode != null) 
                ? FindMinNode(subtreeRoot.LeftNode) 
                : subtreeRoot;
        }

        private BinaryTreeNode<T> RemoveMinNode(BinaryTreeNode<T> node)
        {
            if (node.LeftNode == null)
                return node.RightNode;

            node.LeftNode = RemoveMinNode(node.LeftNode);
            return node.Balance();
        }

        /// <summary>
        /// Removes a node with specified data from
        /// a parameter subtree.
        /// </summary>
        /// <param name="subtreeRoot"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> Remove(BinaryTreeNode<T> subtreeRoot, T data)
        {
            if (subtreeRoot == null) return null;

            if (data.CompareTo(subtreeRoot.Data) <= -1)
                subtreeRoot.LeftNode = Remove(subtreeRoot.LeftNode, data);
            else if (data.CompareTo(subtreeRoot.Data) >= 1)
                subtreeRoot.RightNode = Remove(subtreeRoot.RightNode, data);
            // Data equality. 
            else
            {
                var left = subtreeRoot.LeftNode;
                var right = subtreeRoot.RightNode;
                // Null to subtree.
                subtreeRoot = null;

                if (right == null) return right;
                var min = FindMinNode(right);
                min.RightNode = RemoveMinNode(right);
                min.LeftNode = left;
                return min.Balance();
            }

            return subtreeRoot.Balance();
        }

        ///// <summary>
        ///// Adds data into the binary-tree.
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public BinaryTreeNode<T> Add(T data)
        //{
        //    return Add(new BinaryTreeNode<T>(data));
        //}

        ///// <summary>
        ///// Adds a new node to the binary-tree.
        ///// </summary>
        ///// <param name="node"></param>
        ///// <param name="currentNode"></param>
        ///// <returns></returns>
        //public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        //{
        //    if (RootNode == null)
        //    {
        //        node.ParentNode = null;
        //        return RootNode = node;
        //    }

        //    // Current node (from which we start) here is 
        //    // a potential pointer to THIS node as a parent.
        //    currentNode = currentNode ?? RootNode;
        //    node.ParentNode = currentNode;

        //    var result = node.Data.CompareTo(currentNode.Data);
        //    if (result == 0)
        //    {
        //        return currentNode;
        //    }
        //    else
        //    {
        //        if (result < 0)
        //        {
        //            if (currentNode.LeftNode == null)
        //                return currentNode.LeftNode = node;
        //            else
        //                return Add(node, currentNode.LeftNode);
        //        }
        //        else
        //        {
        //            if (currentNode.RightNode == null)
        //                return currentNode.RightNode = node;
        //            else
        //                return Add(node, currentNode.RightNode);
        //        }
        //    }
        //}
    }
}
