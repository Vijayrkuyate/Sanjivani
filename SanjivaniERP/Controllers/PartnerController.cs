using Microsoft.AspNet.Identity;
using SanjivaniBusinessLayer;
using SanjivaniERP.Models;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Data;
using Hangfire;
using System.Net.Mime;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace SanjivaniERP.Controllers
{
    public class PartnerController : Controller
    {
        public ApplicationSignInManager _signInManager;
        public ApplicationUserManager _userManager;
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        ClsProductBALcs objProductBAL = new ClsProductBALcs();
        // GET: Partner
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

        public ActionResult _partialSetEditCPBusinessDetail(BusinessDetails BD)
        {
            SessionTest();
            if (string.IsNullOrEmpty(Convert.ToString(BD.TypeofHosting1)))
            {
                BD.TypeofHosting1 = 0;
            }
            if (string.IsNullOrEmpty(Convert.ToString(BD.HostingPlatform1)))
            {
                BD.HostingPlatform1 = 0;
            }
            BD.TypeofHosting = Convert.ToString(BD.TypeofHosting1);
            BD.HostingPlatform = Convert.ToString(BD.HostingPlatform1);
            BD.CustId = Convert.ToString(Session["CustId"]);
            Session["Domain"] = BD.CurrentDomainProvide;
            bool res = objPartnerBAL.SetCPBusinessDtl(BD);
            //if (res)
            //{
            //    //int Res = Mb.UpdateMemPassword(UserId, Mp.Password);
            //    return Json(new { success = true, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json(new { Success = false, Messege = "Please Enter Valid Old Password", Status = 400 });
            //}
            //Session["Tab"] = "2";
            return RedirectToAction("Chennelpartner", "Partner");
            //return View();
        }
        public ActionResult _partialSetEditBankDeatil(BankDetails bd)
        {
            SessionTest();
            bd.BankName = Convert.ToString(bd.BankName1);
            bd.CustId = Convert.ToString(Session["CustId"]);
            bool res = objPartnerBAL.setCPBankDtl(bd);

            Session["Tab"] = "3";
            return RedirectToAction("Chennelpartner", "Partner");
        }
        public ActionResult Chennelpartner(string CustId,string EditId)
        {
            SessionTest();
            if (CustId != "0" && CustId!=null)
            {
                Session["CustId"] = CustId;
                if(EditId!=null)
                Session["EditId"] = EditId;
            }
                
            else
            {
                if (EditId != null)
                    Session["EditId"] = EditId;
                CustId = Convert.ToString(Session["CustId"]);
            }
               
            ChennelpartnerModel dc = new ChennelpartnerModel();


            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            if (CustId != null)
            {
                dc.CustId = CustId;
                return View(dc);
            }
            return View();
        }
        public bool DirectoryExists(string directory)
        {
           
            bool directoryExists;

            var request = (FtpWebRequest)WebRequest.Create(directory);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential("pioneers", "d@8Pg~4Ea0Dv$9C");

            try
            {
                using (request.GetResponse())
                {
                    directoryExists = true;
                }
            }
            catch (WebException)
            {
                directoryExists = false;
            }

            return directoryExists;
        }
        public static bool CheckFileExistOnFTP(string ServerUri, string FTPUserName, string FTPPassword)
        {
           
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ServerUri);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(FTPUserName, FTPPassword);
            //request.Method = WebRequestMethods.Ftp.GetFileSize;
            // request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
            }
            return true;
        }
        public ActionResult ChannaPartnerList()
        {
            SessionTest();
            DataSet ds = new DataSet();
            //string SourceDomain = "ftp://pioneers@103.235.106.17/shop.pioneersoft.co.in";
            //string DestinationDomain = "ftp://pioneers@103.235.106.17/";
            //NetworkCredential credentials = new NetworkCredential("pioneers", "d@8Pg~4Ea0Dv$9C");
            //ds = objPartnerBAL.GetFolder();
            ////ds.Tables[0].Rows.Clear();
            ////ds.Tables[1].Rows.Clear();

            //string directoryUrl = DestinationDomain + "shop.pioneersoft.co.in";

            //if (!DirectoryExists(directoryUrl))
            //{
            //    try
            //    {
            //        //Console.WriteLine($"Creating {name}");
            //        FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create(directoryUrl);
            //        requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
            //        requestDir.Credentials = credentials;
            //        requestDir.GetResponse().Close();
            //    }
            //    catch (WebException ex)
            //    {
            //        FtpWebResponse response = (FtpWebResponse)ex.Response;
            //        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
            //        {
            //            // probably exists already
            //        }
            //        else
            //        {
            //            RedirectToAction("ChannaPartnerList", "Partner");
            //        }
            //    }


            //}
            //var cssFiles = Directory.GetFiles(Server.MapPath("~/Views")
            //                             );
            var ChennelPartnerList = objPartnerBAL.GetChennelPartnerList();
            ViewBag.ChennelPartnerList = ChennelPartnerList;
            //UpLoadStoreFront();
            // BackgroundJob.Enqueue(() => UpLoadStoreFront());
            return View();

        }
        public ActionResult ViewCP(int CustId)
        {
            SessionTest();
            return View();
        }
        public ActionResult UpL()
        {
            if (Session["Dothis"].ToString() == "1")
            {
                string Domaim = Session["Domain"].ToString();
                BackgroundJob.Enqueue(() => UpLoadStoreFront(Domaim));
                //  UpLoadStoreFront(Domaim);

            }
            //Session["Completemsg"] = "Yes";
            Session["Dothis"] = "0";
            return RedirectToAction("ChannaPartnerList", "Partner");
        }
        public void UpLoadStoreFront(string Domaim)
        {
            //RedirectToAction("NewCP", "Partner");

            DataSet ds = new DataSet();
          
            string SourceDomain = "ftp://pioneers@103.235.106.17/master.pioneersoft.co.in";
            string DestinationDomain = "ftp://pioneers@103.235.106.17/" + Domaim;
            NetworkCredential credentials = new NetworkCredential("pioneers", "d@8Pg~4Ea0Dv$9C");
               
            ds = objPartnerBAL.GetFolder();
            ds.Tables[0].Rows.Clear();
            ds.Tables[1].Rows.Clear();
            ds = objPartnerBAL.GetFolder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string directoryUrl = DestinationDomain + dr["Folder"].ToString();

                if (!DirectoryExists(directoryUrl))
                {
                    try
                    {
                        //Console.WriteLine($"Creating {name}");
                        FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create(directoryUrl);
                        requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                        requestDir.Credentials = credentials;
                        requestDir.GetResponse().Close();
                    }
                    catch (WebException ex)
                    {
                        FtpWebResponse response = (FtpWebResponse)ex.Response;
                        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                        {
                            // probably exists already
                        }
                        else
                        {
                            RedirectToAction("ChannaPartnerList", "Partner");
                        }
                    }

                }
            }
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                try
                {
                    //NetworkCredential credentials = new NetworkCredential("pioneers", "d@8Pg~4Ea0Dv$9C");
                    //var cssFiles = Directory.GetFiles(Server.MapPath("~/Views"));
                    if(dr["FileName"].ToString().Trim() == "~/StoreFront/Views/CP")
                    {
                        string a = "";
                    }
                    var cssFiles = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath(dr["FileName"].ToString().Trim()));
                    foreach (string file in cssFiles)
                    {
                        using (WebClient client = new WebClient())
                        {
                            string url = "ftp://pioneers@103.235.106.17/" + Domaim + dr["DestinationFile"].ToString().Trim() + "/";
                            if (!CheckFileExistOnFTP(url + Path.GetFileName(file), "pioneers", "d@8Pg~4Ea0Dv$9C"))
                            {
                                client.Credentials = credentials;
                                client.UploadFile(url + Path.GetFileName(file), file);

                            }
                            //Console.WriteLine($"Uploading {file}");

                        }
                    }
                    Session["Completemsg"] = "Yes";
                    Session["Dothis"] = "0";
                }
                catch (Exception)
                {

                    RedirectToAction("ChannaPartnerList", "Partner");
                }

            }

        }
        public ActionResult EditChannalPartner(string CustId)
        {
            SessionTest();
            Session["CustId"] = CustId;
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            ChennelpartnerModel Cm = objPartnerBAL.GetChannalPartnerDtl(Convert.ToInt32(CustId));
            return View(Cm);
        }
        public ActionResult NewCP()
        {
            SessionTest();
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            return View();
        }
        [HttpPost]
        public ActionResult SaveChennelPartnerDetails1(FormCollection fc, ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            //if (ModelState.IsValid)
            //{
            //    var user = new ApplicationUser { UserName = model.UserName, Email = model.EmailID };
            //    var result =  UserManager.CreateAsync(user, model.pwd);

            //}

            ///If we got this far, something failed, redisplay form
            //return View(model);
            if (ModelState.IsValid)
            {
                var EventsTitleList = objPartnerBAL.SaveChennelPartnerDetails(model, postedFile);
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
                                var filePath = Server.MapPath("~/Documents/Logo/" + filename1);
                                file.SaveAs(filePath);
                                var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                            }
                        }
                        else if (k == 1)
                        {
                            var Type = 1;
                            var filePath = Server.MapPath("~/Documents/Pan/" + filename);
                            file.SaveAs(filePath);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        else if (k == 2)
                        {
                            var Type = 2;
                            var path = Path.Combine(Server.MapPath("~/Documents/RegDocument/"), filename);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        else if (k == 3)
                        {
                            var Type = 3;
                            var path = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto/"), filename);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        else if (k == 4)
                        {
                            var Type = 4;
                            var path = Path.Combine(Server.MapPath("~/Documents/OwnerSignature/"), filename);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        k++;
                    }
                }
                var ChennelPartnerList = objPartnerBAL.GetChennelPartnerList();
                ViewBag.ChennelPartnerList = ChennelPartnerList;
            }

            string url = "http://bds.pioneersoft.co.in";
            return Redirect("http://bds.pioneersoft.co.in");
        }
        [HttpPost]
        public ActionResult SaveChennelPartnerDetails(FormCollection fc, ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
          
            if (ModelState.IsValid)
            {
                var EventsTitleList = objPartnerBAL.SaveChennelPartnerDetails(model, postedFile);
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
                                var filePath = Server.MapPath("~/Documents/Logo/" + filename1);
                                file.SaveAs(filePath);
                                var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                            }
                        }
                        else if (k == 1)
                        {
                            var Type = 1;
                            var filePath = Path.Combine(Server.MapPath("~/Documents/Pan/"), filename);
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
                var ChennelPartnerList = objPartnerBAL.GetChennelPartnerList();
                ViewBag.ChennelPartnerList = ChennelPartnerList;
            }


            return View();
        }

        public ActionResult RejectCP()
        {
            SessionTest();
            bool res = objPartnerBAL.RejectChannalPartner(Convert.ToInt32(Session["CustId"]));
            return RedirectToAction("ChannaPartnerList", "Partner");
        }
        public ActionResult UserIntraction(string CustId)
        {
            SessionTest();
            UserIntraction cd = new UserIntraction();
            cd.CustID = Convert.ToInt32(CustId);
            //if (IntractionId != "")
            //    cd = objPartnerBAL.GetDeleteUserIntraction(Convert.ToInt32(IntractionId));
            return View();
        }
        [HttpGet]
        public JsonResult DeleteUserIntraction(string IntractionId)
        {
            var CustId = Convert.ToString(Session["CustId"]);
            bool res = objPartnerBAL.GetDeleteUserIntraction(Convert.ToInt32(IntractionId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult _PartialUserIntarction(string CustId)
        {
            SessionTest();
            Session["Msg"] = "";
            if (CustId != "")
                ViewBag.UserIntract = objPartnerBAL.GetUserIntraction(Convert.ToInt32(CustId));
            return View();
        }

        public ActionResult EditUserIntraction(string CustId)
        {
            SessionTest();
            return View();
        }

        public ActionResult SetUserIntraction(UserIntraction UsD)
        {
            SessionTest();
            UsD.CustID = Convert.ToInt32(Session["CustId"]);
            bool res = objPartnerBAL.setUserIntarction(UsD);
            if (res)
            {
                //int Res = Mb.UpdateMemPassword(UserId, Mp.Password);
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Success = false, Messege = "Please Enter Valid Old Password", Status = 400 });
            }

        }
        public ActionResult _PartialCPPerstionalDtl(string CustId)
        {
            SessionTest();
            Session["Msg"] = "";
            Session["CustId"] = CustId;
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            if (CustId != "")
            {
                var d = objPartnerBAL.GetCPForEdit(Convert.ToInt32(CustId));
                return View(d);
            }
            return View();
        }

        public ActionResult _PartialCPBusinessDtl(string CustId)
        {
            SessionTest();
            Session["Msg"] = "";
            Session["CustId"] = CustId;
            ViewBag.TypeOfHosting = new SelectList(objPartnerBAL.GetTypeofHosting(), "TypeHostingId", "TypeofHosting");
            ViewBag.HostingPlatForm = new SelectList(objPartnerBAL.GetHostingPlatform(), "HostingPlatformId", "HostingPlatForm");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            if (CustId != "")
            {
                var d = objPartnerBAL._partialGetCPBusinessDtl(CustId);
                Session["Domain"] = d.CurrentDomainProvide;
                return View(d);
            }
            else
                return View();
        }
        public JsonResult getuserdat(string CustId)
        {
            SessionTest();
            Session["Msg"] = "";
            Session["Tab"] = "";
            if (CustId == "")
                CustId = "0";
            var list = objPartnerBAL.GetCountryStateForCPPersonal(Convert.ToInt32(CustId));
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _PartialgetCPBankDtl(string CustId)
        {
            SessionTest();
            Session["Msg"] = "";
            Session["CustId"] = CustId;
            ViewBag.bank = new SelectList(objPartnerBAL.GetBank(), "BankId", "BankName");
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            if (CustId != "")
            {
                var d = objPartnerBAL._partialGetCPBankDtl(CustId);
                return View(d);
            }
            else
                return View();
        }
        public ActionResult DeleteCp()
        {
            SessionTest();
            bool res = objPartnerBAL.DeleteCP(Convert.ToInt32(Session["CustId"]));
            return RedirectToAction("ChannaPartnerList", "Partner");
        }
        public ActionResult _partialCPDocument(string CustId)
        {
            SessionTest();
            return View();
        }
        public ActionResult _PartialgetCPDocument()
        {
            SessionTest();
            int CustId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBAL.getCpDocument(CustId);
            return View(d);
        }
        public ActionResult ApproveCp()
        {
            
            string SourceDomain = "ftp://pioneers@103.235.106.17/shop.pioneersoft.co.in";
            string DestinationDomain = "ftp://pioneers@103.235.106.17/" + Session["Domain"];
            NetworkCredential credentials = new NetworkCredential("pioneers", "d@8Pg~4Ea0Dv$9C");
           
            {
                string directoryUrl = DestinationDomain;

                if (!DirectoryExists(directoryUrl))
                {
                    try
                    {
                        //Console.WriteLine($"Creating {name}");
                        FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create(directoryUrl);
                        requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                        requestDir.Credentials = credentials;
                        requestDir.GetResponse().Close();
                    }
                    catch (WebException ex)
                    {
                        FtpWebResponse response = (FtpWebResponse)ex.Response;
                        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                        {
                            // probably exists already
                        }
                        else
                        {
                          //  RedirectToAction("ChannaPartnerList", "Partner");
                        }
                    }

                }
            }

            Session["Completemsg"] = "No";
            Session["Dothis"] = "1";
            bool res = objPartnerBAL.ApproveCP(Convert.ToInt32(Session["CustId"]));
            // Session["Domain"] = model.ObjBusinessDetails.CurrentDomainProvide;
            return RedirectToAction("UpL", "Partner");
        }

        public ActionResult _SetCPDocument(HttpPostedFileBase[] postedFile)
        {
            SessionTest();
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
                            var path = Path.Combine(Server.MapPath("~/Documents/Logo/"), fileName);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                        }
                    }
                    else if (k == 1)
                    {
                        var Type = 1;
                        var filePath = Path.Combine(Server.MapPath("~/Documents/Pan/"), filename);
                        file.SaveAs(filePath);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 2)
                    {
                        var Type = 2;
                        var path = Path.Combine(Server.MapPath("~/Documents/RegDocument/"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 3)
                    {
                        var Type = 3;
                        var path = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto/"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 4)
                    {
                        var Type = 4;
                        var path = Path.Combine(Server.MapPath("~/Documents/OwnerSignature/"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    k++;
                }
            }
            return RedirectToAction("Chennelpartner", "Partner");
        }

        public ActionResult Wallet()
        {
            SessionTest();
            ViewBag.BindCPCustomer = new SelectList(objProductBAL.GetCPDropDown(), "CustId", "CustName");
            return View();
        } 
        public ActionResult _WalletAmount(string CPName)
        {
            SessionTest();
            if (CPName == "--All CP--")
                CPName = null;
            ViewBag.WalletAmount = objProductBAL.GetpartialWalletAmt(CPName);
            
            return View();
        }
        public ActionResult _WalletAmountLst(string CPName)
        {
            SessionTest();
            if (CPName == "--All CP--")
                CPName = null;
            ViewBag.WalletAmountCPList = objProductBAL.GetpartialWalletAmtLst(CPName);
            return View();
        }
        public ActionResult _OrderCPLst(string CPName)
        {
            SessionTest();
            if (CPName == "--Select CP--")
                CPName = null;
            ViewBag.CPOrderList = objProductBAL.GetpartialCPOrderList(CPName);
            return View();
        }
        public ActionResult ExcelExportCPList()
        {

            List<ChennelpartnerModel> FileData = objPartnerBAL.GetChennelPartnerList();
         

            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("CP Id", typeof(string));
                Dt.Columns.Add("CP Name", typeof(string));
                Dt.Columns.Add("Email Address", typeof(string));
                Dt.Columns.Add("Mobile No", typeof(string));
                Dt.Columns.Add("Address", typeof(string));
                Dt.Columns.Add("Company Name", typeof(string));
               
                
                foreach (var data in FileData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = data.CPId;
                    row[1] = data.chennelpartName;
                    row[2] = data.EmailID;
                    row[3] = data.mobileNo;
                    row[4] = data.Address;
                    row[5] = data.CommanyName;
                   
                    Dt.Rows.Add(row);

                }

                var memoryStream = new MemoryStream();
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].LoadFromDataTable(Dt, true, TableStyles.None);
                    worksheet.Cells["A1:AN1"].Style.Font.Bold = true;
                    worksheet.DefaultRowHeight = 18;


                    worksheet.Column(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    worksheet.Column(6).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Column(7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.DefaultColWidth = 20;
                    worksheet.Column(2).AutoFit();

                    Session["DownloadExcel_FileManager"] = excelPackage.GetAsByteArray();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public ActionResult DownloadCPList()
        {

            if (Session["DownloadExcel_FileManager"] != null)
            {
                byte[] data = Session["DownloadExcel_FileManager"] as byte[];
                return File(data, "application/octet-stream", "ChannalPartnerList.xlsx");
            }
            else
            {
                return new EmptyResult();
            }
        }
        public ActionResult Customer()
        {
            SessionTest();
            var CPCChennelPartnerList = objPartnerBAL.GetCustomerList();
            ViewBag.CPCChennelPartnerList = CPCChennelPartnerList;
            return View();
           
        }
        public ActionResult AddNewCustomer(string CustId, string EditId)
        {
            if (CustId != "0" && CustId != null)
            {
                Session["CustId"] = CustId;
                if (EditId != null)
                    Session["EditId"] = EditId;
            }

            else
            {
                if (EditId != null)
                    Session["EditId"] = EditId;
                CustId = Convert.ToString(Session["CustId"]);
            }
            CPCchannelPartnerModel list = new CPCchannelPartnerModel();
            list.CustId = CustId;
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCPCustomer = new SelectList(objPartnerBAL.GetBindCPCustomer(), "CpCustomer", "CpCustomerName");
            if (CustId != "")
            {
                Session["CustId"] = CustId;
                list.CustId = Convert.ToString(CustId);
                if (!string.IsNullOrWhiteSpace(CustId.ToString()))
                {
                    list = objPartnerBAL.GetCPCChannelEdit(CustId);
                    return View(list);
                }
            }
            return View();
        }
        public ActionResult _partialCustomer(string Custid)
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
        public ActionResult _partialCustomerBankDetail(string Custid)
        {
            SessionTest();
            Session["Msg"] = "";
            CPCchannelPartnerModel list = new CPCchannelPartnerModel();
            BankDetails list1 = new BankDetails();
            Custid = Convert.ToString(Session["Custid"]);
            if (Custid != "")
            {
                if (!string.IsNullOrWhiteSpace(Custid.ToString()))
                {
                    ViewBag.bank = new SelectList(objPartnerBAL.GetBank(), "BankId", "BankName");
                    ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
                    ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
                    list = objPartnerBAL.GetCPCChannelEdit(Custid);
                    list1.CustId = list.CustId;
                    list1 = list.ObjBackDetails;
                    list1.CustId = list.CustId;
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

        public ActionResult _partialCustomerDocument()
        {
            SessionTest();
            Session["Msg"] = "";
            CPCchannelPartnerModel list = new CPCchannelPartnerModel();
            //  list = objPartnerBAL.GetCPCChannelEdit(Custid);
            return View();
        }
        public ActionResult _partialSetCustomerBankDeatil(BankDetails bd)
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
                CPCchannelPartnerModel model = new CPCchannelPartnerModel();
                model.CustId = bd.CustId;
            }
            Session["Tab"] = "3";
            return RedirectToAction("AddNewCustomer", "Partner", new { CustId = bd.CustId });
        }

        public ActionResult _SetCustomerDocument(HttpPostedFileBase[] postedFile)
        {
            SessionTest();
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
            return RedirectToAction("AddNewCustomer", "Partner", new { CustId = EventsTitleList });
        }
        public ActionResult DeleteCustomer()
        {
            int CustId = Convert.ToInt32(Convert.ToString(Session["CustId"]));
            bool res = objPartnerBAL.DeleteDirector(CustId);
            return RedirectToAction("Customer", "Partner");
        }
        public ActionResult DeleteCPCustomer()
        {
            int CustId = Convert.ToInt32(Convert.ToString(Session["CustId"]));
            bool res = objPartnerBAL.DeleteDirector(CustId);
            return RedirectToAction("CPCChennelPartnerList", "CP");
        }
    }
}