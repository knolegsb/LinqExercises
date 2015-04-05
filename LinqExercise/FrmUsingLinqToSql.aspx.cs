using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmUsingLinqToSql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Northwind DB에 대한 기본 클래스 : Repository, Controller
            NorthwindDataContext db = new NorthwindDataContext();

            // 고객 정보를 배열로 전환
            Customer[] customers = db.Customers.ToArray();

            // 런던에 거주하는 고객
            // var q = customers.Where(c => c.City == "London").Select(c => c.CompanyName);
            //IEnumerable<string> q = customers.Where(c => c.City == "London").Select(c => c.CompanyName); // 원칙적으로는 IEnumerable<string>을 써야 한다.

            //var q = from c in customers
            //        where c.City == "London"
            //        select c;

            // 익명형식으로 회사명만
            //var q = from customer in customers
            //        where customer.City == "London"
            //        select new { CompanyName = customer.CompanyName, City = customer.City };

            // 상품 정보 입력
            var q = from p in db.Products
                    where p.UnitPrice >= 25 && p.UnitPrice <= 50
                    orderby p.UnitPrice descending
                    select p;

            // 출력
            this.GridView.DataSource = q; // q.ToList()를 써 주어도 됀다
            this.GridView.DataBind();
        }
    }
}