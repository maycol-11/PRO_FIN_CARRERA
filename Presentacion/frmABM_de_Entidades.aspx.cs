using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades_Compartidas;
using Logica;

public partial class frmABM_de_Entidades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Habilitar(true);
    }

    void Habilitar(bool habilita) 
    {
        txtNombre.Enabled = habilita;
        btnBuscar.Enabled = habilita;

        txtDireccion.Enabled = !habilita;
        txtTelefono.Enabled = !habilita;

        btnAgregar.Enabled = !habilita;
        btnEliminarTelefono.Enabled = !habilita;
        btnModificar.Enabled = !habilita;
        btnEliminar.Enabled = !habilita;

        btnAgregarTelefono.Enabled = !habilita;
        btnEliminarTelefono.Enabled = !habilita;
        lstbLista_Telefonos.Enabled = !habilita;
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string _Nombre = txtNombre.Text;

            Entidad _E = Logica_Entidad.Buscar(_Nombre);

            if (_E == null)
            {
                Habilitar(false);
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminarTelefono.Enabled = false;                
                lblMensaje.Text = "No existe ninguna Entidad con el nombre ingresado. Puede agregarlo.";
            }
            else if (_E is Entidad)
            {                                
                Habilitar(false);
                btnAgregar.Enabled = false;
                txtDireccion.Text = _E.Direccion;
                Session["Entidad"] = _E;

                lstbLista_Telefonos.DataSource = _E.Telefonos;
                lstbLista_Telefonos.DataBind();               
                                              
                lblMensaje.Text = "";
            }
            else
                lblMensaje.Text = "Error por tipo de datos desconocido.";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }


    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Habilitar(true);
        txtNombre.Text = string.Empty;
        txtDireccion.Text = string.Empty;        
        txtTelefono.Text = string.Empty;        
        lstbLista_Telefonos.Items.Clear();
        lblMensaje.Text = string.Empty;
    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string _Nombre = txtNombre.Text;
            string _Direccion = txtDireccion.Text;
            string _Telefono = txtTelefono.Text;

            //Obtengo los telefonos desde el listbox
            List<string> _ListaTelefonos = new List<string>();
            foreach (ListItem item in lstbLista_Telefonos.Items)
                _ListaTelefonos.Add(item.Text);

            Entidad _E = new Entidad(_Nombre, _Direccion, _ListaTelefonos);

            Logica_Entidad.Agregar(_E);
            btnLimpiar_Click(null,null);
            lblMensaje.Text = "La entidad se agrego correctamente.";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }    

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try 
        {
           List<string> _ListaTelefonos = new List<string>();
            foreach (ListItem item in lstbLista_Telefonos.Items)
                _ListaTelefonos.Add(item.Text);

            Entidad en = (Entidad)Session["Entidad"];
            en.Nombre = txtNombre.Text;
            en.Direccion = txtDireccion.Text;
            en.Telefonos = _ListaTelefonos;

            Logica_Entidad.Modificar(en);
            btnLimpiar_Click(null,null);
            lblMensaje.Text = "La entidad " + en.Nombre + " se modifico de forma correcta.";
        }
        catch(Exception ex)
        { lblMensaje.Text = ex.Message; }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Entidad en = (Entidad)Session["Entidad"];

            Logica_Entidad.Eliminar(en);
            btnLimpiar_Click(null,null);
            lblMensaje.Text = "La entidad " + en.Nombre + " se elimino de forma correcta.";
        }
        catch(Exception ex)
        { lblMensaje.Text = ex.Message; }
    }

    protected void btnAgregarTelefono_Click(object sender, EventArgs e)
    {
        try 
        {
            string _Telefono = txtTelefono.Text.Trim();
            List<string> _ListaTelefonos = new List<string>();

            foreach (ListItem item in lstbLista_Telefonos.Items)
            {
                if (item.Text == _Telefono)
                    throw new Exception("Ya existe el numero telefonico que intenta Agregar");
            }
            lstbLista_Telefonos.Items.Add(_Telefono);

            txtTelefono.Text = "";
        }
        catch (Exception ex) { lblMensaje.Text = ex.Message; }
    }

    protected void btnEliminarTelefono_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstbLista_Telefonos.SelectedIndex >= 0)
            {
                lstbLista_Telefonos.Items.RemoveAt(lstbLista_Telefonos.SelectedIndex);
            }

        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
}