using System;
using System.Collections.Generic;

namespace ProjektstudiumZuordnung
{
    class Project
    {
        public int capacity { get; private set; }
        public List<Job> jobs { get; private set; }
        public List<Student> students { get; private set; }
        public List<Initiator> initiators { get; private set; }

        public int projectID { get; private set; }
        public Distribute[] distribution { get; private set; }
        public Project(int _capacity, List<Job> _jobs, List<Student> _students, int _projectID, Distribute[] _distributen, List<Initiator> _initiators)
        {
            capacity = _capacity;
            jobs = _jobs;
            students = _students;
            projectID = _projectID;
            distribution = _distributen;
            initiators = _initiators;
        }
        public void SetStudentToStudentList(Student student)
        {
            Console.WriteLine("Student " + student.iD + " wurde zugeordnet");
            student.SetProject(projectID);
            students.Add(student);
        }
        public void Unmatch(Student student)
        {

            Console.WriteLine("Student unmatch " + student.iD + "");

            student.UnmatchProject();

            // int i = 0;
            // foreach (Student s in students)
            // {
            //     if (s.iD == student.iD)
            //     {
            //         students.RemoveAt(i);
            //     }
            //     i++;
            // }

            for (int i = students.Count-1; i >=0; i--)
            {
                if (students[i].iD == student.iD)
                {
                    students.RemoveAt(i);
                   // Hier muss noch die Favourite gelöscht werden!!

                   students[i].RemoveFavourite(0);

                }


            }
            
        }
        public void SetInitatorToStudentList(Initiator student)
        {
            initiators.Add(student);
        }
        public bool IsSpaceLeftInProject()
        {
            if (capacity - students.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool DegreeCourseDistributeCheck(Student student)
        {
            int x = 0;
            Distribute distribute = GetDistribute(student.degreeCourse);

            if (distribute != null)
            {
                foreach (AStudent s in students)
                {
                    if (s.degreeCourse == distribute.degreeCourse)
                    {
                        x++;
                    }
                }
                if (x < distribute.count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public Student GetOldStudent(Favourite favourite)
        {
            foreach (Student oldStudent in students)
            {
                if (oldStudent.GetFavouriteOfCurrentProject() != null)
                {
                    if (oldStudent.GetFavouriteOfCurrentProject().job == favourite.job)
                    {
                        return oldStudent;
                    }
                }
            }
            return null;
        }
        public Student GetOldStudentStuGa(Student currentStudent)
        {
            foreach (Student oldStudent in students)
            {
                if (oldStudent.degreeCourse == currentStudent.degreeCourse)
                {
                    return oldStudent;
                }
            }
            return null;
        }
        public bool IsJobValid(Job job)
        {
            foreach (Job j in jobs)
            {
                if (j == job)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsJobFree(Job job)
        {
            foreach (Student student in students)
            {
                if (student.GetFavouriteOfCurrentProject() != null)
                {
                    if (student.GetFavouriteOfCurrentProject().job == job)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private Distribute GetDistribute(DegreeCourse degreeCourse)
        {
            foreach (Distribute distribute in distribution)
            {
                if (distribute.degreeCourse == degreeCourse)
                {
                    return distribute;
                }
            }
            return null;
        }
        public bool GetFreeJob(Student student)
        {
            List<Job> listedJobs = new List<Job>();
            List<Job> currentJobs = new List<Job>(jobs);
            List<int> indizies = new List<int>();
            foreach (Student placedStudent in students)
            {
                if (placedStudent.GetFavouriteOfCurrentProject() != null)
                {
                    Job placedStudentJob = placedStudent.GetFavouriteOfCurrentProject().job;
                    listedJobs.Add(placedStudentJob);
                }
            }
            int j = 0;
            foreach (Job _job in currentJobs)
            {
                foreach (Job _listedJob in listedJobs)
                {
                    if (_job == _listedJob)
                    {
                        indizies.Add(j);
                    }

                }
                j++;
            }
            indizies.Sort();
            for (int i = indizies.Count - 1; i >= 0; i--)
            {
                currentJobs.RemoveAt(indizies[i]);
            }
            bool b = false;
            if (currentJobs.Count > 0)
            {
                foreach (Job _currentJob in currentJobs)
                {
                    if (student.IsJobContainingFavourites(_currentJob))
                    {
                        b = true;
                    }
                }
            }
            return b;
        }
    }
}
