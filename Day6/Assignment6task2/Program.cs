using Assignment6task2.Models;

namespace Assignment6task2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Events events = new Events();

            events.RegWDWorkshop(1684, new Student("Affan", "BE"));
            events.RegWDWorkshop(1685, new Student("Atharva", "BE"));
            events.RegWDWorkshop(1686, new Student("Pratik", "BE"));
            events.RegWDWorkshop(1685, new Student("Nikhil", "BE"));
            events.RegWDWorkshop(1687, new Student("Kapil", "BE"));

            events.WDStudentList();

            events.RegUIUXWorkshop(1685, new Student("Pratik", "BE"));
            events.RegUIUXWorkshop(1684, new Student("Pranit", "BE"));
            events.RegUIUXWorkshop(1685, new Student("Nikhil", "BE"));
            events.RegUIUXWorkshop(1686, new Student("Atharva", "BE"));
            events.RegUIUXWorkshop(1687, new Student("Kapil", "BE"));

            events.UIUXStudentList();


            events.RegRoboWorkshop(1687, new Student("Affan", "BE"));
            events.RegRoboWorkshop(1684, new Student("Pranit", "BE"));
            events.RegRoboWorkshop(1685, new Student("Atharva", "BE"));
            events.RegRoboWorkshop(1686, new Student("Nikhil", "BE"));
            events.RegRoboWorkshop(1685, new Student("Sumit", "BE"));

            events.RoboStudentList();
        }
    }
}
