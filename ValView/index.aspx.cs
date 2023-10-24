using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValView
{
    public partial class indexx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUserProfileClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Account.aspx", true);
        }

        protected void btnLoginClick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", true);
        }

        protected void btnTournamentsClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewTournaments.aspx", true);
        }

        protected void btnTeamsClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewTeams.aspx", true);
        }

        protected void btnPlayersClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewPlayers.aspx", true);
        }
    }
}