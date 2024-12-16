﻿using System;
using System.Web;

namespace WebApplication1a
{
    public class IISHandler2 : IHttpHandler
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
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //разместите здесь вашу реализацию обработчика.
            string parmA = context.Request.QueryString["aaa"];
            string parmB = context.Request.QueryString["bbb"];

            string responseText = $"POST-Http-SEK: ParmA = {parmA}, ParmB = {parmB}";

            context.Response.ContentType = "text/plain";
            context.Response.Write(responseText);

        }

        #endregion
    }
}
