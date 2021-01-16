using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;
using Logica;

public partial class frmCambio_Estado_Solicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Listar();
    }

    void Listar()
    {
        Session["ListarSolicitudAlta"] = Logica_Solicitud.ListadoSolicitudAlta();
        grvLista_de_Solicitudes.DataSource = (List<Solicitud>)Session["ListarSolicitudAlta"];
        grvLista_de_Solicitudes.DataBind();
    }

    protected void grvLista_de_Tramite_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            List<Solicitud> listaSolicitud = (List<Solicitud>)Session["ListarSolicitudAlta"];
            int fila = Convert.ToInt32(e.CommandArgument);
            Solicitud so = listaSolicitud[fila];

            if (e.CommandName == "Anular")
                so.Estado = "ANULADA";
            else if (e.CommandName == "Ejecutar")
                so.Estado = "EJECUTADA";

            Logica_Solicitud.ModificarEstado(so);
            Listar();

            lblMensaje.Text = "El estado de la solicitud " + so.Numero + " se cambio a " + so.Estado;
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }       
    }
}