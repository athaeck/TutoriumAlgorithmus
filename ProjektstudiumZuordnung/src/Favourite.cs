using System;

namespace ProjektstudiumZuordnung
{
    class Favourite
    {
        public int projectID { get; set; }
        public Job job { get; set; }

        public Favourite(int _projectID, Job _job)
        {
            projectID = _projectID;
            job = _job;
        }
    }
}
