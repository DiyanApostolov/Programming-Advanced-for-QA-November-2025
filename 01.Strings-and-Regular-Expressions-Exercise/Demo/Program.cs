
int number = int.Parse(Console.ReadLine());

// if-else statemet

if (number % 2 == 0)
{
    Console.WriteLine("even");
}
else
{
    Console.WriteLine("odd");
}

// тернарен оператор - ternary operator

string result = number % 2 == 0 ? "even" : "odd";

Console.WriteLine(result);
