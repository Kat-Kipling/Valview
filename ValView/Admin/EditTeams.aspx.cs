using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
                DataSet teams = valoViewAPI.getTeams();
                DataSet allPlayers = valoViewAPI.getAllPlayerInfo();

                gvTeams.DataSource = teams.Tables["dtTeams"];
                gvTeams.DataBind();

                drpTeam1.DataSource = allPlayers.Tables["dtPlayers"];
                drpTeam2.DataSource = allPlayers.Tables["dtPlayers"];
                drpTeam3.DataSource = allPlayers.Tables["dtPlayers"];
                drpTeam4.DataSource = allPlayers.Tables["dtPlayers"];
                drpTeam5.DataSource = allPlayers.Tables["dtPlayers"];
                drpTeam1.DataTextField = "Username";
                drpTeam1.DataValueField = "ID";
                drpTeam2.DataTextField = "Username";
                drpTeam2.DataValueField = "ID";
                drpTeam3.DataTextField = "Username";
                drpTeam3.DataValueField = "ID";
                drpTeam4.DataTextField = "Username";
                drpTeam4.DataValueField = "ID";
                drpTeam5.DataTextField = "Username";
                drpTeam5.DataValueField = "ID";
                drpTeam1.DataBind();
                drpTeam2.DataBind();
                drpTeam3.DataBind();
                drpTeam4.DataBind();
                drpTeam5.DataBind(); // This is lazy; better to add each dropdown box to a list and bind via iterating through items in said list. But I'm lazy right now and trying to get this banged out ^^'
            }
        }

        protected void gvTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvTeams.SelectedRow.Cells[0].Text);
            List<string> teamDetails = valoViewAPI.getTeamInfo(id).ToList();

            foreach (var item in teamDetails)
            {
                Debug.WriteLine(item);
            }
        }
    }
}