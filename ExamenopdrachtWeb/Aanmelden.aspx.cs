using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SvLib.Managers;

namespace ExamenopdrachtWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAanmelden_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtGebruiker.Text) || string.IsNullOrEmpty(txtWachtwoord.Text))
                {
                    Foutmelding.Text = "Vul alle velden in.";
                    Foutmelding.Visible = true;
                    return;
                }

                if (GebruikerManager.Login(txtGebruiker.Text, txtWachtwoord.Text))
                {
                    Session["user"] = txtGebruiker.Text;
                    Response.Redirect("DefaultAangemeld.aspx");
                }
                else
                {
                    Foutmelding.Text = "Deze combinatie gebruikersnaam - wachtwoord is niet gekend.";
                    Foutmelding.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Foutmelding.Text = "Er is een fout opgetreden: " + ex.Message;
                Foutmelding.CssClass = "alert alert-danger";
                Foutmelding.Visible = true;
            }
        }
    }
}