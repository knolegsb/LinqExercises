using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class LinqEx_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> query =
                from num in numbers
                where num > 5 && num < 10
                select num;

            GridView1.DataSource = query;
            GridView1.DataBind();
        }
    }
}