namespace PhoneBookTests
{
    using NUnit.Framework;
    using PhoneBook;

    [TestFixture]
    public class PhoneTest
    {
        [Test]
        public void PrintBasicInfo()
        {
            var employee = new Employee("Sylwek", "Mroz", 448, Locations.Koszalin, "973642743");

            Assert.AreEqual(employee.PrintBasicInfo(), "Name: Sylwek InternalPhone: 973642743");
        }

        [Test]
        public void PrintFullInfo()
        {
            var employee2 = new Employee("Sylwek", "Mroz", 448, Locations.Koszalin, "973642743");
            Assert.AreEqual(employee2.PrintFullInfo(), "Name: Sylwek Surname: Mroz BadgeID: 448 Department: Koszalin InternalPhone: 973642743");
        }
    }
}
