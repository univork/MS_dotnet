using System.Globalization;
using System.Threading.Tasks.Sources;

/*
დაწერეთ პროგრამა, რომელიც მოითხოვს მომხმარებლისგან თვის რიგითი ნომრის
შეყვანას და გამოაქვს შესაბამისი წელიწადის დრო. იმ შემთხვევაში, როდესაც თვე
შეყვანილია არასწორად, პროგრამამ უნდა გამოიტანოს შეცდომის შეტყობინება.
*/
static void calendar() {
    Console.Write("Month: ");
    bool success = int.TryParse(Console.ReadLine(), out int month);

    if (month < 1 || month > 12 || !success) Console.WriteLine("Invalid month");
    else {
        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        Console.WriteLine(monthName);
    }
}


/*
დაწერეთ პროგრამა, რომელიც შეყვანილი კვირის დღეების რიგითი ნომრის
შესაბამისად გამოიტანს შეტყობინებას <<სამუშაო დღე>> ან <<შაბათი>> ან <<კვირა>>.
*/
static void workDay() {
    bool success = int.TryParse(Console.ReadLine(), out int day);

    if (day < 1 || day > 7 || !success) 
        Console.WriteLine("Invalid day");
    else if (day == 6)
        Console.WriteLine("შაბათი");
    else if (day == 7)
        Console.WriteLine("კვირა");
    else Console.WriteLine("სამუშაო დღე");
}


/*
დაწერეთ პროგრამა, რომელიც გამოითვლის სხეულის მასის ინდექსს და
მომხმარებელს მისცემს რეკომენდაციას.
*/
static void BMIRecomendation() {
    Console.Write("Mass: ");
    double mass = double.Parse(Console.ReadLine());
    Console.Write("Height: ");
    double height = double.Parse(Console.ReadLine());

    double bmi = mass / height * height;


    if (bmi < 16) {
        Console.WriteLine("წონის მწვავე დეფიციტი");
        double recommended_mass = 18.5 * height * height;
        double mass_to_gain = recommended_mass - mass;
        Console.WriteLine($"გთხოვთ მოიმატოთ ${mass_to_gain} კილო");
    } else if (bmi < 18.5)
    {
        Console.WriteLine("წონის დეფიციტი");
        double recommended_mass = 18.5 * height * height;
        double mass_to_gain = recommended_mass - mass;
        Console.WriteLine($"გთხოვთ მოიმატოთ ${mass_to_gain} კილო");
    } else if (bmi > 25 && bmi < 30)
    {
        Console.WriteLine("ზედმეტი წონა");
        double recommended_mass = 25 * height * height;
        double mass_to_lose = mass - recommended_mass;
        Console.WriteLine($"გთხოვთ დაიკლოთ ${mass_to_lose} კილო");
    } else
    {
        Console.WriteLine("სიმსუქნე");
        double recommended_mass = 25 * height * height;
        double mass_to_lose = mass - recommended_mass;
        Console.WriteLine($"გთხოვთ დაიკლოთ ${mass_to_lose} კილო");

    }

}


/*
კლავიატურიდან შეიყვანეთ გამოცდაზე სტუდენტის მიერ მიღებული შეფასება
(შეფასების სისტემა - 51% – 100%). ეკრანზე გამოვიდეს სტუდენტის შედეგი შემდეგი
ანალიზით: თუ შეფასება მერყეობს 0-50% -მდე გამოვიდეს შეტყობინება „You’ve failed
the exam... “. ანალოგიურად,
51-60% - „You’ve passed the exam. The result - E“
61-70% - „You’ve passed the exam. The result - D“
71-80% - „You’ve passed the exam. The result - C“
81-90% - „You’ve passed the exam. The result - B“
91-99% - „You’ve passed the exam. The result - A“
100% - „You’ve passed the exam. You’re an excellent student! The result - A“;
*/
static void studentExam() {
    Console.Write("Score: ");
    double score = double.Parse(Console.ReadLine()); ;

    if (score < 0 || score > 100)
        Console.WriteLine("Invalid score");
    else if (score < 51)
        Console.WriteLine("You've failed the exam ... ☹️");
    else if (score >= 51 && score <= 60)
        Console.WriteLine("You've passed the exam. The result - E");
    else if (score >= 61 && score <= 70)
        Console.WriteLine("You've passed the exam. The result - D");
    else if (score >= 71 && score <= 80)
        Console.WriteLine("You've passed the exam. The result - C");
    else if (score >= 81 && score <= 90)
        Console.WriteLine("You've passed the exam. The result - B");
    else if (score >= 91 && score <= 99)
        Console.WriteLine("You've passed the exam. The result - A");
    else
        Console.WriteLine("You've passed the exam. You're an excellent student! The result - A");
}


/*
შეადგინეთ ვალუტის გაცვლის პროგრამა, რომელსაც ლარებში შემოტანილი თანხის
სიდიდე გადაყავს მოთხოვნის შესაბამისად დოლარში (D), ევროში (E) ან ფუნტში (P).
*/
static void currencyExchange() {
    Dictionary<string, double> exhange_rates = new() {
        {"D", 0.38},
        {"E", 0.35},
        {"P", 0.30},
    };

    Console.Write("Money: ");
    double money = double.Parse(Console.ReadLine());
    Console.Write("Currency (D, E, P): ");
    string currency = Console.ReadLine();

    Console.WriteLine($"{money} GEL in {currency} is {money * exhange_rates[currency]}");
}

/*
მოცემული ნატურალური რიცხვისათვის განსაზღვრეთ, ქმნის თუ არა მისი ციფრები
არითმეტიკულ პროგრესიას. ითვლება, რომ რიცხვი შედგება მინიმუმ 3 ციფრისგან.
მაგალითად, 1357, 963.
*/
static void isProgression() {
    Console.Write("n = ");
    int n = int.Parse(Console.ReadLine());

    int prev = n % 10;
    n /= 10;
    int difference = prev - n % 10;

    bool success = true;

    while (n > 0) {
        int next = n % 10;
        n /= 10;
        if (prev - next != difference)
        {
            success = false;
            break;
        }
        prev = next;
    }

    if (success) Console.WriteLine("yes");
    else  Console.WriteLine("no");
}


/*
დაწერეთ ფუნქცია, რომელიც ბეჭდავს პირველი ათი რიცხვის კვადრატებს შემდეგი
სახით:
*/
static void squares()
{
    Console.WriteLine("--------------");
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine(String.Format("{0, 3}\t{1, 3}", i, i*i));
    }
    Console.WriteLine("--------------");
}


Console.WriteLine("Task 1");
calendar();

Console.WriteLine("\nTask 2");
workDay();

Console.WriteLine("\nTask 3");
BMIRecomendation();

Console.WriteLine("\nTask 4");
studentExam();

Console.WriteLine("\nTask 5");
currencyExchange();

Console.WriteLine("\nTask 6");
isProgression();

Console.WriteLine("\nTask 7");
squares();

