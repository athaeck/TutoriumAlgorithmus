using System;
using System.Collections.Generic;
namespace ProjektstudiumZuordnung
{
    class Project
    {
        public int capacity { get; private set; }
        public List<Job> jobs { get; private set; }
        public List<AStudent> students { get; private set; }
        public int projectID { get; private set; }
        public Distribute[] distribution { get; private set; }
        public Project(int _capacity, List<Job> _jobs, List<AStudent> _students, int _projectID, Distribute[] _distributen)
        {
            capacity = _capacity;
            jobs = _jobs;
            students = _students;
            projectID = _projectID;
            distribution = _distributen;
        }
        public void SetStudentToStudentList(AStudent student)
        {
            students.Add(student);
        }
        public bool IsSpaceLeftInProject()
        {
            if (capacity - students.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsSpaceAtJob(Student student)
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
    }
}
