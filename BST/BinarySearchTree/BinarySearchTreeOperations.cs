using System;
public class BinarySearchTreeOperations
    {
        public Node  root;
        
        public BinarySearchTreeOperations()
        {
            root = null;
        }
        /// <summary>
        /// To get root of the tree.  
        /// </summary>
        /// <returns>Node</returns>
        public Node GetRoot()
        {
            return root;
        }
        /// <summary>
        /// To process the input string to be inserted for binary search tree
        /// </summary>
        /// <param name="nodedata"></param>
        public void Insert(string nodedata)
        {
          string [] data  =nodedata.Split(';');
          foreach(string item in data)
          {
              InsertNode(int.Parse(item));
          }
        }
        /// <summary>
        /// represents insertion of node to the binary search tree.
        /// </summary>
        /// <param name="id"></param>
        private void InsertNode(int id)
        {
            Node newNode = new Node();
            newNode.Data = id;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (id < current.Data)
                    {
                        current = current.LeftNode;
                        if (current == null)
                        {
                            parent.LeftNode = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.RightNode;
                        if (current == null)
                        {
                            parent.RightNode = newNode;
                            return;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// To represent traversing of binary search tree in ascending order.
        /// </summary>
        /// <param name="rootNode"></param>
        public void Inorder(Node rootNode)
        {
            if (rootNode != null)
            {
                Inorder(rootNode.LeftNode);
                Console.Write(rootNode.Data + " ");
                Inorder(rootNode.RightNode);
            }
        }
         /// <summary>
         /// To represent traversing binary search tree in descending order.
         /// </summary>
         /// <param name="rootNode"></param>
        public void DescendingOrder(Node rootNode)
        {
            if (rootNode != null)
            {
                DescendingOrder(rootNode.RightNode);
                Console.Write(rootNode.Data + " ");
                DescendingOrder(rootNode.LeftNode);
            }
        }
        /// <summary>
        /// To represent the search functionality for a given key to be searched.
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node SearchNode(Node rootNode,int key)
       {
         Node currentNode =rootNode;
         if(rootNode!=null)
         {
           if(currentNode.Data==key)
           {
               return currentNode;
           }
           else if(currentNode.Data>key)
           {
              SearchNode(currentNode.LeftNode,key);
           }
           else if(currentNode.Data<key)
           {
              SearchNode(currentNode.RightNode,key);
           }
       }
       return null; 
    }
    /// <summary>
    /// To display the traversals of binary search tree. 
    /// </summary>
    /// <param name="node"></param>
    public void Display(Node node)
    {
        Console.WriteLine("Inorder Traversal : (Ascending Order of nodes in  Tree)");
        Inorder(node);
        Console.WriteLine("\n");
        Console.WriteLine("Descending Order of nodes in Tree : ");
        DescendingOrder(node);
    }

}
    