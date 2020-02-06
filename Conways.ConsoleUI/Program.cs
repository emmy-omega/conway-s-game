using System;
using Conways.Library;

namespace Conways.ConsoleUI
{
  class Program
  {
    static void Main(string[] args)
    {
      var grid = new LifeGrid(25, 65);
      grid.Randomize();

      ShowGrid(grid.currentState);

      while (Console.ReadLine() != "q")
      {
        grid.UpdateState();
        ShowGrid(grid.currentState);
      }
    }

    private static void ShowGrid(CellState[,] currentState)
    {
      Console.Clear();
      int x = 0;
      int rowLength = currentState.GetUpperBound(1) + 1;
      foreach (var state in currentState)
      {
        var output = state == CellState.Alive ? "0" : ".";
        Console.Write(output);
        x++;
        if (x >= rowLength)
        {
          x = 0;
          Console.WriteLine();
        }
      }
    }
  }
}
