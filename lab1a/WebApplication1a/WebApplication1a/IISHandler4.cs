using System;
using System.Web;

namespace WebApplication1a
{
    public class IISHandler4 : IHttpHandler
    {
        #region Члены IHttpHandler

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            int x = int.Parse(context.Request.Form["x"]);
            int y = int.Parse(context.Request.Form["y"]);

            int sum = x + y;

            context.Response.ContentType = "text/plain";
            context.Response.Write(sum);
        }

        #endregion
    }
}
