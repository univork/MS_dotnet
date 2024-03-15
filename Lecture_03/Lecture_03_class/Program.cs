using Lecture_03_class;


Console.WriteLine("TRAIN");
Train train = new Train();
train.setVars(10, 20, 40, 100);
train.getVars();
train.income();


Console.WriteLine("\nCar");
Car car = new Car("blue", 4, "Abraham Lincoln", "Ford");
car.GetInfo();


Console.WriteLine("\nMyClass");
MyClass_2 myclass = new MyClass_2();
myclass.GetMinMax([1, 2, 3]);


Console.WriteLine("\nCourse");
Course course = new Course();
course.AddSubject("Math");
course.PrintSubjects();
