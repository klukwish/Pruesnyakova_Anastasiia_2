using Lab2;
Interval myinterval1 = new Interval(12, 39);
Console.WriteLine($"Лiва границя: {myinterval1.Leftedge}. Права границя: {myinterval1.Rightedge}");

int mylength = myinterval1.Length();
Console.WriteLine($"Довжина iнтервала: {mylength}");

myinterval1.Bias(2);

myinterval1.ComprStretch(-2, 2);

myinterval1.Compare(12, 54);

myinterval1.Sum(12, 23);

myinterval1.Diff(12, 23);

myinterval1.jsons(myinterval1);

myinterval1.jsond();
