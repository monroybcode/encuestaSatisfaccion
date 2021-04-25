using System;
using EncuestaSatisfaccion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Style;

namespace ControlAcceso.Controllers
{
   
    public class ReporteRespuestasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ReporteRespuestas
        public ActionResult Index()
        {
            var lp = db.Respuestas.Select(x => new listrepo
            {
                id = x.IdEncuestado,
                nombre = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.Nombre + " " + y.Apa + " " + y.Ama).FirstOrDefault(),
                puesto = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.puesto).FirstOrDefault(),
                fechaAlta = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.fechaAlta).FirstOrDefault(),
                fechaContestado = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.fechaContestado).FirstOrDefault(),
                contestado = (db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.Contestada).FirstOrDefault() == 1 ? "Sí" : "No"),
                rp1 = x.rp1,
                rp2 = x.rp2,
                rp3 = x.rp3,
                rp4 = x.rp4,
                rp5 = x.rp5,
                rp6 = x.rp6,
                rp7 = x.rp7,
                rp8 = x.rp8,
                rp9 = x.rp9,
                rp10 = x.rp10,
                rp11 = x.rp11,
                rp12 = x.rp12,
                rp13 = x.rp13,
                rp14 = x.rp14,
                rp15 = x.rp15,
                rp16 = x.rp16,
                rp17 = x.rp17,
                rp18 = x.rp18,
                rp19 = x.rp19
            }).ToList();
            ViewBag.Respuestas = lp;
            return View();
        }

        public ActionResult IndexP()
        {
            var lp = db.Respuestas.Select(x => new listrepo
            {
                id = x.IdEncuestado,
                nombre = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.Nombre + " " + y.Apa + " " + y.Ama).FirstOrDefault(),
                puesto = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.puesto).FirstOrDefault(),
                fechaAlta = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.fechaAlta).FirstOrDefault(),
                fechaContestado = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.fechaContestado).FirstOrDefault(),
                contestado = (db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.Contestada).FirstOrDefault()==1?"Sí":"No"),
                rp1 =x.rp1,
                rp2=x.rp2,
                rp3 = x.rp3,
                rp4 = x.rp4,
                rp5 = x.rp5,
                rp6 = x.rp6,
                rp7 = x.rp7,
                rp8 = x.rp8,
                rp9 = x.rp9,
                rp10 = x.rp10,
                rp11 = x.rp11,
                rp12 = x.rp12,
                rp13 = x.rp13,
                rp14 = x.rp14,
                rp15 = x.rp15,
                rp16 = x.rp16,
                rp17 = x.rp17,
                rp18 = x.rp18,
                rp19 = x.rp19
            }).ToList();
            ViewBag.Respuestas = lp;

            return PartialView("Index");
        }


        [HttpPost]
        public ActionResult gDta(string n,int c, string p, DateTime? fi, DateTime? ff, DateTime? fif, DateTime? fff) {
            try {
                var lp = db.Respuestas.Select(x => new listrepo
                {
                    id = x.IdEncuestado,
                    nombre = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.Nombre + " " + y.Apa + " " + y.Ama).FirstOrDefault(),
                    puesto = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.puesto).FirstOrDefault(),
                    fechaAlta = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.fechaAlta).FirstOrDefault(),
                    fechaContestado = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.fechaContestado).FirstOrDefault(),
                    contestado = (db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.Contestada).FirstOrDefault() == 1 ? "Sí" : "No"),
                    rp1 = x.rp1,
                    rp2 = x.rp2,
                    rp3 = x.rp3,
                    rp4 = x.rp4,
                    rp5 = x.rp5,
                    rp6 = x.rp6,
                    rp7 = x.rp7,
                    rp8 = x.rp8,
                    rp9 = x.rp9,
                    rp10 = x.rp10,
                    rp11 = x.rp11,
                    rp12 = x.rp12,
                    rp13 = x.rp13,
                    rp14 = x.rp14,
                    rp15 = x.rp15,
                    rp16 = x.rp16,
                    rp17 = x.rp17,
                    rp18 = x.rp18,
                    rp19 = x.rp19
                });

                if (n.Trim() != "") {
                   lp= lp.Where(x => x.nombre.Contains(n.Trim()));
                }
                if (c > 0)
                {
                    if (c == 1)
                        lp = lp.Where(x => x.contestado == "Sí");
                    else
                        lp = lp.Where(x => x.contestado == "No");
                }
                if (fi != null && fif != null)
                {
                    lp = lp.Where(x => x.fechaAlta >= fi || x.fechaAlta<=fif);
                }
                else { 
                if (fi != null) {
                    lp = lp.Where(x => x.fechaAlta >= fi);
                }
                if (fif != null)
                {
                    lp = lp.Where(x => x.fechaAlta <= fif);
                }
                }

                if (ff != null && fff != null)
                {
                    lp = lp.Where(x => x.fechaContestado >= ff && x.fechaContestado <= fff);
                }
                else
                {
                    if (ff != null)
                    {
                        lp = lp.Where(x => x.fechaContestado >= ff);
                    }
                    if (fff != null)
                    {
                        lp = lp.Where(x => x.fechaContestado <= fff);
                    }
                }
                if (p.Trim() != "") {
                    lp = lp.Where(x => x.puesto.Contains(p));
                }

                var listado = lp.ToList();
                return Json(new { R = 1, listado });
            }
            catch(Exception e) {
                return Json(new { R = 0, e.Message });
            }
        
        }


        public ActionResult generaXcel(string n, int c, string p, DateTime? fi, DateTime? ff, DateTime? fif, DateTime? fff)
        {
            try
            {
                var subPath = "~/Archivos/Reporte/";
                var fname = "ReporteRespuestas" + ".xlsx";
                try
                {
                    string filePath = string.Empty;
                    string path = Server.MapPath("~/Archivos/Reporte/");

                    filePath = path + Path.GetFileName("ReporteRespuestas" + ".xlsx");
                    System.IO.File.Delete(filePath);
                }
                catch (Exception er)
                {
                    Console.WriteLine("No existe el archivo");
                }
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
                var RFisica = Path.Combine(Server.MapPath(subPath), fname);

                var returl = subPath.Replace("~", "..") + fname;



                var lp = db.Respuestas.Select(x => new listrepo
                {
                    id = x.IdEncuestado,
                    nombre = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.Nombre + " " + y.Apa + " " + y.Ama).FirstOrDefault(),
                    puesto = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.puesto).FirstOrDefault(),
                    fechaAlta = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.fechaAlta).FirstOrDefault(),
                    fechaContestado = db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.fechaContestado).FirstOrDefault(),
                    contestado = (db.Encuestados.Where(y => y.Id == x.IdEncuestado).Select(y => y.Contestada).FirstOrDefault() == 1 ? "Sí" : "No"),
                    rp1 = x.rp1,
                    rp2 = x.rp2,
                    rp3 = x.rp3,
                    rp4 = x.rp4,
                    rp5 = x.rp5,
                    rp6 = x.rp6,
                    rp7 = x.rp7,
                    rp8 = x.rp8,
                    rp9 = x.rp9,
                    rp10 = x.rp10,
                    rp11 = x.rp11,
                    rp12 = x.rp12,
                    rp13 = x.rp13,
                    rp14 = x.rp14,
                    rp15 = x.rp15,
                    rp16 = x.rp16,
                    rp17 = x.rp17,
                    rp18 = x.rp18,
                    rp19 = x.rp19
                });

                if (n.Trim() != "")
                {
                    lp = lp.Where(x => x.nombre.Contains(n));
                }
                if (c > 0)
                {
                    if (c == 1)
                        lp = lp.Where(x => x.contestado == "Sí");
                    else
                        lp = lp.Where(x => x.contestado == "No");
                }
                if (fi != null && fif != null)
                {
                    lp = lp.Where(x => x.fechaAlta >= fi && x.fechaAlta <= fif);
                }
                if (fi != null)
                {
                    lp = lp.Where(x => x.fechaAlta >= fi);
                }
                if (fif != null)
                {
                    lp = lp.Where(x => x.fechaAlta <= fif);
                }

                if (ff != null && fff != null)
                {
                    lp = lp.Where(x => x.fechaContestado >= ff && x.fechaContestado <= fff);
                }
                if (ff != null)
                {
                    lp = lp.Where(x => x.fechaContestado >= ff);
                }
                if (fif != null)
                {
                    lp = lp.Where(x => x.fechaContestado <= fff);
                }
                if (p.Trim() != "")
                {
                    lp = lp.Where(x => x.puesto.Contains(p));
                }

                var listado = lp.ToList();

                if (listado.Count == 0)
                {
                    var re2 = new { R = 2, URL = returl };
                    return Json(re2);
                }
                using (var target = new ExcelPackage(new System.IO.FileInfo(RFisica)))
                {
                    var ws = target.Workbook.Worksheets.Add("Hoja 1");
                    var rw = 2;
                    ExcelRange cols = ws.Cells["A:XFD"];
                    var res2 = listado.Count + 1;

                    foreach (var itm in listado)
                    {
                        ws.SetValue(rw, 2, itm.id);
                        ws.SetValue(rw, 3, itm.nombre);
                        ws.SetValue(rw, 4, itm.contestado);
                        ws.SetValue(rw, 5, itm.puesto);
                        ws.SetValue(rw, 6, itm.fechaAlta.ToShortDateString());
                        ws.SetValue(rw, 7, itm.fechaContestado.Value.ToShortDateString());
                        ws.SetValue(rw, 8, itm.rp1);
                        ws.SetValue(rw, 9, itm.rp2);
                        ws.SetValue(rw, 10, itm.rp3);
                        ws.SetValue(rw, 11, itm.rp4);
                        ws.SetValue(rw, 12, itm.rp5);
                        ws.SetValue(rw, 13, itm.rp6);
                        ws.SetValue(rw, 14, itm.rp7);
                        ws.SetValue(rw, 15, itm.rp8);
                        ws.SetValue(rw, 16, itm.rp9);
                        ws.SetValue(rw, 17, itm.rp10);
                        ws.SetValue(rw, 18, itm.rp11);
                        ws.SetValue(rw, 19, itm.rp12);
                        ws.SetValue(rw, 20, itm.rp13);
                        ws.SetValue(rw, 21, itm.rp14);
                        ws.SetValue(rw, 22, itm.rp15);
                        ws.SetValue(rw, 23, itm.rp16);
                        ws.SetValue(rw, 24, itm.rp17);
                        ws.SetValue(rw, 25, itm.rp18);
                        ws.SetValue(rw, 26, itm.rp19);

                        rw++;
                    }


                    ws.InsertRow(rw, 1);

                    Color azulStar2 = System.Drawing.ColorTranslator.FromHtml("#C2BBBB");
                    using (var rng = ws.Cells["B" + 1 + ":AA" + 1])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        rng.Style.WrapText = true;
                        rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rng.Style.Fill.BackgroundColor.SetColor(azulStar2);
                    }
                    using (var rng = ws.Cells["A" + rw + ":Z" + rw])
                    {
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rng.Style.Fill.BackgroundColor.SetColor(azulStar2);
                    }




                    //Write the headers and style them

                    ws.Cells["B1"].Value = "ID";
                    ws.Cells["C1"].Value = "Nombre Encuestado";
                    ws.Cells["D1"].Value = "Contestado";
                    ws.Cells["E1"].Value = "Puesto";
                    ws.Cells["F1"].Value = "Fecha alta";
                    ws.Cells["G1"].Value = "Fecha contestado";
                    ws.Cells["H1"].Value = "Estatus del candidato";
                    ws.Cells["I1"].Value = "Reclutador o primer contacto";
                    ws.Cells["J1"].Value = "¿Cómo te enteraste de la vacante?";
                    ws.Cells["K1"].Value = "Cuando leíste la descripción del trabajo, ¿era clara y comprensible?";
                    ws.Cells["L1"].Value = "Después de que te postulaste o enviaste tu información, ¿Cuánto tiempo tardamos en contactarte?";
                    ws.Cells["M1"].Value = "¿El reclutador se comportó amable durante la entrevista?";
                    ws.Cells["N1"].Value = "¿El reclutador explicó claramente los detalles del puesto?";
                    ws.Cells["O1"].Value = "¿Te sentiste cómodo durante la entrevista?";
                    ws.Cells["P1"].Value = "Después de la entrevista, ¿se te informó cuáles serían los siguientes pasos del proceso?";
                    ws.Cells["Q1"].Value = "En caso de haber acudido a una entrevista presencial, ¿se te informó oportunamente con quién debías presentarte?";
                    ws.Cells["R1"].Value = "En tu visita a hospital, ¿alguna persona te recibió para pasarte a entrevista?";
                    ws.Cells["S1"].Value = "¿El entrevistador aclaró tus dudas y complementó la información de la vacante?";
                    ws.Cells["T1"].Value = " ¿El entrevistador fue amable contigo?";
                    ws.Cells["U1"].Value = "Para tu entrevista presencial, ¿tuviste que viajar a alguno de nuestros hospitales y/o Oficinas Corporativas?";
                    ws.Cells["V1"].Value = "En caso de haber viajado a alguna otra sede, ¿se te ofreció el pago de tus viáticos?";
                    ws.Cells["W1"].Value = "¿El reclutador dio seguimiento puntual a tu proceso durante todas las etapas?";
                    ws.Cells["X1"].Value = "En general, ¿Qué tan satisfecho estás con el proceso de reclutamiento?";
                    ws.Cells["Y1"].Value = "En función de tu experiencia, ¿recomendarías a Star Médica como lugar para trabajar, a un colega o conocido?";
                    ws.Cells["Z1"].Value = "¿Tienes algún comentario o sugerencia adicional que nos pueda ayudar a mejorar el proceso de reclutamiento?";
                   


                    using (var rng = ws.Cells["A1:A" + res2])
                    {
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rng.Style.Fill.BackgroundColor.SetColor(azulStar2);
                    }
                    using (var rng = ws.Cells["AA1:AA" + res2])
                    {
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rng.Style.Fill.BackgroundColor.SetColor(azulStar2);
                    }

                    //Console.WriteLine("{0:HH.mm.ss}
                    ws.Cells[1, 1, res2, 12].AutoFitColumns(30); //Autofit columns and lock and format cells...", DateTime.Now);
                    var ro = res2 + 1;

                    Console.WriteLine("{0:HH.mm.ss}\tSaving...", DateTime.Now);
                    target.Compression = CompressionLevel.BestSpeed;
                    target.Save();
                }

                var re = new { R = 1, URL = returl };
                return Json(re);

            }
            catch (Exception e)
            {
                var result = new { R = 0, e.Message };
                return Json(result);
            }
        }


    }
}
