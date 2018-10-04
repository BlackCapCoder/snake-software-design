using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{
  class Point {
    public int X { get; set; }
    public int Y { get; set; }
  }

  class SnakeMess
  {
    public static void Main(string[] arguments)
    {
      int         newDir = 2;
      bool        pause  = false;
      int         boardW = Console.WindowWidth;
      int         boardH = Console.WindowHeight;
      Random      rng    = new Random();
      Point       app    = new Point();
      List<Point> snake  = new List<Point>();
      Stopwatch   t      = new Stopwatch(); t.Start();

      for (int i=0; i<4; i++) snake.Add(new Point{ X=10, Y=10 });

      Console.Clear();
      Console.CursorVisible = false;
      Console.Title = "Høyskolen Kristiania - SNAKE";
      put(snake.First(), ConsoleColor.Green, "@");
      spawn();

      while (true) {
        if (Console.KeyAvailable) {
          ConsoleKeyInfo cki = Console.ReadKey(true);
          if (cki.Key == ConsoleKey.Escape) break;
          pause ^= cki.Key == ConsoleKey.Spacebar;
          for (int i = 0; i < 4; i++)
            if ((int) cki.Key == (40 - (i*7)%4) && newDir != i) newDir = (2+i)%4;
        }

        if (pause || t.ElapsedMilliseconds < 100) continue;
        t.Restart();

        Point newH = new Point { X=snake.Last().X-((newDir-1)*3-1)%2, Y=snake.Last().Y+(newDir*3-1)%2 };

        bool q = newH.X == app.X && newH.Y == app.Y;

        if ( newH.X < 0 || newH.X >= boardW
          || newH.Y < 0 || newH.Y >= boardH
          || hit(newH)
          || (q && snake.Count + 1 >= boardW * boardH)
           ) break;

        put(snake.Last(), ConsoleColor.Yellow, "0");
        put(newH, ConsoleColor.Yellow, "@");
        snake.Add(newH);

        if (q) {
          spawn();
          continue;
        }

        snake.RemoveAt(0);
        put(snake.First(), ConsoleColor.Yellow, " ");
      }
      bool hit (Point p) {
        foreach (Point x in snake) if (x.X == p.X && x.Y == p.Y) return true;
        return false;
      }
      void spawn(){
        do { app.X = rng.Next(0, boardW); app.Y = rng.Next(0, boardH); } while (hit(app));
        put(app, ConsoleColor.Green, "$");
      }
      void put(Point p, ConsoleColor c, String s) {
        Console.ForegroundColor = c;
        Console.SetCursorPosition(p.X, p.Y);
        Console.Write(s);
      }
    }
  }
}
