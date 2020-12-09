using System;

namespace ProjektstudiumZuordnung
{
    class Distribute
    {
        public DegreeCourse degreeCourse { get; set; }
        public int count { get; set; }
        public Distribute(DegreeCourse _degreeCourse, int _count)
        {
            degreeCourse = _degreeCourse;
            count = _count;
        }
    }
}
