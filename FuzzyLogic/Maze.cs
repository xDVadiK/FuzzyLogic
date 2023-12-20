using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyLogic
{
    internal class Maze
    {
        private char[,] maze;
        private Robot robot;
        FuzzyVariable near;
        FuzzyVariable far;

        public Maze(string maze, int[] parametersNear, int[] parametersFar)
        {
            string[] rows = maze.Split('\n');
            this.maze = new char[rows.Length - 1, rows[0].Length - 1];
            for (int i = 0; i < rows.Length; i++)
            {
                string row = rows[i].Trim();
                for (int j = 0; j < row.Length; j++)
                {
                    this.maze[i, j] = row[j];
                }
            }
            near = new FuzzyVariable("near", parametersNear[0], parametersNear[1], parametersNear[2], parametersNear[3]);
            far = new FuzzyVariable("far", parametersFar[0], parametersFar[1], parametersFar[2], parametersFar[3]);
            robot = new Robot(this.maze, near, far);
        }

        public char[,] movement()
        {
            string direction = robot.DeterminingDirectionMovement();
            maze[robot.RRow, robot.RColumn] = '-';
            switch (direction)
            {
                case "top":
                    maze[robot.RRow - 1, robot.RColumn] = 'r';
                    break;
                case "right":
                    maze[robot.RRow, robot.RColumn + 1] = 'r';
                    break;
                case "bottom":
                    maze[robot.RRow + 1, robot.RColumn] = 'r';
                    break;
                case "left":
                    maze[robot.RRow, robot.RColumn - 1] = 'r';
                    break;
            }
            return maze;
        }


    }
}
