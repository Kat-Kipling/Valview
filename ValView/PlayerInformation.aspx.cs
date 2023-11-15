using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValView.localhost;

namespace ValView
{
    public partial class PlayerInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ValoViewAPI api = new ValoViewAPI();
                List<String> playerDetails = api.getPlayerDetails(Convert.ToInt32(Request.QueryString["PlayerID"])).ToList();
                int playerId = Convert.ToInt32(Request.QueryString["PlayerID"]);

                lblUsername.Text += playerDetails[1];
                lblTeam.Text += playerDetails[2];
                lblCountry.Text += playerDetails[3];
                lblRank.Text += playerDetails[4];
                lblDivision.Text += playerDetails[5];
                lblMainRole.Text += playerDetails[6];
                lblSecRole.Text += playerDetails[7];
                lblMainAgent.Text += playerDetails[8];
                imgPlayerPicture.ImageUrl = "~/" + playerDetails[9];
            }
        }
    }
}