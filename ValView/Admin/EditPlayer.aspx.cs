using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
                DataSet allPlayers = valoViewAPI.getAllPlayerInfo();
                DataSet teams = valoViewAPI.getTeams();
                DataSet ranks = valoViewAPI.getRanks();
                DataSet divisions = valoViewAPI.getDivisions();
                DataSet agents = valoViewAPI.getAgents();
                DataSet roles = valoViewAPI.getRoles();


                gvPlayers.DataSource = allPlayers.Tables["dtPlayers"];
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
            imgPlayerPicture.ImageUrl = "~/" + playerDetails[9];
            drpDiv.ClearSelection();
            drpAgent.ClearSelection();
            drpMainRole.ClearSelection();
            drpSecRole.ClearSelection();
            drpRank.ClearSelection();
            drpTeam.ClearSelection();

            if (!playerDetails[2].Equals(""))
            {
                drpTeam.Items.FindByText(playerDetails[2]).Selected = true;
            }
            else
            {
                drpDiv.Items[1].Selected = true;
            }
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPlayerName.Text) && 
                !String.IsNullOrEmpty(txtPlayerCountry.Text) &&
                drpAgent.SelectedValue != "" &&
                drpMainRole.SelectedValue != "" &&
                drpTeam.SelectedValue != "" &&
                drpRank.SelectedValue != "" &&
                drpDiv.SelectedValue != "" &&
                drpSecRole.SelectedValue != "")
            {
                ValoViewAPI valoViewAPI = new ValoViewAPI();
                string name = txtPlayerName.Text;
                string country = txtPlayerCountry.Text;
                int agentValue = Convert.ToInt32(drpAgent.SelectedItem.Value);
                int mainRoleValue = Convert.ToInt32((drpMainRole.SelectedItem.Value));
                int teamValue = Convert.ToInt32(drpTeam.SelectedItem.Value);
                int rankValue = Convert.ToInt32(drpRank.SelectedItem.Value);
                int dropDivValue = Convert.ToInt32(drpDiv.SelectedItem.Value);
                int dropSecRoleValue = Convert.ToInt32((drpSecRole.SelectedItem.Value));
                string imageUrl = "/images/players/Default_Profile.png";

                if (uplPlayerImage.HasFile)
                {
                    imageUrl = "/images/players/" + uplPlayerImage.FileName;
                    uplPlayerImage.SaveAs(Server.MapPath("~") + imageUrl);
                }

                valoViewAPI.addNewPlayer(name, teamValue, country, rankValue, dropDivValue, mainRoleValue, dropSecRoleValue, agentValue, imageUrl);
                lblOutput.Text = "Player added!";
                DataSet allPlayers = valoViewAPI.getAllPlayerInfo();
                gvPlayers.DataSource = allPlayers.Tables["dtPlayers"];
                gvPlayers.DataBind();
            }
            else
            {
                lblOutput.Text = "Please ensure all fields are valid.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            drpDiv.ClearSelection();
            drpAgent.ClearSelection();
            drpMainRole.ClearSelection();
            drpSecRole.ClearSelection();
            drpRank.ClearSelection();
            drpTeam.ClearSelection();
            txtPlayerID.Text = string.Empty;
            txtPlayerName.Text = string.Empty;
            txtPlayerCountry.Text = string.Empty;
            imgPlayerPicture.ImageUrl = "/images/players/Default_Profile.png";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPlayerName.Text) &&
                !String.IsNullOrEmpty(txtPlayerCountry.Text) &&
                drpAgent.SelectedValue != "" &&
                drpMainRole.SelectedValue != "" &&
                drpTeam.SelectedValue != "" &&
                drpRank.SelectedValue != "" &&
                drpDiv.SelectedValue != "" &&
                drpSecRole.SelectedValue != "")
            {
                ValoViewAPI valoViewAPI = new ValoViewAPI();
                int id = Convert.ToInt32(txtPlayerID.Text);
                List<String> playerDetails = valoViewAPI.getPlayerDetails(id).ToList();
                string imageUrl = playerDetails[9];
                string name = txtPlayerName.Text;
                string country = txtPlayerCountry.Text;
                int agentValue = Convert.ToInt32(drpAgent.SelectedItem.Value);
                int mainRoleValue = Convert.ToInt32((drpMainRole.SelectedItem.Value));
                int teamValue = Convert.ToInt32(drpTeam.SelectedItem.Value);
                int rankValue = Convert.ToInt32(drpRank.SelectedItem.Value);
                int dropDivValue = Convert.ToInt32(drpDiv.SelectedItem.Value);
                int dropSecRoleValue = Convert.ToInt32((drpSecRole.SelectedItem.Value));

                if(uplPlayerImage.HasFile)
                {
                    imageUrl = "/images/players/" + uplPlayerImage.FileName;
                    uplPlayerImage.SaveAs(Server.MapPath("~") + imageUrl);
                }

                valoViewAPI.editPlayer(id, name, teamValue, country, rankValue, dropDivValue, mainRoleValue, dropSecRoleValue, agentValue, imageUrl);
                imgPlayerPicture.ImageUrl = imageUrl;
                lblOutput.Text = "Player edited!";
                DataSet allPlayers = valoViewAPI.getAllPlayerInfo();
                gvPlayers.DataSource = allPlayers.Tables["dtPlayers"];
                gvPlayers.DataBind();
                imgPlayerPicture.ImageUrl = imageUrl;
            }
            else
            {
                lblOutput.Text = "Please ensure you've selected a player, and all fields are valid.";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtPlayerID.Text))
            {
                ValoViewAPI valoViewAPI = new ValoViewAPI();
                valoViewAPI.deletePlayer(Convert.ToInt32(txtPlayerID.Text));
                btnClear_Click(sender, e);
                lblOutput.Text = "Player deleted!";
                DataSet allPlayers = valoViewAPI.getAllPlayerInfo();
                gvPlayers.DataSource = allPlayers.Tables["dtPlayers"];
                gvPlayers.DataBind();
            }
            else
            {
                lblOutput.Text = "Please select a player first.";
            }
        }
    }
}