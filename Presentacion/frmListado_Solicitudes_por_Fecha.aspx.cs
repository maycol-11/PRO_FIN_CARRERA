using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;
using Logica;

public partial class frmListado_Solicitudes_por_Fecha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnListar_Click(object sender, EventArgs e)
    {
        try 
        {
            DateTime _Fecha = Convert.ToDateTime(txtFecha.Text);
            Session["listaFecha"] = Logica_Solicitud.ListadoFecha(_Fecha);

            grvSolicitudes.DataSource = (List<Solicitud>)Session["listaFecha"];
            grvSolicitudes.DataBind();
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            txtFecha.Text = string.Empty;
            txtEntidades.Text = string.Empty;
            txtTramites.Text = string.Empty;
            grvSolicitudes.DataSource = null;
            grvSolicitudes.DataBind();
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }
    protected void grvSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            if (grvSolicitudes.SelectedIndex >= 0)
            {
                txtEntidades.Text = string.Empty;
                txtTramites.Text = string.Empty;
                List<Solicitud> _Milista = (List<Solicitud>)Session["ListaFecha"];

                Tramite _Tr = _Milista[grvSolicitudes.SelectedIndex].Tramite;
                txtTramites.Text += _Tr.ToString();

                Entidad _En = _Milista[grvSolicitudes.SelectedIndex].Tramite.Entidad;                
                txtEntidades.Text += _En.ToString();
            }
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }
}