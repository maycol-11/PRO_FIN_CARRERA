using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;
using Logica;

public partial class frmABM_de_Empleados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            Habilitar(true);
    }

    void Habilitar (bool habilita)
    {
        txtCedula.Enabled = habilita;
        btnBuscar.Enabled = habilita;

        txtNombre.Enabled = !habilita;
        txtContrasenia.Enabled = !habilita;
        btnAgregar.Enabled = !habilita;
        btnModificar.Enabled = !habilita;
        btnEliminar.Enabled = !habilita;
    }
    
    protected void btnBuscar_Click1(object sender, EventArgs e)
    {
        try
        {
            int _Cedula = Convert.ToInt32(txtCedula.Text);
            Empleado _Em = Logica_Empleado.Buscar(_Cedula);

            if (_Em == null)
            {
                Habilitar(false);
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                lblMensaje.Text = "No existe ningun Empleado con la C.I. Ingresado. Puede agregarlo.";
            }
            else if (_Em is Empleado)
            {
                Habilitar(false);
                txtNombre.Text = _Em.Nombre;
                txtContrasenia.Text = _Em.Contrasenia;
                Session["Empleado"] = _Em;
                lblMensaje.Text = "";
            }
            else
                lblMensaje.Text = "Error por tipo de dato desconocido";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }

    protected void btnLimpiar_Click1(object sender, EventArgs e)
    {
        try
        {
            Habilitar(true);
            txtCedula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtContrasenia.Text = string.Empty;
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
    protected void btnAgregar_Click1(object sender, EventArgs e)
    {
        try
        {
            int _Cedula = Convert.ToInt32(txtCedula.Text);
            string _Nombre = txtNombre.Text;
            string _Contrasenia = txtContrasenia.Text;


            Empleado _Em = new Empleado(_Cedula, _Nombre, _Contrasenia);
            Logica_Empleado.Agregar(_Em);

            btnLimpiar_Click1(null, null);
            lblMensaje.Text = "El empleado se Agrego Correctamente.";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }

    protected void btnModificar_Click1(object sender, EventArgs e)
    {
        try
        {
            Empleado em = (Empleado)Session["Empleado"];

            em.Cedula = Convert.ToInt32(txtCedula.Text);
            em.Nombre = txtNombre.Text;
            em.Contrasenia = txtContrasenia.Text;

            Logica_Empleado.Modificar(em);

            btnLimpiar_Click1(null, null);
            lblMensaje.Text = "El Empleado se modifico correctamente.";

        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }

    protected void btnEliminar_Click1(object sender, EventArgs e)
    {
        try
        {
            Empleado em = (Empleado)Session["Empleado"];
            Logica_Empleado.Eliminar(em);

            btnLimpiar_Click1(null, null);
            lblMensaje.Text = "El empleado se Elimino de forma correcta.";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
}