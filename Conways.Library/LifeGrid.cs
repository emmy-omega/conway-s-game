using System;

namespace Conways.Library
{
    public class LifeGrid
    {
        int gridHeight, gridWidth;
        public CellState[,] currentState, nextState;

        public LifeGrid(int height, int width)
        {
            this.gridHeight = height;
            this.gridWidth = width;

            currentState = new CellState[this.gridHeight, this.gridWidth];
            nextState = new CellState[this.gridHeight, this.gridWidth];

            for (int i = 0; i < this.gridHeight; i++)
            {
                for (int j = 0; j < this.gridWidth; j++)
                {
                    currentState[i, j] = CellState.Dead;
                }
            }
        }

        public void UpdateState()
        {
            for (int i = 0; i < this.gridHeight; i++)
            {
                for (int j = 0; j < this.gridWidth; j++)
                {
                    var liveNeighbors = GetLiveNeighbors(i, j);
                    nextState[i, j] = LifeRules.GetNewState(currentState[i, j], liveNeighbors);
                }
            }
            currentState = nextState;
            nextState = new CellState[this.gridHeight, this.gridWidth];
        }

        private int GetLiveNeighbors(int positiveX, int positiveY)
        {
            int liveNeighbors = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    int neighborX = positiveX + i;
                    int neighborY = positiveY + j;

                    // Check boardaries
                    if (neighborX >= 0 && neighborX < this.gridHeight && neighborY >= 0 && neighborY < this.gridWidth)
                        if (currentState[neighborX, neighborY] == CellState.Alive)
                            liveNeighbors++;
                }
            }
            return liveNeighbors;

        }

        public void Randomize()
        {
            Random random = new Random();
            for (int i = 0; i < this.gridHeight; i++)
            {
                for (int j = 0; j < this.gridWidth; j++)
                {
                    var next = random.Next(2);
                    var newState = next < 1 ? CellState.Dead : CellState.Alive;
                    currentState[i, j] = newState;
                }
            }
        }
    }
}