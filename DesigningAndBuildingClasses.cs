public class DesigningAndBuildingClasses
{
    /* Designing and Building Classes using object-oriented principles
    1. Write a program that that demonstrates use of four basic principles of object-oriented programming
    /Abstraction/, /Encapsulation/, /Inheritance/ and /Polymorphism/. */
    //Abstraction
    public abstract class Vehicle2
    {
        public abstract void Start();
    }

    //Encapsulation
    public class Account
    {
        private double balance;

        public void Deposit(double amount)
        {
            if (amount > 0)
                balance += amount;
        }

        public double GetBalance()
        {
            return balance;
        }
    }

    //Inheritance
    public class Vehicle
    {
        public virtual void Drive()
        {
            Console.WriteLine("Vehicle is moving");
        }
    }

    public class Car : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Car is driving");
        }

        public void Drive(int speed)
        {
            Console.WriteLine($"Car is driving at {speed} km/h");
        }
    }

    //Polymorphism
    public class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Employee is working.");
        }
    }

    public class Manager : Employee
    {
        public override void Work()
        {
            Console.WriteLine("Manager is managing the team.");
        }
    }

    public class Developer : Employee
    {
        public override void Work()
        {
            Console.WriteLine("Developer is writing code.");
        }
    }

    /* 2. Use /Abstraction/ to define different classes for each person type such as Student and Instructor.
    These classes should have behavior for that type of person. */
    public abstract class Human
    {
        public string Name;

        public Human(string name)
        {
            Name = name;
        }

        public abstract void Act();
    }

    public class Child : Human
    {
        public Child(string name) : base(name)
        {
        }

        public override void Act()
        {
            Console.WriteLine("Studying");
        }
    }

    public class Teacher : Human
    {
        public Teacher(string name) : base(name)
        {
        }

        public override void Act()
        {
            Console.WriteLine("Teaching");
        }
    }

    /* 3. Use /Encapsulation/ to keep many details private in each class. */

    class BankAccount
    {
        private double balance;

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public double GetBalance()
        {
            return balance;
        }
    }

    /* 4. Use /Inheritance/ by leveraging the implementation already created in the Person class to save code in Student and Instructor classes. */
    public class Transportation
    {
        public virtual void Drive()
        {
            Console.WriteLine("Transportation is moving");
        }
    }

    public class Train : Transportation
    {
        public override void Drive()
        {
            Console.WriteLine("Train is driving");
        }

        public void Drive(int speed)
        {
            Console.WriteLine($"Train is driving at {speed} km/h");
        }
    }

    /* 5. Use /Polymorphism/ to create virtual methods that derived classes could override to create specific behavior such as salary calculations. */
    class People
    {
        public virtual double GetSalary()
        {
            return 0;
        }
    }

    class Saler : People
    {
        public override double GetSalary()
        {
            return 5000;
        }
    }


    /* 6. Make sure to create appropriate /interfaces/ such as
    ICourseService, IStudentService, IInstructorService, IDepartmentService, IPersonService, IPersonService (should have person specific methods).
    IStudentService, IInstructorService should inherit from IPersonService.
    Person
    Calculate Age of the Person.
    Calculate the Salary of the person, Use decimal for salary.
    Salary cannot be negative number.
    Can have multiple Addresses, should have method to get addresses.
    Instructor
    Belongs to one Department, and he can be Head of the Department.
    Instructor will have added bonus salary based on his experience, calculate his years of experience based on Join Date.
    Student
    Can take multiple courses.
    Calculate student GPA based on grades for courses.
    Each course will have grade from A to F.
    Course
    Will have list of enrolled students.
    Department
    Will have one Instructor as head.
    Will have Budget for school year (start and end Date Time).
    Will offer list of courses. */
    interface IPersonService
    {
        int GetAge();
        decimal GetSalary();
        string[] GetAddresses();
    }

    interface IStudentService : IPersonService
    {
        double GetGPA();
    }

    interface IInstructorService : IPersonService
    {
        int GetExperience();
        bool IsHead();
    }

    abstract class Person : IPersonService
    {
        public DateTime Birth;
        private decimal salary;
        private List<string> addresses = new();

        public int GetAge()
        {
            return DateTime.Now.Year - Birth.Year;
        }

        public decimal GetSalary()
        {
            return salary;
        }

        public void SetSalary(decimal s)
        {
            if (s >= 0) salary = s;
        }

        public void AddAddress(string a)
        {
            addresses.Add(a);
        }

        public string[] GetAddresses()
        {
            return addresses.ToArray();
        }
    }

    class Student : Person, IStudentService
    {
        public List<char> Grades = new();

        public double GetGPA()
        {
            if (Grades.Count == 0)
            {
                return 0;
            }

            double total = 0;

            foreach (char g in Grades)
            {
                if (g == 'A')
                {
                    total += 4;
                } else if (g == 'B')
                {
                    total += 3;
                } else if (g == 'C')
                {
                    total += 2;
                } else if (g == 'D')
                {
                    total += 1;
                } else
                {
                    total += 0;
                }
            }

            return total / Grades.Count;
        }
    }

    class Instructor : Person, IInstructorService
    {
        public DateTime Join;
        public Department Dept;

        public int GetExperience()
        {
            return DateTime.Now.Year - Join.Year;
        }

        public bool IsHead()
        {
            return Dept?.Head == this;
        }

        public new decimal GetSalary()
        {
            return base.GetSalary() + GetExperience() * 100;
        }
    }

    class Course
    {
        public List<Student> Students = new();
    }

    class Department
    {
        public Instructor Head;
        public List<Course> Courses = new();
    }

    /* 7. Try creating the two classes below, and make a simple program to work with them, as described below.
    Create a Color class:
    On a computer, colors are typically represented with a red, green, blue, and alpha (transparency) value, usually in the range of 0 to 255. Add these as instance variables.
    A constructor that takes a red, green, blue, and alpha value.
    A constructor that takes just red, green, and blue, while alpha defaults to 255 (opaque).
    Methods to get and set the red, green, blue, and alpha values from a Color instance.
    A method to get the grayscale value for the color, which is the average of the red, green and blue values.
    Create a Ball class:
    The Ball class should have instance variables for size and color (the Color class you just created).
    Let’s also add an instance variable that keeps track of the number of times it has been thrown.
    Create any constructors you feel would be useful.
    Create a Pop method, which changes the ball’s size to 0.
    Create a Throw method that adds 1 to the throw count, but only if the ball hasn’t been popped (has a size of 0).
    A method that returns the number of times the ball has been thrown.
    Write some code in your Main method to create a few balls, throw them around a few times, pop a few, and try to throw them again,
    and print out the number of times that the balls have been thrown. (Popped balls shouldn’t have changed.) */
    public static void Seven()
    {
        Color red = new Color(255, 0, 0);
        Color green = new Color(0, 255, 0, 200);
        Color blue = new Color(0, 0, 255);

        Ball ball1 = new Ball(10, red);
        Ball ball2 = new Ball(8, green);
        Ball ball3 = new Ball(5, blue);

        ball1.Throw();
        ball1.Throw();
        ball2.Throw();
        ball3.Pop();
        ball3.Throw();

        Console.WriteLine("Ball 1 throws: " + ball1.GetThrowCount());
        Console.WriteLine("Ball 2 throws: " + ball2.GetThrowCount());
        Console.WriteLine("Ball 3 throws: " + ball3.GetThrowCount());
    }

    class Color
    {
        private int red;
        private int green;
        private int blue;
        private int alpha;

        public Color(int r, int g, int b, int a)
        {
            red = r;
            green = g;
            blue = b;
            alpha = a;
        }

        public Color(int r, int g, int b)
        {
            red = r;
            green = g;
            blue = b;
            alpha = 255;
        }

        public int GetRed()
        {
            return red;
        }

        public void SetRed(int value)
        {
            red = value;
        }

        public int GetGreen()
        {
            return green;
        }

        public void SetGreen(int value)
        {
            green = value;
        }

        public int GetBlue()
        {
            return blue;
        }

        public void SetBlue(int value)
        {
            blue = value;
        }

        public int GetAlpha()
        {
            return alpha;
        }

        public void SetAlpha(int value)
        {
            alpha = value;
        }

        public int GetGrayScale()
        {
            return (red + green + blue) / 3;
        }
    }

    class Ball
    {
        private int size;
        private Color color;
        private int throwCount;

        public Ball(int size, Color color)
        {
            this.size = size;
            this.color = color;
            throwCount = 0;
        }

        public void Pop()
        {
            size = 0;
        }

        public void Throw()
        {
            if (size > 0)
            {
                throwCount++;
            }
        }

        public int GetThrowCount()
        {
            return throwCount;
        }
    }
}
