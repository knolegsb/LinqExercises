using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmGroupBy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetCDrive();
            //GetStringMethods();
            // 오버로드된 메서드의 개수
            var q =
                from m in typeof(string).GetMethods()
                orderby m.Name
                //select new { MethodName = m.Name };
                //group m by m.Name;
                group m by m.Name into g // 그룹화된 컬렉션을 g라는 임시 개체에 담기
                select new { MethodName = g.Key, 오버로드카운트 = g.Count() };
            // 출력
            GridView.DataSource = q;
            GridView.DataBind();
        }

        private void GetStringMethods()
        {
            // String 클래스에 있는 모든 메서드 목록 뽑아내자
            var q =
                from m in typeof(String).GetMethods()
                orderby m.Name
                //select m;
                select new { MethodName = m.Name }; // C# 언어 사양서 : 메쏘드(X) => 메서드(O)

            // 출력
            GridView.DataSource = q;
            GridView.DataBind();
        }

        private void GetCDrive()
        {
            // C 드라이브의 모든 폴더 리스트 출력
            var directories = from dir in System.IO.Directory.GetDirectories("c:\\")
                              orderby dir
                              select dir;

            // 출력
            this.GridView.DataSource = directories.ToList();
            this.GridView.DataBind();
        }
    }
}