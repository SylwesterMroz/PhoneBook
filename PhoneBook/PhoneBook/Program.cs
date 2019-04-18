namespace PhoneBook
{
    using System;
    public class Program
    {
        public static PhoneBook myPhoneBook = new PhoneBook();

        public static void Main(string[] args)
        {
            SeedPhoneBookWithData();
            Console.WriteLine("Phone book");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Write Location or Quit");
            string textFromLine;
            while (true)
            {
                textFromLine = Console.ReadLine();
                var commands = textFromLine.Split(' ');
                switch (commands[0])
                {
                    case "Location":
                        Console.WriteLine(AllEmployeesInLocation(commands[1]));
                            break;
                    case "Quit":
                        return;
                    default:
                        Console.WriteLine("Unknown value");
                        break;
                }
            }



        }

        private static string AllEmployeesInLocation(string location)
        {
            Locations parsedDepartment;
            Enum.TryParse(location, out parsedDepartment);
            var employeesFromLocation = myPhoneBook.EmployeesFromLocation(parsedDepartment);
            string result = string.Empty;
            employeesFromLocation.ForEach(x => result +=$"{x.PrintFullInfo()}\n");
            return result;
        }

        public static void SeedPhoneBookWithData()
        {
            var employee = new Employee("Bartek", "En", 123, Locations.Koszalin, "00-4567");
            var employee2 = new Employee("Ania", "Zar", 456, Locations.Wroclaw, "00-1597");
            var employee3 = new Employee("Sylwek", "Mroz", 789, Locations.Szczecin, "00-1999");
            var employee4 = new Employee("Marcin", "Rek", 963, Locations.Szczecin, "00-1588");

            myPhoneBook.AddEmployee(employee);
            myPhoneBook.AddEmployee(employee2);
            myPhoneBook.AddEmployee(employee3);
            myPhoneBook.AddEmployee(employee4);
        }
    }
}
