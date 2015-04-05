using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace LinqExercise
{
    public partial class FrmXElement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindDataContext db = new NorthwindDataContext();

            //XElement xe = new XElement("result");
            //XElement xe = new XElement("result", "Hello");
            //XElement xe = new XElement("result", new XElement("hello", "world"));
            //XElement xe = new XElement("result",
            //    from c in db.Customers
            //    select new XElement("contact", c.CompanyName)
            //    );

            XElement xe = new XElement("result",
                from c in db.Customers
                where c.City == "London"
                select new XElement("contact", 
                    new XAttribute("name", c.CompanyName),
                    new XAttribute("phone", c.Phone)
                    )
                );

            // 만들어진 XML 출력
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.Write(xe.ToString());
            Response.End();
        }
    }
}