using System;using System.Collections.Generic;using System.Linq;using System.Diagnostics;namespace SnakeMess{class P{
public int X{get;set;}public int Y{get;set;}}class SnakeMess{public static void Main(){int a=2;bool b=false;int w=
Console.WindowWidth;int h=Console.WindowHeight;Random r=new Random();P p=new P();List<P>s=Enumerable.Repeat<P>(new P{
X=10,Y=10},4).ToList();Stopwatch t=new Stopwatch();t.Start();Console.Clear();Console.CursorVisible=false;Console.Title=
"Høyskolen Kristiania - SNAKE";S();while(true){ConsoleKey k=Console.KeyAvailable?Console.ReadKey(true).Key:0;
Enumerable.Range(0,4).ToList().ForEach(i=>{if((int)k==(40-(i*7)%4)&&a!=i)a=(2+i)%4;});P newH=new P{X=s.Last().X-((a-1)*3
-1)%2,Y=s.Last().Y+(a*3-1)%2};if(k==ConsoleKey.Escape||newH.X<0||newH.X>=w||newH.Y<0||newH.Y>=h||hit(newH))break;if((b^=
k==ConsoleKey.Spacebar)||t.ElapsedMilliseconds<100)continue;t.Restart();if(newH.X==p.X&&newH.Y==p.Y)S();else s.RemoveAt
(0);put(new[]{s.Last(),newH,s.First()},ConsoleColor.Yellow,"0@ ");s.Add(newH);}bool hit(P q){foreach(P x in s)if(x.X==
q.X&&x.Y==q.Y)return true;return false;}void S(){do{p.X=r.Next(0, w);p.Y=r.Next(0, h);}while(hit(p));put(new[]{p},
ConsoleColor.Green,"$");}void put(P[]ps,ConsoleColor c,String x){Console.ForegroundColor=c;for(int i=0;i<x.Length;i++){
Console.SetCursorPosition(ps[i].X,ps[i].Y);Console.Write(x[i]);}}}}}
