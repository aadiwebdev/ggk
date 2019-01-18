using System;
using System.Collections.Generic;
public class AllPairShortestPath 
{ 
    const int INF = 99999, noOfVertices = 10; 
  /// <summary>
  /// To represent the Floyd Warshall's all pair shorest path algorithm.
  /// </summary>
  /// <param name="["></param>
  /// <param name="next"></param>
  /// <param name="graph"></param>
  /// <returns></returns>
    public int[,] FindShortestPath(int [,] pathAdjMatrix , int[,] graph) 
    { 
        int[,] costAdjMatrix = new int[noOfVertices, noOfVertices];
        int i, j, k; 
    
		for (i = 0; i < noOfVertices; i++) 
        { 
            for (j = 0; j < noOfVertices; j++)
            { 
                costAdjMatrix[i, j] = graph[i, j];
				pathAdjMatrix[i,j] = j;
            } 
        } 
  
		for (k = 0; k < noOfVertices; k++) 
        { 
            for (i = 0; i < noOfVertices; i++) 
            { 
                for (j = 0; j < noOfVertices; j++) 
                { 
                    if (costAdjMatrix[i, k] + costAdjMatrix[k, j] < costAdjMatrix[i, j])  
                    { 
                        costAdjMatrix[i, j] = costAdjMatrix[i, k] + costAdjMatrix[k, j];
						pathAdjMatrix[i,j]=pathAdjMatrix[i,k];
                    }
					
                } 
            } 
        }		
		return costAdjMatrix;
      }

  /// <summary>
  /// To diplay the shorest path from the source to destination
  /// </summary>
  /// <param name="path"></param>
  
    public void Display(List<int> path) 
    { 
		int currentNode;
        for(currentNode=0;currentNode<path.Count-1;currentNode++) 
        { 
             Console.Write(path[currentNode]+"-->");            
        } 
		Console.Write(path[currentNode]);
    }

/// <summary>
/// To construct the path adjacent matrix  in order to get the intermediate cities to be visited.
/// </summary>
/// <param name="["></param>
/// <param name="pathAdjMatrix"></param>
/// <param name="source"></param>
/// <param name="destination"></param>
/// <returns></returns>
 
	public List<int> GetPathConstruct(int [,] pathAdjMatrix ,int source,int destination)
	{
		int temp=0;
		List<int> path = new List<int>();
		if(source>destination)
		{
		  temp=source;
		  source=destination;
	      destination=temp;		 
		}
	   if(pathAdjMatrix[source,destination]==0)
	   {
	     return path;
	   }
		 path.Add(source);
		while(source!=destination)
		{
		  source =pathAdjMatrix[source,destination];
		  path.Add(source);	
		}
		
		if(temp!=0)
		{
		   path.Reverse();
		   return path;
		}
			return path;
	}
}