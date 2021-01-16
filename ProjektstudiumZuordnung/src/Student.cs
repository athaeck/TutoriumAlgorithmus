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
        public int GetIndexOfFavourite(Favourite favourite)
        {
            int i = 0;

            foreach (Favourite f in favouriteList)
            {
                if (f.projectID == favourite.projectID)
                {
                    return i;
                }
                i++;
            }

            return 0;
        }
        public Favourite GetFavouriteOfCurrentProject()
        {
            if (matched)
            {
                foreach (Favourite favourite in favouriteList)
                {
                    if (favourite.projectID == projectID)
                    {
                        return favourite;
                    }
                }
            }
            return null;
        }
        public double GetHappiness()
        {
            int i = 0;
            int index = 0;
            bool forcedAssigned = true;
            Favourite f = null;
            if (favouriteList.Count > 0)
            {
                foreach (Favourite favourite in favouriteList)
                {
                    if (favourite.projectID == projectID)
                    {
                        f = favourite;
                    }
                }
            }
            if (f != null)
            {
                foreach (Favourite favourite in originaleFavouriteList)
                {
                    if (favourite.projectID == f.projectID && favourite.job == f.job)
                    {
                        index = i;
                        forcedAssigned = false;
                    }
                    i++;
                }
            }
            else
            {
                foreach (Favourite favourite in originaleFavouriteList)
                {
                    if (favourite.projectID == projectID)
                    {
                        index = i;
                    }
                    i++;
                }
            }
            if (forcedAssigned == true)
            {
                index = originaleFavouriteList.Count;
            }
            double returnGrade = 6;
            switch (index)
            {
                case 0:
                    returnGrade = 1;
                    break;
                case 1:
                    returnGrade = 2.25;
                    break;
                case 2:
                    returnGrade = 4;
                    break;
                case 3:
                    returnGrade = 6;
                    break;
            }
            return returnGrade;

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
