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
                gvPlayers.DataSource = players;
                gvPlayers.DataBind();
            }
        }
    }
}