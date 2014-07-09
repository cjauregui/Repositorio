using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Xml;

using BusinessModel.Entities;

public partial class Empresas : System.Web.UI.Page

{

    protected override void OnInit(EventArgs e)
    {
        Empresa objEmpresa = new Empresa();

        foreach (string medio in Empresa.clasesMedios)
        {
            litMedios.Text = litMedios.Text +"<input id='chk" + medio + "' type='checkbox' runat='server'/><label for='chk" + medio + "'>" + medio + "</label>";

        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCategorias();
            var items = lstSubCategorias.Items;
            items.Add(new ListItem("--Seleccione categoría--", "0"));
            BindEmpresas();
        }
        
    }
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        if(txtBuscar.Value!="")
            {

                BindBusquedaEmpresa(txtBuscar.Value);
            }
        
    }

    protected void lstCategorias_Change(object sender, EventArgs e)
    {

        BindSubCategorias(Convert.ToInt32(lstCategorias.Value));

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
       
        if (validaDatos()==1)
        {
            Empresa objEmpresa = new Empresa();

            objEmpresa.updEmpresa(Convert.ToInt32(txtidEmpresa.Value), 
                            Convert.ToInt32(lstCategorias.Value), 
                            Convert.ToInt32(lstSubCategorias.Value), 
                            Convert.ToInt32(lstTipoEmpresas.Value), 
                            txtNombre.Value);
            Response.Redirect("Index.aspx");
        }

        
    }

    protected int validaDatos()
    {
        int resultado = 1;

        if (txtNombre.Value == "")
        {
            lblNombre.Attributes.Add("class", "error");
            txtNombre.Attributes.Add("placeholder", "Es necesario teclear el nombre");
            resultado= 0;
        }
        //if (lstCategoria.Value == "0")
        //{
        //    lblCategoria.Attributes.Add("class", "error");
            //resultado= 0;
        //}

        return resultado;
        
    }


    protected void BindCategorias()
    {
        Categoria objCategoria = new Categoria();
        List<Categoria> objCategorias = new List<Categoria>();

        objCategorias = objCategoria.getAllCategorias();

        if (objCategorias != null)
        {
            var items = lstCategorias.Items;
            items.Add(new ListItem("--Seleccione un valor--", "0"));

            foreach (Categoria objCat in objCategorias)
            {

                items.Add(new ListItem(objCat.categoria, objCat.idCategoria.ToString()));
                
            }

        }

    }
    protected void BindSubCategorias(int idCat)
    {
        SubCategoria objSubCategoria = new SubCategoria();
        List<SubCategoria> objSubCategorias = new List<SubCategoria>();

        objSubCategorias = objSubCategoria.getSubCategoriasxCategoria(idCat);

        if (objSubCategorias != null)
        {
            var items = lstSubCategorias.Items;
            items.Clear();
            items.Add(new ListItem("--Seleccione un valor--", "0"));

            foreach (SubCategoria objSubCat in objSubCategorias)
            {

                items.Add(new ListItem(objSubCat.subCategoria, objSubCat.idSubCategoria.ToString()));

            }

        }

    }

    protected void BindEmpresas()
    {
        Empresa objEmpresa = new Empresa();
        List<Empresa> objEmpresas = new List<Empresa>();

        objEmpresas = objEmpresa.getAllEmpresas();

        if (objEmpresas!=null)
        {
            litEmpresas.Text = "<table>"+ 
                                    "<thead>"+ 
                                        "<tr>"+ 
                                          "<th>Empresa</th>"+ 
                                          "<th>Dirección</th>"+ 
                                          "<th>&nbsp;</th>"+ 
                                          "<th>&nbsp;</th>"+ 
                                        "</tr>"+ 
                                    "</thead>"+ 
                                    "<tbody>";
   
 
            foreach (Empresa objEmpresita in objEmpresas)    
            {
                litEmpresas.Text = litEmpresas.Text + "<tr>" +
                                  "<td>" + objEmpresita.nombre + "</td>" +
                                  "<td>" + objEmpresita.domCalle + " No." + objEmpresita.domNoExt;
                if (objEmpresita.domNoInt != String.Empty)
                {
                    litEmpresas.Text = litEmpresas.Text + "-" + objEmpresita.domNoInt + "</td>";
                }
                else
                { 
                    litEmpresas.Text = litEmpresas.Text + "</td>";
                }
                litEmpresas.Text = litEmpresas.Text +
                                   "<td>&nbsp;</td>"+
                                   "<td>&nbsp;</td>" +
                                "</tr>";
            }

                litEmpresas.Text = litEmpresas.Text + " </tbody>" +
                                    "</table>";

        }

    }

    protected void BindBusquedaEmpresa(string busqueda)
    {
        Empresa objEmpresa = new Empresa();
        List<Empresa> objEmpresas = new List<Empresa>();

        objEmpresas = objEmpresa.getEmpresasxNombrexParametro(busqueda);

        if (objEmpresas.Count != 0)
        {
            litEmpresas.Text = "<table>" +
                                    "<thead>" +
                                        "<tr>" +
                                          "<th>Empresa</th>" +
                                          "<th>Domicilio</th>" +
                                          "<th>Medios</th>" +
                                        "</tr>" +
                                    "</thead>" +
                                    "<tbody>";


            foreach (Empresa objEmpresita in objEmpresas)
            {
                litEmpresas.Text = litEmpresas.Text + "<tr>" +
                                  "<td>" + objEmpresita.nombre + "</td>" +
                                  "<td>" + objEmpresita.domCalle+" No."+objEmpresita.domNoExt+" Int."+objEmpresita.domNoInt + "</td>" +
                                  "<td>" + objEmpresita.medios + "</td>";
              
                litEmpresas.Text = litEmpresas.Text +
                                "</tr>";
            }

            litEmpresas.Text = litEmpresas.Text + " </tbody>" +
                                "</table>";

        }
        else
        {
            litEmpresas.Text = "<table>" +
                                    "<thead>" +
                                        "<tr>" +
                                          "<th>Empresa</th>" +
                                          "<th>Domicilio</th>" +
                                          "<th>Medios</th>" +
                                        "</tr>" +
                                    "</thead>" +
                                    "<tbody>"+
                                    "<tr>" +
                                  "<td colspan='3'>No hay coincidencias</td></tbody>" +
                                "</table>";
        }

    }
}