using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmUsingStoredProcedure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindDataContext db = new NorthwindDataContext();

            int? count = 0;
            var q = db.CustOrderHist("ALFKI", ref count);
            lbl.Text = count.ToString();

            this.ctrl.DataSource = q;
            this.ctrl.DataBind();
        }
    }
}