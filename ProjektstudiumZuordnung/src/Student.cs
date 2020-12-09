using System;
using System.Collections.Generic;
namespace ProjektstudiumZuordnung
{
    class Student : AStudent
    {
        public List<Favourite> favouriteList { get; set; }
        public DegreeCourse degreeCourse { get; set; }
        public int iD { get; set; }
        public bool matched { get; set; }
        public int projectID { get; set; }
        public Student(List<Favourite> _favouriteList, DegreeCourse _degreeCourse, int _iD, bool _matched, int _projectID) : base(_degreeCourse, _iD)
        {
            favouriteList = _favouriteList;
            matched = _matched;
            projectID = _projectID;
        }
    }
}
