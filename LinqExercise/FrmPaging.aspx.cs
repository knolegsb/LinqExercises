using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmPaging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 매개변수로 처리
            int? page = Convert.ToInt32(Request["Page"]);
            int pageSize = 5;

            // 데이터 모델
            NorthwindDataContext db = new NorthwindDataContext();
            
            // 조회
            var products = from product in db.Products
                           where product.Order_Details.Count > 1
                           orderby product.ProductID
                           select new
                           {
                               product.ProductID,
                               product.ProductName,
                               NumOrders = product.Order_Details.Count, // 구매수량
                               Revenue = // 총수입 
                                    product.Order_Details.Sum(o => o.UnitPrice * o.Quantity)
                           };
                           //select product;

            // 출력
            GridView.DataSource = products.ToList().Skip((page ?? 0)*pageSize).Take(pageSize);
            GridView.DataBind();

            var cnt = (from o in db.Order_Details
                      where o.ProductID == 1
                      select o).Count();
            Response.Write(cnt.ToString());
        }
    }
}