using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValView.localhost;

namespace ValView
{
    public partial class PlayerInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ValoViewAPI api = new ValoViewAPI();
                List<String> playerDetails = api.getPlayerDetails(Convert.ToInt32(Request.QueryString["PlayerID"])).ToList();

                foreach (var item in playerDetails)
                {
                    Debug.WriteLine(item);
                }

                Debug.WriteLine("idk");
            }
        }
    }
}