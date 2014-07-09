<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Empresas.aspx.cs" Inherits="Empresas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>PUBLICITI</title>
    <link rel="stylesheet" href="css/foundation.css" />
    <script src="js/vendor/modernizr.js"></script>
</head>
<body>
    <form id="frmEmpresa" runat="server">
        <nav class="top-bar" "data-topbar"> 
            <ul class="title-area"> 
                <li class="name"> 
                    <h1>
                        <a href="#"></a>
                    </h1> 
                </li> 
                <!-- Remove the class "menu-icon" to get rid of menu icon. Take out "Menu" to just have icon alone --> 
                <li class="toggle-topbar menu-icon">
                    <a href="#"><span>Menu</span></a>
                </li> 
            </ul> 
            <section class="top-bar-section"> 
                <!-- Left Nav Section --> 
                <ul class="left"> 
                    <li  class="active">
                        <a href="#">Inicio</a>
                    </li> 
                </ul> 
                <!-- Right Nav Section --> 
                <ul class="right"> 
                    <li>
                        <a href="#">Empresas</a>
                    </li> 
                    <li class="has-dropdown"> 
                        <a href="#">Catálogos</a> 
                        <ul class="dropdown"> 
                            <li>
                                <a href="#">Colonias</a>
                            </li>
                            <li>
                                <a href="#">Municipios</a>
                            </li>
                            <li>
                                <a href="#">Estados</a>
                            </li>
                        </ul> 
                    </li> 
                </ul> 
            </section> 
        </nav>
        <div class="row">
            <div class="large-12 columns">
                <h1>Catálogos WEB</h1>
            </div>
        </div>

  

        <div class="row">
            <div class="large-12 columns">
                <label>Buscar Empresa:
                    <input id="txtBuscar" type="text" runat="server"/>
                </label>
            </div>
        </div>
        <div class="row">
            <div class="large-12 columns">
                <input id="btnConsultar" type="submit" class="button [tiny small large]" value="Consultar" OnServerClick="btnConsultar_Click" runat="server" />
            </div>
        </div>

        <div class="row">
            <div class="large-12 columns">
                <asp:Literal ID="litEmpresas" runat="server"></asp:Literal>
            </div>
        </div>

        <div class="row">
            <div class="large-12 columns">
                <fieldset>
                        <legend>Datos de la Empresa</legend>
                        <div class="row">
                            <div class="large-12 columns">
                                <label id="lblNombre" runat="server">Nombre de la empresa:
                                    <input id="txtidEmpresa" type="hidden" runat="server"/>
                                    <input id="txtNombre" type="text" runat="server" class="error"/>
                                </label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="large-12 columns">
                                <fieldset>
                                    <legend>Dirección</legend>
                                    <div class="large-8 columns">
                                        <label>Calle
                                            <input id="txtDomCalle" runat="server"/>
                                        </label>
                                    </div>
                                    <div class="large-2 columns">
                                        <label>No. Ext.
                                            <input id="txtDomNoExt" runat="server"/>
                                        </label>
                                    </div>
                                    <div class="large-2 columns">
                                        <label>No. Int.
                                            <input id="txtDomNoInt" runat="server"/>
                                        </label>
                                    </div>
                                </fieldset>
                            </div>
                        </div>

                        <div class="row">
                            <div class="large-4 columns">
                                <label id="lblCategorias" runat="server">Categoría:
                                    <select id="lstCategorias" runat="server" OnServerChange="lstCategorias_Change">
                                    </select>
                                </label>
                            </div>
                            <div class="large-4 columns">
                                <label id="lblSubCategorias" runat="server">Subcategoría:
                                    <select id="lstSubCategorias" runat="server">
                                    </select>
                                </label>
                            </div>
                            <div class="large-4 columns">
                                <label id="lblTipoEmpresas" runat="server">Tipo de Cliente:
                                    <select id="lstTipoEmpresas" runat="server">
                                    </select>
                                </label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="large-12 columns">
                                <fieldset>
                                    <legend>Medios</legend>
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <asp:Literal ID="litMedios" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                 </fieldset>
                            </div>
                        </div>


                        <div class="row">
                            <div class="large-12 columns">
                                <input id="btnEnviar" type="submit" class="button [tiny small large]" value="Enviar Actualización" OnServerClick="btnEnviar_Click" runat="server" />
                            </div>
                        </div>

                    </fieldset>
                </div>
            </div>
        <script src="js/vendor/jquery.js"></script>
        <script src="js/foundation.min.js"></script>
        <script>
            $(document).foundation();
        </script>
    </form>
</body>
</html>
