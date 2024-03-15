// ------------------------------- 1 ------------------------------- 
Console.WriteLine("Task 1");

double z(double x, double y)
{
    double result;
    if (Math.Abs(x - y) == 4) result = 2 * x + 3 * y;
    else if (Math.Abs(x - y) == 5) result = Math.Sqrt(x + y);
    else if (Math.Abs(x - y) == 6) result = y - x;
    else result = 10;

    return result;
}

Console.Write("x = ");
double x = double.Parse(Console.ReadLine());

Console.Write("y = ");
double y = double.Parse(Console.ReadLine());

Console.WriteLine($"z = {z(x, y)}");


// ------------------------------- 2 ------------------------------- 

Console.WriteLine("Task 2");

Console.Write("a = ");
double a = double.Parse(Console.ReadLine());

Console.Write("b = ");
double b = double.Parse(Console.ReadLine());

Console.Write("c = ");
double c = double.Parse(Console.ReadLine());


bool check_triangle(double a, double b, double c)
{
    return a + b > c && a + c > b && b + c > a;
}

if (check_triangle(a, b, c)) Console.WriteLine("Yes");
else Console.WriteLine("No");


// ------------------------------- 3 ------------------------------- 

Console.WriteLine("Task 3");

Console.Write("x = ");
double x1 = double.Parse(Console.ReadLine());

Console.WriteLine($"S = {x1 * x1}");
Console.WriteLine($"P = {4 * x1}");



// ------------------------------- 4 ------------------------------- 

Console.WriteLine("Task 4");

Console.Write("n = ");

int n = int.Parse(Console.ReadLine());

Func<int, bool> is_leap = n => n % 4 == 0 && (n % 100 != 0 || n % 400 == 0);

if (is_leap(n)) Console.WriteLine("Yes");
else Console.WriteLine("No");

