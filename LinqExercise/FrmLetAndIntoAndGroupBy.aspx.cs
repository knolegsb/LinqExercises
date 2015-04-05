using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public class NickName
    {
        public int Num { get; set; }
        public string Name { get; set; }
    }
    public partial class FrmLetAndIntoAndGroupBy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 데이터 원본 가져오기
            List<NickName> data = new List<NickName>(){
                new NickName {Num = 1, Name="RedPlus"},
                new NickName {Num = 2, Name="rednuke"},
                new NickName {Num = 3, Name="REDPLUS"},
                new NickName {Num = 4, Name="redminus"}
            };
            // 데이터 조회
            //var q = from d in data
            //            let lwr = d.Name.ToLower()
            //        where lwr == "redplus"
            //        select lwr;

            //var q = from d in data
            //        where d.Name.ToLower().StartsWith("red")
            //        select d
            //            into temp
            //            where temp.Name.Length < 8
            //            select temp;

            var q = from d in data
                    let lwr = d.Name.ToLower()
                    where lwr.StartsWith("red")
                    group d by lwr
                        into newGroup
                        orderby newGroup.Key ascending // 키값에 따라서 오름차순 정렬
                        select newGroup;

            // 데이터 출력
            //foreach (var item in q)
            //{
            //    Response.Write(item.Name + "<br/>");
            //}

            //foreach (var item in q)
            //{
            //    Response.Write(item.Num + ", " + item.Name + "<br />");
            //}

            foreach (var item in q)
            {
                Response.Write(item.Key + ", " + "(" + item.Count().ToString() + ")" + "<br />");
                foreach (NickName nick in item)
                {
                    Response.Write("&nbsp;&nbsp;" + nick.Num.ToString() + ", " + nick.Name + "<br />");
                }
            }
        }
    }
}