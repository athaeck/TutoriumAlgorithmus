using System;
using System.Collections.Generic;
namespace ProjektstudiumZuordnung
{
    class Project
    {
        public int capacity { get; set; }
        public List<Job> jobs { get; set; }
        public List<AStudent> students { get; set; }
        public int projectID { get; set; }
        public Distribute[] distribution { get; set; }
        public Project(int _capacity, List<Job> _jobs, List<AStudent> _students, int _projectID, Distribute[] _distributen)
        {
            capacity = _capacity;
            jobs = _jobs;
            students = _students;
            projectID = _projectID;
            distribution = _distributen;
        }

    }
}
