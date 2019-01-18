using System;

   class Program
    {
        const int INF = 99999;
        // Driver Code 
    public static void Main(string[] args) 
    { 
		int source,destination;
		int [,] pathAdjMatrix=new int[10,10];
        int [,] graph =new int [,]
	  {
		{0,1,2,INF,INF,INF,INF,INF,INF,INF},
		{1,0,INF,INF,3,INF,INF,INF,INF,INF},
		{2,INF,0,1,INF,INF,INF,INF,INF,INF},
		{INF,INF,1,0,INF,2,INF,8,INF,INF},
		{INF,3,INF,INF,0,1,4,INF,INF,INF},
		{INF,INF,INF,2,1,0,INF,INF,INF,INF},
		{INF,INF,INF,INF,4,INF,0,3,1,INF},
		{INF,INF,INF,8,INF,INF,3,0,INF,2},
		{INF,INF,INF,INF,INF,INF,1,INF,0,3},
		{INF,INF,INF,INF,INF,INF,INF,2,3,0}
	  };
		Console.WriteLine("Enter the starting city:");
		source=int.Parse(Console.ReadLine());
		Console.WriteLine("Enter the destination city:");
	    destination=int.Parse(Console.ReadLine());
	     
        AllPairShortestPath path = new AllPairShortestPath(); 
  
        int [,] resultantweightedGraph = path.FindShortestPath(pathAdjMatrix,graph);
         Console.Write(("The Shortest path is "));
		 path.Display(path.GetPathConstruct(pathAdjMatrix,source,destination));
		 Console.WriteLine(" with total distance of " +resultantweightedGraph[source,destination]);
	     Console.ReadLine();
    }
}