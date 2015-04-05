using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmOrderBy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> names = new List<string>() { "RedPlus", "Bobby", "YellowPlum" };
            // 기본
            foreach(var name in names)
            {
                Response.Write(name + "<br/>");
            }
            // 정렬
            foreach(var name in names.OrderBy(n => n))
            {
                Response.Write(name + "<br/>");
            }
            // 내림차 순 정렬
            foreach (var name in names.OrderByDescending(n => n))
            {
                Response.Write(name + "<br/>");
            }
        }
    }
}