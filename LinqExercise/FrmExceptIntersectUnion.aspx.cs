using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmExceptIntersectUnion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 데이터 원본
            int[] first = { 2, 4, 6, 8, 10 };
            int[] second = { 3, 6, 9, 12 };

            // 차집합: first-second
            var except = first.Except(second);
            foreach(var item in except)
            {
                Response.Write(item.ToString() + "<br/>");
            }
            Response.Write("<hr />");

            // 교집합
            var intersection = first.Intersect(second);
            foreach (var item in intersection)
            {
                Response.Write(item.ToString() + "<br />");
            }
            Response.Write("<hr />");

            // 합집합
            var union = first.Union(second).OrderBy(n => n).Reverse();
            foreach (var item in union)
            {
                Response.Write(item.ToString() + "<br />");
            }
            Response.Write("<hr />");
        }
    }
}