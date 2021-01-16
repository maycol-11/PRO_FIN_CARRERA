using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;
using Logica;

public partial class frmABM_de_Tipos_de_Tramites : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            Habilitar(true);
            CargarEntidades();           
        }
    }

    void Habilitar(bool habilita) 
    {
        ddlEntidades.Enabled = habilita;
        txtCodigo.Enabled = habilita;

        txtNombre.Enabled = !habilita;
        txtDescripcion.Enabled = !habilita;
        btnAgregar.Enabled = !habilita;
        btnModificar.Enabled = !habilita;
        btnEliminar.Enabled = !habilita;
    }

    void CargarEntidades()
    {
        List<Entidad> _Entidades = Logica_Entidad.Listar_Entidad();
        List<string> _NombreEntidades = new List<string>();

        foreach (Entidad en in _Entidades)
            _NombreEntidades.Add(en.Nombre);

        ddlEntidades.DataSource = _NombreEntidades;
        ddlEntidades.DataBind();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Habilitar(true);
        CargarEntidades();
        txtNombre.Text = string.Empty;
        txtDescripcion.Text = string.Empty;
        txtCodigo.Text = string.Empty;
        lblMensaje.Text = string.Empty;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try 
        {
            string _Codigo = txtCodigo.Text;
            string _Nombre_Entidad = ddlEntidades.SelectedItem.Text;

            Tramite _Tr = Logica_Tramite.Buscar(_Codigo, _Nombre_Entidad);

            if (_Tr == null)
            {
                Habilitar(false);
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                lblMensaje.Text = "No existe ninguna Tramite con el Codigo ingresado. Puede agregarlo.";
            }
            else if (_Tr is Tramite)
            {
                Habilitar(false);
                btnAgregar.Enabled = false;

                txtNombre.Text = _Tr.Nombre;
                txtCodigo.Text = _Tr.Codigo;
                txtDescripcion.Text = _Tr.Descripcion;
                ddlEntidades.Text = _Tr.Entidad.Nombre;
                Session["Tramite"] = _Tr;
                //ddlEntidades.DataBind();

                lblMensaje.Text = "";
            }
            else
                lblMensaje.Text = "Error por tipo de datos desconocido.";
        }
        catch(Exception ex)
        { lblMensaje.Text = ex.Message; }
    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try 
        {
            string _Codigo = txtCodigo.Text;
            string _Nombre_Entidad = ddlEntidades.SelectedItem.Text;
            string _Nombre_Tramite = txtNombre.Text;
            string _Descripcion = txtDescripcion.Text;
            Entidad _En = Logica_Entidad.Buscar(_Nombre_Entidad);

            Tramite _Tr = new Tramite(_Codigo, _Nombre_Tramite, _Descripcion, _En);

            Logica_Tramite.Agregar(_Tr);

            btnLimpiar_Click(null, null);
            lblMensaje.Text = "Se Agrego correctamente el trmite " + _Nombre_Tramite + " para la entidad " + _En.Nombre + ".";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try 
        {           
            string nomEntidad = ddlEntidades.Text;

            Tramite tr = (Tramite)Session["Tramite"];
            tr.Codigo = txtCodigo.Text;
            tr.Nombre = txtNombre.Text;
            tr.Descripcion = txtDescripcion.Text;
            tr.Entidad = Logica_Entidad.Buscar(nomEntidad);

            Logica_Tramite.Modificar(tr);
            btnLimpiar_Click(null, null);
            lblMensaje.Text = "Se Modifico correctamente el trmite " + tr.Nombre + " para la entidad " + tr.Entidad.Nombre + ".";

        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try 
        {
            Tramite tr = (Tramite)Session["Tramite"];

            Logica_Tramite.Eliminar(tr);
            btnLimpiar_Click(null, null);
            lblMensaje.Text = "Se Elimino correctamente el trmite " + tr.Nombre + " para la entidad " + tr.Entidad.Nombre + ".";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
}