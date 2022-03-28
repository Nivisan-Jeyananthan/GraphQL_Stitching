namespace Students;

public class Query
{
    public IEnumerable<TLernender?>? GetStudents([Service] BISSContext dbcontext)
    {
        return dbcontext.TLernenders;
    }
}