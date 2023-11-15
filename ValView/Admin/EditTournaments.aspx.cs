using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValView.Admin
{
    public partial class EditTournaments : System.Web.UI.Page
    {
        private localhost.ValoViewAPI api = new localhost.ValoViewAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataSet tournaments = api.getAllTournaments();

                gvTournaments.DataSource = tournaments.Tables["dtTournaments"];
                gvTournaments.DataBind();
            }
        }

        protected void gvTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}