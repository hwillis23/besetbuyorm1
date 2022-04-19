using System;
using System.Collections.Generic;
using System.Text;

namespace bestbuy_orm_1
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments(); //Stubbed out method
        void InsertDepartment(string newDepartmentName);
    }
}
