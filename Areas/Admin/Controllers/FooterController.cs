using bandienthoai.Areas.Admin.Models.DAO;
using bandienthoai.Areas.Admin.Models.EF;
using bandienthoai.Common;
using bandienthoai.Models.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class FooterController : BaseController
    {
        // GET: Admin/Footer
        public ActionResult Index()
        {
            //  var dao = new FooterDAO().ViewDetail(2);
            Edit();
            return View();
        }
        public void Edit()
        {
            //  var txtContent = Request.Unvalidated.Form.Get("txtContent");
          
          
            string exePath = Server.MapPath("\\Data\\Footer\\" + "ft" + 2 + ".cshtml");
            FileStream fs = new FileStream(exePath, FileMode.Open);
            using (StreamReader sw = new StreamReader(fs))
            {

                ViewBag.Footer= sw.ReadToEnd();

            }
            fs.Close();
         
        }
      
        public ActionResult SaveData(FOOTER sp)
        {
            if (ModelState.IsValid)
            {

                var dao = new FooterDAO();
                var txtContent = Request.Unvalidated.Form.Get("txtContent");

                sp.CREATEBY = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
                sp.CREATEDATE = DateTime.Now;
               // decimal id = dao.Insert(sp);
               
                   // var namenew = dao.getIDLastChild();
                    //string exePath = System.AppContext.BaseDirectory + "\\Data\\Content\\" + namenew + ".html";
                    string exePath = Server.MapPath("\\Data\\Footer\\" + "ft" + 2 + ".cshtml");
                    FileStream fs = new FileStream(exePath, FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var s in txtContent)
                        {
                            sw.Write(s);
                        }
                        sw.Flush();

                    }
                    fs.Close();
                    //sp.NOIDUNG = "/Data/Footer/" + "ft" + 2 + ".html";
                    //dao.updatenoidung(sp);
              
                    return RedirectToAction("Index", "Footer");
                }
                
            
            return View("Index");
        }
       
    }
}