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
    public class CPController : Controller
    {
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        // GET: CP
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewCp()
        {
            return View();
        }
        public ActionResult _partialCPPartner()
        {
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            return View();
        }
        public ActionResult _partialCPBusinessDetail()
        {
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            return View();
        }
        public ActionResult _partialSetCPBusinessDetail(BusinessDetails BD)
        {
            BD.CustId = Convert.ToString(Session["CustId"]);
            bool res = objPartnerBAL.SetCPBusinessDtl(BD);

            Session["Tab"] = "3";
            return RedirectToAction("ChannelPartner", "CP");
        }
        public ActionResult _partialCPBankDetail()
        {
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            return View();
        }
        public ActionResult _partialSetBankDeatil(BankDetails bd)
        {
            bd.CustId = Convert.ToString(Session["CustId"]);
            bool res = objPartnerBAL.setCPBankDtl(bd);

            Session["Tab"] = "4";
            return RedirectToAction("ChannelPartner", "CP");
        }
        public ActionResult _partialCPDocument()
        {
            return View();
        }
        public ActionResult _SetCPDocument(HttpPostedFileBase[] postedFile)
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
                            var path = Path.Combine(Server.MapPath("~/Documents/Logo"), fileName);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                        }
                    }
                    else if (k == 1)
                    {
                        var Type = 1;
                        var filePath = Path.Combine(Server.MapPath("~/Documents/Pan" + filename));
                        file.SaveAs(filePath);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 2)
                    {
                        var Type = 2;
                        var path = Path.Combine(Server.MapPath("~/Documents/RegDocument"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 3)
                    {
                        var Type = 3;
                        var path = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 4)
                    {
                        var Type = 4;
                        var path = Path.Combine(Server.MapPath("~/Documents/OwnerSignature"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    k++;
                }
            }
            string url = "https://sanjivanitechnology.com";
            return Redirect("https://sanjivanitechnology.com");
        }
        public ActionResult ChannelPartner()
        {
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            return View();
        }
        public ActionResult CPCChennelPartner(int CustId)
        {
            CPCchannelPartnerModel list = new CPCchannelPartnerModel();
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCPCustomer = new SelectList(objPartnerBAL.GetBindCPCustomer(), "CpCustomer", "CpCustomerName");
            if (CustId > 0)
            {
                Session["CustId"] = CustId;
                list.CustId =Convert.ToString(CustId);
                if (!string.IsNullOrWhiteSpace(CustId.ToString()))
                {
                    list = objPartnerBAL.GetCPCChannelEdit(CustId);
                    return View(list);
                }
            }
            return View();
        }
        public ActionResult CPCChennelPartnerList()
        {
            var CPCChennelPartnerList = objPartnerBAL.GetCPCChannelPartnerList();
            ViewBag.CPCChennelPartnerList = CPCChennelPartnerList;
            return View();
        }
        public ActionResult DirectorBusinessOwnersList()
        {
            List<DirectorBusinessModel> DirectorModel = objPartnerBAL.GetDirectorBusinessOwnerList();
            ViewBag.DirectorBusinessOwnerList = DirectorModel;
            return View();
        }
        public ActionResult DirectorBusinessOwners(int CustId)
        {
            DirectorBusinessModel list = new DirectorBusinessModel();
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            if (CustId > 0)
            {
                if (!string.IsNullOrWhiteSpace(CustId.ToString()))
                {
                    list = objPartnerBAL.GetDirectorBusinessOwners(CustId);
                    return View(list);
                }
            }
            return View();
        }
    }
}