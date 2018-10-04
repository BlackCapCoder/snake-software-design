using System;using System.Linq;using System.Diagnostics;using static System.Console;namespace N{class P{public int X{get
;set;}public int Y{get;set;}}class N{static void Main(){bool A=true,b=!A;int a=2,w=WindowWidth,h=WindowHeight;var r=new
Random();P p=new P();var s=Enumerable.Repeat<P>(new P{X=10,Y=10},4).ToList();var t=new Stopwatch();t.Start();Clear();
CursorVisible=!A;Title="Høyskolen Kristiania - SNAKE";S();while(A){int k=KeyAvailable?(int)ReadKey(A).Key:0;for(int i
=0;i<4;i++)if(k==(40-(i*7)%4)&&a!=i)a=(2+i)%4;P n=new P{X=s.Last().X-((a-1)*3-1)%2,Y=s.Last().Y+(a*3-1)%2};if(k==27||n.X
<0||n.X>=w||n.Y<0||n.Y>=h||H(n))break;if((b^=k==32)||t.ElapsedMilliseconds<100)continue;t.Restart();if(n.X==p.X&&n.Y==p.
Y)S();else s.RemoveAt(0);G(new[]{s.Last(),n,s.First()},14,"0@ ");s.Add(n);}bool H(P q){foreach(P x in s)if(x.X==q.X&&x.Y
==q.Y)return A;return!A;}void S(){do{p.X=r.Next(0,w);p.Y=r.Next(0,h);}while(H(p));G(new[]{p},10,"$");}void G(P[]j,int c,
String x){ForegroundColor=(ConsoleColor)c;for(int i=0;i<x.Length;i++){SetCursorPosition(j[i].X,j[i].Y);Write(x[i]);}}}}}
