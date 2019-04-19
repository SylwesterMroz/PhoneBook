namespace PhoneBookTests
{
    using System;
    using NUnit.Framework;
    using PhoneBook;

    [TestFixture]
    public class PhoneTest
    {
        private Employee testEmployee;

        [SetUp]
        public void SetUp()
        {
            this.testEmployee = new Employee("Sylwek", "Mroz", 448, Locations.Koszalin, "973642743");
        }

        [Test]
        public void Employee_Check_All_Info()
        {
            var employee = this.testEmployee;
            Assert.Multiple(() =>
            {
                Assert.That(employee.Name, Is.EqualTo("Sylwek"));
                Assert.That(employee.SurName, Is.EqualTo("Mroz"));
                Assert.That(employee.BadgeID, Is.EqualTo(448));
                Assert.That(employee.Location, Is.EqualTo(Locations.Koszalin));
                Assert.That(employee.InternalPhone, Is.EqualTo("973642743"));
            });
        }

        [Test]
        public void PrintBasicInfo()
        {
            var employee = this.testEmployee;

            Assert.AreEqual(employee.PrintBasicInfo(), "Name: Sylwek InternalPhone: 973642743");
        }

        [Test]
        public void PrintFullInfo()
        {
            var employee2 = this.testEmployee;
            Assert.AreEqual(employee2.PrintFullInfo(), "Name: Sylwek Surname: Mroz BadgeID: 448 Department: Koszalin InternalPhone: 973642743");
        }

        [Test]
        public void PhoneBook_Add_Employees()
        {
            var employee = new Employee("Bartek", "En", 123, Locations.Koszalin, "00-4567");
            var employee2 = new Employee("Ania", "Zar", 456, Locations.Wroclaw, "00-1597");
            var employee3 = new Employee("Sylwek", "Mroz", 789, Locations.Szczecin, "00-1999");
            var employee4 = new Employee("Marcin", "Rek", 963, Locations.Szczecin, "00-1588");

            var phoneBook = new PhoneBook();

            phoneBook.AddEmployee(employee);
            phoneBook.AddEmployee(employee2);
            phoneBook.AddEmployee(employee3);
            phoneBook.AddEmployee(employee4);

            foreach (var element in phoneBook.EmployeesFromLocation(Locations.Szczecin))
            {
                Console.WriteLine(element.Name);
            }
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("I will always run");
        }
    }
}
