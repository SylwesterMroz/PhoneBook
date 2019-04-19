namespace PhoneBook
{
    using System;

    public class Program
    {
        private static PhoneBook myPhoneBook = new PhoneBook();

        public static void Main(string[] args)
        {
            SeedPhoneBookWithData();
            Console.WriteLine("Phone book");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Find by: Location, Name, ID \nor Add new employee \nor Quit");
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
                    case "Name":
                        Console.WriteLine(FindEmployeesByName(commands[1]));
                        break;
                    case "ID":
                        int findID = Convert.ToInt32(commands[1]);
                        Console.WriteLine(FindEmployeesByID(findID));
                        break;
                    case "Add":
                        int id = Convert.ToInt32(commands[3]);
                        Locations loc;
                        Enum.TryParse(commands[4], out loc);
                        AddNewEmployee(commands[1], commands[2], id, loc, commands[5]);
                        break;
                    case "Quit":
                        return;
                    default:
                        Console.WriteLine("Unknown value");
                        break;
                }
            }
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

        private static string AllEmployeesInLocation(string location)
        {
            Locations parsedDepartment;
            Enum.TryParse(location, out parsedDepartment);
            var employeesFromLocation = myPhoneBook.EmployeesFromLocation(parsedDepartment);
            string result = string.Empty;
            employeesFromLocation.ForEach(x => result += $"{x.PrintFullInfo()}\n");
            return result;
        }

        private static string FindEmployeesByName(string findName)
        {
            
            var employeesName = myPhoneBook.FindByName(findName);
            string result = string.Empty;
            employeesName.ForEach(x => result += $"{x.PrintFullInfo()}\n");
            return result;
        }

        private static void AddNewEmployee(string name, string surName, int badgeID, Locations department, string internalPhone)
        {
            var employee5 = new Employee(name, surName, badgeID, department, internalPhone);
            myPhoneBook.AddEmployee(employee5);
            Console.WriteLine(employee5.PrintFullInfo());
        
        }

        private static string FindEmployeesByID(int findID)
        {

            var employeesID = myPhoneBook.FindByID(findID);
            string result = string.Empty;
            employeesID.ForEach(x => result += $"{x.PrintFullInfo()}\n");
            return result;
        }

    }
}
