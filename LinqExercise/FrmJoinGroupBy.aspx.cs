using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmJoinGroupBy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsingJoinMethod();
            UsingGroupByMethod();
        }

        private void UsingGroupByMethod()
        {
            // 나이에 따른 카운트
            var peoples = (new JoinGroupBy.People()).GetPeoples();

            // 키값에 따라서 그룹화
            var peoplesGroupByAgeRange = peoples.GroupBy(p =>
            {
                if (p.Age < 30)
                {
                    return "Twenties";
                }
                if (p.Age >= 30 && p.Age < 40)
                {
                    return "Thirties";
                }
                if (p.Age >= 40)
                {
                    return "Forties";
                }
                return "Error";
            });
            foreach (var item in peoplesGroupByAgeRange)
            {
                Response.Write(String.Format("Age: {0}, Count: {1}<br/>", item.Key, item.Count()));
            }
        }

        private void UsingJoinMethod()
        {
            // 데이터 가져오기
            var peoples = (new JoinGroupBy.People()).GetPeoples();
            var companies = (new JoinGroupBy.Company()).GetCompanies();

            // 조인
            var peoplesAndCompanies = peoples.Join(companies, p => p.CompanyName, c => c.CompanyName,
                                    (p, c) => new { p.Name, p.Age, c.CompanyName, c.Country });

            // 출력
            foreach (var item in peoplesAndCompanies)
            {
                Response.Write(String.Format("Name: {0}, Company Location: {1}<br/>", item.Name, item.Country));
            }
        }

    }

    namespace JoinGroupBy
    {
        public class People
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string CompanyName { get; set; }

            public IEnumerable<People> GetPeoples()
            {
                IEnumerable<People> peoples = new[] {
                    new People{Name = "Shawn Green", Age=21, CompanyName="Microsoft"},
                    new People{Name = "Bwol Kang", Age=34, CompanyName="Amazon"},
                    new People{Name = "Misnak Kwon", Age=36, CompanyName="Apple"},
                    new People{Name = "Kazo Nam", Age=45, CompanyName="Google"}
                };
                return peoples;
            }
        }

        public class Company
        {
            public string CompanyName { get; set; }
            public string Country { get; set; }

            public List<Company> GetCompanies()
            {
                List<Company> companies = new List<Company> {
                    new Company{ CompanyName="Microsoft", Country="Seattle"},
                    new Company{ CompanyName="Amazon", Country="Seattle"},
                    new Company{ CompanyName="Apple", Country="Saratoga"},
                    new Company{ CompanyName="Google", Country="Mountain View"}
                };
                return companies;
            }
        }
    }
}