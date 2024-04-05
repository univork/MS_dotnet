//1.შექმენით 10 - ელემენტიანი დინამიური მასივი სტრიქონების მასივის საფუძველზე.
//დინამიურ მასივს დაუმატეთ ორი სტრიქონი. ეკრანზე გამოიტანეთ დინამიურ მასივში
//ელემენტების რაოდენობა და თვით დინამიური მასივი.

using System.Collections;

Console.WriteLine("Task 1");
List<string> arr1 = ["s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10"];
arr1.Add("s11");
arr1.Add("s12");
Console.WriteLine(arr1.Count);
foreach (string item in arr1)
{
    Console.Write(item);
    Console.Write(" ");
}



//2.შექმენით 10 - ელემენტიანი დინამიური მასივი სტრიქონების მასივის საფუძველზე.
//დინამიური მასივიდან წაშალეთ სამი სტრიქონი. ეკრანზე გამოიტანეთ დინამიურ მასივში
//ელემენტების რაოდენობა და თვით დინამიური მასივი.

Console.WriteLine("\nTask 2");
List<string> arr2 = ["s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10"];
arr2.Remove("s1");
arr2.Remove("s10");
Console.WriteLine(arr2.Count);
foreach (string item in arr2)
{
    Console.Write(item);
    Console.Write(" ");
}



//3.შექმენით 10 - ელემენტიანი დინამიური მასივი სტრიქონების მასივის საფუძველზე.
//დინამიურ მასივს ჩაუმატეთ სტრიქონი მე-2 პოზიციიდან. ეკრანზე გამოიტანეთ დინამიურ
//მასივში ელემენტების რაოდენობა და თვით დინამიური მასივი. 

Console.WriteLine("\nTask 3");
List<string> arr3 = ["s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10"];
arr3.Insert(1, "hii");
Console.WriteLine(arr3.Count);
foreach (string item in arr3)
{
    Console.Write(item);
    Console.Write(" ");
}



//4.შექმენით 10 - ელემენტიანი დინამიური მასივი სტრიქონების მასივის საფუძველზე.
//დინამიურ მასივში მოძებნეთ თქვენი სახელი. ეკრანზე გამოიტანეთ მოძებნილი ელემენტის
//ინდექსი, დინამიურ მასივში ელემენტების რაოდენობა და თვით დინამიური მასივი. 

Console.WriteLine("\nTask 4");
List<string> arr4 = ["s1", "s2", "s3", "s4", "gunter", "s6", "s7", "s8", "s9", "s10"];
Console.WriteLine(arr4.FindIndex(x => x == "gunter"));



//5.შექმენით 10 - ელემენტიანი ჰეშ - ცხრილი.ჰეშ - ცხრილს დაუმატეთ ორი ელემენტი. ეკრანზე
//გამოიტანეთ ჰეშ-ცხრილში ელემენტების რაოდენობა და ყველა გასაღები და ყველა სიდიდე. 

Console.WriteLine("\nTask 5");
Hashtable htbl1 = new() {
    { 1, "one" },
    { 2, "two" },
    { 3, "three" },
    { 4, "four" },
    { 5, "five" },
    { 6, "six" },
    { 7, "seven" },
    { 8, "eight" },
    { 9, "nine" },
    { 10, "ten" },
};
htbl1.Add(11, "eleven");
htbl1.Add(12, "twelve");
Console.WriteLine(htbl1.Count);
foreach (DictionaryEntry entry in htbl1) {
    Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
}



//6.შექმენით 10 - ელემენტიანი ჰეშ - ცხრილი.ჰეშ - ცხრილიდან წაშალეთ ორი ელემენტი.
//ეკრანზე გამოიტანეთ ჰეშ-ცხრილში ელემენტების რაოდენობა და ყველა გასაღები და ყველა
//სიდიდე. 

Console.WriteLine("\nTask 6");
Hashtable htbl2 = new() {
    { 1, "one" },
    { 2, "two" },
    { 3, "three" },
    { 4, "four" },
    { 5, "five" },
    { 6, "six" },
    { 7, "seven" },
    { 8, "eight" },
    { 9, "nine" },
    { 10, "ten" },
};
htbl2.Remove(10);
htbl2.Remove(2);
Console.WriteLine(htbl2.Count);
foreach (DictionaryEntry entry in htbl2) {
    Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
}



//7.შექმენით 10 - ელემენტიანი ჰეშ - ცხრილი.ჰეშ - ცხრილში შეასრულეთ ძებნა გასაღებისა და
//სიდიდის მიხედვით. ნაპოვნი გასაღები და სიდიდე ეკრანზე გამოიტანეთ. ეკრანზე გამოიტანეთ
//ჰეშ-ცხრილში ელემენტების რაოდენობა და ყველა გასაღები და ყველა სიდიდე.

Console.WriteLine("\nTask 7");
Hashtable htbl3 = new() {
    { 1, "one" },
    { 2, "two" },
    { 3, "three" },
    { 4, "four" },
    { 5, "five" },
    { 6, "six" },
    { 7, "seven" },
    { 8, "eight" },
    { 9, "nine" },
    { 10, "ten" },
};
if(htbl3.ContainsKey(1) && htbl3.ContainsValue("one"))
{
    Console.WriteLine(htbl3[1]);
}
Console.WriteLine(htbl3.Count);
foreach (DictionaryEntry entry in htbl3) {
    Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
}



//8.შექმენით 10 - ელემენტიანი რიგი.წაიკითხეთ და ეკრანზე გამოიტანეთ რიგის I ელემენტის
//მნიშვნელობა მისი წაშლის გარეშე. ეკრანზე გამოიტანეთ რიგში არსებული ელემენტების
//რაოდენობა და რიგის ყველა ელემენტი. რიგიდან ყველა ელემენტი წაშალეთ. 
Console.WriteLine("\nTask 8");
Queue<int> q1 = new([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
Console.WriteLine(q1.Peek());
Console.WriteLine(q1.Count);
foreach(int item in q1)
{
    Console.WriteLine(item);
}
q1.Clear();


//9.შექმენით 10 - ელემენტიანი რიგი.წაიკითხეთ და ეკრანზე გამოიტანეთ რიგის I ელემენტის
//მნიშვნელობა მისი წაშლის გარეშე. ეკრანზე გამოიტანეთ რიგში არსებული ელემენტების
//რაოდენობა და რიგის ყველა ელემენტი. რიგიდან ყველა ელემენტი წაშალეთ.

Console.WriteLine("\nTask 9");


//10.შექმენით 10 - ელემენტიანი სტეკი.წაიკითხეთ და ეკრანზე გამოიტანეთ სტეკის
//უკანასკნელი ელემენტის მნიშვნელობა მისი წაშლის გარეშე. ეკრანზე გამოიტანეთ სტეკში
//არსებული ელემენტების რაოდენობა და სტეკის ყველა ელემენტი. სტეკიდან ყველა ელემენტი
//წაშალეთ.

Console.WriteLine("\nTask 10");
Stack<int> stk = new([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
Console.WriteLine(stk.Peek());
Console.WriteLine(stk.Count);
foreach(int item in stk)
{
    Console.WriteLine(item);
}
stk.Clear();

