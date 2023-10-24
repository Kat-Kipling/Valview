using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValView
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            ValoViewAPI.ValoViewAPI viewAPI = new ValoViewAPI.ValoViewAPI();
            int userId = viewAPI.attemptSignIn(txtUsername.Text, txtPassword.Text);

            if (userId != -1)
            {
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, true);
            }
            else
            {
                lblOutput.Text = "Login unsuccessful. Please check your username and password, and try again.";
            }

        }
    }
}