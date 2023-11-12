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
    public partial class EditPlayer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ValoViewAPI valoViewAPI = new ValoViewAPI();
                DataSet gs = valoViewAPI.getAllPlayerInfo();
                DataSet teams = valoViewAPI.getTeams();
                DataSet ranks = valoViewAPI.getRanks();
                DataSet divisions = valoViewAPI.getDivisions();
                DataSet agents = valoViewAPI.getAgents();
                DataSet roles = valoViewAPI.getRoles();


                gvPlayers.DataSource = gs.Tables["dtPlayers"];
                gvPlayers.DataBind();

                drpTeam.DataSource = teams.Tables["dtTeams"];
                drpTeam.DataTextField = "Team Name";
                drpTeam.DataValueField = "Team ID";
                drpTeam.DataBind();

                drpRank.DataSource = ranks.Tables["dtRanks"];
                drpRank.DataTextField = "Rank Name";
                drpRank.DataValueField = "ID";
                drpRank.DataBind();

                drpDiv.DataSource = divisions.Tables["dtDivisions"];
                drpDiv.DataTextField = "Division";
                drpDiv.DataValueField = "ID";
                drpDiv.DataBind();


                drpAgent.DataSource = agents.Tables["dtAgents"];
                drpAgent.DataTextField = "Agent Name";
                drpAgent.DataValueField = "ID";
                drpAgent.DataBind();

                drpMainRole.DataSource = roles.Tables["dtRoles"];
                drpMainRole.DataTextField = "Role Name";
                drpMainRole.DataValueField = "ID";
                drpMainRole.DataBind();

                drpSecRole.DataSource = roles.Tables["dtRoles"];
                drpSecRole.DataTextField = "Role Name";
                drpSecRole.DataValueField = "ID";
                drpSecRole.DataBind();
            }
        }

        protected void gvPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvPlayers.SelectedRow.Cells[0].Text);

            ValoViewAPI api = new ValoViewAPI();
            List<String> playerDetails = api.getPlayerDetails(id).ToList();
            txtPlayerID.Text = playerDetails[0];
            txtPlayerName.Text = playerDetails[1];

            drpDiv.ClearSelection();
            drpAgent.ClearSelection();
            drpMainRole.ClearSelection();
            drpSecRole.ClearSelection();
            drpRank.ClearSelection();
            drpTeam.ClearSelection();

            drpTeam.Items.FindByText(playerDetails[2]).Selected = true;
            txtPlayerCountry.Text = playerDetails[3];
            drpRank.Items.FindByText(playerDetails[4]).Selected = true;
            if (!playerDetails[5].Equals(""))
            {
                drpDiv.Items.FindByText(playerDetails[5]).Selected = true;
            }
            else
            {
                drpDiv.Items[1].Selected = true;
            }
            drpMainRole.Items.FindByText(playerDetails[6]).Selected = true;
            if(!playerDetails[7].Equals(""))
            {
                drpSecRole.Items.FindByText(playerDetails[7]).Selected = true;
            }
            else
            {
                drpSecRole.Items[1].Selected = true;
            }
            drpAgent.Items.FindByText(playerDetails[8]).Selected = true;
        }
    }
}