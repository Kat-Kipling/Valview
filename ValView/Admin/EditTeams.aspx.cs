using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValView.localhost;

namespace ValView.Admin
{
    public partial class EditTeams : System.Web.UI.Page
    {
        private ValoViewAPI valoViewAPI = new ValoViewAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataSet ds = valoViewAPI.getTeams();

                gvTeams.DataSource = ds.Tables["dtTeams"];
                gvTeams.DataBind();
            }
        }

        protected void gvTeams_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}