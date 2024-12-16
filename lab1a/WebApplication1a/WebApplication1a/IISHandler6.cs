using System;
using System.Web;
using System.IO;

namespace WebApplication1a
{
    public class IISHandler6 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //разместите здесь вашу реализацию обработчика.
            if (context.Request.HttpMethod == "GET")
            {
                string filePath = context.Server.MapPath("~/task6.html");
                string htmlContent = File.ReadAllText(filePath);

                context.Response.ContentType = "text/html";
                context.Response.Write(htmlContent);
            }
            else if (context.Request.HttpMethod == "POST")
            {
                int x = int.Parse(context.Request.Form["x"]);
                int y = int.Parse(context.Request.Form["y"]);

                int res = x * y;

                context.Response.ContentType = "text/html";
                context.Response.Write($"<p>Результат: {res}</p>");
            }

        }

        #endregion
    }
}
