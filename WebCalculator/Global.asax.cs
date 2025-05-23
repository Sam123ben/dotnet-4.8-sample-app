using System;
using System.Web;
using System.Web.Routing;

namespace WebCalculator
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            // Code that runs on application shutdown
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Exception ex = Server.GetLastError();
            
            // Log the error (you can implement logging here)
            System.Diagnostics.Debug.WriteLine($"Unhandled exception: {ex?.Message}");
            
            // Clear the error
            Server.ClearError();
            
            // Redirect to error page
            Response.Redirect("~/Error.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            // Add custom routes here if needed
            // Example: routes.MapPageRoute("Calculator", "calc", "~/Default.aspx");
        }
    }
}