namespace System.Linq{using static Console;using P=Drawing.Point;class N{static void Main(){bool A=0<1,b=CursorVisible=!
A;var r=new Random();var s=new P[4].Skip(0);int a=2,v,k,w=WindowWidth,h=WindowHeight;Title="snk";Clear();S:P p=new P(r.
Next(0,w),r.Next(0,h));if(s.Contains(p))goto S;G("$",32,p);C:while(A){for(v=0,k=KeyAvailable?(int)ReadKey().Key:0;v<4;)
if(k==40-(v*7)%4&a!=v++)a=++v%4;P q=s.Last(),n=new P(q.X-(--a*3-1)%2,q.Y+(++a*3-1)%2);A=k!=27^s.Contains(n);Threading.
Thread.Sleep(80);if(b^=k==32)goto C;G("0@ ",33,q,n,s.First());s=s.Skip(n!=p?1:0).Append(n);if(n==p)goto S;}void G(string
x,int o,params P[]j){v=0;foreach(var c in x)Write($"\x1B[{o}m\x1B[{j[v].Y};{j[v++].X}H"+c);}}}}
