using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmMethodChaining : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] names = { "RedPlus", "Tablo", "Honesty", "YellowPlum" };

            var nick = names.Where(n => n.StartsWith("Red")).OrderBy(s => s);
            foreach(var name in nick)
            {
                Response.Write(name + "<br/>");
            }
        }
    }
}