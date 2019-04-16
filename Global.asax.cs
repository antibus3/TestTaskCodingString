using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using CodeGeneration;

namespace TestTaskCodingString
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //  Создать список имён
            List<string> nameObject = new List<string>() { "", "Обьект 1", "Обьект 2", "Обьект 3", "Обьект 5" };
            Dictionary<int, string> ListObjectBase = new Dictionary<int, string>();
            for (int i = 1; i<=4; i++)
            ListObjectBase.Add(i, nameObject[i]);
            Session["ListObject"] = ListObjectBase;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}