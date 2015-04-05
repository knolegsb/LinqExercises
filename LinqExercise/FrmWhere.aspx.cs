using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmWhere : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] names = { "RedPlus", "Bobby", "Honesty", "YellowPlum" };

            var reds = names.Where(n => n.StartsWith("Red") && n.Length > 6);

            foreach(var name in reds)
            {
                Response.Write(name + "<br/>");
            }
        }
    }
}