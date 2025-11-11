
string input = Console.ReadLine();

// Key -> companyName
// Value -> List<string> employeeId's
Dictionary<string, List<string>> companies = new();

while (input != "End")
{
    string[] arguments = input.Split(" -> ");
    string companyName = arguments[0];
    string employeeId = arguments[1];

    // проверявам, дали имам тази фирма
    if (companies.ContainsKey(companyName) == false) 
    {
        // само ако я нямаме, тогава я добавяме
        companies.Add(companyName, new List<string>());
    }

    // проверяваме дали служителя е вече добавен във фирмата
    if (companies[companyName].Contains(employeeId) == false) 
    {
        // само тогава добавямев служителя
        companies[companyName].Add(employeeId);
    }

    input = Console.ReadLine();
}


// Output
foreach(var kvp in companies)
{
    Console.WriteLine(kvp.Key);

    foreach (var employeeId in kvp.Value)
    {
        Console.WriteLine($"-- {employeeId}");
    }
}

