using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmSelectSelectMany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] arr = { "abc", "def", "fed", "cba" };

            var s1 = arr.Select(a => a); // 람다식에 따른 데이터 조회
            foreach(var items in s1)
            {
                Response.Write(items + "<br/>");
            }
            Response.Write("<br />");
            var s2 = arr.SelectMany(a => a);
            foreach(var items in s2)
            {
                Response.Write(items + "<br/>"); // char형으로 분리
            }

        }
    }
}