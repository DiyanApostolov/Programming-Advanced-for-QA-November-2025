using _03.TeamworkProjects;

int n = int.Parse(Console.ReadLine());

List<Team> teams = new List<Team>();

for (int i = 0; i < n; i++)
{
    string[] createInfo = Console.ReadLine().Split("-");
    string creator = createInfo[0];
    string teamName = createInfo[1];

    // проверяваме дали вече не съществува отбор с това име 
    if (teams.Any(t => t.Name == teamName))
    {
        Console.WriteLine($"Team {teamName} was already created!");
    }
    // проверяваме дали създателя не е вече създател на някой друг отбор
    else if (teams.Any(t => t.Creator == creator)) 
    {
        Console.WriteLine($"{creator} cannot create another team!");
    }
    else
    {
        // създаваме си нов отбор
        Team currentTeam = new Team(teamName, creator);

        // добавяме до в списъка с отбори
        teams.Add(currentTeam);

        Console.WriteLine($"Team {teamName} has been created by {creator}!");
    }
}

string input = Console.ReadLine();

while (input != "end of assignment")
{
    string[] userTeamInfo = input.Split("->");
    string memberName = userTeamInfo[0];
    string teamName = userTeamInfo[1];

    // проверяваме дали отбора съществува
    if (teams.Any(t => t.Name == teamName) == false)
    {
        Console.WriteLine($"Team {teamName} does not exist!");
    }
    // проверяваме дали потребителя не участва вече в друг отбор ИЛИ дали не е създател
    else if (teams.Any(t => t.Members.Contains(memberName) || t.Creator == memberName)) 
    {
        Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
    }
    else
    {
        // вадим си отбора (по референция) от списъка, като го търсим по име
        Team teamToAddMember = teams.First(t => t.Name == teamName);

        // добавям играча в списъка Members на отбора
        teamToAddMember.Members.Add(memberName);
    }


    input = Console.ReadLine();
}


foreach (Team team in teams
                        .Where(t => t.Members.Count > 0)   // взима само отборите които ИМАТ Members
                        .OrderByDescending(t => t.Members.Count) // сортира в низходящ ред по броя на Members
                        .ThenBy(t => t.Name))              // сортира по името на отбора в азбучен ред
                        
{
    Console.WriteLine(team.Name);
    Console.WriteLine($"- {team.Creator}");

    foreach (var member in team.Members
                                .OrderBy(m => m)) // сортираме Members по азбучен ред
    {
        Console.WriteLine($"-- {member}");
    }
}

Console.WriteLine("Teams to disband:");

foreach (Team team in teams
                        .Where(t => t.Members.Count == 0) // взима само отборите които НЯМАТ Members
                        .OrderBy(t => t.Name))            // сортира по името на отбора в азбучен ред
{
    Console.WriteLine(team.Name);
}