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
                DataSet regions = valoViewAPI.getRegions();

                gvTeams.DataSource = teams.Tables["dtTeams"];
                gvTeams.DataBind();

                drpRegion.DataSource = regions.Tables["dtRegions"];
                drpRegion.DataTextField = "Region Name";
                drpRegion.DataValueField = "Region ID";
                drpRegion.DataBind();

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

            txtTeamID.Text = teamDetails[0];
            txtTeamName.Text = teamDetails[1];
            txtTeamCountry.Text = teamDetails[2];

            drpRegion.ClearSelection();
            drpTeam1.ClearSelection();
            drpTeam2.ClearSelection();
            drpTeam3.ClearSelection();
            drpTeam4.ClearSelection();
            drpTeam5.ClearSelection();

            drpRegion.Items.FindByText(teamDetails[3]).Selected = true;
            
            if(!teamDetails[4].Equals("---EMPTY---"))
            {
                drpTeam1.Items.FindByText(teamDetails[4]).Selected = true;
            }
            else
            {
                drpTeam1.Items[1].Selected = true;
            }

            if (!teamDetails[5].Equals("---EMPTY---"))
            {
                drpTeam2.Items.FindByText(teamDetails[5]).Selected = true;
            }
            else
            {
                drpTeam2.Items[1].Selected = true;
            }

            if (!teamDetails[6].Equals("---EMPTY---"))
            {
                drpTeam3.Items.FindByText(teamDetails[6]).Selected = true;
            }
            else
            {
                drpTeam3.Items[1].Selected = true;
            }

            if (!teamDetails[7].Equals("---EMPTY---"))
            {
                drpTeam4.Items.FindByText(teamDetails[7]).Selected = true;
            }
            else
            {
                drpTeam4.Items[1].Selected = true;
            }

            if (!teamDetails[8].Equals("---EMPTY---"))
            {
                drpTeam5.Items.FindByText(teamDetails[8]).Selected = true;
            }
            else
            {
                drpTeam5.Items[1].Selected = true;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (drpTeam1.SelectedValue != "" &&
                    drpTeam2.SelectedValue != "" &&
                    drpTeam3.SelectedValue != "" &&
                    drpTeam4.SelectedValue != "" &&
                    drpTeam5.SelectedValue != "" &&
                    drpRegion.SelectedValue != "" &&
                    !String.IsNullOrEmpty(txtTeamName.Text) &&
                    !String.IsNullOrEmpty(txtTeamCountry.Text))
            {
                valoViewAPI.addTeam(txtTeamName.Text, Convert.ToInt32(drpRegion.SelectedItem.Value), txtTeamCountry.Text);
                int teamId = valoViewAPI.getTeamIdByName(txtTeamName.Text);

                if(Convert.ToInt32(drpTeam1.SelectedValue) != -1)
                {
                    valoViewAPI.addPlayerToTeam(Convert.ToInt32(drpTeam1.SelectedValue), teamId);
                }

                if (Convert.ToInt32(drpTeam2.SelectedValue) != -1)
                {
                    valoViewAPI.addPlayerToTeam(Convert.ToInt32(drpTeam2.SelectedValue), teamId);
                }

                if (Convert.ToInt32(drpTeam3.SelectedValue) != -1)
                {
                    valoViewAPI.addPlayerToTeam(Convert.ToInt32(drpTeam3.SelectedValue), teamId);
                }

                if (Convert.ToInt32(drpTeam4.SelectedValue) != -1)
                {
                    valoViewAPI.addPlayerToTeam(Convert.ToInt32(drpTeam4.SelectedValue), teamId);
                }

                if (Convert.ToInt32(drpTeam5.SelectedValue) != -1)
                {
                    valoViewAPI.addPlayerToTeam(Convert.ToInt32(drpTeam5.SelectedValue), teamId);
                }


                txtTeamID.Text = string.Empty;
                txtTeamName.Text = string.Empty;
                txtTeamCountry.Text = string.Empty;

                drpRegion.ClearSelection();
                drpTeam1.ClearSelection();
                drpTeam2.ClearSelection();
                drpTeam3.ClearSelection();
                drpTeam4.ClearSelection();
                drpTeam5.ClearSelection();
                lblOutput.Text = "Team created!";
                DataSet teams = valoViewAPI.getTeams();
                gvTeams.DataSource = teams.Tables["dtTeams"];
                gvTeams.DataBind();
            }
            else
            {
                lblOutput.Text = "Please ensure all fields are valid.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtTeamID.Text = string.Empty;
            txtTeamName.Text = string.Empty;
            txtTeamCountry.Text = string.Empty;

            drpRegion.ClearSelection();
            drpTeam1.ClearSelection();
            drpTeam2.ClearSelection();
            drpTeam3.ClearSelection();
            drpTeam4.ClearSelection();
            drpTeam5.ClearSelection();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
                if (drpTeam1.SelectedValue != "" &&
                    drpTeam2.SelectedValue != "" &&
                    drpTeam3.SelectedValue != "" &&
                    drpTeam4.SelectedValue != "" &&
                    drpTeam5.SelectedValue != "" &&
                    drpRegion.SelectedValue != "" &&
                    !String.IsNullOrEmpty(txtTeamName.Text) &&
                    !String.IsNullOrEmpty(txtTeamCountry.Text))
                {

                    int teamId = Convert.ToInt32(gvTeams.SelectedRow.Cells[0].Text);
                    List<String> oldTeamDetails = valoViewAPI.getTeamInfo(teamId).ToList();
                    int oldTeam1Id = valoViewAPI.getPlayerIdByName(oldTeamDetails[4]);
                    int oldTeam2Id = valoViewAPI.getPlayerIdByName(oldTeamDetails[5]);
                    int oldTeam3Id = valoViewAPI.getPlayerIdByName(oldTeamDetails[6]);
                    int oldTeam4Id = valoViewAPI.getPlayerIdByName(oldTeamDetails[7]);
                    int oldTeam5Id = valoViewAPI.getPlayerIdByName(oldTeamDetails[8]);

                    int newTeamMem1Id = Convert.ToInt32(drpTeam1.SelectedItem.Value);
                    int newTeamMem2Id = Convert.ToInt32(drpTeam2.SelectedItem.Value);
                    int newTeamMem3Id = Convert.ToInt32(drpTeam3.SelectedItem.Value);
                    int newTeamMem4Id = Convert.ToInt32(drpTeam4.SelectedItem.Value);
                    int newTeamMem5Id = Convert.ToInt32(drpTeam5.SelectedItem.Value);

                    if(newTeamMem1Id != oldTeam1Id)
                    {
                        valoViewAPI.removePlayerFromTeam(oldTeam1Id);
                    }

                    if (newTeamMem2Id != oldTeam2Id)
                    {
                        valoViewAPI.removePlayerFromTeam(oldTeam2Id);
                    }

                    if (newTeamMem3Id != oldTeam3Id)
                    {
                        valoViewAPI.removePlayerFromTeam(oldTeam3Id);
                    }

                    if (newTeamMem4Id != oldTeam4Id)
                    {
                        valoViewAPI.removePlayerFromTeam(oldTeam4Id);
                    }

                    if (newTeamMem5Id != oldTeam5Id)
                    {
                        valoViewAPI.removePlayerFromTeam(oldTeam5Id);
                    }

                    valoViewAPI.addPlayerToTeam(newTeamMem1Id, Convert.ToInt32(txtTeamID.Text));
                    valoViewAPI.addPlayerToTeam(newTeamMem2Id, Convert.ToInt32(txtTeamID.Text));
                    valoViewAPI.addPlayerToTeam(newTeamMem3Id, Convert.ToInt32(txtTeamID.Text));
                    valoViewAPI.addPlayerToTeam(newTeamMem4Id, Convert.ToInt32(txtTeamID.Text));
                    valoViewAPI.addPlayerToTeam(newTeamMem5Id, Convert.ToInt32(txtTeamID.Text));


                txtTeamID.Text = string.Empty;
                txtTeamName.Text = string.Empty;
                txtTeamCountry.Text = string.Empty;

                drpRegion.ClearSelection();
                drpTeam1.ClearSelection();
                drpTeam2.ClearSelection();
                drpTeam3.ClearSelection();
                drpTeam4.ClearSelection();
                drpTeam5.ClearSelection();

                lblOutput.Text = "Team updated!";
                    DataSet teams = valoViewAPI.getTeams();
                    gvTeams.DataSource = teams.Tables["dtTeams"];
                    gvTeams.DataBind();
                }
                else
                {
                    lblOutput.Text = "Please ensure all fields are valid.";
                }
            }

            protected void btnDelete_Click(object sender, EventArgs e)
            {
            if (!String.IsNullOrEmpty(txtTeamID.Text))
            {
                ValoViewAPI valoViewAPI = new ValoViewAPI();
                valoViewAPI.deleteTeam(Convert.ToInt32(txtTeamID.Text));
                btnClear_Click(sender, e);
                lblOutput.Text = "Team deleted!";
                DataSet teams = valoViewAPI.getTeams();
                gvTeams.DataSource = teams.Tables["dtTeams"];
                gvTeams.DataBind();
            }
            else
            {
                lblOutput.Text = "Please select a player first.";
            }
        }
    }
}