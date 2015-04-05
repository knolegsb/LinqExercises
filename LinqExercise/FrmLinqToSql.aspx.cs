using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmLinqToSql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            // 데이터 개체 : LINQ to SQL, ADO.NET Entity Framework, ADO.NET, Enterprise Library
            NorthwindDataContext db = new NorthwindDataContext();

            // 상품 정보 조회
            var products = from p in db.Products
                           where p.Category.CategoryName == "Beverages"
                           orderby p.ProductID descending
                           //select p;
                           select new
                           {
                               p.ProductID,
                               p.ProductName,
                               Category = p.Category.CategoryName,
                               Price = p.UnitPrice
                           };

            // 출력
            this.ctrl.DataSource = products.ToList();
            this.ctrl.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            // 입력
            NorthwindDataContext db = new NorthwindDataContext();

            // 하나의 상품 정보 저장 개체
            Product p = new Product { CategoryID=1, ProductName="쉽게 배우는 LINQ", UnitPrice=1000m};
            db.Products.InsertOnSubmit(p); // SubmitChanges() 메서드 실행시 입력됨

            // 실제 메모리 상에서 변경된 값을 실행
            db.SubmitChanges(); // Insert문 실행

            // 출력
            DisplayData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // 수정
            NorthwindDataContext db = new NorthwindDataContext();

            Product product = db.Products.First(p => p.ProductName.Contains("쉽게"));
            product.UnitPrice += 1000m;

            db.SubmitChanges(); // Update

            DisplayData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // 삭제
            NorthwindDataContext db = new NorthwindDataContext();

            // 삭제할 상품을 읽어오기
            Product deleteProduct = db.Products.First(p => p.ProductName.StartsWith("쉽게"));
            db.Products.DeleteOnSubmit(deleteProduct);
            db.SubmitChanges(); // Delete

            DisplayData();
        }
    }
}