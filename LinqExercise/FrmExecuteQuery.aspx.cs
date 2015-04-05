using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmExecuteQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindDataContext db = new NorthwindDataContext();

            UsingLINQ(db);
            UsingQuery(db, 2);
        }

        private void UsingQuery(NorthwindDataContext db, int categoryId)
        {
            // 인라인 SQL 구문으로 데이터 조회
            //var q2 = db.ExecuteQuery<Product>("Select * From Products Where CategoryID =1");
            var q2 = db.ExecuteQuery<Product>("Select * From Products Where CategoryID = {0}", categoryId);

            this.GridView2.DataSource = q2;
            this.GridView2.DataBind();
        }

        private void UsingLINQ(NorthwindDataContext db)
        {
            // LINQ 구문으로 데이터 조회
            var q1 = from p in db.Products
                     where p.CategoryID == 1
                     select p;

            this.GridView1.DataSource = q1;
            this.GridView1.DataBind();
        }
    }
}