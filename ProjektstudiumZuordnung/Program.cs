using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
namespace ProjektstudiumZuordnung
{
    class Program
    {
        public static List<Initiator> initiatorList = new List<Initiator>();
        public static List<Project> projectList = new List<Project>();
        public static List<Student> studentList = new List<Student>();

        private static string test_number = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Begin Initiation");
            GetData();
            Console.WriteLine(initiatorList);
            Console.WriteLine(projectList);
            Console.WriteLine(studentList);
            Console.WriteLine("Loaded Data");
        }
        static void GetData()
        {
            InitStudents();
            InitInitiators();
            InitProjects();
        }
        static void InitStudents()
        {
            switch (test_number)
            {
                case "two":
                    Console.WriteLine("TBD");
                    break;
                case "three":
                    Console.WriteLine("TBD");
                    break;
                default:
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.ORGANISATION), new Favourite(1, Job.PRODUKTION), new Favourite(0, Job.KONZEPTION) }, DegreeCourse.OMB, 0, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(1, Job.ORGANISATION), new Favourite(0, Job.ORGANISATION), new Favourite(2, Job.KONZEPTION) }, DegreeCourse.OMB, 1, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.PRODUKTION), new Favourite(2, Job.PROJEKTMANAGEMENT), new Favourite(1, Job.ORGANISATION) }, DegreeCourse.MIB, 2, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(2, Job.KONZEPTION), new Favourite(0, Job.PROJEKTMANAGEMENT), new Favourite(1, Job.PROJEKTMANAGEMENT) }, DegreeCourse.MKB, 3, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.KONZEPTION), new Favourite(2, Job.PROJEKTMANAGEMENT), new Favourite(2, Job.PRODUKTION) }, DegreeCourse.MIB, 5, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(2, Job.PRODUKTION), new Favourite(0, Job.PROJEKTMANAGEMENT), new Favourite(0, Job.KONZEPTION) }, DegreeCourse.OMB, 6, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(2, Job.ORGANISATION), new Favourite(0, Job.ORGANISATION), new Favourite(1, Job.ORGANISATION) }, DegreeCourse.MIB, 7, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.PROJEKTMANAGEMENT), new Favourite(1, Job.ORGANISATION), new Favourite(2, Job.ORGANISATION) }, DegreeCourse.MIB, 8, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(1, Job.KONZEPTION), new Favourite(2, Job.PROJEKTMANAGEMENT), new Favourite(0, Job.PROJEKTMANAGEMENT) }, DegreeCourse.OMB, 9, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(1, Job.ORGANISATION), new Favourite(0, Job.ORGANISATION), new Favourite(2, Job.PROJEKTMANAGEMENT) }, DegreeCourse.MKB, 10, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.KONZEPTION), new Favourite(1, Job.ORGANISATION), new Favourite(1, Job.KONZEPTION) }, DegreeCourse.MKB, 11, false, -1));
                    break;
            }
        }
        static void InitInitiators()
        {
            switch (test_number)
            {
                case "two":
                    Console.WriteLine("TBD");
                    break;
                case "three":
                    Console.WriteLine("TBD");
                    break;
                default:
                    initiatorList.Add(new Initiator(DegreeCourse.MKB, 4, 1));
                    break;
            }
        }
        static void InitProjects()
        {
            switch (test_number)
            {
                case "two":
                    Console.WriteLine("TBD");
                    break;
                case "three":
                    Console.WriteLine("TBD");
                    break;
                default:
                    projectList.Add(new Project(4, new List<Job>() { Job.PROJEKTMANAGEMENT, Job.ORGANISATION, Job.PRODUKTION, Job.KONZEPTION }, new List<AStudent>(), 0, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }));
                    projectList.Add(new Project(3, new List<Job>() { Job.ORGANISATION, Job.KONZEPTION, Job.PRODUKTION }, new List<AStudent>(), 1, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }));
                    projectList.Add(new Project(4, new List<Job>() { Job.PROJEKTMANAGEMENT, Job.ORGANISATION, Job.PRODUKTION, Job.KONZEPTION }, new List<AStudent>(), 2, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }));
                    break;
            }
        }
    }
}
