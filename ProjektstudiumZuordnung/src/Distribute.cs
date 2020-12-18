using System;

namespace ProjektstudiumZuordnung
{
    class Distribute
    {
        public DegreeCourse degreeCourse { get; private set; }
        public int count { get; private set; }
        public Distribute(DegreeCourse _degreeCourse, int _count)
        {
            degreeCourse = _degreeCourse;
            count = _count;
        }
    }
}
