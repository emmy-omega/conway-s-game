using System;

namespace Conways.Library
{
    public enum CellState
    {
        Alive,
        Dead
    }
    public class LifeRules
    {
        public static CellState GetNewState(CellState currentState, int liveNeighbors)
        {
            CellState newState = currentState;
            switch (currentState)
            {
                case CellState.Alive:
                    if (liveNeighbors < 2 || liveNeighbors > 3)
                        newState = CellState.Dead;
                    break;
                case CellState.Dead:
                    if (liveNeighbors == 3)
                        newState = CellState.Alive;
                    break;
            }
            return newState;
        }

    }

}
