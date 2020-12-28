abstract class AStudent
{
    public DegreeCourse degreeCourse;
    public int iD{get;private set;}
    protected AStudent(DegreeCourse _degreeCourse, int _iD)
    {
        degreeCourse = _degreeCourse;
        iD = _iD;
    }
}

