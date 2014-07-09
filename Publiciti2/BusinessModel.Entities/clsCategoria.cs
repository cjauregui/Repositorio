using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Common;

using System.Configuration;

using Support.DataBases.Provider;

namespace BusinessModel.Entities
{
    public class Categoria
    {

        public int idCategoria { get; set; }
        public string categoria { get; set; }

        private string cadenaConexion = ConfigurationManager.ConnectionStrings["dbPubliciti" + System.Web.HttpContext.Current.Session["Permiso"].ToString()].ConnectionString;

        public List<Categoria> getAllCategorias()
        {
            DataHelper objDAL = new DataHelper(DataAbstraction.DataProvider.SQLServer, cadenaConexion);
            List<Categoria> objList = new List<Categoria>();


            DbDataReader dr = objDAL.ReadData("Clientes_stpGetCategorias", CommandType.StoredProcedure);


            try
            {
                while (dr.Read())
                {
                    Categoria objItem = new Categoria();

                    objItem.idCategoria = dr.GetInt32(0);
                    objItem.categoria = dr.GetString(1);

                    objList.Add(objItem);
                }

                dr.Close();
            }
            catch
            {
                Bitacora registro = new Bitacora();
                if (objDAL.ExceptionMessage != null)
                {
                    registro.registroError(objDAL.ExceptionMessage);
                }

                else
                {
                    registro.registroError();
                }
                objList = null;
                registro = null;
            }

            objDAL.Dispose();

            return objList;

        }
    }
}
