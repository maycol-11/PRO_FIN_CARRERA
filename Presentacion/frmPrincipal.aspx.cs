using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;
using Logica;

public partial class Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            Session["Entidades"] = Logica_Entidad.Listar_Entidad();
            List<Entidad> listaEntidades = (List<Entidad>)Session["Entidades"];
            grvEntiades.DataSource = listaEntidades;
            grvEntiades.DataBind();
        }
    }
    protected void grvEntiades_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            List<Entidad> listaEntidades = (List<Entidad>)Session["Entidades"];
            Entidad _En = listaEntidades[grvEntiades.SelectedIndex];
            List<Tramite> listaTramites = Logica_Tramite.Listar_Tramite_X_Entidad(_En);
            grvTramites.DataSource = listaTramites;
            grvTramites.DataBind();
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }
}