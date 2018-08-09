//
//  Program.cs
//  Parents
//
//  Created by Nicholas Weg on 2/10/17.
//  Copyright © 2017 Nicholas Weg. All rights reserved.
//

using System;

namespace Parents
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			string[] parent = new string[100]; 
			string[] children = new string[100];
			string parent_hold, child_hold;
			int num_children = 0, total_children = 0, that = 0;
		 	bool parentless = true;
			    
		 	Console.Write("This program prints parent-child pairs.\n");
			Console.Write("Enter parents and children below, use 'quit' to stop.\n");

			Console.Write("Parent: ");

			parent_hold = Console.ReadLine();

			while (parent_hold != "quit")
		    {
				num_children = 0;
				Console.Write("How many children does " + parent_hold + " have? ");
				num_children = Console.Read() - 48;
				Console.Write("\n");
				total_children += num_children;
				Console.Write("Children of " + parent_hold + ": \n");
				for (; that < total_children; that++)
		        {
					child_hold = Console.ReadLine();
		            parent[that] = parent_hold;
		            children[that] = child_hold;
		        }
				Console.Write("Parent: ");
				parent_hold = Console.ReadLine();
		    }



			for (int x = 0; x < total_children; x++)
		    {
		        parentless = true;
		        for (int y = 0; y < total_children; y++)
		        {
		            if (parent[x] == " ")
		                parentless = false;
		            if (parent[x] == children[y])
		                parentless = false;
		        }
		        if (parentless == true)
		        {
		            children[total_children] = parent[x];
		            parent[total_children] = " ";
		            total_children++;
		        }
		    }


			int hold;
		    string min, parent_min;
		    
		    
		    for (int x = 0; x < total_children-1; x++)
		    {
		        min = children[x];
		        parent_min = parent[x];
		        hold = x;
		        for (int y = x+1; y < total_children; y++)
		        {
					if (string.Compare(children[y], min) < 0)
		            {
		                min = children[y];
		                parent_min = parent[y];
		                hold = y;
		            }
		        }
		        children[hold] = children[x];
		        parent[hold] = parent[x];
		        children[x] = min;
		        parent[x] = parent_min;
		    }

			Console.Write("\n" + String.Format("{0,-9:D}", "Child") + "Parent\n");
			Console.Write(String.Format("{0,-9:D}","-----") + "------\n");
		    for (int y = 0; y < total_children; y++)
		    {
				Console.Write(String.Format("{0,-9:D}",children[y]) + parent[y] + "\n");
		    }

		}
	}
}