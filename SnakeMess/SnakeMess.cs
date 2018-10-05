namespace System.Linq{using static Console;using P=Drawing.Point;using T=DateTime;class N{static void Main(){bool A=0<1,
b=CursorVisible=!A;var r=new Random();P p=new P();var t=T.Now;var s=new P[4].Select(_=>new P{X=10,Y=10});int a=2,v,k,w=
WindowWidth,h=WindowHeight;Clear();Title="snk";S:p.X=r.Next(0,w);p.Y=r.Next(0,h);if(s.Contains(p))goto S;v=10;G(new[]{p}
,"$");C:while(A){for(v=0,k=KeyAvailable?(int)ReadKey(A).Key:0;v<4;)if(k==40-(v*7)%4&a!=v++)a=++v%4;P n=new P{X=s.Last().
X-((a-1)*3-1)%2,Y=s.Last().Y+(a*3-1)%2};A=k!=27&n.X>=0&n.X<w&n.Y>=0&n.Y<h&!s.Contains(n);if((b^=k==32)|(T.Now-t).Ticks<
10e5)goto C;t=T.Now;v=14;G(new[]{s.Last(),n,s.First()},"0@ ");s=s.Skip(n!=p?1:0).Append(n);if(n==p)goto S;}void G(P[]j,
string x){ForegroundColor=(ConsoleColor)v;for(v=0;v<x.Length;){SetCursorPosition(j[v].X,j[v].Y);Write(x[v++]);}}}}}
