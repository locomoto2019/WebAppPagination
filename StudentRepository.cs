using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppPagination.Models;

namespace WebAppPagination.Repository
{
    public class StudentRepository : IPagination<StudentModel>
    {
        StudentDataContext Context = new StudentDataContext();

        public IQueryable<StudentModel> GetPaginated(string filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered)
        {
            var data = Context.Student.AsQueryable();
            totalRecords = data.Count();
            if (!string.IsNullOrEmpty(filter))
            {
                data = data.Where(x => x.shortname.ToUpper().Contains(filter.ToUpper()));
            }
            recordsFiltered = data.Count();
            data = data.OrderBy(x => x.shortname).Skip((initialPage * pageSize)).Take(pageSize);
            return data;
        }
    }
}