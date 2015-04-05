using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmInnerJoin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindDataContext db = new NorthwindDataContext();

            var q = from product in db.Products
                    //select product;
                        join category in db.Categories 
                        on product.CategoryID 
                        equals category.CategoryID //equals 구문을 사용하여야 함. == (x)
                    select new { 
                        ProductName = product.ProductName,
                        CategoryName = category.CategoryName
                    };

            this.GridView.DataSource = q.ToList();
            this.GridView.DataBind();
        }
    }
}