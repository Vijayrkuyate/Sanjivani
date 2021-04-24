using SanjivaniBusinessLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanjivaniERP.Controllers
{
    public class GlobalhelpController : Controller
    {
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        // GET: Globalhelp
        public ActionResult Index()
        {
            SessionTest();
            return View();
        }
        public void SessionTest()
        {
            if (Session["CustName"] != null)
            {
                //do something
            }
            else
            {
                Response.Redirect(Url.Action("Login", "Account"));
            }


        }
        public ActionResult GlobalHelpDesk(int GID)
        {
            SessionTest();
            if (GID >0)
            {
                var d1 = objPartnerBAL.getGlobaldeskImgs(GID);
                var std = d1.Where(s => s.GID == GID).FirstOrDefault();
                return View(std);
            }
            return View();
        }
        public ActionResult _SetGlobalHelDskQue(GlobalHelpdesk model, HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            var Value = objPartnerBAL.SaveGlobalHelDskQue(model, postedFile);
            Session["GID"] = Value;
            if (model.files != null)
            {
                foreach (var file in model.files)
                {
                    if (file != null)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Documents/Globaldesk/"), fileName);
                        file.SaveAs(path);
                        // var UploadDocument = objPartnerBAL.UploadGlobalHelpImg(filename1, Value);
                    }
                }
            }

            return  RedirectToAction("_PartialgetGlobaldeskImag", "Globalhelp",new {GID= Value });
        }
        public ActionResult _PartialgetGlobaldeskImag()
        {
            SessionTest();
            //int GID=Convert.ToInt32(Session["GID"]);
            int GID = 0;
            var d1 = objPartnerBAL.getGlobaldeskImgs(GID);
            for (int i = 0; i < d1.Count; i++)
            {
                ViewBag.name = d1[i].Name;
                ViewBag.img= d1[i].imagfile;
            }
           // var d = objPartnerBAL.getCpDocument(GID);
            return View(d1);
        }

        public ActionResult DeleteGlobalImg(int ImgId)
        {
            SessionTest();
            //bool res = objPartnerBAL.DeleteGlobalImg(ImgId);
            //return RedirectToAction("GlobalHelpDesk", "Globalhelp",new {GID=0 });
            bool res = objPartnerBAL.DeleteGlobalImg(Convert.ToInt32(ImgId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
       
    }
    
}