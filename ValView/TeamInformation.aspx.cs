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
    public partial class TeamInformation : System.Web.UI.Page
    {
        private ValoViewAPI valoViewApi = new ValoViewAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet team = valoViewApi.getTeamData(Convert.ToInt32(Request.QueryString["TeamID"]));
                gvTeamInfo.DataSource = team;
                gvTeamInfo.DataBind();
            }
        }
    }
}