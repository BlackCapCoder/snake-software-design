namespace System.Linq{using static Console;using P=Drawing.Point;class N{static void Main(){bool A=0<1,b=!A;int a=2,v,k,
w=WindowWidth,h=WindowHeight;var r=new Random();P p=new P();var s=new P[4].Select(_=>new P{X=10,Y=10}).ToList();var t=
new Diagnostics.Stopwatch();t.Start();Clear();CursorVisible=!A;Title="snk";S();bool H(P q)=>s.Contains(q);C:while(A){for
(v=0,k=KeyAvailable?(int)ReadKey(A).Key:0;v<4;)if(k==40-(v*7)%4&a!=v++)a=++v%4;P n=new P{X=s.Last().X-((a-1)*3-1)%2,Y=s.
Last().Y+(a*3-1)%2};A=k!=27&n.X>=0&n.X<w&n.Y>=0&n.Y<h&!H(n);if((b^=k==32)|t.ElapsedMilliseconds<100)goto C;t.Restart();
if(n==p)S();else s.RemoveAt(0);G(new[]{s.Last(),n,s.First()},14,"0@ ");s.Add(n);}void S(){do{p.X=r.Next(0,w);p.Y=r.Next
(0,h);}while(H(p));G(new[]{p},10,"$");}void G(P[]j,int c,string x){ForegroundColor=(ConsoleColor)c;for(v=0;v<x.Length;)
{SetCursorPosition(j[v].X,j[v].Y);Write(x[v++]);}}}}}
