using SanjivaniBusinessLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanjivaniERP.Views.CP
{
    public class CPCController : Controller
    {
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        // GET: CPC
        public ActionResult Index()
        {
            SessionTest();
            return View();
        }
        public void ValidDate()
        {
            //DateTime dt1 = Convert.ToDateTime("15/04/2021");
            //DateTime dt2 = DateTime.Now;
            //if (dt2 > dt1)
            //{
            //    Response.Redirect(Url.Action("Login", "Account"));
            //}
        }
        public void SessionTest()
        {
            ValidDate();
            if (Session["CustName"] != null)
            {
                //do something
            }
            else
            {
                Response.Redirect(Url.Action("Login", "Account"));
            }


        }
        public ActionResult _partialCPCChannelPartner(string Custid)
        {
            SessionTest();
            Session["Msg"] = "";
            CPCchannelPartnerModel Lst = new CPCchannelPartnerModel();
            //Custid =Convert.ToInt32(Session["Custid"]);
            if (Custid != "")
            {
                if (!string.IsNullOrWhiteSpace(Custid.ToString()))
                {
                    ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
                    ViewBag.BindCPCustomer = new SelectList(objPartnerBAL.GetBindCPCustomer(), "CpCustomer", "CpCustomerName");
                    Lst = objPartnerBAL.GetCPCChannelEdit(Custid);
                    Session["Custid"] = Lst.CustId;
                }
            }
            else
            {
                ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
                ViewBag.BindCPCustomer = new SelectList(objPartnerBAL.GetBindCPCustomer(), "CpCustomer", "CpCustomerName");
            }
            return View(Lst);
        }

        public ActionResult _partialCPCBankDetail(string Custid)
        {
            SessionTest();
            Session["Msg"] = "";
            CPCchannelPartnerModel list = new CPCchannelPartnerModel();
            BankDetails list1 = new BankDetails();
            Custid = Convert.ToString(Session["Custid"]);
            if (Custid!= "")
            {
                if (!string.IsNullOrWhiteSpace(Custid.ToString()))
                {
                    ViewBag.bank = new SelectList(objPartnerBAL.GetBank(), "BankId", "BankName");
                    ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
                    ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
                    list = objPartnerBAL.GetCPCChannelEdit(Custid);
                    list1.CustId = list.CustId;
                    list1 = list.ObjBackDetails;
                    list1.CustId= list.CustId;
                }
            }
            else
            {
                ViewBag.bank = new SelectList(objPartnerBAL.GetBank(), "BankId", "BankName");
                ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
                ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            }
            return View(list1);
        }

        public ActionResult _partialCPCDocument()
        {
            SessionTest();
            Session["Msg"] = "";
            CPCchannelPartnerModel list = new CPCchannelPartnerModel();
          //  list = objPartnerBAL.GetCPCChannelEdit(Custid);
            return View();
        }
        public ActionResult _partialSetBankDeatil(BankDetails bd)
        {
            SessionTest();
            int custid = Convert.ToInt32(bd.CustId);
            if (custid > 0)
            {
                bool res = objPartnerBAL.setCPCBankDtl(bd);
            }
            else
            {
                bd.CustId = Convert.ToString(Session["CustId"]);
                bool res = objPartnerBAL.setCPCBankDtl(bd);
            }
            Session["Tab"] = "3";
            return RedirectToAction("CPCChennelPartner", "CP", new { CustId = 0 });
        }
        public ActionResult _SetCPCDocument(HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            Session["Tab"] = "3";
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
                            var filePath = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto" + filename1));
                            file.SaveAs(filePath);
                            var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename1, EventsTitleList, Type);
                        }
                    }
                    else if (k == 1)
                    {
                        var Type = 1;
                        var filePath = Path.Combine(Server.MapPath("~/Documents/Pan" + filename));
                        file.SaveAs(filePath);
                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 2)
                    {
                        var Type = 2;
                        var path = Path.Combine(Server.MapPath("~/Documents/AdhaarCard"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 3)
                    {
                        var Type = 3;
                        var path = Path.Combine(Server.MapPath("~/Documents/LightBill"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 4)
                    {
                        var Type = 4;
                        var path = Path.Combine(Server.MapPath("~/Documents/Passport"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, EventsTitleList, Type);
                    }
                    k++;
                }
            }
            //string url = "https://sanjivanitechnology.com";
            //return Redirect("https://sanjivanitechnology.com");
            return RedirectToAction("CPCChennelPartner", "CP", new { CustId = 0 });
        }

        public ActionResult _PartialgetCPCDocument()
        {
            SessionTest();
            int CustId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBAL.getCpDocument(CustId);
            return View(d);
        }
    }
}