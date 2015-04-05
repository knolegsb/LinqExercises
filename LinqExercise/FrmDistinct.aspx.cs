using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmDistinct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // [1] Input
            string[] arr = { "DotNet", "Java", "ASP", "ASP" };
            // [2] Process
            var result = arr.Select(a => a).Distinct();
            // [3] Output
            foreach(string pro in result)
            {
                Response.Write(pro + "<br />");
            }
        }
    }
}