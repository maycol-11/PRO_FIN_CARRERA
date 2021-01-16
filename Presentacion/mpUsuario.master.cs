using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;

public partial class mpUsuario : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();
        }

        if (Session["user"] == null)
            Response.Redirect("frmLogueo.aspx");
        if (!(Session["user"] is Empleado))
            Response.Redirect("frmError.aspx");

        lblUsuario.Text = Session["user"].ToString();
    }

    protected void lbtnCerrar_Secion_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Response.Redirect("frmLogueo.aspx");
    }
}
