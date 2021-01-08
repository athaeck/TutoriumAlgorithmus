using System;
using System.Collections.Generic;
namespace ProjektstudiumZuordnung
{
    class Student : AStudent
    {
        public List<Favourite> favouriteList { get; private set; }
        public bool matched { get; private set; }
        public int projectID { get; private set; }
        public List<Favourite> originaleFavouriteList { get; private set; }

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
        public void SetOriginalFavourites()
        {
            List<Favourite> l = new List<Favourite>(favouriteList);
            originaleFavouriteList = l;
        }
        public Favourite GetFavouriteOfCurrentProject()
        {
            if (matched)
            {
                foreach (Favourite favourite in originaleFavouriteList)
                {
                    if (favourite.projectID == projectID)
                    {
                        return favourite;
                    }
                }
            }
            return null;
        }
        public void SetProject(int _projectID)
        {
            projectID = _projectID;
            matched = true;
        }
        public void UnmatchProject()
        {
            projectID = -1;
            matched = false;
        }
        public bool IsJobContainingFavourites(Job job)
        {
            foreach (Favourite favourite in favouriteList)
            {
                if (favourite.job == job)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
