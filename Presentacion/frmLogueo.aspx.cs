using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;
using Logica;

public partial class frmLogueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnIniciar_Secion_Click(object sender, EventArgs e)
    {
        try 
        {
            int _Cedula = 0;
            if (!int.TryParse(txtCedula.Text, out _Cedula))
                throw new Exception("El nombre de funcionario no tiene formato correcto");

            string _Contrasenia = txtContrasenia.Text;

            Empleado _Em = Logica_Empleado.Login(_Cedula, _Contrasenia);

            if (_Em == null)
                lblMensaje.Text = "El usuario y/o Contrasenia no son Correctos";
            else 
            {
                Session["user"] = _Em;
                Response.Redirect("frmRegistrar_una_Solicitud.aspx");
            }
        }
        catch(Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
}