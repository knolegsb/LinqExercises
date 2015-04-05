using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmAggregate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            // 누적
            var r = arr.Aggregate((sum, i) => sum + i); // sum 변수에 넘겨온 값(i)를 누적(SUM)
            Response.Write(r + "<br/>");

            var r2 = arr.Aggregate(100, (sum, i) => sum + i); // 100 + 누적값
            Response.Write(r2 + "<br />");

            var r3 = arr.Aggregate(100, (sum, i) => sum + i, sum => sum + 30); // 100 + 누적값 + 30
            Response.Write(r3 + "<br />");
        }
    }
}