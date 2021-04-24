using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SanjivaniModalView
{
    public class ProductBusinessModal
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCatId { get; set; }
        public string DomainERPCode { get; set; }
        public string ProductCode { get; set; }
        public string DomainProviderCode { get; set; }
        public string SACCode { get; set; }
        public string RegistrartionPrice { get; set; }
        public string RenewalPrice { get; set; }
        public string TransferPrice { get; set; }
        public string DomainregistrationPrice { get; set; }
        public string PropductImage { get; set; }
        public string CPName { get; set; }
        public string CostPrice { get; set; }
        public string SellingPrice { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
    public class ProductEmail
    {
        public int EmailProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCatId { get; set; }
        public string ProductProvider { get; set; }
        public string ProductCode { get; set; }
        public string EmailImage { get; set; }
        public string SACCode { get; set; }
        public string RegistrationPrice { get; set; }
        public string RenewalPrice { get; set; }
        public string CostPrice { get; set; }
        public string SellingPrice { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
    public class ProductHosting
    {
        public int HostintProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCatId { get; set; }
        public int HostingCatId { get; set; }
        public string ProductImage { get; set; }
        public int HostingSubCatId { get; set; }
        public string Price { get; set; }
        public string HostingSubCat { get; set; }
        public string HostingCat { get; set; }
        public string DomainSize { get; set; }
        public string SSDDiskSapce { get; set; }
        public string CostPrice { get; set; }
        public string TransferSize { get; set; }
        public string EmailAccount { get; set; }
        public string DatabaseSize { get; set; }
        public string SSL { get; set; }
        public string SellingPrice { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
    public class SetPrice
    {
        public int CustId { get; set; }
        public string Amount { get; set; }
        public int ProductCatId { get; set; }
        public string CustName { get; set; }
        public string ProductCat { get; set; }
    }
    public class HostingCategeory
    {
        public int HostingCatId { get; set; }
        public int HostingSubCatId { get; set; }
        public string HostingCat { get; set; }
       
        public string HostingSubCat { get; set; }
        
    }
    public class InvoicePrint
    {
        public string ServiceProviderName { get; set; }
        public string CompanyName { get; set; }
        public string ServiceProviderAddress { get; set; }
        public string ServiceProviderCity { get; set; }
        public string ServiceProviderPostalCode { get; set; }
        public string ServiceProviderMobileNo { get; set; }
        public string ServiceProviderEmail { get; set; }
        public string ServiceProviderGSTIN { get; set; }
        public string ServiceProviderRegNo { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerMoNo { get; set; }
        public string CustomerEmail { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderId { get; set; }
        public string OrderDate { get; set; }
        public List<Order> Productlst = new List<Order>();
        public List<OrderMasterDetail> OrderDetail = new List<OrderMasterDetail>();
    }
    public class OrderMasterDetail
    {
        public string Subtotal { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string InvoiceTotal { get; set; }

    }
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductCatId { get; set; }

        public string ProductName { get; set; }
        public string Price { get; set; }
        public string CostPrise { get; set; }
        public string Margin { get; set; }
        public string CPCId { get; set; }
        public string OrderDate { get; set; }
        public string ProductCat { get; set; }
        public string MobileNo { get; set; }
        public string CustName { get; set; }
        
        public string Qty { get; set; }
        public string RatePerQty { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CreationDate { get; set; }
        public string ExpiryDate { get; set; }
        public string DeletionDate { get; set; }
        public string BasePrise { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string InvoiceAmt { get; set; }
    }
}
