using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValView.localhost;

namespace ValView.Admin
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                localhost.ValoViewAPI api = new localhost.ValoViewAPI();
                try
                {
                    List<String> userDetails = api.getUserDetails(Session["username"].ToString()).ToList();
                }
                catch(Exception ex) //This shouldn't ever meet due to page being locked behind signing in - thus session variable should always exist.
                {

                }
            }
        }
    }
}