// See https://aka.ms/new-console-template for more information
using System;


namespace MarsTerrain
{
    class Robot
    {
        public int x { get; set; } // Robot X Position
        public int y { get; set; } // Robot Y Position

        private int row_max;
        private int col_max;

        public string direct = "N"; // Robot direction
        string[] directs = {"N", "E", "S", "W"};

        public Robot()
        {
            x = 1;
            y = 1;
        }

        public void SetSize(string size)
        {
            var splitSize = size.Split("x");
            row_max = Int32.Parse(splitSize[0]);
            col_max = Int32.Parse(splitSize[1]);
        }

        public void RunCommand(string command)
        {
            for (int i = 0; i < command.Length; i++)
            {
                Move(command[i]);
            }
        }

        public void TurnLeft()
        {
            int index = Array.IndexOf(directs, direct);
            if (index > -1 && index < directs.Length)
            {
                direct = directs[(index-1+directs.Length) % directs.Length];
            } else
            {
                Console.Out.WriteLine("Input Correct Value for direction");
            }
        }

        public void TurnRight()
        {
            int index = Array.IndexOf(directs, direct);

            if (index > -1 && index < directs.Length)
            {
                direct = directs[(index + 1 + directs.Length) % directs.Length];
            } else
            {
                Console.Out.WriteLine("Input Correct Value for direction");
            }
        }

        public void Move()
        {
            switch (direct)
            {
                case "N":
                    if (y < row_max)
                    {
                        y = y + 1;
                    }
                    break;
                case "W":
                    if (x > 0)
                    {
                        x = x - 1;
                    }
                    break;
                case "E":
                    if (x < col_max)
                    {
                        x = x + 1;
                    }
                    break;
                case "S":
                    if (y > 0)
                    {
                        y = y - 1;
                    }
                    break;
                default:
                    break;
            }
        }

        public void Move(char c)
        {
            switch (c)
            {
                case 'F':
                    Move();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                default:
                    break;
            }
        }

        public void PrintStats()
        {
            var temp = "";
            switch (direct)
            {
                case "N":
                    temp = "North";
                    break;
                case "S":
                    temp = "South";
                    break;
                case "W":
                    temp = "West";
                    break;
                case "E":
                    temp = "East";
                    break;
            }       
            Console.Out.WriteLine("Result: " + x + "," + y + " " + temp);
        }
    }
}

namespace MarsTerrain
{
    class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine(); // Read the X-Row and Y-Row
            string command = Console.ReadLine(); // Read the Command of the Robot


            Robot robot = new Robot();
            robot.SetSize(size);
            robot.RunCommand(command);
            robot.PrintStats();
        }
    }
}
