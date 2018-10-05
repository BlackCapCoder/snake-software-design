namespace System.Linq{using static Console;using P=Drawing.Point;class N{static void Main(){bool A=0<1,b=CursorVisible=!
A;var r=new Random();P p=new P();var s=new P[4].Select(_=>new P(10,10));int a=2,v,k,w=WindowWidth,h=WindowHeight;Clear()
;Title="snk";S:p.X=r.Next(0,w);p.Y=r.Next(0,h);if(s.Contains(p))goto S;v=10;G(new[]{p},"$");C:while(A){for(v=0,k=
KeyAvailable?(int)ReadKey(A).Key:0;v<4;)if(k==40-(v*7)%4&a!=v++)a=++v%4;P q=s.Last(),n=new P(q.X-(--a*3-1)%2,q.Y+(++a*3-
1)%2);A=k!=27&n.X>=0&n.X<w&n.Y>=0&n.Y<h&!s.Contains(n);Threading.Thread.Sleep(80);if((b^=k==32))goto C;v=14;G(new[]{q,n,
s.First()},"0@ ");s=s.Skip(n!=p?1:0).Append(n);if(n==p)goto S;}void G(P[]j,string x){ForegroundColor=(ConsoleColor)v;for
(v=0;v<x.Length;){SetCursorPosition(j[v].X,j[v].Y);Write(x[v++]);}}}}}
