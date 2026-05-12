using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenopdrachtWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAanmelden_Click(object sender, EventArgs e)
        {
            if (txtGebruiker.Text == "admin" && txtWachtwoord.Text == "1234")
            {
                Session["user"] = txtGebruiker.Text;
                Response.Redirect("DefaultAangemeld.aspx");
            }
            else
            {
                Foutmelding.Text = "Deze combinatie gebruikersnaam -\r\nwachtwoord is niet gekend.";
            }
        }
    }
}