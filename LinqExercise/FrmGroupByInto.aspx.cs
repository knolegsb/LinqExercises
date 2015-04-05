using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqExercise
{
    public partial class FrmGroupByInto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 샘플 문자열
            string sentence = "the quick brown fox jumps over the lazy dog";
            // 분할
            string[] words = sentence.Split(' ');
            // 글자수에 따른 그룹화
            // [1] 쿼리 표현식 사용
            var q = from word in words
                    group word.ToUpper() by word.Length into gr
                    orderby gr.Key
                    select new { Length = gr.Key, Words = gr };

            // [2] 쿼리 연산자 사용 : 확장 메서드
            var q2 = words
                    .GroupBy(w => w.Length, w => w.ToUpper())
                    .Select(g => new { Length = g.Key, Words = g })
                    .OrderBy(o => o.Length);
            // 출력
            foreach(var obj in q2)
            {
                Response.Write("Number of Words : " + obj.Length + "<br />");
                foreach (string word in obj.Words)
                {
                    Response.Write("&nbsp;&nbsp;" + word + "<br />");
                }
            }
        }
    }
}