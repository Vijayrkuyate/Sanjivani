using SanjivaniBusinessLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using IronPdf;

namespace SanjivaniERP.Controllers
{
    public class DirectorController : Controller
    {
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        ClsProductBALcs objProductBAL = new ClsProductBALcs();
        
        // GET: Director
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
        public ActionResult _partialDirectorPersonalDetails(string Custid)
        {
            SessionTest();
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
            SessionTest();
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
            SessionTest();
            string Custid = "3013";
            var list = objPartnerBAL.GetDirectorChannelEdit(Custid);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _partialDirectorDocument()
        {
            SessionTest();
            return View();
        }

        public ActionResult _partialSetBankDeatil(BankDetails bd)
        {
            SessionTest();
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
            return RedirectToAction("DirectorBusinessOwners", "CP", new { CustId = EventsTitleList });
        }

        public ActionResult _PartialgetDirectorDocument()
        {
            SessionTest();
            int CustId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBAL.getDirectorDocument(CustId);
            ViewBag.data = d;
            return View(d);

        }

        public ActionResult Dashboard()
        {
            
            SessionTest();
           // ViewBag.GHD= objPartnerBAL.GetTicketCount("0");
            ViewBag.Reveneue = objPartnerBAL.GetDirectorReveneue();
            ViewBag.ProductCount = objPartnerBAL.GetProductCountForDirectorDash();
            var d = objPartnerBAL.GetDirectorDashboard();
            return View(d);
        }
        public ActionResult CPDashboard()
        {
            
            SessionTest();
            var d = objPartnerBAL.GetDirectorDashboard();
            return View(d);
        }
        public ActionResult CPCDashboard()
        {
            SessionTest();
            var d = objPartnerBAL.GetDirectorDashboard();
            return View(d);
        }
        public ActionResult GHD()
        {
            SessionTest();
            return View();
        }
        public ActionResult _partialGHD()
        {
            SessionTest();
            var d = objPartnerBAL.getGHDList();
            return View(d);
        }
        public ActionResult SetGHD(GHDs test, FormCollection fc)
        {
            SessionTest();
            if (test.Link.ToString().Contains("embed") == true)
            {

            }
            else
            {
                string Link = test.Link.Replace("www.youtube.com/", "www.youtube.com/embed/");
                test.Link = Link;
            }


            bool res = objPartnerBAL.setGHD(test);
            if (res)
            {
                return Json(new { success = true, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult OrgChart()
        {
            SessionTest();
            ViewBag.CPOrg = objPartnerBAL.getcpOrg();
            ViewBag.CPCOrg = objPartnerBAL.getcpCOrg();
            ViewBag.Customer = objPartnerBAL.getCustomerOrg();
            ViewBag.Director = objPartnerBAL.getDirectorOrg();
            ViewBag.Affilator = objPartnerBAL.getAffilatorOrg();
            return View();
        }
        public ActionResult DeleteGHD(string GHDId)
        {
            SessionTest();
            bool res = objPartnerBAL.DeleteGHD(Convert.ToInt32(GHDId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult VOC()
        {
            SessionTest();
            return View();
        }
        public ActionResult _partialVOC()
        {
            SessionTest();
            var d = objPartnerBAL.GetVOC();
            return View(d);
        }
        public ActionResult DeleteVOC(string VocDtlId)
        {
            SessionTest();
            bool res = objPartnerBAL.deleteVOC(Convert.ToInt32(VocDtlId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SetVOC(VOCust vc)
        {
            SessionTest();
            Session["VOC"] = vc.Voc;
            if (vc.VocDtlId == null)
                vc.VocDtlId = "0";
            if (vc.VocId == null)
                vc.VocId = "0";
            bool res = objPartnerBAL.SetVOC(vc);
            if (res)
            {
                return Json(new { success = true, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult TicketOpen()
        {
            SessionTest();
            ViewBag.TicketType = new SelectList(objPartnerBAL.GetTicketType(), "TicketTypeId", "TicketType");
            return View();
        }
        public ActionResult _partialTicketCount(string TicketTypeId)
        {
            var d = objPartnerBAL.GetTicketCount(TicketTypeId);
            return View(d);
        }
        public ActionResult _partialGetOpenTicket(string TicketTypeId)
        {
            var d = objPartnerBAL.GetOpenTicketCount(TicketTypeId);
            return View(d);
        }
        public ActionResult GHDTicket()
        {
            SessionTest();
            ViewBag.TicketType = new SelectList(objPartnerBAL.GetTicketType(), "TicketTypeId", "TicketType");
            var d = objPartnerBAL.GetGHDTicket();
            return View(d);
        }
        public ActionResult CPBanner()
        {
            SessionTest();
            ViewBag.BindCPCustomer = new SelectList(objProductBAL.GetCPDropDown(), "CustId", "CustName");
            return View();
        }
        public ActionResult _partialCPBanner(string Name)
        {
            SessionTest();
            ViewBag.CPBanner = objPartnerBAL.GetCPBanner(Name);
            return View();
        }
        public ActionResult SetCPBanner(FormCollection fc, HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            string CPName = fc["CustName"];
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    var filename1 = Path.GetFileName(file.FileName);
                    if (filename1 != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/CPStorefront/Banner/" + filename1);
                        file.SaveAs(filePath);
                        bool res = objPartnerBAL.SetCPBanner(CPName, filename1);
                    }


                }
            }
            return RedirectToAction("CPBanner", "Director");
        }
        public ActionResult CPCompanyLogo()
        {
            SessionTest();
            ViewBag.BindCPCustomer = new SelectList(objProductBAL.GetCPDropDown(), "CustId", "CustName");
            return View();
        }
        public ActionResult _partialCompanyLogo(string Name)
        {
            SessionTest();
            ViewBag.CPBanner = objPartnerBAL.GetCompanyLogo(Name);
            return View();
        }
        public ActionResult SetCompanyLogo(FormCollection fc, HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            string CPName = fc["CustName"];
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    var filename1 = Path.GetFileName(file.FileName);
                    if (filename1 != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/CPStorefront/LoginPage/" + filename1);
                        file.SaveAs(filePath);
                        bool res = objPartnerBAL.SetCompanyLogo(CPName, filename1);
                    }


                }
            }
            return RedirectToAction("CPCompanyLogo", "Director");
        }
        public ActionResult CPClient()
        {
            SessionTest();
            ViewBag.BindCPCustomer = new SelectList(objProductBAL.GetCPDropDown(), "CustId", "CustName");
            return View();
        }
        public ActionResult _partialCPClient(string CustName)
        {
            SessionTest();
            ViewBag.CPBanner = objPartnerBAL.GetCPClient(CustName);
            return View();
        }
        public ActionResult SetCPClient(FormCollection fc, HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            string CPName = fc["CustName"];
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    var filename1 = Path.GetFileName(file.FileName);
                    if (filename1 != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/CPStorefront/Client/" + filename1);
                        file.SaveAs(filePath);
                        bool res = objPartnerBAL.SetCPClient(CPName, filename1);
                    }


                }
            }
            return RedirectToAction("CPClient", "Director");
        }
        public ActionResult CPLoginPage()
        {
            SessionTest();
            ViewBag.BindCPCustomer = new SelectList(objProductBAL.GetCPDropDown(), "CustId", "CustName");
            return View();
        }
        public ActionResult _partialCPLoginPage(string CustName)
        {
            SessionTest();
            ViewBag.CPBanner = objPartnerBAL.GetCPLoginPage(CustName);
            return View();
        }
        public ActionResult SetCPLoginPage(FormCollection fc, HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            string CPName = fc["CustName"];
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    var filename1 = Path.GetFileName(file.FileName);
                    if (filename1 != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/CPStorefront/LoginPage/" + filename1);
                        file.SaveAs(filePath);
                        bool res = objPartnerBAL.SetCPLoginPage(CPName, filename1);
                    }


                }
            }
            return RedirectToAction("CPLoginPage", "Director");
        }
        public ActionResult PeopleTalks()
        {
            SessionTest();
            ViewBag.BindCPCustomer = new SelectList(objProductBAL.GetCPDropDown(), "CustId", "CustName");
            return View();
        }
        public ActionResult _partialPeopleTalks(string CustName)
        {
            SessionTest();
            ViewBag.CPBanner = objPartnerBAL.GetCPPeopleTalks(CustName);
            return View();
        }
        public ActionResult SetCPPeopleTalk(FormCollection fc, HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            string CPName = fc["CustName"];
            string PopleTalk = fc["PeoplesTalk"];
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    var filename1 = Path.GetFileName(file.FileName);
                    if (filename1 != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/CPStorefront/PeopleTalks/" + filename1);
                        file.SaveAs(filePath);
                        bool res = objPartnerBAL.SetCPPeopleTalk(CPName, PopleTalk, filename1);
                    }


                }
            }
            return RedirectToAction("PeopleTalks", "Director");
        }
        public ActionResult DeleteDirector(DirectorBusinessModel DD,FormCollection fc)
        {
            int CustId = Convert.ToInt32(Convert.ToString(Session["CustId"]));
            bool res = objPartnerBAL.DeleteDirector(CustId);
            return RedirectToAction("DirectorBusinessOwnersList", "CP");
        }
        public ActionResult ExcelExportDirectorList()
        {
            
            List<DirectorBusinessModel> FileData = objPartnerBAL.GetDirectorBusinessOwnerList();


            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("Owner Name", typeof(string));
                Dt.Columns.Add("Email ID", typeof(string));
                Dt.Columns.Add("Mobile No", typeof(string));
                Dt.Columns.Add("User Id", typeof(string));

                foreach (var data in FileData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = data.OwnerName;
                    row[1] = data.EmailID;
                    row[2] = data.mobileNo;
                    row[3] = data.UserId;
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

        public ActionResult DownloadDirectorList()
        {

            if (Session["DownloadExcel_FileManager"] != null)
            {
                byte[] data = Session["DownloadExcel_FileManager"] as byte[];
                return File(data, "application/octet-stream", "DirectorList.xlsx");
            }
            else
            {
                return new EmptyResult();
            }
        }

        public ActionResult ViewSalesTicket(string TicketId)
        {
            SessionTest();
            var d = objPartnerBAL.GetSalesGHDTicket(Convert.ToInt32(TicketId));
            return View(d);
        }
        public ActionResult ViewTechanicalTicket(string TicketId)
        {
            string abc = "";
            var d = objPartnerBAL.GetTechanicalGHDTicket(Convert.ToInt32(TicketId));
            DataTable dt = objPartnerBAL.GetDNSSettingForTechanical(Convert.ToInt32(d.CustomerDomainProductDnsMId));
            foreach (DataRow dr in dt.Rows)
            {
                if(dr["DNSType"].ToString()!="")
                {
                    abc= "Type"+":"+"  "+dr["DNSType"].ToString() + "</br>";
                }
                if (dr["Name"].ToString() != "")
                {
                    abc = abc+ "Name" + ":" + "  " + dr["Name"].ToString()+ "</br>";
                }
                if (dr["Value"].ToString() != "")
                {
                    abc = abc + "Value" + ":" + "  " + dr["Value"].ToString() + "</br>";
                }
                if (dr["TTL"].ToString() != "")
                {
                    abc = abc + "TTL" + ":" + "  " + dr["TTL"].ToString() + "</br>";
                }
                if (dr["Priority"].ToString() != "")
                {
                    abc = abc + "Priority" + ":" + "  " + dr["Priority"].ToString() + "</br>";
                }
                if (dr["Protocol"].ToString() != "")
                {
                    abc = abc + "Protocol" + ":" + "  " + dr["Protocol"].ToString() + "</br>";
                }
                if (dr["Weight"].ToString() != "")
                {
                    abc = abc + "Weight" + ":" + "  " + dr["Weight"].ToString() + "</br>";
                }
                if (dr["Port"].ToString() != "")
                {
                    abc = abc + "Port" + ":" + "  " + dr["Port"].ToString() + "</br>";
                }
            }
            d.DNS = abc;
            return View(d);
        }
        public ActionResult UpdateTicketStatus(string Type,string TicketId)
        {
            bool res = objPartnerBAL.updateTicketStatus(Type, TicketId);
            return RedirectToAction("TicketOpen", "Director");
        }
        public ActionResult Mailbox()
        {
            SessionTest();
            ViewBag.DirectorMailBox = objPartnerBAL.GetDirectorMailBox();
            return View();
        }
        public ActionResult Compose()
        {
            return View();
        }
        public ActionResult SendMail(FormCollection fc)
        {
            int CustId = Convert.ToInt32(Session["UserId"]);
            string msg = fc["msg"].ToString();
            string Email = fc["email"].ToString();
            int A = objPartnerBAL.sendmail(msg, Email, CustId);
            return RedirectToAction("Mailbox", "Director");
        }
        public ActionResult SentBox()
        {
            int CustId = Convert.ToInt32(Session["UserId"]);
            ViewBag.DirectorMailBox = objPartnerBAL.GetSentMailBox(CustId);
            return View();
        }
        public ActionResult Invoice()
        {
            SessionTest();
            return View();
        }
        public ActionResult Nested()
        {
            SessionTest();
            return View();
        }
        public ActionResult OrgChartNew()
        {
            SessionTest();
            return View();
        }
        public ActionResult _OrgChartNew(string CPName)
        {
            ViewBag.Org = objPartnerBAL._orgChartNew(CPName);
            return View();
        }
        public ActionResult _RedirectOrg(string CustId,string CustCategeory)
        {
            if(CustCategeory=="Director")
            {
                return RedirectToAction("DirectorBusinessOwners", "CP", new { CustId });
            }
            if (CustCategeory == "Customer")
            {
                return RedirectToAction("AddNewCustomer", "Partner", new { CustId });
            }
            if (CustCategeory == "CP")
            {
                return RedirectToAction("Chennelpartner", "Partner", new { CustId });
            }
            if (CustCategeory == "CPC")
            {
                return RedirectToAction("CPCChennelPartner", "CP", new { CustId });
            }
            return View();
        }
        public ActionResult CSR()
        {
            SessionTest();
            if (Session != null && Session["TenantSessionId"] != null)
            {
                string a = "";
            }
                return View();
        }
        public ActionResult CSRDtl(string Title)
        {
            SessionTest();
            return View();
        }
        public ActionResult Report()
        {
            return View();
        }
        public ActionResult CPReport()
        {
            return View();
        }
        [DataContract]
        public class DataPoint
        {
            public DataPoint(string label, double y)
            {
                this.Label = label;
                this.Y = y;
            }

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "label")]
            public string Label = "";

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "y")]
            public Nullable<double> Y = null;
        }
        [DataContract]
        public class DataPoints
        {
            public DataPoints(string label, double y)
            {
                this.Label = label;
                this.Y = y;
            }

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "label")]
            public string Label = "";

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "y")]
            public Nullable<double> Y = null;
        }
        public ActionResult _partialCPBarchart()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Jan", 10));
            dataPoints.Add(new DataPoint("Feb", 20));
            dataPoints.Add(new DataPoint("Mar", 17));
            dataPoints.Add(new DataPoint("April", 39));
            dataPoints.Add(new DataPoint("May", 30));
            dataPoints.Add(new DataPoint("Jun", 25));
            dataPoints.Add(new DataPoint("Jul", 15));
            dataPoints.Add(new DataPoint("Aug", 95));
            dataPoints.Add(new DataPoint("Sep", 7));
            dataPoints.Add(new DataPoint("Oct", 2));
            dataPoints.Add(new DataPoint("Nov", 1));
            dataPoints.Add(new DataPoint("Dec", 0));
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
        public ActionResult _partialCPProductBarchart()
        {
            List<DataPoints> dataPoints = new List<DataPoints>();
            dataPoints.Add(new DataPoints("Domain", 2700));
            dataPoints.Add(new DataPoints("Hosting", 1968));
            dataPoints.Add(new DataPoints("Email", 1700));
            dataPoints.Add(new DataPoints("SSL", 450));
            dataPoints.Add(new DataPoints("PaymentGetway", 200));
            ViewBag.DataPoints12 = JsonConvert.SerializeObject(dataPoints);

            return View();
           
        }
        public ActionResult CustomerAggre()
        {
            return View();
        }
        public ActionResult _PartialCustomerAggre()
        {
            var d = objPartnerBAL.GetCustomerAggre();
            return View(d);
        }
        public ActionResult SetCustomerAggrement(CustomerAggrements CA)
        {
            SessionTest();
           
          
            if (CA.CustomerAggrementId == null)
                CA.CustomerAggrementId = 0;
            bool res = objPartnerBAL.SetCustomerAggrement(CA);
            if (res)
            {
                return Json(new { success = true, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteCustomerAggre(string GHDId)
        {
            SessionTest();
            bool res = objPartnerBAL.DeleteCustomerAggrem(Convert.ToInt32(GHDId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CPAggrement()
        {
            return View();
        }
        public ActionResult _PartialCPAggre()
        {
            var d = objPartnerBAL.GetCPAggre();
            return View(d);
        }
        public ActionResult SetCPAggrement(CPAggrements CA)
        {
            SessionTest();


            if (CA.CPAggrementId == null)
                CA.CPAggrementId = 0;
            bool res = objPartnerBAL.SetCPAggrement(CA);
            if (res)
            {
                return Json(new { success = true, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteCPAggre(string GHDId)
        {
            SessionTest();
            bool res = objPartnerBAL.DeleteCPAggrem(Convert.ToInt32(GHDId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }

        //Privacy

        public ActionResult Privacy()
        {
            return View();
        }
        public ActionResult _PartialPrivacy()
        {
            var d = objPartnerBAL.GetPrivacy();
            return View(d);
        }
        public ActionResult SetPrivacy(Privacys CA)
        {
            SessionTest();


            if (CA.PrivacyId == null)
                CA.PrivacyId = 0;
            bool res = objPartnerBAL.SetPrivacy(CA);
            if (res)
            {
                return Json(new { success = true, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeletePrivacy(string GHDId)
        {
            SessionTest();
            bool res = objPartnerBAL.DeletePrivacy(Convert.ToInt32(GHDId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }

        //ProductAggrement

        public ActionResult ProductAggrement()
        {
            return View();
        }
        public ActionResult _PartialProductAggrement()
        {
            var d = objPartnerBAL.GetProductAggrement();
            return View(d);
        }
        public ActionResult SetProductAggrement(ProductAggrements CA)
        {
            SessionTest();


            if (CA.ProductAggrementId == null)
                CA.ProductAggrementId = 0;
            bool res = objPartnerBAL.SetProductAggrement(CA);
            if (res)
            {
                return Json(new { success = true, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteProductAggrement(string GHDId)
        {
            SessionTest();
            bool res = objPartnerBAL.DeleteProductAggrement(Convert.ToInt32(GHDId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// /pdf
        /// </summary>
        /// <returns></returns>
        public ActionResult CustAggrenPDF()
        {
            return View();
        }
        public ActionResult _PartialCustAggrenPDF()
        {
            return View();
        }
        public ActionResult ExportPDF()
        {
           // return new Rotativa.ActionAsPdf("GetPersons");
            Console.WriteLine("Hold on tight!");

            var htmlToPdf = new HtmlToPdf();  // new instance of HtmlToPdf

            //html to pdf
            //html to turn into pdf
            var html = @"<h1>Hello World!</h1><br><p>This is IronPdf.</p>";

            // turn html to pdf
            var pdf = htmlToPdf.RenderHtmlAsPdf(html);

            // save resulting pdf into file
            pdf.SaveAs(Server.MapPath("~/Content")); 

            //url to pdf
            // uri of the page to turn into pdf
            var uri = new Uri("http://www.google.com/ncr");

            // turn page into pdf
            pdf = htmlToPdf.RenderUrlAsPdf(uri);

            // save resulting pdf into file
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "UrlToPdf.Pdf"));

            Console.WriteLine("Done. Please find results under '{0}' directory.", Directory.GetCurrentDirectory());
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return View();
        }
        /// <summary>
        /// /Employeee
        /// </summary>
        /// <returns></returns>
        /// 

        public ActionResult Employee()
        {
            var d = objPartnerBAL.GetEmpList();
            return View(d);
        }
        public ActionResult NewEmployee(string CustId, string EditId)
        {
            SessionTest();
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

            Employees dc = new Employees();


            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetEmpRole(), "EmpRoleId", "EmpRole");
            //ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            if (CustId != null)
            {
                dc.CustId = CustId;
                return View(dc);
            }
            return View();
        }
        public ActionResult _PartialEmpDtl(string CustId)
        {
            SessionTest();
            Session["Msg"] = "";
            Session["CustId"] = CustId;
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetEmpRole(), "EmpRoleId", "EmpRole");
            if (CustId != "")
            {
                var d = objPartnerBAL.GetEmpForEdit(Convert.ToInt32(CustId));
                return View(d);
            }
            return View();
        }
        public ActionResult _PartialgetEmployeeBankDtl(string CustId)
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
        public ActionResult _partialSetEmpEditBankDeatil(BankDetails bd)
        {
            SessionTest();
            bd.BankName = Convert.ToString(bd.BankName1);
            bd.CustId = Convert.ToString(Session["CustId"]);
            bool res = objPartnerBAL.setCPBankDtl(bd);

            Session["Tab"] = "3";
            return RedirectToAction("NewEmployee", "Director");
        }
        public ActionResult DeleteEmp()
        {
            SessionTest();
            bool res = objPartnerBAL.DeleteEmp(Convert.ToInt32(Session["CustId"]));
            return RedirectToAction("Employee", "Director");
        }
        public ActionResult LeaveAttendance()
        {
            ViewBag.Emplyoee = new SelectList(objPartnerBAL.GetEmpList(), "CustId", "chennelpartName");
            return View();
        }
        public ActionResult EmpCalender(string CustName,string Date)
        {
            if(Date=="")
             Date = Convert.ToString(DateTime.Now);
            DataTable dtcalender = objPartnerBAL.GetEmpCalender(Date);
            DataTable dtEmpAtt= objPartnerBAL.GetEmpAttendance(CustName, Date);
            if(dtEmpAtt.Rows.Count>0)
            {
                foreach (DataRow dr in dtEmpAtt.Rows)
                {
                    if(dr["DayName"].ToString()=="Mon")
                    {
                        DataRow[] result = dtcalender.Select("Mon = '" + dr["Day"] + "'");
                        if (result.Length > 0)
                            result[0]["Mon"] = dr["Day"] + "-" + dr["Status"];
                    }
                    if (dr["DayName"].ToString() == "Tue")
                    {
                        DataRow[] result = dtcalender.Select("Tue = '" + dr["Day"] + "'");
                        if (result.Length > 0)
                            result[0]["Tue"] = dr["Day"] + "-" + dr["Status"];
                    }
                    if (dr["DayName"].ToString() == "Wed")
                    {
                        DataRow[] result = dtcalender.Select("Wed = '" + dr["Day"] + "'");
                        if (result.Length > 0)
                            result[0]["Wed"] = dr["Day"] + "-" + dr["Status"];
                    }
                    if (dr["DayName"].ToString() == "Thu")
                    {
                        DataRow[] result = dtcalender.Select("Thu = '" + dr["Day"] + "'");
                        if (result.Length > 0)
                            result[0]["Thu"] = dr["Day"] + "-" + dr["Status"];
                    }
                    if (dr["DayName"].ToString() == "Fri")
                    {
                        DataRow[] result = dtcalender.Select("Fri = '" + dr["Day"] + "'");
                        if (result.Length > 0)
                            result[0]["Fri"] =dr["Day"] + "-" + dr["Status"];
                    }
                    if (dr["DayName"].ToString() == "Sat")
                    {
                        DataRow[] result = dtcalender.Select("Sat = '" + dr["Day"] + "'");
                        if (result.Length > 0)
                            result[0]["Sat"] = Convert.ToString(dr["Day"].ToString() + "-" + dr["Status"].ToString());
                    }
                    if (dr["DayName"].ToString() == "Sun")
                    {
                        DataRow[] result = dtcalender.Select("Sun = '" + dr["Day"] + "'");
                        if (result.Length > 0)
                            result[0]["Sun"] = dr["Day"] + "-" + dr["Status"];
                    }
                }
            }
            System.Collections.Generic.List<Calendera> lst = new List<Calendera>();
            foreach (DataRow dr in dtcalender.Rows)
            {
                Calendera cl = new Calendera();
                cl.Mon = dr["Mon"].ToString();
                cl.Tue = dr["Tue"].ToString();
                cl.Wed = dr["Wed"].ToString();
                cl.Thu = dr["Thu"].ToString();
                cl.Fri = dr["Fri"].ToString();
                cl.Sat = dr["Sat"].ToString();
                cl.Sun = dr["Sun"].ToString();
                lst.Add(cl);
            }
            return View(lst);
        }
        public ActionResult SetEmpAttendance(EmpAttendance CA,FormCollection fc)
        {
            string sts = fc["Cars"].ToString();
            if(sts=="Present")
            CA.Status = "P";
            if (sts == "Absent")
                CA.Status = "A";
            if (sts == "Leave")
                CA.Status = "L";
            SessionTest();
            bool res = objPartnerBAL.SetEmpAttendance(CA);
            if (res)
            {
                return RedirectToAction("LeaveAttendance", "Director");
            }
            else
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}