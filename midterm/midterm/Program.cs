
using midterm;

List<Software> softs = new List<Software>()
{
    new Test("test_soft_1", "company1", new DateTime(2024, 1, 2), DateTime.Now, 3),
    new Test("test_soft_2", "company2", new DateTime(2023, 2, 1), new DateTime(2023, 4, 10), 5),
    new Free("freeware_1", "GNU", new DateTime(1998, 10, 5)),
    new Commercial("com_1", "Microsoft", new DateTime(2022, 10, 4), 300, new DateTime(2024, 2, 3), 5)
};

foreach (Software s in softs)
{
    Console.WriteLine(s.Info());
}

Console.WriteLine("Valid softs only");
foreach (Software s in softs)
{
    if(s.IsValid())
        Console.WriteLine(s.Info());
}
