using System;
using System.Collections.Generic;
namespace ProjektstudiumZuordnung
{
    class Student : AStudent
    {
        public List<Favourite> favouriteList { get; private set; }
        public bool matched { get; private set; }
        public int projectID { get; private set; }
        public Student(List<Favourite> _favouriteList, DegreeCourse _degreeCourse, int _iD, bool _matched, int _projectID) : base(_degreeCourse, _iD)
        {
            favouriteList = _favouriteList;
            matched = _matched;
            projectID = _projectID;
        }
        public void RemoveFavourite(int i)
        {
            favouriteList.RemoveAt(i);
        }
    }
}
