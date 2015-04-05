using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{    
    public partial class FrmSingle : System.Web.UI.Page
    {
        private List<string> names = new List<string> { "RedPlus", "Bob", "RedEable" };
        protected void Page_Load(object sender, EventArgs e)
        {
            //OldSelectData();
            NewSelectData();
        }

        protected void OldSelectData()
        {
            string r = "";
            foreach (string name in names)
            {
                if (name == "RedPlus")
                {
                    r = name;
                }
            }

            Response.Write(r);
        }
        protected void NewSelectData()
        {
            //string name = names.Single(n => n == "RedPlus");
            string name = names.SingleOrDefault(n => n == "RedPlus");

            Response.Write(name);
        }
    }
}