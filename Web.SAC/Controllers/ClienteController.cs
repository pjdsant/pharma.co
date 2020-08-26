using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Web.SAC.Models;

namespace Web.SAC.Controllers
{
    public class ClienteController : Controller
    {
        #region Método para Listar Clientes - READ

        //GET Cliente/ListarCliente
        public JsonResult ListarCliente()
        {
            using (var db = new ClientesEntities())
            {
                List<Cliente> listarCliente = db.Clientes.ToList();

                return Json(listarCliente, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Método para Adicionar um Cliente - CREATE

        //POST /Cliente/AdicionarCliente
        [HttpPost]
        public JsonResult AdicionarCliente(Cliente cliente)
        {
            if(cliente != null)
            {
                using (var db = new ClientesEntities())
                {

                    db.Clientes.Add(cliente);
                    db.SaveChanges();

                    return Json(new { success = true });

                }
            }
            return Json(new { success = false });
        }

        #endregion

        #region Método para Adicionar um Cliente - CREATE Using Proc

        //POST /Cliente/AdicionarCliente
        [HttpPost]
        public JsonResult AdicionarClienteProc(Cliente cliente)
        {
            if (cliente != null)
            {

                string cnnString = ConfigurationManager.ConnectionStrings["ClienteDB"].ConnectionString;

                
                try
                {
                    SqlConnection cnn = new SqlConnection(cnnString);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.ins_Cliente";
                    cmd.Parameters.Add(new SqlParameter("@nome", cliente.Nome));
                    cmd.Parameters.Add(new SqlParameter("@usuario", cliente.Usuario));
                    cmd.Parameters.Add(new SqlParameter("@email", cliente.Email));
                    cmd.Parameters.Add(new SqlParameter("@senha", cliente.Senha));
                    cnn.Open();
                    object o = cmd.ExecuteScalar();
                    cnn.Close();

                    return Json(new { success = true });

                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
            }
            return Json(new { success = false });
        }

        #endregion
    }
}