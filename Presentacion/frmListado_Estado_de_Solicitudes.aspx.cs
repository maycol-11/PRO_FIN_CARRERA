using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;
using Logica;

public partial class frmListado_Estado_de_Solicitudes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            CargarEntidades();
            CargarFiltro();
            ddlFiltro.Enabled = false;
        }
        
    }

    void CargarFiltro()
    {
        List<string> filtro = new List<string>();
        string _Todos = "TODOS";
        string _Ejecutada = "EJECUTADA";
        string _Anulada = "ANULADA";

        filtro.Add(_Todos);
        filtro.Add(_Ejecutada);
        filtro.Add(_Anulada);

        ddlFiltro.DataSource = filtro;
        ddlFiltro.DataBind();
    }

    void CargarEntidades()
    {
        Session["Entidades"] = Logica_Entidad.Listar_Entidad();
        List<Entidad> _Entidades = (List<Entidad>)Session["Entidades"];
        

        if (_Entidades.Count > 0)
        {
            ddlEntidad.DataSource = _Entidades;
            ddlEntidad.DataTextField = "Nombre";
            ddlEntidad.DataBind();

            CargarTramite(ddlEntidad.SelectedItem.Text);
        }
        else if (_Entidades.Count == 0)
        {
            List<string> lista = new List<string>();
            string vacio = "Lista de entidaes vacia";
            lista.Add(vacio);
            ddlEntidad.DataSource = lista;
            ddlEntidad.DataBind();
        }
    }

    void CargarTramite(string pNombre)
    {
        List<Entidad> _Entidades = (List<Entidad>)Session["Entidades"];
        Entidad _En = null;
        foreach (Entidad en in _Entidades) 
        {
            if (en.Nombre == pNombre)
                _En = en;
        }
        Session["Tramites"] = Logica_Tramite.Listar_Tramite_X_Entidad(_En);
        grvTramite.DataSource = (List<Tramite>)Session["Tramites"];
        grvTramite.DataBind();
    }
    protected void ddlEntidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CargarTramite(ddlEntidad.SelectedItem.Text);
            grvSolicitudes.DataSource = null;
            grvSolicitudes.DataBind();
            grvTramite.SelectedIndex = -1;
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }
    protected void grvTramite_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Tramite> listaTramite = (List<Tramite>)Session["Tramites"];
            string _Codigo = listaTramite[grvTramite.SelectedIndex].Codigo;
            string _Estado = ddlFiltro.SelectedItem.Text;

            ddlFiltro.Enabled = true;

            List<Solicitud>listaSolicitudes = Logica_Solicitud.ListarSolicitud(_Codigo, _Estado);
            grvSolicitudes.DataSource = listaSolicitudes;
            grvSolicitudes.DataBind();
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }
    protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Tramite> listaTramite = (List<Tramite>)Session["Tramites"];
            string _Codigo = listaTramite[grvTramite.SelectedIndex].Codigo;
            string _Estado = ddlFiltro.SelectedItem.Text;

            List<Solicitud> listaSolicitudes = Logica_Solicitud.ListarSolicitud(_Codigo, _Estado);
            grvSolicitudes.DataSource = listaSolicitudes;
            grvSolicitudes.DataBind();
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }
}