using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;
using Logica;

public partial class frmConsulta_Estado_Solicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { txtEstado_Solicitud.Enabled = false; }
    }
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try 
        {
            int _Numero_Solicitud = Convert.ToInt32(txtNumero_Solicitud.Text);
            Solicitud _So = Logica_Solicitud.Buscar(_Numero_Solicitud);

            if(_So != null)
            {
                txtEstado_Solicitud.Text = _So.Estado;
                lblMensaje.Text = "";
            }
            else
            {
                txtNumero_Solicitud.Text = string.Empty;
                lblMensaje.Text = "No Existe una solicitud con el numero: " + _Numero_Solicitud;
            }
                
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try 
        {
            txtEstado_Solicitud.Text = string.Empty;
            txtNumero_Solicitud.Text = string.Empty;
            lblMensaje.Text = string.Empty;
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }
}