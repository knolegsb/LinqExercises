using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmQueryExpression : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 도시 이름에서 조건 검색
            string[] cities = { "London", "Amsterdam", "San Francisco", "Las Vegas", "Boston", "Raleigh", "Chicago", "Charlestown", "Helsingki" };

            // 도시명의 길이가 4인 도시명을 대문자로 출력
            // [1] 쿼리 연산자 사용
            // var query = cities.Where(c => c.Length > 4).OrderBy(c => c).Select(c => c.ToUpper());
            // [2] 쿼리 표현식 사용 : 닷넷 언어에서 사용되는 DSL(SQL문과 비슷)
            var query = from city in cities
                        where city.Length > 4
                        orderby city
                        select city.ToUpper();
            // select * from product // SQL문
            // from p in products select // LINQ


            // 출력
            this.GridView.DataSource = query.ToList(); // ToList()는 포함해도 되고 하지 않아도 된다.
            this.GridView.DataBind();
        }
    }
}