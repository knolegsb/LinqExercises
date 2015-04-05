using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmSumCountAverageMaxMin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            // 합계(SUM)
            int sum = arr.Where(s => s % 2 == 0).Sum();
            Response.Write("합계 : " + sum.ToString() + "<br />");

            // 카운트(COUNT)
            int count = arr.Where(c => c > 2).Count();
            Response.Write("2보다 큰 수의 개수 : " + count.ToString() + "<br />");

            // 평균(AVERAGE)
            double average = arr.Average(a => a);
            Response.Write("평균 : " + average.ToString() + "<br />");

            // 최대값(MAX)
            int max = arr.Max();
            Response.Write("최대값 : " + max.ToString() + "<br />");

            // 최소값(MIN)
            int min = arr.Min();
            Response.Write("최소값 : " + min.ToString() + "<br />");
        }
    }
}