using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
                    lblUsername.Text = userDetails[1];
                    lblName.Text = userDetails[3] + " " + userDetails[4];
                    lblPronouns.Text = userDetails[5];
                    imgUserProfilePic.ImageUrl = "~/" + userDetails[6];
                }
                catch(Exception ex) //This shouldn't ever meet due to page being locked behind signing in - thus session variable should always exist.
                {

                }
            }
        }

        protected void btnPlayerManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPlayer.aspx", true);
        }

        protected void btnTeamManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditTeams.aspx", true);
        }

        protected void btnTournamentManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditTournaments.aspx", true);
        }
    }
}