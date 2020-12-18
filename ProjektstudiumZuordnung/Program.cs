using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
namespace ProjektstudiumZuordnung
{
    class Program
    {
        public static List<Initiator> initiatorList { get; set; }
        public static List<Project> projectList { get; set; }
        public static List<Student> studentList { get; set; }

        private static string test_number = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Begin Initiation");
            GetData();
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
                    Console.WriteLine("Go");
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
                    Console.WriteLine("TBD");
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
                    Console.WriteLine("TBD");
                    break;
            }
        }
    }
}
