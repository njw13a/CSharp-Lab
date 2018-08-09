using System;
using System.Diagnostics;

namespace BinaryTree
{
	class Node<T>
	{
		public T data;
		public Node<T> left;
		public Node<T> right;

		public Node(T newData)
		{
			this.data = newData;
			left = null;
			right = null;
		}
		//public void destroy() { if (n == null) return; destroy(left); destroy(right); delete n; }

		public int height()
		{
			int l = 0, r = 0;

			if (left != null)
				l = 1 + left.height();
			if (right != null)
				r = 1 + right.height();

			if (l > r)
				return l;
			else
				return r;
		}

	}

	class Tree<T> where T : IComparable<T>
	{
		Node<T> root;
		public int count = 0;

		public Tree() {root = null;}

		public void initialize() {root = null;}
		//public void destroy() { root.destroy(); root = null; }
		public void insert(T value)
		{
			count++;
			Node<T> newNode = new Node<T>(value);

			if (root == null)
			{ // empty tree
				root = newNode;
				return;
			}

			Node<T> walker = root;
			while (true)
			{
				if (walker.data.CompareTo(value) > 0)
				{
					if (walker.left == null)
					{
						walker.left = newNode;
						return;
					}
					else
						walker = walker.left;
				}
				else // walker->data < value
				{
					if (walker.right == null)
					{
						walker.right = newNode;
						return;
					}
					else
						walker = walker.right;
				}
			}
		}

		public int countNodes(){return count;}

		public int contains(T value)
		{
			Node<T> walker = root;
			int depth = 0;

			while (walker != null)
			{
				if (walker.data.CompareTo(value) == 0)
					return depth;
				else if (walker.data.CompareTo(value) > 0)
					walker = walker.left;
				else // walker->data < value
					walker = walker.right;
				depth++;
			}
			return -1;
		}

		public int height()
		{
			return root.height();
		}

		public T minValue()
		{
			Node<T> min = root;
			while (min.left != null)
				min = min.left;
			return min.data;
		}

		public T maxValue()
		{
			Node<T> max = root;
			while (max.right != null)
				max = max.right;
			return max.data;
		}
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			char D = 'D', L = 'L', R = 'R', W = 'W', Y = 'Y';
			Tree<char> tree = new Tree<char>();
			//T.initialize();
			tree.insert(L);
			tree.insert(D);
			tree.insert(W);
			tree.insert(Y);
			tree.insert(R);
			Console.WriteLine(tree.countNodes());
			Console.WriteLine(tree.height());
			Console.WriteLine(tree.contains(L));
			Console.WriteLine(tree.contains(Y));
			Console.WriteLine(tree.minValue());
			Console.WriteLine(tree.maxValue());
			Debug.Assert(tree.countNodes() == 5);

		}
	}
}
