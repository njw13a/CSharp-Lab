using System;
using System.Text;

namespace MazeSolver
{
	class MainClass
	{
		public static int findStart(string m, int s)
		{
			int start = 0;
			for (int x = 0; x < s * s; x++)
			{
				if (m[x] == 'S')
				{
					start = x;
					break;
				}
			}
			return start;
		}

		public static bool checknorth(string maze, int mazesize, int pos)
		{
			int x;
			x = pos - mazesize;
			if ((maze[x] == '.') || (maze[x] == 'F'))
				return true;
			else
				return false;
		}

		public static bool checkeast(string maze, int pos)
		{
			int x;
			x = pos + 1;
			if ((maze[x] == '.') || (maze[x] == 'F'))
				return true;
			else
				return false;
		}

		public static bool checksouth(string maze, int mazesize, int pos)
		{
			int x;
			x = pos + mazesize;
			if ((maze[x] == '.') || (maze[x] == 'F'))
				return true;
			else
				return false;
		}

		public static bool checkwest(string maze, int pos)
		{
			int x;
			x = pos - 1;
			if ((maze[x] == '.') || (maze[x] == 'F'))
				return true;
			else
				return false;
		}

		public static int choosePath(string maze, int pos, int mazesize)
		{
			int paths = 0;
			if (checknorth(maze, mazesize, pos) == true)
				paths++;
			if (checkeast(maze, pos) == true)
				paths++;
			if (checksouth(maze, mazesize, pos) == true)
				paths++;
			if (checkwest(maze, pos) == true)
				paths++;
			return paths;
		}

		public static void setCorrect(ref string maze, int mazesize)
		{
			StringBuilder sb = new StringBuilder(maze);
			for (int x = 0; x < mazesize * mazesize; x++)
			{
				if (maze[x] == '!')
					sb[x] = '#';
				if (maze[x] == 'T')
					sb[x] = 'W';
				maze = sb.ToString();
			}
		}

		public static void setWrong(ref string maze, int mazesize, ref int pos, ref string direction, ref int fork, ref bool begin)
		{
			StringBuilder sb = new StringBuilder(maze);
			for (int x = 0; x < mazesize * mazesize; x++)
			{
				if (maze[x] == 'W')
					sb[x] = '.';
				if (maze[x] == 'T')
					sb[x] = '%';
				if (maze[x] == '!')
					sb[x] = '.';
				if (maze[x] == '#')
					sb[x] = '.';
			}
			maze = sb.ToString();
			pos = findStart(maze, mazesize);
			fork = 0;
			direction = "";
			begin = false;

		}

		public static void takeStep(string maze, int mazesize, ref int pos, ref string direction)
		{
			if (checknorth(maze, mazesize, pos) == true)
			{
				//cout << "north";
				pos -= mazesize;
				direction += 'N';
				Console.WriteLine('N');
			}
			else if (checkeast(maze, pos) == true)
			{
				//cout << "east";
				pos++;
				direction += 'E';
				Console.WriteLine('E');
			}
			else if (checksouth(maze, mazesize, pos) == true)
			{
				//cout << "south";
				pos += mazesize;
				direction += 'S';
				Console.WriteLine('S');
			}
			else if (checkwest(maze, pos) == true)
			{
				//cout << "west";
				pos--;
				direction += 'W';
				Console.WriteLine('W');
			}
			else
			{
				//pos = findStart(maze, mazesize);
				//setWrong(maze, mazesize, pos,);
				//direction = "";
			}
		}

		public static void setBranch(ref string maze, ref int pos, int mazesize, ref int fork, ref string direction)
		{
			StringBuilder sb = new StringBuilder(maze);
			bool begin = true;
			if (maze[pos] == 'S')
			{
				if (choosePath(maze, pos, mazesize) > 1)
					fork += 1;
			}

			if (maze[pos] == '.')
				sb[pos] = 'T';
			maze = sb.ToString();
			if ((fork > 0) && (choosePath(maze, pos, mazesize) > 1))
				setCorrect(ref maze, mazesize);
			if ((choosePath(maze, pos, mazesize) > 1) && (maze[pos] != 'S'))
			{
				fork += 1;
				sb[pos] = '!';
				maze = sb.ToString();
			}
			if (choosePath(maze, pos, mazesize) == 0)
				setWrong(ref maze, mazesize, ref pos, ref direction, ref fork, ref begin);
			if (begin == true)
				takeStep(maze, mazesize, ref pos, ref direction);
		}

		public static void Main(string[] args)
		{
			string maze = ""; 
			int mazesize;
			string direction = "";
			string hold;
			int pos;
			int fork = 0;

			//Console.WriteLine("prompt");

			//Write the text file into a string

			//ifstream fin;
			string filename;

			filename = Console.ReadLine();
			maze = System.IO.File.ReadAllText(filename);
			mazesize = maze[0] - '0';
			/*fin.open(filename.c_str());

			if (fin.is_open())
			{
				fin >> mazesize;
				while (fin >> hold)
				{
					maze += hold;
				}
			}

			else
			{
				cout << "Unable to open file\n";
			}

			fin.close();*/

			pos = findStart(maze, mazesize);

			Console.WriteLine(maze);
			//Console.WriteLine(mazesize);
			//Console.WriteLine(pos);


			while (maze[pos] != 'F')
			{
				if ((choosePath(maze, pos, mazesize) == 0) && maze[pos] == 'S')
				{
					Console.WriteLine(maze);
					Console.Write("No path.");
					break;
				}
				setBranch(ref maze, ref pos, mazesize, ref fork, ref direction);
			}

			Console.Write(direction);
		}
	}
}
