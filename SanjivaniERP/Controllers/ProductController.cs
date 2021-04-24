using SanjivaniBusinessLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace SanjivaniERP.Controllers
{
    public class ProductController : Controller
    {
        ClsPartnerBAL objPartnerBALs = new ClsPartnerBAL();
        ClsProductBALcs objPartnerBAL = new ClsProductBALcs();
        // GET: Product
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
        public ActionResult Product()
        {
            SessionTest();
            return View();
        }
        public ActionResult Domain()
        {
            SessionTest();
            int CatId = 1;
            var d = objPartnerBAL.GetDoaminList(CatId);
            return View(d);
        }
        public ActionResult AddDomain(int ProductId)
        {
            SessionTest();
            ProductBusinessModal Pd = new ProductBusinessModal();
            Pd.ProductId = ProductId;
           
            return View(Pd);
        }
        public ActionResult _partialAddProduct(string productId)
        {
            SessionTest();
            //if (productId != "0")
            //{
            var d = objPartnerBAL.GetProductById(Convert.ToInt32(productId));
                return View(d);
           // }
           //else
           // {
               
               // return View();
            //}
                
        }
        public ActionResult SetDomain(ProductBusinessModal Pd, HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                  //  var filename1 = Path.GetFileName(file.FileName);
                    Pd.PropductImage = Convert.ToString(Path.GetFileName(file.FileName));
                    if (filename != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/Documents/ProductImage/" + filename);
                        file.SaveAs(filePath);
                        // var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                    }
                }
            }
            var Res = objPartnerBAL.SetDomain(Pd);
            return RedirectToAction("Domain", "Product");
        }
        public ActionResult DeleteProduct(int ProductId)
        {
            SessionTest();
            bool res = objPartnerBAL.deleteProduct(ProductId);
            return RedirectToAction("Domain", "Product");
        }
        public ActionResult Email()
        {
            SessionTest();
            var d = objPartnerBAL.GetEmailProductList();
            return View(d);
        }
        public ActionResult AddEmail(int ProductId)
        {
            SessionTest();
            ProductEmail Pd = new ProductEmail();
            Pd.EmailProductId = ProductId;

            return View(Pd);
        }
        public ActionResult _partialAddEmail(string productId)
        {
            SessionTest();
            var d = objPartnerBAL.GetProductEmailById(Convert.ToInt32(productId));
            return View(d);
        }
        public ActionResult SetEmailProduct(ProductEmail Pd, HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    //  var filename1 = Path.GetFileName(file.FileName);
                    Pd.EmailImage = Convert.ToString(Path.GetFileName(file.FileName));
                    if (filename != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/Documents/ProductImage/" + filename);
                        file.SaveAs(filePath);
                        // var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                    }
                }
            }
            var Res = objPartnerBAL.SetEmailProduct(Pd);
            return RedirectToAction("Email", "Product");
        }

        public ActionResult DeleteEmailProduct(int ProductId)
        {
            SessionTest();
            bool res = objPartnerBAL.deleteEmailProduct(ProductId);
            return RedirectToAction("Email", "Product");
        }
        public ActionResult Hosting()
        {
            SessionTest();
            var d = objPartnerBAL.GetHostingProductList();
            return View(d);
        }
        public ActionResult AddHosting(int ProductId)
        {
            SessionTest();
            ProductHosting Pd = new ProductHosting();
            Pd.HostintProductId = ProductId;

            return View(Pd);
        }
        public ActionResult _partialAddHosting(string productId)
        {
            SessionTest();
            ViewBag.BindHostingCat = new SelectList(objPartnerBAL.GetHostingCat(), "HostingCatId", "HostingCat");
            ViewBag.BindHostingSubCat = new SelectList(objPartnerBAL.GetHostingSubCat(), "HostingSubCatId", "HostingSubCat");
            var d = objPartnerBAL.GetProductHostingById(Convert.ToInt32(productId));
            return View(d);
        }
        public ActionResult SetHostingProduct(ProductHosting Pd, HttpPostedFileBase[] postedFile)
        {
            SessionTest();
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    //  var filename1 = Path.GetFileName(file.FileName);
                    Pd.ProductImage = Convert.ToString(Path.GetFileName(file.FileName));
                    if (filename != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/Documents/ProductImage/" + filename);
                        file.SaveAs(filePath);
                        // var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                    }
                }
            }
            var Res = objPartnerBAL.SetHostingProduct(Pd);
            return RedirectToAction("Hosting", "Product");
        }

        public ActionResult DeleteHostingProduct(int ProductId)
        {
            SessionTest();
            bool res = objPartnerBAL.deleteHOstingProduct(ProductId);
            return RedirectToAction("Hosting", "Product");
        }
        public ActionResult SetPrice()
        {
            SessionTest();
            ViewBag.BindCPCustomer = new SelectList(objPartnerBAL.GetCPDropDown(), "CustId", "CustName");
            ViewBag.BindProductCat = new SelectList(objPartnerBAL.GetProductCatDropDown(), "ProductCatId", "ProductCat");
            return View();
        }
        public ActionResult _partialSetPrice(string CustName,string Categeory)
        {
            SessionTest();
            var d = objPartnerBAL.GetCPDoaminPriceList(CustName, Categeory);
            return View(d);
        }
        public ActionResult _partialEmailSetPrice(string CustName, string Categeory)
        {
            SessionTest();
            var d = objPartnerBAL.GetCPEmailPriceList(CustName, Categeory);
            return View(d);
        }
        public ActionResult _partialHostingSetPrice(string CustName, string Categeory)
        {
            SessionTest();
            var d = objPartnerBAL.GetCPHostingPriceList(CustName, Categeory);
            return View(d);
        }
        [HttpGet]
        public JsonResult SetPriceList(string Cat,string Name,string amount)
        {
            SessionTest();

            bool res = objPartnerBAL.SetProductPrice(Cat, Name, amount);
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
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOrder()
        {
            SessionTest();
            var d = objPartnerBAL.GetOrderList();
            return View(d);
        }
        public ActionResult ManageOrder(string OrderMasterId)
        {
            Session["OrderMasterId"] = OrderMasterId;
            var d = objPartnerBAL.GetBillingDtl(Convert.ToInt32(OrderMasterId));
            return View(d);
        }
        public ActionResult printbill()
        {
            string OrderMasterId = Session["OrderMasterId"].ToString();
            var d = objPartnerBAL.GetBillingDtl(Convert.ToInt32(OrderMasterId));
            return View(d);
        }
        [HttpGet]
        public JsonResult SetCustomerPriceList(string Cat, string Name, string Amount,string ProductId)
        {

            bool res = objPartnerBAL.setCustomerPriceList(Cat, Name, Amount, ProductId);
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ExcelExportOrderList()
        {

            List<Order> FileData = objPartnerBAL.GetOrderList();


            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("Product Name", typeof(string));
                Dt.Columns.Add("Prise", typeof(string));
                Dt.Columns.Add("Order Date", typeof(string));
                Dt.Columns.Add("Customer", typeof(string));
                Dt.Columns.Add("Mobile No", typeof(string));
                foreach (var data in FileData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = data.ProductName;
                    row[1] = data.Price;
                    row[2] = data.OrderDate;
                    row[3] = data.CustName;
                    row[4] = data.MobileNo;
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
        public ActionResult DownloadOrderList()
        {

            if (Session["DownloadExcel_FileManager"] != null)
            {
                byte[] data = Session["DownloadExcel_FileManager"] as byte[];
                return File(data, "application/octet-stream", "OrderList.xlsx");
            }
            else
            {
                return new EmptyResult();
            }
        }

        public ActionResult ExcelExportDomainList()
        {
            int CatId = 1;
            
            List<ProductBusinessModal> FileData = objPartnerBAL.GetDoaminList(CatId);


            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("Product Code", typeof(string));
                Dt.Columns.Add("Product Name", typeof(string));
                Dt.Columns.Add("SAC Code", typeof(string));
                Dt.Columns.Add("Registraion Prise", typeof(string));
                Dt.Columns.Add("Renewal Prise", typeof(string));
                Dt.Columns.Add("Transfer Prise", typeof(string));
                Dt.Columns.Add("Restoration Prise", typeof(string));
                foreach (var data in FileData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = data.ProductCode;
                    row[1] = data.ProductName;
                    row[2] = data.SACCode;
                    row[3] = data.RegistrartionPrice;
                    row[4] = data.RenewalPrice;
                    row[5] = data.TransferPrice;
                    row[6] = data.DomainregistrationPrice;
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
        public ActionResult DownloadDomainList()
        {

            if (Session["DownloadExcel_FileManager"] != null)
            {
                byte[] data = Session["DownloadExcel_FileManager"] as byte[];
                return File(data, "application/octet-stream", "DomainList.xlsx");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}