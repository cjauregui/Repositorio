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
    public class SubCategoria
    {

        public int idSubCategoria { get; set; }
        public int idCategoria { get; set; }
        public string subCategoria { get; set; }

        private string cadenaConexion = ConfigurationManager.ConnectionStrings["dbPubliciti" + System.Web.HttpContext.Current.Session["Permiso"].ToString()].ConnectionString;

        public List<SubCategoria> getSubCategoriasxCategoria(int idCat)
        {
            DataHelper objDAL = new DataHelper(DataAbstraction.DataProvider.SQLServer, cadenaConexion);
            List<SubCategoria> objList = new List<SubCategoria>();


            DbDataReader dr = objDAL.ReadData("Clientes_stpGetSubCategoriasxCategoria", CommandType.StoredProcedure, new DataParameter("idCategoria", idCat));


            try
            {
                while (dr.Read())
                {
                    SubCategoria objItem = new SubCategoria();

                    objItem.idSubCategoria = dr.GetInt32(0);
                    objItem.idCategoria = dr.GetInt32(1);
                    objItem.subCategoria = dr.GetString(2);

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
