using SanjivaniBusinessLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Table;

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
        public ActionResult NewCp()
        {
            ValidDate();
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
            
            ViewBag.TypeOfHosting = new SelectList(objPartnerBAL.GetTypeofHosting(), "TypeHostingId", "TypeofHosting");
            ViewBag.HostingPlatForm= new SelectList(objPartnerBAL.GetHostingPlatform(), "HostingPlatformId", "HostingPlatForm");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            return View();
        }
        public ActionResult _partialSetCPBusinessDetail(BusinessDetails BD)
        {
            
            BD.CustId = Convert.ToString(Session["CustId"]);
            BD.Annulturnoveer = "0";
            bool res = objPartnerBAL.SetCPBusinessDtl(BD);

            Session["Tab"] = "3";
            return RedirectToAction("ChannelPartner", "CP");
        }
        public ActionResult _partialCPBankDetail()
        {
            
            ViewBag.bank= new SelectList(objPartnerBAL.GetBank(), "BankId", "BankName");
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
                            var path = Path.Combine(Server.MapPath("~/Documents/Logo/"), fileName);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                        }
                    }
                    else if (k == 1)
                    {
                        var Type = 1;
                        var filePath = Path.Combine(Server.MapPath("~/Documents/Logo/"), filename);
                        file.SaveAs(filePath);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 2)
                    {
                        var Type = 2;
                        var path = Path.Combine(Server.MapPath("~/Documents/Logo/"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 3)
                    {
                        var Type = 3;
                        var path = Path.Combine(Server.MapPath("~/Documents/Logo/"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 4)
                    {
                        var Type = 4;
                        var path = Path.Combine(Server.MapPath("~/Documents/Logo/"), filename);
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
            ValidDate();
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            return View();
        }
        public ActionResult CPCChennelPartner(string CustId)
        {
            ValidDate();
            CPCchannelPartnerModel list = new CPCchannelPartnerModel();
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCPCustomer = new SelectList(objPartnerBAL.GetBindCPCustomer(), "CpCustomer", "CpCustomerName");
            if (CustId!="")
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
            ValidDate();

            var CPCChennelPartnerList = objPartnerBAL.GetCPCChannelPartnerList();
            ViewBag.CPCChennelPartnerList = CPCChennelPartnerList;
            return View();
        }
        public ActionResult DirectorBusinessOwnersList()
        {
            ValidDate();
            List<DirectorBusinessModel> DirectorModel = objPartnerBAL.GetDirectorBusinessOwnerList();
            ViewBag.DirectorBusinessOwnerList = DirectorModel;
            return View();
        }
        public ActionResult DirectorBusinessOwners(string CustId,string EditId)
        {
            ValidDate();
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

            DirectorBusinessModel list = new DirectorBusinessModel();
            list.CustId = CustId;
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            //if (CustId != "")
            //{
            //    if (!string.IsNullOrWhiteSpace(CustId.ToString()))
            //    {
            //        list = objPartnerBAL.GetDirectorBusinessOwners(CustId);
            //        return View(list);
            //    }
            //}
            if (CustId != "0" && CustId != "")
            {
               // list = objPartnerBAL.GetDirectorBusinessOwners(CustId);
                list.CustId = CustId;
                return View(list);
            }
            return View();
        }
        public async Task<JsonResult>CheckUserIdExits(string UserId)
        {
            
            DataTable dt = objPartnerBAL.CheckUserIdExists(UserId);
            if (dt.Rows.Count>0)
            {
                return Json(new { Messege = "Session timed out please try again", Status = 400 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { Messege = "Session timed out please try again", Status = 200 }, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult>checEmailIdExits(string Email)
        {
           
            DataTable dt = objPartnerBAL.CheckEmailExists(Email);
            if (dt.Rows.Count > 0)
            {
                return Json(new { Messege = "Session timed out please try again", Status = 400 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { Messege = "Session timed out please try again", Status = 200 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ExcelExportCPCList()
        {

            List<CPCchannelPartnerModel> FileData = objPartnerBAL.GetCPCChannelPartnerList();


            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("User Id", typeof(string));
                Dt.Columns.Add("Email ID", typeof(string));
                Dt.Columns.Add("Mobile No", typeof(string));
                Dt.Columns.Add("Address", typeof(string));

                foreach (var data in FileData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = data.UserId;
                    row[1] = data.EmailID;
                    row[2] = data.mobileNo;
                    row[3] = data.Address;
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

        public ActionResult DownloadCPCList()
        {

            if (Session["DownloadExcel_FileManager"] != null)
            {
                byte[] data = Session["DownloadExcel_FileManager"] as byte[];
                return File(data, "application/octet-stream", "ChannalPartnerCustomerList.xlsx");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}