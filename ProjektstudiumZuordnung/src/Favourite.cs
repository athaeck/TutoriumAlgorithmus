using System;

namespace ProjektstudiumZuordnung
{
    class Favourite
    {
        public int projectID { get; private set; }
        public Job job { get; private set; }

        public Favourite(int _projectID, Job _job)
        {
            projectID = _projectID;
            job = _job;
        }
    }
}
