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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                localhost.ValoViewAPI valoViewData = new localhost.ValoViewAPI();
                DataSet ds = valoViewData.getAllTournaments();

                reptTournaments.DataSource = ds.Tables["dtTournaments"];
                reptTournaments.DataBind();
            }
        }

        protected void btnViewMatches_Click(object sender, EventArgs e)
        {

        }
    }
}