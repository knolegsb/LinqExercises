using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmAllAnyContain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            // 모두 포함하는지?
            var all = numbers.All(a => a % 2 == 0); // 모두 짝수인지? false
            Response.Write(all.ToString() + "<br/>");

            // 하나라도 포함하는지?
            var any = numbers.Any(a => a % 7 == 0); // 7의 배수가 하나라도 있는지? true
            Response.Write(any.ToString() + "<br/>");

            // 모두 포함하는지?
            var contain = numbers.Contains(0); // 0을 포함하는지? false
            Response.Write(contain.ToString() + "<br/>");

        }
    }
}