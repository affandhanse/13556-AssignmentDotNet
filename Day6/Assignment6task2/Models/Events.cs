using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Exception;

namespace Assignment6task2.Models
{
    internal class Events
    {

        Dictionary<int, Student> WebDevWorkshop = new Dictionary<int, Student>();
        Dictionary<int, Student> RoboticsAutomationWorkshop = new Dictionary<int, Student>();
        Dictionary<int, Student> UIUXWorkshop = new Dictionary<int, Student>();



        //web dev workhop methods
        public void RegWDWorkshop(int studentId, Student student)
        {
            try

            {

                if (!FindStudentIdWD(studentId))
                {

                    WebDevWorkshop.Add(studentId, student);
                    Console.WriteLine($"Student ID:{studentId} Registered succesfully  for Web Dev Workshop");
                    Console.WriteLine();

                }
                else
                {
                    throw new IdAlreadyExceptionException($"Student ID:{studentId} is already Registered for Web Dev Workshop");
                }
            }
            catch (IdAlreadyExceptionException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public bool FindStudentIdWD(int studentId)
        {
            return WebDevWorkshop.ContainsKey(studentId);
        }

        public void WDStudentList()
        {
            Console.WriteLine();
            Console.WriteLine("Student List of Web Dev Workshop:");
            foreach (KeyValuePair<int, Student> wDW in WebDevWorkshop)
            {
                Console.WriteLine($"StudentId:{wDW.Key}\tStudent Name:{wDW.Value.StudentName}\t{wDW.Value.StudentCourseName}");
            }
        }




        //ui ux workshop 


        public void RegUIUXWorkshop(int studentId, Student student)
        {
            try
            {
                if (!FindStudentIdUIUX(studentId))
                {

                    UIUXWorkshop.Add(studentId, student);
                    Console.WriteLine($"Student ID:{studentId} succesfully Register for UI/UX Workshop");
                    Console.WriteLine();

                }
                else
                {

                    throw new IdAlreadyExceptionException($"Student ID:{studentId} already Register for UI/UX Workshop!!");

                }

            }
            catch (IdAlreadyExceptionException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UIUXStudentList()
        {
            Console.WriteLine();
            Console.WriteLine("Student List of UI/UX Workshop:");
            foreach (KeyValuePair<int, Student> uiUxW in UIUXWorkshop)
            {
                Console.WriteLine($"StudentId:{uiUxW.Key}\tStudent Name:{uiUxW.Value.StudentName}\t{uiUxW.Value.StudentCourseName}");
            }
        }
        public bool FindStudentIdUIUX(int studentId)
        {
            return UIUXWorkshop.ContainsKey(studentId);
        }


        //robotics workshop methods
        public void RegRoboWorkshop(int studentId, Student student)
        {
            try
            {
                if (!FindStudentIdRA(studentId))
                {

                    RoboticsAutomationWorkshop.Add(studentId, student);
                    Console.WriteLine($"Student ID:{studentId} succesfully Register for Robotics Automation Workshop");
                    Console.WriteLine();
                }
                else
                {
                    throw new IdAlreadyExceptionException($"Student ID:{studentId} already Register for Robotics Automation Workshop!!");
                }
            }
            catch (IdAlreadyExceptionException e)
            {
                Console.WriteLine(e.Message);
            }
        }



        public void RoboStudentList()
        {
            Console.WriteLine();
            Console.WriteLine("Student List of Robotics Automation Workshop:");
            foreach (KeyValuePair<int, Student> rAW in RoboticsAutomationWorkshop)
            {
                Console.WriteLine($"StudentId:{rAW.Key}\tStudent Name:{rAW.Value.StudentName}\t{rAW.Value.StudentCourseName}");
            }
        }

        public bool FindStudentIdRA(int studentId)
        {
            return RoboticsAutomationWorkshop.ContainsKey(studentId);
        }
    }
}
