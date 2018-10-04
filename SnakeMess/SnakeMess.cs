using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// WARNING: DO NOT code like this. Please. EVER!
//          "Aaaargh!"
//          "My eyes bleed!"
//          "I facepalmed my facepalm."
//          Etc.
//          I had a lot of fun obfuscating this code! And I can now (proudly?) say that this is the uggliest short piece of code I've ever written!
//          (It could maybe have been even ugglier? But the idea wasn't to make it fuggly-uggly, just funny-uggly or sweet-uggly. ;-)
//
//          -Tomas

namespace SnakeMess
{
  class Point
  {
    public int X; public int Y;
    public Point(int x = 0, int y = 0) { X = x; Y = y; }
    public Point(Point input) { X = input.X; Y = input.Y; }
  }

  class SnakeMess
  {
    public static void Main(string[] arguments)
    {
      Console.Clear();
      Console.CursorVisible = false;
      Console.Title = "Høyskolen Kristiania - SNAKE";

      bool pause = false;
      short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
      int boardW = Console.WindowWidth, boardH = Console.WindowHeight;
      Random rng = new Random();
      Point app  = new Point();

      List<Point> snake = new List<Point>();
      for (int i=0; i<4; i++) snake.Add(new Point(10, 10));
      put(snake.First(), ConsoleColor.Green, "@");
      spawn();

      Stopwatch t = new Stopwatch(); t.Start();

      while (true) {
        if (Console.KeyAvailable) {
          ConsoleKeyInfo cki = Console.ReadKey(true);
          if (cki.Key == ConsoleKey.Escape) break;
          pause ^= cki.Key == ConsoleKey.Spacebar;
          if (cki.Key == ConsoleKey.K && newDir != 2) newDir = 0;
          if (cki.Key == ConsoleKey.L && newDir != 3) newDir = 1;
          if (cki.Key == ConsoleKey.J && newDir != 0) newDir = 2;
          if (cki.Key == ConsoleKey.H && newDir != 1) newDir = 3;
        }

        if (pause) continue;
        if (t.ElapsedMilliseconds < 100) continue;
        t.Restart();

        Point newH = new Point(snake.Last());

        if (newDir == 0) newH.Y -= 1;
        if (newDir == 1) newH.X += 1;
        if (newDir == 2) newH.Y += 1;
        if (newDir == 3) newH.X -= 1;

        if ( newH.X < 0 || newH.X >= boardW
          || newH.Y < 0 || newH.Y >= boardH
           ) break;

        put(snake.Last(), ConsoleColor.Yellow, "0");
        put(newH, ConsoleColor.Yellow, "@");
        if (hit(newH)) break;
        snake.Add(newH);

        if (newH.X == app.X && newH.Y == app.Y) {
          if (snake.Count + 1 >= boardW * boardH) break;
          spawn();
        } else {
          snake.RemoveAt(0);
          put(snake.First(), ConsoleColor.Yellow, " ");
        }
      }
      bool hit (Point p) {
        foreach (Point x in snake) if (x.X == p.X && x.Y == p.Y) return true;
        return false;
      }
      void spawn(){
        do { app.X = rng.Next(0, boardW); app.Y = rng.Next(0, boardH); } while (hit(app));
        put(app, ConsoleColor.Green, "$");
      }
    }
    static void put(Point p, ConsoleColor c, String s) {
      Console.ForegroundColor = c;
      Console.SetCursorPosition(p.X, p.Y);
      Console.Write(s);
    }
  }
}
