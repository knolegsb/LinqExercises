using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmSkipTake : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindDataContext db = new NorthwindDataContext();

            //GetProductCount(db);
            //UsingSkipTake(db);

            // 내부적으로 실행된 SQL 구문을 출력
            db.Log = Response.Output;

            var q = from p in db.Products
                    orderby p.ProductName descending
                    select new { p.ProductID, p.ProductName };

            this.GridView.DataSource = q.Skip(3).Take(5);
            this.GridView.DataBind();
        }

        private void UsingSkipTake(NorthwindDataContext db)
        {
            var q = from product in db.Products
                    where product.Category.CategoryName == "Beverages"
                    select new { product.ProductID, ProductName = product.ProductName };

            // 앞에 3개 제외하고, 최대 (Top) 5개 데이터 출력
            this.GridView.DataSource = q.Skip(3).Take(5);
            this.GridView.DataBind();
        }

        private void GetProductCount(NorthwindDataContext db)
        {
            // 조회 결과 카운트
            var q = (from product in db.Products
                    where product.Category.CategoryName == "Beverages"
                     select product).Count(); 
                    //select new { product.ProductID, ProductName = product.ProductName };

            //this.GridView.DataSource = q;
            //this.GridView.DataBind();

            Response.Write(q.ToString());
        }
    }
}