namespace System.Linq{using static Console;class P{public int X,Y;}class N{static void Main(){bool A=0<1,b=!A;int a=2,v,
k,w=WindowWidth,h=WindowHeight;var r=new Random();P p=new P();var s=new P[4].Select((_)=>new P{X=10,Y=10}).ToList();var
t=new Diagnostics.Stopwatch();t.Start();Clear();CursorVisible=!A;Title="snk";S();while(A){for(v=0,k=KeyAvailable?(int)
ReadKey(A).Key:0;v<4;v++)if(k==40-(v*7)%4&a!=v)a=(2+v)%4;P n=new P{X=s.Last().X-((a-1)*3-1)%2,Y=s.Last().Y+(a*3-1)%2};if
(k==27|n.X<0|n.X>=w|n.Y<0|n.Y>=h|H(n))break;if((b^=k==32)|t.ElapsedMilliseconds<100)continue;t.Restart();if(n.X==p.X&n.Y
==p.Y)S();else s.RemoveAt(0);G(new[]{s.Last(),n,s.First()},14,"0@ ");s.Add(n);}bool H(P q){foreach(P x in s)if(x.X==q.X&
x.Y==q.Y)return A;return!A;}void S(){do{p.X=r.Next(0,w);p.Y=r.Next(0,h);}while(H(p));G(new[]{p},10,"$");}void G(P[]j,int
c,String x){ForegroundColor=(ConsoleColor)c;for(v=0;v<x.Length;){SetCursorPosition(j[v].X,j[v].Y);Write(x[v++]);}}}}}
