using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
namespace SnakeMess {
  class Point {
    public int X { get; set; }
    public int Y { get; set; }
  }
  class SnakeMess {
    public static void Main() {
      int         newDir = 2;
      bool        pause  = false;
      int         boardW = Console.WindowWidth;
      int         boardH = Console.WindowHeight;
      Random      rng    = new Random();
      Point       app    = new Point();
      List<Point> snake  = Enumerable.Repeat<Point>(new Point{ X=10, Y=10 }, 4).ToList();
      Stopwatch   t      = new Stopwatch(); t.Start();
      Console.Clear();
      Console.CursorVisible = false;
      Console.Title = "Høyskolen Kristiania - SNAKE";
      spawn();
      while (true) {
        ConsoleKey k = Console.KeyAvailable? Console.ReadKey(true).Key: 0;
        Enumerable.Range(0,4).ToList().ForEach(i=>{if((int)k==(40-(i*7)%4)&&newDir!=i)newDir=(2+i)%4;});
        Point newH = new Point { X=snake.Last().X-((newDir-1)*3-1)%2, Y=snake.Last().Y+(newDir*3-1)%2 };
        if (k==ConsoleKey.Escape||newH.X<0||newH.X>=boardW||newH.Y<0||newH.Y>=boardH||hit(newH))break;
        if ((pause ^= k == ConsoleKey.Spacebar) || t.ElapsedMilliseconds < 100) continue;
        t.Restart();
        if (newH.X == app.X && newH.Y == app.Y) spawn(); else snake.RemoveAt(0);
        put(new[] {snake.Last(),newH,snake.First()}, ConsoleColor.Yellow, "0@ ");
        snake.Add(newH);
      }
      bool hit (Point p) {
        foreach (Point x in snake) if (x.X == p.X && x.Y == p.Y) return true;
        return false;
      }
      void spawn(){
        do { app.X = rng.Next(0, boardW); app.Y = rng.Next(0, boardH); } while (hit(app));
        put(new[] {app}, ConsoleColor.Green, "$");
      }
      void put(Point[] ps, ConsoleColor c, String s) {
        Console.ForegroundColor = c;
        for (int i=0; i<ps.Length; i++) {
          Console.SetCursorPosition(ps[i].X, ps[i].Y);
          Console.Write(s[i]);
        }
      }
    }
  }
}
