using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net.Mail;
using System.Net;
using System.Configuration;


namespace BusinessModel.Entities
{
    public class Bitacora
    {
        private string nombreArchivo = @ConfigurationManager.AppSettings["bitacora"].ToString();

        public void registroError(string Mensaje="Error no identificado")
        {
            StreamWriter Archivo;

            string[] lineas = { 
                                  "Fecha:   "+DateTime.Now.ToString(), 
                                  "Usuario: "+System.Web.HttpContext.Current.Session["Usuario"].ToString(),
                                  "Permiso: "+System.Web.HttpContext.Current.Session["Permiso"].ToString(), 
                                  "Error:   "+Mensaje 
                              };
            try
            {
                if (File.Exists(nombreArchivo))
                {
                    Archivo = File.AppendText(nombreArchivo);
                }
                else
                {
                    Archivo = File.CreateText(nombreArchivo);
                }

                foreach (String linea in lineas)
                {
                    Archivo.WriteLine(linea);
                }

                Archivo.WriteLine();

                Archivo.Close();

            }
            catch
            {
                Console.Write("Error de I/O en la creacion o lectura de archivo de bitácora");
            }

            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(ConfigurationManager.AppSettings["remitente"].ToString());

                string[] destinatarios = ConfigurationManager.AppSettings["destinatarios"].Split(';');

                foreach (String destinatario in destinatarios)
                {
                    correo.To.Add(destinatario);
                }

                correo.Subject = "Error en servidor de aplicación";

                correo.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                foreach (String linea in lineas)
                {
                    correo.Body = correo.Body +linea+System.Environment.NewLine;
                }

                correo.IsBodyHtml = false;
                correo.Priority = MailPriority.High;

                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["remitente"].ToString(), ConfigurationManager.AppSettings["remitenteClave"].ToString());

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(correo);
                }
                catch
                {
                    Console.Write("Error de I/O en el envío de correo de bitácora");
                }
            }
            catch
            {
                Console.Write("Error de I/O en la creacion o lectura de archivo de bitácora");
            }
            
            
        }
    
    }
}
