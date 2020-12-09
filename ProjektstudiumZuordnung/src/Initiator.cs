using System;

namespace ProjektstudiumZuordnung
{
    class Initiator : AStudent
    {
        public DegreeCourse degreeCourse { get; set; }
        public int iD { get; set; }
        public int groupeID { get; set; }
        public Initiator(DegreeCourse _degreeCourse, int _iD, int _groupeID) : base(_degreeCourse, _iD)
        {
            groupeID = _groupeID;
        }
    }
}
