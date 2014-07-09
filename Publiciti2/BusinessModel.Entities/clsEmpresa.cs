using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Spatial;

using Support.DataBases.Provider;

namespace BusinessModel.Entities
{
    public class Empresa
    {
        public int idEmpresa { get; set; }
        public int idCategoria { get; set; }
        public int idSubCategoria { get; set; }
        public int idTipoCliente { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
	    public string domCalle { get; set; }
	    public string domNoExt { get; set; }
	    public string domNoInt { get; set; }
	    public int domIdColonia { get; set; }
	    public string domCP { get; set; }
	    public int domIdCiudad { get; set; }
	    public int domIdMunicipio { get; set; }
	    public int domIdEstado { get; set; }
	    public int domIdPais { get; set; }
	    public string keywords { get; set; }
	    public bool estatus { get; set; }
	    public double mapaLatitud  { get; set; }
        public double mapaLongitud { get; set; }
	    public int imagen  { get; set; }
	    public int imagenNo  { get; set; }
        public bool comercioE { get; set; }
	    public string medios  { get; set; }
        public int unico { get; set; }

        public static string[] clasesMedios = { "Facebook", "Twitter", "YouTube" };


        private string cadenaConexion = ConfigurationManager.ConnectionStrings["dbPubliciti" + System.Web.HttpContext.Current.Session["Permiso"].ToString()].ConnectionString;

        public Empresa getEmpresa(int idEmpresa)
        {
            DataHelper objDAL = new DataHelper(DataAbstraction.DataProvider.SQLServer, cadenaConexion);

            DbDataReader dr = objDAL.ReadData("Clientes_stpGetEmpresa", CommandType.StoredProcedure, new DataParameter("idEmpresa", idEmpresa));

            try
            {
                if (dr.Read())
                {
                    this.idEmpresa = dr.GetInt32(0);
                    this.idCategoria = dr.GetInt32(1);
                    this.idSubCategoria = dr.GetInt32(2);
                    this.idTipoCliente = dr.GetInt32(3);
                    this.nombre = dr.GetString(4);
                    this.descripcion = dr.GetString(5);
                    this.domCalle = dr.GetString(6);
                    this.domNoExt = dr.GetString(7);
                    if (!dr.IsDBNull(8))
                    {
                        this.domNoInt = dr.GetString(8);
                    }
                    else
                    {
                        this.domNoInt = string.Empty;
                    }
                    this.domIdColonia = dr.GetInt32(9);
                    this.domCP = dr.GetString(10);
                    this.domIdCiudad = dr.GetInt32(11);
                    this.domIdMunicipio = dr.GetInt32(12);
                    this.domIdEstado = dr.GetInt32(13);
                    this.domIdPais = dr.GetInt32(14);
                    this.keywords = dr.GetString(15);
                    this.estatus = dr.GetBoolean(16);
                    //this.mapaLatitud = dr.GetDouble(17);
                    //this.mapaLongitud = dr.GetDouble(18);
                    this.imagen = dr.GetInt16(19);
                    this.imagenNo = dr.GetInt16(20);
                    this.comercioE = dr.GetBoolean(21);
                    this.medios = dr.GetString(22);

                }
                dr.Close();
                objDAL.Dispose();
            }
            catch (Exception ex)
            {
                Bitacora registro = new Bitacora();
                if (objDAL.ExceptionMessage != null)
                {
                    registro.registroError(objDAL.ExceptionMessage);
                }

                else
                {
                    registro.registroError(ex.Message);
                }
                registro = null;
            }

            return this;
        }

        public List<Empresa> getEmpresasxNombrexParametro(string busqueda)
        {
            DataHelper objDAL = new DataHelper(DataAbstraction.DataProvider.SQLServer, cadenaConexion);
            List<Empresa> objList = new List<Empresa>();


            DbDataReader dr = objDAL.ReadData("Clientes_stpGetEmpresasxNombrexParametro", CommandType.StoredProcedure, new DataParameter("busqueda", busqueda));


            try
            {
                while (dr.Read())
                {
                    Empresa objItem = new Empresa();

                    objItem.unico = dr.GetInt32(0);
                    objItem.idEmpresa = dr.GetInt32(1);
                    objItem.nombre = dr.GetString(2);
                    objItem.domCalle = dr.GetString(3);
                    objItem.domNoExt = dr.GetString(4);
                    if (!dr.IsDBNull(5))
                    { 
                        objItem.domNoInt = dr.GetString(5);
                    }
                    else
                    {
                        objItem.domNoInt = string.Empty;
                    }
                    objItem.domIdColonia = dr.GetInt32(6);
                    if (!dr.IsDBNull(7))
                    {
                        objItem.mapaLatitud = dr.GetDouble(7);
                    }
                    else
                    {
                        objItem.mapaLatitud = 0;
                    }
                    if (!dr.IsDBNull(8))
                    {
                        objItem.mapaLongitud = dr.GetDouble(8);
                    }
                    else
                    {
                        objItem.mapaLongitud = 0;
                    }
                    if (!dr.IsDBNull(9))
                    {
                        objItem.medios = dr.GetString(9);
                    }
                    else
                    {
                        objItem.medios = string.Empty;
                    }

                    objList.Add(objItem);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Bitacora registro = new Bitacora();
                if (objDAL.ExceptionMessage != null)
                {
                    registro.registroError(objDAL.ExceptionMessage);
                }

                else
                {
                    registro.registroError(ex.Message);
                }
                objList = null;
                registro = null;
            }

            objDAL.Dispose();

            return objList;

        }

        public List<Empresa> getAllEmpresas()
        {
            DataHelper objDAL = new DataHelper(DataAbstraction.DataProvider.SQLServer, cadenaConexion);
            List<Empresa> objList = new List<Empresa>();


            DbDataReader dr = objDAL.ReadData("Clientes_stpGetEmpresas", CommandType.StoredProcedure);


            try
            {
                while (dr.Read())

                    
                {
                    Empresa objItem = new Empresa();

                    objItem.idEmpresa = dr.GetInt32(0);
                    objItem.idCategoria = dr.GetInt32(1);
                    objItem.idSubCategoria = dr.GetInt32(2);
                    objItem.idTipoCliente = dr.GetInt32(3);
                    objItem.nombre = dr.GetString(4);
                    objItem.descripcion = dr.GetString(5);
                    objItem.domCalle = dr.GetString(6);
                    objItem.domNoExt = dr.GetString(7);
                    if (!dr.IsDBNull(8))
                    {
                        objItem.domNoInt= dr.GetString(8);
                    }
                    else
                    {
                        objItem.domNoInt = string.Empty;
                    }
                    objItem.domIdColonia = dr.GetInt32(9);
                    objItem.domCP = dr.GetString(10);
                    objItem.domIdCiudad = dr.GetInt32(11);
                    objItem.domIdMunicipio = dr.GetInt32(12);
                    objItem.domIdEstado = dr.GetInt32(13);
                    objItem.domIdPais = dr.GetInt32(14);
                    objItem.keywords = dr.GetString(15);
                    objItem.estatus = dr.GetBoolean(16);
                    //if (!dr.IsDBNull(17))
                    //{
                    //    objItem.mapaLatitud = dr.GetDouble(17);
                    //}
                    //else
                    //{
                    //    objItem.mapaLatitud = 0;
                    //}

                    //if (!dr.IsDBNull(18))
                    //{
                    //    objItem.mapaLongitud = dr.GetDouble(18);
                    //}
                    //else
                    //{
                    //    objItem.mapaLongitud = 0;
                    //}
                    objItem.imagen = dr.GetInt16(19);
                    objItem.imagenNo = dr.GetInt16(20);
                    objItem.comercioE = dr.GetBoolean(21);
                    objItem.medios = dr.GetString(22);

                    objList.Add(objItem);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Bitacora registro = new Bitacora();
                if (objDAL.ExceptionMessage != null)
                {
                    registro.registroError(objDAL.ExceptionMessage);
                }

                else
                { 
                    registro.registroError(ex.Message);
                }
                objList = null;
                registro = null;
            }
            
            objDAL.Dispose();

            return objList;

        }

        public Empresa setEmpresa(int idEmpresa, int idCategoria, int idSubCategoria, int idTipoCliente, string nombre)
        {
            DataHelper objDAL = new DataHelper(DataAbstraction.DataProvider.SQLServer, cadenaConexion);

            try
            {

                objDAL.Execute("Clientes_stpSetEmpresa2", CommandType.StoredProcedure, 
                                                                new DataParameter("idEmpresa", idEmpresa),
                                                                new DataParameter("idCategoria", idCategoria),
                                                                new DataParameter("idSubCategoria", idSubCategoria),
                                                                new DataParameter("idTipoCliente", idTipoCliente),
                                                                new DataParameter("nombre", nombre)
                                                                );
            }
            catch (Exception ex)
            {
                Bitacora registro = new Bitacora();
                if (objDAL.ExceptionMessage != null)
                {
                    registro.registroError(objDAL.ExceptionMessage);
                }

                else
                {
                    registro.registroError(ex.Message);
                }
           
                registro = null;
            }

            objDAL.Dispose();

            return this;
        }

        public Empresa updEmpresa(int idEmpresa, int idCategoria, int idSubCategoria, int idTipoCliente, string nombre)
        {
            DataHelper objDAL = new DataHelper(DataAbstraction.DataProvider.SQLServer, cadenaConexion);

            try
            {

                objDAL.Execute("Clientes_stpUpdEmpresa2", CommandType.StoredProcedure,
                                                                new DataParameter("idEmpresa", idEmpresa),
                                                                new DataParameter("idCategoria", idCategoria),
                                                                new DataParameter("idSubCategoria", idSubCategoria),
                                                                new DataParameter("idTipoCliente", idTipoCliente),
                                                                new DataParameter("nombre", nombre)
                                                                );
            }
            catch (Exception ex)
            {
                Bitacora registro = new Bitacora();
                if (objDAL.ExceptionMessage != null)
                {
                    registro.registroError(objDAL.ExceptionMessage);
                }

                else
                {
                    registro.registroError(ex.Message);
                }

                registro = null;
            }


            objDAL.Dispose();

            return this;
        }

        
    }

}