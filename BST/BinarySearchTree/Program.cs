using System;

    enum Operations
    {
      Insert,
      Display,
      Search
    }
    class Program
    {
        public static void Main(string[] args)
        {
            string node;
            BinarySearchTreeOperations tree = new BinarySearchTreeOperations();
            int searchKey;
            Console.WriteLine("\n**********************BINARY SEARCH TREE IMPLEMENTATION IN C#*******************\n");
            while(true)
            {
                Console.WriteLine("\n 0 => Inserting data\n\n 1 => Traverse tree in all orders\n\n 2 => Search for a node using key!\n\n");
                    int choice =int.Parse(Console.ReadLine());
              switch(choice)
             {
              case (int)Operations.Insert:
                                       Console.WriteLine("\nEnter the nodes to be inserted..(semicolon seperated)\n");
                                       node=Console.ReadLine();
                                       tree.Insert(node);
                                       break;
              
              case (int)Operations.Display:
                                        Console.WriteLine("\nTraversal of Tree in Following Order\n");    
                                         tree.Display(tree.GetRoot());
                                         break;

              case (int)Operations.Search:
                                        Console.WriteLine("Enter the key to be searched..");
                                        searchKey=int.Parse(Console.ReadLine());
                                        if(tree.SearchNode(tree.GetRoot(),searchKey)!=null){
                                            Console.WriteLine("\nSearch element is found in tree...!\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nNot Found!! in the tree...\n");
                                        }
                                        break;
              default:
                       Console.WriteLine("None of your choice matched!!Try again Later!!");
                       break;                                                                                  
             }
            }
            Console.ReadLine();
        }
    }

    