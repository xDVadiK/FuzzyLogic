using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic
{
    internal class Robot
    {
        private char[,] maze;
        FuzzyVariable near;
        FuzzyVariable far;
        public int RRow { get; set; }
        public int RColumn { get; set; }

        public Robot(char[,] maze, FuzzyVariable near, FuzzyVariable far)
        {
            this.maze = maze;
            this.near = near;
            this.far = far;
        }

        public string DeterminingDirectionMovement()
        {
            int[] distances = CalculateDistances();
            string[] distancesName = { "top", "right", "bottom", "left" };
            List<LinguisticVariable> directions = new List<LinguisticVariable>();
            for (int i = 0; i < distances.Length; i++)
            {
                if (near.GetMembership(distances[i]) < far.GetMembership(distances[i]))
                {
                    directions.Add(new LinguisticVariable(distancesName[i], far));
                }
                else
                {
                    directions.Add(new LinguisticVariable(distancesName[i], near));
                }
            }

            List<string> matchingVariableNames = new List<string>();

            foreach (LinguisticVariable direction in directions)
            {
                if (direction.Variable != null && direction.Variable.Name == "far")
                {
                    matchingVariableNames.Add(direction.Name);
                }
            }

            if (matchingVariableNames.Count > 0)
            {
                Random random = new Random();
                return matchingVariableNames[random.Next(0, matchingVariableNames.Count)];
            }
            else
            {
                return "stop";
            }
        }

        public int[] CalculateDistances()
        {
            int rowCount = maze.GetLength(0);
            int columnCount = maze.GetLength(1);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (maze[i, j] == 'r')
                    {
                        RRow = i;
                        RColumn = j;
                        break;
                    }
                }
            }

            // Array to store distances (top, right, bottom, left)
            int[] distances = {0,0,0,0};

            // top
            for (int i = RRow - 1; i > -1; i--)
            {
                if (maze[i, RColumn] == 'o')
                {
                    break;
                } 
                else
                {
                    distances[0]++;
                }
            }

            // right
            for (int j = RColumn + 1; j < columnCount; j++)
            {
                if (maze[RRow, j] == 'o')
                {
                    break;
                }
                else
                {
                    distances[1]++;
                }
            }

            // bottom
            for (int i = RRow + 1; i < rowCount; i++)
            {
                if (maze[i, RColumn] == 'o')
                {
                    break;
                }
                else
                {
                    distances[2]++;
                }
            }

            // left
            for (int j = RColumn - 1; j > -1; j--)
            {
                if (maze[RRow, j] == 'o')
                {
                    break;
                }
                else
                {
                    distances[3]++;
                }
            }

            return distances;
        }
    }
}