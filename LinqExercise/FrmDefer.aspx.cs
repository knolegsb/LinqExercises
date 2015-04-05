using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmDefer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            DirectExecution(numbers);
            //DeferredExecution(numbers);
        }

        private void DirectExecution(List<int> numbers)
        {
            // 짝수만 출력
            //var query = (from n in numbers
            //            where n % 2 == 0
            //            select n).ToList(); // ToList나 ToArray를 추가하면 직접 실행

            var query = (from n in numbers
                         where n % 2 == 0
                         select n);

            // numbers에 짝수 데이터를 추가
            numbers.Add(8);

            Response.Write("Number of Records : " + query.Count().ToString() + "<br />");
            // 출력
            foreach (var num in query) // <= 여기에서 실행
            {
                Response.Write(String.Format("{0}<br />", num));
            }
        }

        private void DeferredExecution(List<int> numbers)
        {
            // 짝수만 출력
            var query = from n in numbers
                        where n % 2 == 0
                        select n;

            // numbers에 짝수 데이터를 추가
            numbers.Add(8);

            // 출력
            foreach (var num in query)
            {
                Response.Write(String.Format("{0}<br />", num));
            }
        }
    }
}