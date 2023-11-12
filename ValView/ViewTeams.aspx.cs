using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValView.localhost;

namespace ValView
{
    public partial class ViewTeams : System.Web.UI.Page
    {
        private ValoViewAPI valoViewAPI = new ValoViewAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataSet ds = valoViewAPI.getTeams();

                reptTeams.DataSource = ds.Tables["dtTeams"];
                reptTeams.DataBind();
            }
        }

        protected void reptTeams_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnViewTeam_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            HiddenField teamId = (HiddenField)item.FindControl("teamId");
            string ah = teamId.Value;
            Response.Redirect("TeamInformation.aspx?TeamID=" + ah);
        }
    }
}