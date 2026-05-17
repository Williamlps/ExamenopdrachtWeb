using SvLib.DataObjects;
using SvLib.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenopdrachtWeb
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private void SetConnectionStrings()
        {
            string cn = ConfigurationManager.ConnectionStrings["Cn"].ConnectionString;

            TypeMateriaalManager.ConnectionString = cn;
            MerkManager.ConnectionString = cn;
            MateriaalManager.ConnectionString = cn;
            MaatManager.ConnectionString = cn;
            MateriaalMaatManager.ConnectionString = cn;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SetConnectionStrings();

            if (!IsPostBack)
            {
                string sport = Request.QueryString["sport"];
                int typeSportId = 0;

                if (sport == "Alpine")
                {
                    TitelHuren.Text = "Alpineski's huren";
                    typeSportId = 1;
                }
                else
                {
                    TitelHuren.Text = "Langlaufski's huren";
                    typeSportId = 2;
                }

                ViewState["TypeSportId"] = typeSportId;

                dpBeginDatum.Text = DateTime.Today.ToString("yyyy-MM-dd");
                dpEindDatum.Text = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");

                LaadTypeMateriaal(typeSportId);
            }
        }

        private void LaadTypeMateriaal(int typeSportId)
        {
            try
            {
                List<TypeMateriaal> typeMaterialen = TypeMateriaalManager.GetByTypeSport(typeSportId);
                ddlTypeMateriaal.DataSource = typeMaterialen;
                ddlTypeMateriaal.DataTextField = "Naam";
                ddlTypeMateriaal.DataValueField = "Id";
                ddlTypeMateriaal.DataBind();
            }
            catch (Exception ex)
            {
                ToonFout("Er is een fout opgetreden: " + ex.Message, "alert-danger");
            }

        }

        private void LaadMerken()
        {
            try
            {
                int typeMateriaalId = Convert.ToInt32(ddlTypeMateriaal.SelectedValue);
                List<Merk> merken = MerkManager.GetByTypeMateriaal(typeMateriaalId);
                ddlMerk.DataSource = merken;
                ddlMerk.DataTextField = "Naam";
                ddlMerk.DataValueField = "Id";
                ddlMerk.DataBind();
                LaadMaterialen();

                ddlMateriaal.Items.Clear();
                ddlMaat.Items.Clear();
                txtBeschikbaar.Text = "";
                imgMateriaal.ImageUrl = "~/images/no-image-available.png";
            }
            catch (Exception ex)
            {
                ToonFout("Er is een fout opgetreden: " + ex.Message, "alert-danger");
            }
        }
        private void LaadMaterialen()
        {
            try
            {
                int typeMateriaalId = Convert.ToInt32(ddlTypeMateriaal.SelectedValue);
                int merkId = Convert.ToInt32(ddlMerk.SelectedValue);
                List<Materiaal> lijst = MateriaalManager.GetByTypeEnMerk(typeMateriaalId, merkId);
                ddlMateriaal.DataSource = lijst;
                ddlMateriaal.DataTextField = "Model";
                ddlMateriaal.DataValueField = "Id";
                ddlMateriaal.DataBind();

                ddlMaat.Items.Clear();
                txtBeschikbaar.Text = "";
                imgMateriaal.ImageUrl = "~/images/no-image-available.png";
            }
            catch (Exception ex)
            {
                ToonFout("Er is een fout opgetreden: " + ex.Message, "alert-danger");
            }
        }

        private void LaadMaten()
        {
            try
            {
                int materiaalId = Convert.ToInt32(ddlMateriaal.SelectedValue);
                List<Maat> lijst = MaatManager.GetByMateriaal(materiaalId);
                ddlMaat.DataSource = lijst;
                ddlMaat.DataTextField = "Naam";
                ddlMaat.DataValueField = "Id";
                ddlMaat.DataBind();

                txtBeschikbaar.Text = "";
                LaadFoto();
            }
            catch (Exception ex)
            {
                ToonFout("Er is een fout opgetreden: " + ex.Message, "alert-danger");
            }
        }

        private void LaadFoto()
        {
            try
            {
                int materiaalId = Convert.ToInt32(ddlMateriaal.SelectedValue);
                Materiaal m = MateriaalManager.GetById(materiaalId);
                if (m != null && !string.IsNullOrEmpty(m.Foto))
                    imgMateriaal.ImageUrl = "~/" + m.Foto.Replace("\\", "/");
                else
                    imgMateriaal.ImageUrl = "~/images/no-image-available.png";
            }
            catch (Exception ex)
            {
                ToonFout("Er is een fout opgetreden: " + ex.Message, "alert-danger");
            }
        }

        private void BerekenBeschikbaar()
        {
            try
            {
                if (ddlMateriaal.Items.Count == 0 || ddlMaat.Items.Count == 0)
                {
                    txtBeschikbaar.Text = "0";
                    return;
                }
                if (string.IsNullOrEmpty(dpBeginDatum.Text) || string.IsNullOrEmpty(dpEindDatum.Text))
                {
                    txtBeschikbaar.Text = "0";
                    return;
                }

                int materiaalId = Convert.ToInt32(ddlMateriaal.SelectedValue);
                int maatId = Convert.ToInt32(ddlMaat.SelectedValue);
                DateTime beginDatum = Convert.ToDateTime(dpBeginDatum.Text);
                DateTime eindDatum = Convert.ToDateTime(dpEindDatum.Text);
                int beschikbaar = MateriaalMaatManager.GetBeschikbaar(materiaalId, maatId, beginDatum, eindDatum);
                txtBeschikbaar.Text = beschikbaar.ToString();
            }
            catch (Exception ex)
            {
                ToonFout("Er is een fout opgetreden: " + ex.Message, "alert-danger");
            }
        }

        private void ToonFout(string boodschap, string cssKlasse)
        {
            HurenFoutmelding.Text = boodschap;
            HurenFoutmelding.CssClass = "alert " + cssKlasse;
            HurenFoutmelding.Visible = true;
        }

        protected void ddlTypeMateriaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            LaadMerken();
        }

        protected void ddlMerk_SelectedIndexChanged(object sender, EventArgs e)
        {
            LaadMaterialen();
        }

        protected void ddlMateriaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            LaadMaten();
            LaadFoto();
        }

        protected void ddlMaat_SelectedIndexChanged(object sender, EventArgs e)
        {
            BerekenBeschikbaar();
        }

        protected void dpBeginDatum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime beginDatum = Convert.ToDateTime(dpBeginDatum.Text);
                DateTime eindDatum = Convert.ToDateTime(dpEindDatum.Text);

                if (beginDatum < DateTime.Today)
                {
                    ToonFout("De begindatum kan niet in het verleden zijn.", "alert-warning");
                    dpBeginDatum.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    return;
                }

                if (beginDatum > eindDatum)
                {
                    dpEindDatum.Text = beginDatum.AddDays(1).ToString("yyyy-MM-dd");
                }

                HurenFoutmelding.Visible = false;
                BerekenBeschikbaar();
            }
            catch (Exception ex)
            {
                ToonFout("Er is een fout opgetreden: " + ex.Message, "alert-danger");
            }
        }

        protected void dpEindDatum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime beginDatum = Convert.ToDateTime(dpBeginDatum.Text);
                DateTime eindDatum = Convert.ToDateTime(dpEindDatum.Text);

                if (eindDatum < beginDatum)
                {
                    ToonFout("De einddatum kan niet voor de begindatum zijn.", "alert-warning");
                    dpEindDatum.Text = beginDatum.AddDays(1).ToString("yyyy-MM-dd");
                    return;
                }

                HurenFoutmelding.Visible = false;
                BerekenBeschikbaar();
            }
            catch (Exception ex)
            {
                ToonFout("Er is een fout opgetreden: " + ex.Message, "alert-danger");
            }
        }
    }
}