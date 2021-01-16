using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;
using Logica;

public partial class frmRegistrar_una_Solicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {            
            //cargo dos listas en la session para trabajar
            Session["listaTramite"] = Logica_Tramite.ListarTramite();

            //cargo las dos grillas
            grvLista_de_Tramites.DataSource = (List<Tramite>)Session["listaTramite"];
            grvLista_de_Tramites.DataBind();

            cldFecha.VisibleDate = DateTime.Today;
            cldFecha.SelectedDate = DateTime.Today;
        }
    }

    protected void grvLista_de_Tramites_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            if (grvLista_de_Tramites.SelectedIndex >= 0)
            {
                List<Tramite> _Milista = (List<Tramite>)Session["listaTramite"];
                Tramite _Tr = _Milista[grvLista_de_Tramites.SelectedIndex];
                txtDetalles.Text += "El tramite seleccionado: " + _Tr.ToString();
            }
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }

    protected void btnRegistrar_Solicitud_Click(object sender, EventArgs e)
    {
        try
        {
            int _Numero_Solicitud;
            DateTime _Fecha;
            Tramite _Tr;
            Empleado _Em;
            string _Solicitante;
            List<Tramite> _Milista = (List<Tramite>)Session["listaTramite"];

            _Numero_Solicitud = 0;
            _Tr = _Milista[grvLista_de_Tramites.SelectedIndex];
            _Em = (Empleado)Session["user"];            
            _Solicitante = txtNombre_Solicitante.Text;
            _Fecha = cldFecha.SelectedDate;
            _Fecha = _Fecha.AddHours(Convert.ToDouble(txtHora.Text));
            _Fecha = _Fecha.AddMinutes(Convert.ToDouble(txtMinutos.Text));

            Solicitud _So = new Solicitud(_Numero_Solicitud,_Fecha, "ALTA", _Solicitante, _Tr, _Em);
            Logica_Solicitud.Agregar(_So);
            btnLimpiar_Click(null,null);
            lblMensaje.Text = "La Solicitud se registro correctamente";
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try 
        {
            cldFecha.SelectedDate = DateTime.Today;
            cldFecha.VisibleDate = DateTime.Today;
            txtHora.Text = string.Empty;
            txtMinutos.Text = string.Empty;
            txtNombre_Solicitante.Text = string.Empty;
            grvLista_de_Tramites.SelectedIndex = -1;
            txtDetalles.Text = string.Empty;
            lblMensaje.Text = string.Empty;
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }
}