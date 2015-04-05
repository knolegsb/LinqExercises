using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmNestedQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //UsingNestingQuery();
            //UsingCorrelatedQuery();
            //UsingJoin();
            UsingGroupJoin();
        }

        private void UsingGroupJoin() // SQL Outer Join
        {
            var q = from d in _departments
                    join e in _employees on d.ID equals e.DepartmentID
                        into empgroup
                    select new { Department = d, Employees = empgroup };
            foreach (var group in q)
            {
                Response.Write(group.Department.Name + "<hr />");
                foreach(var emp in group.Employees)
                {
                    Response.Write("&nbsp;&nbsp;" + emp.Name + "<br />");
                }
            }
        }

        private void UsingJoin()
        {
            // 사원 테이블과 부서 테이블 조인(Join)
            //var q = from e in _employees
            //        join d in _departments
            //            on e.DepartmentID equals d.ID
            //        select new
            //        {
            //            Employees = e,
            //            Departments = d
            //        };

            var q = _employees.Join(_departments, 
                e => e.DepartmentID, 
                d => d.ID, 
                (e, d) => new { Employees = e, Departments = d });
            // 출력
            foreach (var item in q)
            {
                Response.Write(String.Format("Name : {0}, Department : {1}<br />",
                    item.Employees.Name, item.Departments.Name));
            }
        }

        private void UsingCorrelatedQuery()
        {
            // 사원과 부서정보를 다 담아라..
            var q = from emp in _employees
                    select new
                    {
                        Employees = emp,
                        Departments = (
                            from d in _departments
                            where d.ID == emp.DepartmentID
                            select d
                        ).First()
                    };
            foreach(var item in q)
            {
                Response.Write(String.Format("Name : {0}, Department : {1}<br />",
                    item.Employees.Name, item.Departments.Name));
            };
        }

        private void UsingNestingQuery()
        {
            // 중첩된(하위) 쿼리 사용 : 부서가 Engineering 인 사원만 출력
            var q = from emp in _employees
                    where emp.DepartmentID == 
                    (
                        from dept in _departments 
                        where dept.Name == "Engineering" 
                        select dept.ID
                    ).First()
                    select emp;
            // 출력
            foreach (var item in q)
            {
                Response.Write(String.Format("Name: {0}<br />", item.Name));
            }
        }

        // 부서정보 반환 개체
        protected List<NestedQuery.Department> _departments = new List<NestedQuery.Department>()
        {
            new NestedQuery.Department { ID = 1, Name = "Engineering"},
            new NestedQuery.Department { ID = 2, Name = "Sales"},
            new NestedQuery.Department { ID = 3, Name = "Secretary"}
        };

        // 사원정보 반환 개체
        protected List<NestedQuery.Employee> _employees = new List<NestedQuery.Employee>() 
        {
            new NestedQuery.Employee { Name = "John Choi", DepartmentID = 1},
            new NestedQuery.Employee { Name = "Sean Kim", DepartmentID = 2}
        };
    }

    namespace NestedQuery
    {
        public class Department
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public class Employee
        {
            public string Name { get; set; }
            public int DepartmentID { get; set; }
        }
    }
}