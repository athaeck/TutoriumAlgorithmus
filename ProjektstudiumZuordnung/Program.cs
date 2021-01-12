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
        public static List<Student> leftStudentList = new List<Student>();

        private static int unAssignetStudents { get; set; }
        private static string test_number = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Begin Initiation");
            GetData();
            Console.WriteLine("Loaded Data");
            AddingInitiatorsToProjects();
            Console.WriteLine("Added Initiaros");
            Console.WriteLine("Start Adding Student to Projects");
            AddingStudentsToProjects();
            Console.WriteLine("Added Students to Projects");
            Console.WriteLine("Allocate remaining Students");
            RemainingAllocation();
            Console.WriteLine("Allocated remaining Students");
            Console.WriteLine("Output groups");
            ResultOfAlgorithm();

        }
        static void GetData()
        {
            InitStudents();
            InitInitiators();
            InitProjects();
            foreach (Student s in studentList)
            {
                s.SetOriginalFavourites();
            }
        }
        static void InitStudents()
        {
            switch (test_number)
            {
                case "two":
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.ORGANISATION), new Favourite(1, Job.ORGANISATION), new Favourite(2, Job.PRODUKTION) }, DegreeCourse.OMB, 0, false, -1));

                    studentList.Add(new Student(new List<Favourite>() { new Favourite(2, Job.KONZEPTION), new Favourite(0, Job.KONZEPTION), new Favourite(1, Job.PRODUKTION) }, DegreeCourse.MIB, 2, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.PROJEKTMANAGEMENT), new Favourite(0, Job.ORGANISATION), new Favourite(1, Job.ORGANISATION) }, DegreeCourse.OMB, 3, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(1, Job.PROJEKTMANAGEMENT), new Favourite(2, Job.KONZEPTION), new Favourite(0, Job.PRODUKTION) }, DegreeCourse.MKB, 4, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.ORGANISATION), new Favourite(0, Job.PRODUKTION), new Favourite(2, Job.PROJEKTMANAGEMENT) }, DegreeCourse.OMB, 5, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(2, Job.PROJEKTMANAGEMENT), new Favourite(1, Job.PROJEKTMANAGEMENT), new Favourite(0, Job.KONZEPTION) }, DegreeCourse.MIB, 6, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(2, Job.KONZEPTION), new Favourite(2, Job.ORGANISATION), new Favourite(0, Job.KONZEPTION) }, DegreeCourse.MKB, 7, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.KONZEPTION), new Favourite(1, Job.ORGANISATION), new Favourite(0, Job.PRODUKTION) }, DegreeCourse.MKB, 8, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(1, Job.KONZEPTION), new Favourite(0, Job.PROJEKTMANAGEMENT), new Favourite(2, Job.KONZEPTION) }, DegreeCourse.OMB, 9, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(1, Job.ORGANISATION), new Favourite(1, Job.KONZEPTION), new Favourite(1, Job.PROJEKTMANAGEMENT) }, DegreeCourse.MIB, 10, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(2, Job.KONZEPTION), new Favourite(0, Job.ORGANISATION), new Favourite(0, Job.PROJEKTMANAGEMENT) }, DegreeCourse.MKB, 11, false, -1));

                    break;
                case "three":
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(1, Job.ORGANISATION), new Favourite(1, Job.ORGANISATION), new Favourite(2, Job.ORGANISATION) }, DegreeCourse.OMB, 0, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.KONZEPTION), new Favourite(0, Job.PROJEKTMANAGEMENT), new Favourite(2, Job.PROJEKTMANAGEMENT) }, DegreeCourse.OMB, 1, false, -1));

                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.PROJEKTMANAGEMENT), new Favourite(0, Job.PROJEKTMANAGEMENT), new Favourite(0, Job.KONZEPTION) }, DegreeCourse.MIB, 3, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(2, Job.PROJEKTMANAGEMENT), new Favourite(2, Job.PRODUKTION), new Favourite(2, Job.KONZEPTION) }, DegreeCourse.MKB, 4, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.PROJEKTMANAGEMENT), new Favourite(0, Job.KONZEPTION), new Favourite(0, Job.ORGANISATION) }, DegreeCourse.MKB, 5, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(2, Job.PROJEKTMANAGEMENT), new Favourite(2, Job.PROJEKTMANAGEMENT), new Favourite(1, Job.KONZEPTION) }, DegreeCourse.MKB, 6, false, -1));

                    studentList.Add(new Student(new List<Favourite>() { new Favourite(1, Job.KONZEPTION), new Favourite(1, Job.KONZEPTION), new Favourite(2, Job.PRODUKTION) }, DegreeCourse.MIB, 8, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.ORGANISATION), new Favourite(0, Job.ORGANISATION), new Favourite(2, Job.PRODUKTION) }, DegreeCourse.MIB, 9, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(2, Job.PRODUKTION), new Favourite(2, Job.PROJEKTMANAGEMENT), new Favourite(1, Job.PROJEKTMANAGEMENT) }, DegreeCourse.MKB, 10, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(1, Job.ORGANISATION), new Favourite(1, Job.PROJEKTMANAGEMENT), new Favourite(1, Job.ORGANISATION) }, DegreeCourse.OMB, 11, false, -1));
                    break;
                default:
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(0, Job.ORGANISATION), new Favourite(1, Job.PRODUKTION), new Favourite(0, Job.KONZEPTION) }, DegreeCourse.OMB, 0, false, -1));
                    studentList.Add(new Student(new List<Favourite>() { new Favourite(1, Job.ORGANISATION), new Favourite(0, Job.ORGANISATION), new Favourite(2, Job.PRODUKTION) }, DegreeCourse.OMB, 1, false, -1));
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
                    initiatorList.Add(new Initiator(DegreeCourse.MIB, 1, 1));
                    break;
                case "three":
                    initiatorList.Add(new Initiator(DegreeCourse.MIB, 2, 1));
                    initiatorList.Add(new Initiator(DegreeCourse.OMB, 7, 1));
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
                    projectList.Add(new Project(4, new List<Job>() { Job.PROJEKTMANAGEMENT, Job.ORGANISATION, Job.PRODUKTION, Job.KONZEPTION }, new List<Student>(), 0, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }, new List<Initiator>()));
                    projectList.Add(new Project(3, new List<Job>() { Job.PROJEKTMANAGEMENT, Job.ORGANISATION, Job.KONZEPTION }, new List<Student>(), 0, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }, new List<Initiator>()));
                    projectList.Add(new Project(4, new List<Job>() { Job.PROJEKTMANAGEMENT, Job.ORGANISATION, Job.PRODUKTION, Job.KONZEPTION }, new List<Student>(), 0, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }, new List<Initiator>()));
                    break;
                case "three":
                    projectList.Add(new Project(3, new List<Job>() { Job.PROJEKTMANAGEMENT, Job.ORGANISATION, Job.KONZEPTION }, new List<Student>(), 0, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }, new List<Initiator>()));
                    projectList.Add(new Project(3, new List<Job>() { Job.PROJEKTMANAGEMENT, Job.ORGANISATION, Job.KONZEPTION }, new List<Student>(), 0, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }, new List<Initiator>()));
                    projectList.Add(new Project(4, new List<Job>() { Job.PROJEKTMANAGEMENT, Job.ORGANISATION, Job.PRODUKTION, Job.KONZEPTION }, new List<Student>(), 0, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }, new List<Initiator>()));
                    break;
                default:
                    projectList.Add(new Project(4, new List<Job>() { Job.PROJEKTMANAGEMENT, Job.ORGANISATION, Job.PRODUKTION, Job.KONZEPTION }, new List<Student>(), 0, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }, new List<Initiator>()));
                    projectList.Add(new Project(3, new List<Job>() { Job.ORGANISATION, Job.KONZEPTION, Job.PRODUKTION }, new List<Student>(), 1, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }, new List<Initiator>()));
                    projectList.Add(new Project(4, new List<Job>() { Job.PROJEKTMANAGEMENT, Job.ORGANISATION, Job.PRODUKTION, Job.KONZEPTION }, new List<Student>(), 2, new Distribute[3] { new Distribute(DegreeCourse.MIB, 1), new Distribute(DegreeCourse.OMB, 1), new Distribute(DegreeCourse.MKB, 1) }, new List<Initiator>()));
                    break;
            }
        }
        static void AddingInitiatorsToProjects()
        {
            foreach (Initiator init in initiatorList)
            {
                int groupeID = init.groupeID;
                Project project = projectList[groupeID];
                project.SetInitatorToStudentList(init);
            }
            foreach (Project project in projectList)
            {
                int length = project.students.Count;
                if (length > 2)
                {
                    Console.WriteLine("ERROR!!! to(o) many Initiators!");
                }
                else
                {
                    Console.WriteLine("Assignment was successfull");
                }
            }
        }
        static void AddingStudentsToProjects()
        {
            unAssignetStudents = studentList.Count;
            while (unAssignetStudents > 0)
            {
                int _student;
                for (_student = 0; _student < studentList.Count; _student++)
                {


                    int activeFavourite = 0;
                    Student student = studentList[_student];
                    if (student.matched == false)
                    {
                        Console.WriteLine("Student: " + studentList[_student].iD + " " + "is on turn");
                        Favourite favourite;
                        if (student.favouriteList.Count > 0)
                        {
                            favourite = student.favouriteList[activeFavourite];



                            Project project = projectList[favourite.projectID];


                            if (project.IsSpaceLeftInProject() == true)
                            {
                                if (project.IsJobFree(favourite.job))
                                {
                                    if (project.DegreeCourseDistributeCheck(student))
                                    {

                                        project.SetStudentToStudentList(student);
                                        // studentList.RemoveAt(_student);
                                        unAssignetStudents--;

                                    }
                                    else
                                    {
                                        student.RemoveFavourite(activeFavourite);
                                    }
                                }
                                else
                                {
                                    StudentVsStudent(favourite, project, student);

                                    // student.RemoveFavourite(activeFavourite);

                                }
                            }
                            else
                            {
                                StudentVsStudent(favourite, project, student);
                            }
                        }
                        else
                        {
                            SwitchStudentInUnAssigntList(student);
                            unAssignetStudents--;
                            Console.WriteLine("switch");
                        }
                    }
                    Console.WriteLine("### Zyklus durch ###");
                }
            }
        }
        static void SwitchStudentInUnAssigntList(Student student)
        {
            bool b = false;
            foreach (Student added in leftStudentList)
            {
                if(added.iD == student.iD){
                    b = true;
                }
            }
            if(b == false){
            leftStudentList.Add(student);
            }
        }
        static void StudentVsStudent(Favourite currentStudentFavourite, Project relatedProject, Student student)
        {
            Student oldStudent = relatedProject.GetOldStudent(currentStudentFavourite);
            switch (StudentVsStudentCaseFinder(currentStudentFavourite, relatedProject, student, oldStudent))
            {
                case 1:
                    Console.WriteLine("Identisch");
                    if (relatedProject.GetOldStudentStuGa(oldStudent).degreeCourse == student.degreeCourse)
                    {
                        Console.WriteLine("zahl " + CoinFlip());
                        if (CoinFlip() > 50)
                        {
                            //Stu bekommt platz

                            student.SetProject(oldStudent.projectID);
                            oldStudent.UnmatchProject();

                        }
                        else
                        {
                            student.RemoveFavourite(0);
                            //Stu bekommt platz nicht
                        }
                    }
                    else
                    {
                        //Stu bekommt platz nicht
                        student.RemoveFavourite(0);

                    }
                    break;
                case 2:
                    Console.WriteLine("Alt gewinnt ");
                    student.RemoveFavourite(0);
                    break;
                case 3:
                    Console.WriteLine("neu gewinnt ");
                    if (relatedProject.DegreeCourseDistributeCheck(student))
                    {
                        relatedProject.SetStudentToStudentList(student);
                        unAssignetStudents--;
                    }
                    else
                    {
                        student.RemoveFavourite(0);
                    }
                    break;
            }
        }
        static int StudentVsStudentCaseFinder(Favourite currentStudentFavourite, Project relatedProject, Student student, Student oldStudent)
        {
            // Student oldStudent = relatedProject.GetOldStudent(currentStudentFavourite);
            List<Favourite> oldStudentFavourites = oldStudent.originaleFavouriteList;
            List<Favourite> currentStudentFavourites = student.originaleFavouriteList;

            int i = 0;
            int jndex = 0;
            int index = 0;

            foreach (Favourite favourite in oldStudentFavourites)
            {
                if (oldStudentFavourites[i].projectID == relatedProject.projectID)
                {
                    Console.WriteLine("Student OLD gewinnt! Kein switch!");
                    index = i;
                    break;
                }
                if (currentStudentFavourites[i].projectID == relatedProject.projectID)
                {
                    Console.WriteLine("Student NEW gewinnt! Switch!");
                    jndex = i;
                    break;
                }
                i++;
            }
            if (jndex != index)
            {
                if (jndex < index)
                {
                    return 3;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 1;
            }
            // AStudent previouseStudents = relatedProject.students;
            // AStudent previouseStudentsFavListe = aktuellenPorjekt(aktuellerStudent(job.ID));
        }
        static int CoinFlip()
        {
            return new Random().Next(101);
        }
        static void RemainingAllocation()
        {
            if (leftStudentList.Count > 0)
            {

                ShuffleList();

                int lS = leftStudentList.Count;
                while (lS > 0)
                {
                    for (int _leftStudent = 0; _leftStudent < leftStudentList.Count; _leftStudent++)
                    {
                        Student leftStudent = leftStudentList[_leftStudent];
                        if (leftStudent.matched == false)
                        {
                            foreach (Project project in projectList)
                            {
                                if (project.IsSpaceLeftInProject() == true)
                                {
                                    Console.WriteLine(_leftStudent);
                                    if (project.GetFreeJob(leftStudent))
                                    {
                                        project.SetStudentToStudentList(leftStudent);
                                        lS--;
                                        break;
                                    }
                                    else
                                    {
                                        project.SetStudentToStudentList(leftStudent);
                                        lS--;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        static void ResultOfAlgorithm()
        {
            foreach(Project project in projectList) {
                Console.Write("Projekt "+ project.projectID + ": (needs: " + project.capacity + " | has: " + project.students.Count + ") ");
                
                if(project.capacity == project.students.Count) {
                    Console.WriteLine("*** CHECK *** ");
                }
                else {
                    Console.WriteLine("*** FAIL ***");
                }

                Console.Write("---- Needs Jobs: " );
                foreach (Job job in project.jobs)
                    {
                        Console.Write(job +  " ");
                    }
                    Console.WriteLine("");

                Console.Write("---- Needs DegreeCourse: " );
                foreach (Distribute degree in project.distribution)
                    {
                        Console.Write(degree.degreeCourse +  "(" + degree.count + ") ");
                    }
                    Console.WriteLine("");

                Console.Write("-- Initiatiors: " );

                if(project.initiators.Count > 0) {
                    foreach (Initiator initiator in project.initiators)
                    {
                        Console.Write(initiator.iD +  " (" + initiator.degreeCourse + ")");
                    }
                    Console.WriteLine("");
                }
                else {
                    Console.WriteLine("n/A ");
                }

                Console.Write("-- Students: " );
                if(project.students.Count > 0) {
                    foreach (Student student in project.students)
                    {
                        Console.Write(student.iD  + " ("+ student.degreeCourse +" "+ student.GetFavouriteOfCurrentProject().job + ") ");
                    }
                    Console.WriteLine("");
                }
                else {
                    Console.WriteLine("n/A ");
                }

            }
            Console.Write("LeftStudents: ");
            if(leftStudentList.Count > 0) {
                    foreach (Student leftStudent in leftStudentList)
                    {
                        Console.Write(leftStudent.iD  + " ");
                    }
                    Console.WriteLine("");
                }
                else {
                    Console.WriteLine("n/A ");
                }

        }
        static void ShuffleList()
        {
            for (int i = projectList.Count - 1; i > 0; i--)
            {
                Random random = new Random();
                int j = random.Next(i + 1);
                Project temp = projectList[i];
                projectList[i] = projectList[j];
                projectList[j] = temp;
            }
        }
    }
}