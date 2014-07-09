using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessModel.Entities;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["Permiso"] = "Administrador";
            Session["Usuario"] = "cjauregui";
        }
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        if (txtBusqueda.Value != "")
        {

            BindBusquedaEmpresa(txtBusqueda.Value);
        }

    }
    protected void BindBusquedaEmpresa(string busqueda)
    {
        Empresa objEmpresa = new Empresa();
        List<Empresa> objEmpresas = new List<Empresa>();

        objEmpresas = objEmpresa.getEmpresasxNombrexParametro(busqueda);

        if (objEmpresas.Count != 0)
        {
            litEmpresas.Text = "<table>";


            foreach (Empresa objEmpresita in objEmpresas)
            {
                litEmpresas.Text = litEmpresas.Text + "<tr>" +
                                  "<td>" + objEmpresita.nombre + "</td></tr>";
            }

            litEmpresas.Text = litEmpresas.Text + " </tbody>" +
                                "</table>";

        }

    }

}