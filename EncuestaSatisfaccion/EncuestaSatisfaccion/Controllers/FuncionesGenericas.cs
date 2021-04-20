using EncuestaSatisfaccion.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Net.Mime;

namespace EncuestaSatisfaccion.Controllers
{
    [Authorize]
    public class FuncionesGenericas : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public System.Data.DataTable EjectQDt(string Query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = Query;
                da.SelectCommand = cmd;
                System.Data.DataTable TablaDatos = new System.Data.DataTable();
                conn.Open();
                da.Fill(TablaDatos);
                conn.Close();
                return TablaDatos;
            }

            catch (Exception e)

            {
                DataTable dt = new DataTable();
                return dt;
            }

        }



        public string EjectQJson(string Query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = Query;
                da.SelectCommand = cmd;
                System.Data.DataTable TablaDatos = new System.Data.DataTable();
                conn.Open();
                da.Fill(TablaDatos);
                conn.Close();
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                serializer.MaxJsonLength = 2147483647;                                           
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in TablaDatos.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in TablaDatos.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                return serializer.Serialize(rows);
            }

            catch (Exception e)

            {
                return "";
            }

        }


        public async Task SendMail(string Mensaje, string MailTo, string cc, string Titulo, string Adjunto)
        {
            try
            {
                string html = "<label style='font-size:14px;font-weight:bold;'> Hola " + Mensaje + "</label></br>" +
                       "¿Deseas contestar una breve encuesta para ayudarnos a mejorar nuestros servicios? ¡Sólo te tomará 5 minutos!" +
                       "<br/> https://" + Titulo + ":8082/Encuesta/Encuesta/12?mail=" + MailTo + "<br/>" +
                   "Gracias de antemano por tus valiosos comentarios.  Tu opinión será utilizada para asegurar que continuemos mejorando. ";


                DateTime localDate = DateTime.Now;
                using (var client = new SmtpClient())
                using (var mail = new System.Net.Mail.MailMessage())
                {
                    
                        mail.To.Add(MailTo);
                    
                    mail.Subject = "Encuesta Star Medica";
                    mail.Body = html;
                    mail.IsBodyHtml = true;
                    if (Adjunto != "")
                    {
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(Adjunto);
                        mail.Attachments.Add(attachment);
                    }

                    try
                    {
                        client.Send(mail);
                        mail.Dispose();
                    }
                    catch (IOException e)
                    {


                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("error al enviar correo");
            }

        }
        //public async Task SendMailAsink(string Mensaje, string MailTo, string Titulo, string Adjunto)
        //{
        //    try
        //    {
                
        //        SmtpClient smtpClient = new SmtpClient("smtp.office365.com");
        //        smtpClient.Credentials = new System.Net.NetworkCredential("no-reply@starmedica.com", "St4rM3d1c4");
                
        //        smtpClient.Port = 587;
        //        smtpClient.UseDefaultCredentials = true;
        //        smtpClient.EnableSsl = true;
               
        //        using (var mail = new System.Net.Mail.MailMessage())
        //        {
        //            string path = Directory.GetCurrentDirectory();

        //          //  string host = HttpContext.Request.Url.Host;
                    
        //            string html = "<label style='font-size:14px;font-weight:bold;'> Hola " + Mensaje + "</label></br>"+
        //                "¿Deseas contestar una breve encuesta para ayudarnos a mejorar nuestros servicios? ¡Sólo te tomará 5 minutos!" +
        //                "<br/><a href='https://" + Titulo + "/Encuesta/Encuesta/12?mail=" + MailTo + "> https://" +Titulo+"/Encuesta/Encuesta/12?mail="+ MailTo+"</a><br/>"+
        //            "Gracias de antemano por tus valiosos comentarios.  Tu opinión será utilizada para asegurar que continuemos mejorando. ";
                    

        //            AlternateView htmlView =
        //                AlternateView.CreateAlternateViewFromString(html,
        //                                        Encoding.UTF8,
        //                                        MediaTypeNames.Text.Html);
        //            //LinkedResource img =
        //            //  new LinkedResource(@path + "\\wwwroot\\images\\BienvenidaM.png",
        //            //     MediaTypeNames.Image.Jpeg);
        //            //img.ContentId = "imagen";

        //            // Lo incrustamos en la vista HTML...

        //            //htmlView.LinkedResources.Add(img);

        //            mail.AlternateViews.Add(htmlView);

        //            mail.From = new MailAddress("membresias@starmedica.com", "Encuesta Star Médica ");
        //            mail.To.Add(MailTo);
        //            mail.Subject = Titulo;

        //            //  mail.Body = "<img src = '"+ path+"\\wwwroot\\iamges\\BienvenidaM.png" + "' />\n";// Mensaje;
        //            mail.IsBodyHtml = true;
        //            if (Adjunto != "")
        //            {
        //                System.Net.Mail.Attachment attachment;
        //                attachment = new System.Net.Mail.Attachment(Adjunto);
        //                mail.Attachments.Add(attachment);
        //            }

        //            try
        //            {

        //                smtpClient.EnableSsl = true;

        //                await smtpClient.SendMailAsync(mail);

        //            }
        //            catch (IOException e)
        //            {
        //                if (e.Source != null)
        //                    Console.WriteLine("IOException source: {0}", e.Source);
        //            }
        //        }
        //    }

        //    catch (Exception e)

        //    {

        //    }

        //}

        public void EjectQ(string Query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = Query;
                da.SelectCommand = cmd;
                System.Data.DataTable TablaDatos = new System.Data.DataTable();
                conn.Open();
                da.Fill(TablaDatos);
                conn.Close();
            }

            catch (Exception e)
            {
            }
        }

        //public List<GenericList> getUM(int id)
        //{
        //    if (id == 0)
        //    {
        //        var pum = System.Web.HttpContext.Current.Session["perum"].ToString();
        //        var arpum = pum.Split(',');
        //        return db.UnidadesMedicas.Where(x => arpum.Contains(x.Id_UnidadMedica.ToString())).Where(x => x.active == true).OrderBy(x => x.ClaveUnidad).Select(x => new GenericList { Id = x.Id_UnidadMedica, Name = x.UnidadMedica }).ToList();
        //    }
        //    else
        //    {
        //        return db.UnidadesMedicas.Where(x => x.Id_UnidadMedica == id).Where(x => x.active == true).OrderBy(x => x.ClaveUnidad).Select(x => new GenericList { Id = x.Id_UnidadMedica, Name = x.UnidadMedica }).ToList();
        //    }
        //}

       

       
    
      
        public bool GenThumbnail(string path, string image)
        {
            //----------        Getting the Image File
            var RutaCompleta = System.Web.HttpContext.Current.Server.MapPath(path + "/" + image);
            System.Drawing.Image img = System.Drawing.Image.FromFile(RutaCompleta);

            //----------        Getting Size of Original Image
            double imgHeight = img.Size.Height;
            double imgWidth = img.Size.Width;

            //----------        Getting Decreased Size
            double x = imgWidth / 80;
            int newWidth = Convert.ToInt32(imgWidth / x);
            int newHeight = Convert.ToInt32(imgHeight / x);

            //----------        Creating Small Image
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            System.Drawing.Image myThumbnail = img.GetThumbnailImage(newWidth, newHeight, myCallback, IntPtr.Zero);

            //----------        Saving Image
            myThumbnail.Save(System.Web.HttpContext.Current.Server.MapPath(path + "/MIN" + image));
            img.Dispose();

            return true;
        }
        public bool ThumbnailCallback()
        {
            return false;
        }
        


    }
}