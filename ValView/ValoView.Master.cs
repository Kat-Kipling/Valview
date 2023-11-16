using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValView
{
    public partial class ValoView : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {

                    if (Session["username"] == null) //true if not signed in
                    {
                        if (Request.Cookies["userCookie"] != null)
                        {
                            Session["username"] = Request.Cookies["userCookie"]["username"].ToString();
                            FormsAuthentication.RedirectFromLoginPage(Request.Cookies["userCookie"]["username"].ToString(), true);
                        }
                        //Show login link
                        lbtnLogin.Visible = true;
                        //And links to see teams, players and tournaments
                        lbtnTeams.Visible = true;
                        lbtnPlayers.Visible = true;
                        lbtnTournaments.Visible = true;
                        //but don't show logout option, or user profile option.
                        lbtnLogOut.Visible = false;
                        lbtnUserProfile.Visible = false;
                    }
                    else
                    {
                        //Don't show login link
                        lbtnLogin.Visible = false;
                        //But show links to see teams, players and tournaments
                        lbtnTeams.Visible = true;
                        lbtnPlayers.Visible = true;
                        lbtnTournaments.Visible = true;
                        //And logout option and user profile option.
                        lbtnLogOut.Visible = true;
                        lbtnUserProfile.Visible = true;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void btnUserProfileClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Account.aspx", true);
        }

        protected void btnLoginClick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", true);
        }

        protected void btnTournamentsClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewTournaments.aspx", true);
        }

        protected void btnTeamsClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewTeams.aspx", true);
        }

        protected void btnPlayersClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewPlayers.aspx", true);
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            //Show login link
            lbtnLogin.Visible = true;
            //And links to see teams, players and tournaments
            lbtnTeams.Visible = true;
            lbtnPlayers.Visible = true;
            lbtnTournaments.Visible = true;
            //but don't show logout option, or user profile option.
            lbtnLogOut.Visible = false;
            lbtnUserProfile.Visible = false;

            Session["username"] = null;
            FormsAuthentication.SignOut();
            HttpCookie objCookie = new HttpCookie("userCookie");
            objCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(objCookie);
            Response.Redirect("~/index.aspx", true);
        }
    }
}