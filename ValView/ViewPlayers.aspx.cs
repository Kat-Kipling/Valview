using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValView
{
    public partial class ViewPlayers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                localhost.ValoViewAPI valoViewAPI = new localhost.ValoViewAPI();
                DataSet players = valoViewAPI.getAllPlayers();
                
                reptPlayers.DataSource = players;
                reptPlayers.DataBind();
            }
        }

        protected void reptPlayers_ItemCommand(Object sender, RepeaterCommandEventArgs e)
        {

        }

        protected void btnViewPlayer_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            HiddenField playerId = (HiddenField)item.FindControl("playerID");
            string ah = playerId.Value;

            localhost.ValoViewAPI valoViewAPI = new localhost.ValoViewAPI();
            Response.Redirect("PlayerInformation.aspx?PlayerID=" + ah);
        }
    }
}