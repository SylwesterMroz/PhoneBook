namespace PhoneBook
{
    public class Employee
    {
        public Employee(string name, string surName, int badgeID, Locations department, string internalPhone)
        {
            this.Name = name;
            this.SurName = surName;
            this.BadgeID = badgeID;
            this.Location = department;
            this.InternalPhone = internalPhone;
            this.PrintBasicInfo();
        }

        public string Name { get; }

        public string SurName { get; }

        public int BadgeID { get; }

        public Locations Location { get; }

        public string InternalPhone { get; }

        public string Basic { get; }

        public string PrintBasicInfo()
        {
            return $"Name: {Name} InternalPhone: {InternalPhone}";
        }

        public string PrintFullInfo()
        {
            return $"Name: {Name} Surname: {SurName} BadgeID: {BadgeID} Department: {Location} InternalPhone: {InternalPhone}";      
        }
    }
}