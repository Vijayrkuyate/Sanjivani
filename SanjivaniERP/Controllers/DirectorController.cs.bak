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
    public class DirectorController : Controller
    {
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        // GET: Director
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _partialDirectorPersonalDetails(string Custid)
        {
            DirectorBusinessModel list = new DirectorBusinessModel();
            if (Custid != "0")
            {

                ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
                ViewBag.BindCPCustomer = new SelectList(objPartnerBAL.GetBindCPCustomer(), "CpCustomer", "CpCustomerName");
                list = objPartnerBAL.GetDirectorChannelEdit(Custid);
            }
            else
            {
                ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
                ViewBag.BindCPCustomer = new SelectList(objPartnerBAL.GetBindCPCustomer(), "CpCustomer", "CpCustomerName");
            }
            return View(list);
        }
        public ActionResult _partialDirectorBankDetail(string Custid)
        {
            DirectorBusinessModel list = new DirectorBusinessModel();
            BankDetails list1 = new BankDetails();
            if (Custid != "0")
            {

                ViewBag.bank = new SelectList(objPartnerBAL.GetBankName(), "BankId", "BankName");
                ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
                //list = objPartnerBAL.GetDirectorChannelEdit(Custid);
                var d = objPartnerBAL._partialGetCPBankDtl(Custid);

                //list1.CustId = list.CustId;
                // list1 = list.ObjBackDetails;
                // list1.CustId = list.CustId;
                return View(d);
            }
            else
            {
                ViewBag.bank = new SelectList(objPartnerBAL.GetBankName(), "BankId", "BankName");
                ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
                ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            }
            return View();
        }

        public JsonResult getuserdat()
        {
            string Custid = "3013";
            var list = objPartnerBAL.GetDirectorChannelEdit(Custid);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _partialDirectorDocument()
        {
            return View();
        }

        public ActionResult _partialSetBankDeatil(BankDetails bd)
        {
            int custid = Convert.ToInt32(bd.CustId);
            if (custid > 0)
            {
                bool res = objPartnerBAL.setDirectorBankDtl(bd);
            }
            else
            {
                bd.CustId = Convert.ToString(Session["CustId"]);
                bool res = objPartnerBAL.setDirectorBankDtl(bd);
                DirectorBusinessModel model = new DirectorBusinessModel();
                model.CustId = bd.CustId;
            }
            Session["Tab"] = "3";
            return RedirectToAction("DirectorBusinessOwners", "CP", new { CustId = bd.CustId });
        }

        public ActionResult _SetDirectorDocument(HttpPostedFileBase[] postedFile)
        {
            Session["Tab"] = "4";
            int EventsTitleList = Convert.ToInt32(Session["CustId"]);
            var k = 0;
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);
                    if (k == 0)
                    {
                        var filename1 = Path.GetFileName(file.FileName);
                        if (filename1 != null)
                        {
                            var Type = 0;
                            //  var filePath = Server.MapPath("~/Documents/Logo/" + filename1);
                            // file.SaveAs(filePath);
                            var fileName = Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Server.MapPath("~/Documents/Logo/" + filename1));
                            file.SaveAs(filePath);
                            var UploadDocument = objPartnerBAL.SaveUploadDirectorDoc(filename1, EventsTitleList, Type);
                        }
                    }
                    else if (k == 1)
                    {
                        var Type = 1;
                        var filePath = Path.Combine(Server.MapPath("~/Documents/Logo" + filename));
                        file.SaveAs(filePath);
                        var UploadDocument = objPartnerBAL.SaveUploadDirectorDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 2)
                    {
                        var Type = 2;
                        var path = Path.Combine(Server.MapPath("~/Documents/Logo"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadDirectorDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 3)
                    {
                        var Type = 3;
                        var path = Path.Combine(Server.MapPath("~/Documents/Logo"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadDirectorDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 4)
                    {
                        var Type = 4;
                        var path = Path.Combine(Server.MapPath("~/Documents/Logo"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadDirectorDoc(filename, EventsTitleList, Type);
                    }
                    k++;
                }
            }
            //string url = "https://sanjivanitechnology.com";
            //return Redirect("https://sanjivanitechnology.com");
            return RedirectToAction("DirectorBusinessOwners", "CP", new { CustId = EventsTitleList });
        }

        public ActionResult _PartialgetDirectorDocument()
        {
            int CustId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBAL.getDirectorDocument(CustId);
            ViewBag.data = d;
            return View(d);

        }

        public ActionResult Dashboard()
        {
            var d = objPartnerBAL.GetDirectorDashboard();
            return View(d);
        }
    }
}