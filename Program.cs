using Linq.Data;

var dataset = DataSetFactory.CreateDataSet();

OutputJobTitlesOfAllEmployeesWhoseBossIsCEO(dataset);
OutputJobTitlesOfAllEmployeesWhoIsNotAManager(dataset);
OutputJobTitlesAndBithDatesOfAllManagersOlderThen30(dataset);
OutputJobTitlesAndEmployessCountOfManagersWhoesDepartmentsHaveMoreThen5Employees(dataset);

Console.ReadLine();

static void OutputJobTitlesOfAllEmployeesWhoseBossIsCEO(IList<Person> dataset)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("CEO's subordinates:");
    
    var underCEOEmployees = dataset.Where(p => p?.Boss?.JobTitle == "CEO").ToList();

    Console.ResetColor();
    foreach (var person in underCEOEmployees)
    {
        Console.WriteLine($"{person.JobTitle}");
    }
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine(new string('=', 30));
    Console.ResetColor();
}

static void OutputJobTitlesOfAllEmployeesWhoIsNotAManager(IList<Person> dataset)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Employees who's not manager:");
    
    var isNotManager = dataset.Where(p => p?.Boss?.JobTitle != "CEO" && p?.Boss?.JobTitle != null).ToList();

    Console.ResetColor();
    foreach (var person in isNotManager)
    {
        Console.WriteLine($"{person.JobTitle}");
    }
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine(new string('=', 30));
    Console.ResetColor();
}

static void OutputJobTitlesAndBithDatesOfAllManagersOlderThen30(IList<Person> dataset)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Managers older 30:");

    var older30Managers = dataset.Where(p => p?.JobTitle == "Manager" && p?.BirthDate < DateTime.Now - TimeSpan.FromDays(365 * 30)).ToList();

    Console.ResetColor();
    foreach (var person in older30Managers)
    {
        Console.WriteLine($"{person.JobTitle}");
    }
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine(new string('=', 30));
    Console.ResetColor();
}

static void OutputJobTitlesAndEmployessCountOfManagersWhoesDepartmentsHaveMoreThen5Employees(IList<Person> dataset)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Managers, whoes department have more then 5 empliyees:");

    var departmentsGroup = dataset.GroupBy(p => p?.Boss).Where(p => p.Key != null && p.Count() > 5).ToList();

    Console.ResetColor();
    foreach (var dep in departmentsGroup)
    {
        Console.WriteLine($"{dep?.Key?.JobTitle}: has {dep.Count()} employees");
    }
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine(new string('=', 30));
    Console.ResetColor();
}