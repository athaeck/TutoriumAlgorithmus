using System;

namespace ProjektstudiumZuordnung
{
    class Initiator : AStudent
    {
        public int groupeID { get; private set; }
        public Initiator(DegreeCourse _degreeCourse, int _iD, int _groupeID) : base(_degreeCourse, _iD)
        {
            groupeID = _groupeID;
        }
    }
}
