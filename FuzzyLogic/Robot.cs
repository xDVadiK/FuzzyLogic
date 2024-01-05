using System.Collections.Generic;

namespace FuzzyLogic
{
    internal class Robot
    {
        private char[,] maze;
        private FuzzyVariable near;
        private FuzzyVariable far;
        public int RRow { get; set; }
        public int RColumn { get; set; }

        private string prevStep = null;

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

            // Rule 1
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "far")
            {
                prevStep = "left";
                return "left";
            }
            // Rule 2
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "near")
            {
                prevStep = "bottom";
                return "bottom";
            }
            // Rule 3.1
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("right")))
            {
                prevStep = "bottom";
                return "bottom";
            }
            // Rule 3.2
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("top")))
            {
                prevStep = "left";
                return "left";
            }
            // Rule 4
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "near")
            {
                prevStep = "right";
                return "right";
            }
            // Rule 5.1
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("right")))
            {
                prevStep = "right";
                return "right";
            }
            // Rule 5.2
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("left")))
            {
                prevStep = "left";
                return "left";
            }
            // Rule 6.1
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "near"
                && (prevStep == null || prevStep.Equals("left")))
            {
                prevStep = "bottom";
                return "bottom";
            }
            // Rule 6.2
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "near"
                && (prevStep == null || prevStep.Equals("top")))
            {
                prevStep = "right";
                return "right";
            }
            // Rule 7.1
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("left")))
            {
                prevStep = "bottom";
                return "bottom";
            }
            // Rule 7.2
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("top")))
            {
                prevStep = "left";
                return "left";
            }
            // Rule 7.3
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("right")))
            {
                prevStep = "right";
                return "right";
            }
            // Rule 8
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "near")
            {
                prevStep = "top";
                return "top";
            }
            // Rule 9.1
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("bottom")))
            {
                prevStep = "left";
                return "left";
            }
            // Rule 9.2
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("right")))
            {
                prevStep = "top";
                return "top";
            }
            // Rule 10.1
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "near"
                && (prevStep == null || prevStep.Equals("bottom")))
            {
                prevStep = "bottom";
                return "bottom";
            }
            // Rule 10.2
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "near"
                && (prevStep == null || prevStep.Equals("top")))
            {
                prevStep = "top";
                return "top";
            }
            // Rule 11.1
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("top")))
            {
                prevStep = "top";
                return "top";
            }
            // Rule 11.2
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("right")))
            {
                prevStep = "top";
                return "top";
            }
            // Rule 11.3
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("bottom")))
            {
                prevStep = "left";
                return "left";
            }
            // Rule 12.1
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "near"
                && (prevStep == null || prevStep.Equals("bottom")))
            {
                prevStep = "right";
                return "right";
            }
            // Rule 12.2
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "near"
                && (prevStep == null || prevStep.Equals("left")))
            {
                prevStep = "top";
                return "top";
            }
            // Rule 13.1
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("bottom")))
            {
                prevStep = "right";
                return "right";
            }
            // Rule 13.2
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("right")))
            {
                prevStep = "top";
                return "top";
            }
            // Rule 13.3
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("left")))
            {
                prevStep = "top";
                return "top";
            }
            // Rule 14.1
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "near"
                && (prevStep == null || prevStep.Equals("left")))
            {   
                prevStep = "top";
                return "top";
            }
            // Rule 14.2
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "near"
                && (prevStep == null || prevStep.Equals("top")))
            {
                prevStep = "right";
                return "right";
            }
            // Rule 14.3
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "near"
                && (prevStep == null || prevStep.Equals("bottom")))
            {
                prevStep = "right";
                return "right";
            }
            // Rule 15.1
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("bottom")))
            {
                prevStep = "right";
                return "right";
            }
            // Rule 15.2
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("top")))
            {
                prevStep = "left";
                return "left";
            }
            // Rule 15.3
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("left")))
            {
                prevStep = "left";
                return "left";
            }
            // Rule 15.4
            if (directions[0].Variable.Name == "far"
                && directions[1].Variable.Name == "far"
                && directions[2].Variable.Name == "far"
                && directions[3].Variable.Name == "far"
                && (prevStep == null || prevStep.Equals("right")))
            {
                prevStep = "right";
                return "right";
            }
            // Rule 16
            if (directions[0].Variable.Name == "near"
                && directions[1].Variable.Name == "near"
                && directions[2].Variable.Name == "near"
                && directions[3].Variable.Name == "near")
            {
                return "stop";
            }
            return "stop";
        }

        private int[] CalculateDistances()
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