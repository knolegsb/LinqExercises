using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmSelectWithAnonymousObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = Person.GetPersons().Select(p => new { FullName = p.FirstName + " " + p.LastName });

            foreach (var fullName in list)
            {
                Response.Write("Full Name: " + fullName.FullName + "<br/>");
            }
        }
    }
}