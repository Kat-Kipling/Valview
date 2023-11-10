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
    public partial class ViewMatches : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                localhost.ValoViewAPI valoViewAPI = new ValoViewAPI();
                DataSet series = valoViewAPI.getTournamentSeriesByName(Request.QueryString["TournName"]);
                gvSeries.DataSource = series;
                gvSeries.DataBind();
            }
        }
    }
}