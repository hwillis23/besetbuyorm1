using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace bestbuy_orm_1
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection; //field
  
        public DapperDepartmentRepository(IDbConnection connection) // constructor
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }
        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
             new { departmentName = newDepartmentName });
        }

    }


}
