#region KohneTaskFuncAction
#region Action
// Action<int> action = (x) => Console.WriteLine(x);
// action(10);
#endregion

#region Func
// Func<int, int, int> func = (x, y) => x + y;
// int result = func(1, 2);
// Console.WriteLine(result);
#endregion

#region Predicate
// Predicate<int> predicate = (x) => x > 0;
// bool result = predicate(10);
// Console.WriteLine(result);

#endregion

#region FuncName
// Func<string, string> funcName = (x) => ("Hello " + x);
// string result = funcName("FR");
// Console.WriteLine(result);
#endregion

#region PredicateEvenNumbers
// Predicate<int> predicateEvenNumbers = (x) => x % 2 == 0;
// int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
// foreach (int i in numbers)
// {
//     if (predicateEvenNumbers(i))
//     {
//         Console.WriteLine(i);
//     }
// }
#endregion

#region FuncEndirim

// Func<double, double> funcSale = (x) => x * 0.1;
// double result = funcSale(100);
// Console.WriteLine($"Sale: {result}");

#endregion

#region FuncCalculator

// Func<int, int, int> add = (x, y) => x + y;
// Func<int, int, int> subtract = (x, y) => x - y;
// Func<int, int, int> multiply = (x, y) => x * y;
// Func<int, int, int> divide = (x, y) => x / y;
//
// int result = add(1, 2);
// int result2 = subtract(1, 2);
// int result3 = multiply(1, 2);
// int result4 = divide(1, 2);
// Console.WriteLine(result);
// Console.WriteLine(result3);
// Console.WriteLine(result4);
// Console.WriteLine(result2);


#endregion

#region SadeTelebeSistemi
// string studentName = "Ruslan";
// int grade = 100;
//
// Predicate<int> gradePredicate = (x) => x >= 51;
// bool result = gradePredicate(grade);
// Console.WriteLine($"You passed: '{result}', your grade is {grade}");
// Func<int, string> gradeFunc = (x) => x switch
// {
//     >= 91 and <= 100 => "Excellent",
//     >= 81 and <= 90  => "Very Good",
//     >= 71 and <= 80  => "Good",
//     >= 51 and <= 70  => "Passed",
//     >= 0  and <= 50  => "Failed",
//     _ => "Invalid Grade"
// };
//
// string gradeResult = gradeFunc(grade);
// Console.WriteLine($"Your grade is: {gradeResult}");
//
// Action<string> printStudents = (x)  => Console.WriteLine(x);
// printStudents(gradeResult);

#endregion


#endregion

#region Yeni
#region ActionAd
// Action<string, int> FuncAd = (x, y) => Console.WriteLine($"Hello {x}, you are {y} years old");
// FuncAd("Ruslan", 20);
#endregion

#region GPA

using ConsoleApp1;

// Student student = new Student
// {
//     Name = "Ruslan",
//     GPA = 3.5
// };
// Student student2 = new Student
// {
//     Name = "Saleh",
//     GPA = 3.6
// };
// List<Student> students = new List<Student>
// {
//     student,
//     student2
// };
// Predicate<Student> predicate = (x) => x.GPA >= 3.5;
// List<Student> passedStudents = students.FindAll(predicate);
// {
//     Console.WriteLine(student.Name);
// }
// foreach (Student s in passedStudents)
// {
//     Console.WriteLine(s.Name);
//     Console.WriteLine(s.GPA);
// }


#endregion

#region Lambda
// static int Calculate(int a, int b, Func<int, int, int> operation)
// {
//     return operation(a, b);
// }
// Func<int, int, int> multiply = (a, b) => a * b;
// Func<int, int, int> divide = (a, b) => a / b;
// Func<int, int, int> add = (a, b) => a + b;
// Func<int, int, int> subtract = (a, b) => a - b;
//
// Calculate(1, 2, multiply);


#endregion


#endregion