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
            Console.WriteLine("Find by: Location, Name, ID \nAdd new employee: type Add and then Name, Surname, BadgeID, Location, Internal Phone with spaces in between" +
                " \nor Quit to quit");
            string textFromLine;
            while (true)
            {
                textFromLine = Console.ReadLine();
                var commands = textFromLine.Split(' ');
                switch (commands[0])
                {
                    case "Location":
                        try
                        {
                            Console.WriteLine(AllEmployeesInLocation(commands[1]));
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("You did not put anything");
                        }
                        break;
                    case "Name":
                        try
                        {
                            Console.WriteLine(FindEmployeesByName(commands[1]));
                        }
                        catch(IndexOutOfRangeException)
                        {
                            Console.WriteLine("You did not put anything");
                        }
                        
                        break;
                    case "ID":
                        try
                        {
                            int findID = Convert.ToInt32(commands[1]);
                            Console.WriteLine(FindEmployeesByID(findID));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("BadgeID value accepts only numbers");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("You did not put anything");
                        }
                        
                        catch (OverflowException)
                        {
                            Console.WriteLine("BadgeID too long");
                        }

                        break;
                    case "Add":
                        try
                        {
                            int id = Convert.ToInt32(commands[3]);
                            Locations loc;
                            Enum.TryParse(commands[4], out loc);
                            AddNewEmployee(commands[1], commands[2], id, loc, commands[5]);
                            
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Some value was incorrect");
                        }
                        catch(IndexOutOfRangeException)
                        {
                            Console.WriteLine("You didn't put enough data");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("BadgeID too long");
                        }
                        break;

                    case "Quit":
                        return;
                    default:
                        Console.WriteLine("Unknown value. \nValid commands: Location, Name, ID, Add, Quit");
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
