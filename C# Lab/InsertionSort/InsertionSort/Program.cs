//
//  Program.cs
//  InsertionSort
//
//  Created by Nicholas Weg on 2/6/17.
//  Copyright © 2017 Nicholas Weg. All rights reserved.
//

using System;
using System.Collections.Generic;

namespace InsertionSort
{
	class MainClass
	{
		static void print(int[] A, int size)
		{
			Console.Write(A[0]);
			for (int i = 1; i < size; i++)
			{
				Console.Write(", " + A[i]);
			}
			Console.WriteLine("\n");
		}

		public static void Main()
		{
			int[] A = { 5, 7, 2, 3, 6, 0, 9, 1, 8, 4 };
			int size = 10;

			Console.Write("\nINITIAL ARRAY\n");
			print(A, size);

			for (int i = 0; i < size; i++)
			{
				int pos = i;
				int value = A[pos];
				while (pos > 0 && value < A[pos - 1])
				{
					A[pos] = A[pos - 1];
					pos--;
				}
				A[pos] = value;

				Console.Write("Move the value " + A[pos] + " into place : ");
				print(A, size);
			}
			Console.Write("\nSORTED ARRAY\n");
			print(A, size);
		}
	}
}