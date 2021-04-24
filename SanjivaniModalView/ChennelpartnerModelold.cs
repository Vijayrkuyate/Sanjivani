using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SanjivaniModalView
{
    public class ChennelpartnerModel
    {
        public string RegiDate { get; set; }
        
        [Required(ErrorMessage = "Please enter User name.")]
       
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter Password.")]
       
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Invalid password format")]
        [Display(Name = "pwd")]
        public string pwd { get; set; }
        [Required(ErrorMessage = "Please enter Confirm Password.")]
        public string Cpwd { get; set; }
       
        [Required(ErrorMessage = "Please enter Channel Partner Name")]
        public string chennelpartName { get; set; }
        [Required]
        public string mobileNo { get; set; }
        public string AlterMobileNo { get; set; }
        public string EmailID { get; set; }
        public string CpCategory { get; set; }
        public string CPId { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StatusId { get; set; }
        public string CommanyName { get; set; }
        public string AspUserId { get; set; }
        public string ParentId { get; set; }
        public string CustCategroryId { get; set; }
        public string CustId { get; set; }
        public BankDetails ObjBackDetails { get; set; }
        public BusinessDetails ObjBusinessDetails { get; set; }
        public List<State> objState { get; set; }
        public List<CPCategory> ObjCPCategory { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
    public class BankDetails
    {
        [Required(ErrorMessage = "Please enter BankName")]
        public string BankName { get; set; }
        public int BankName1 { get; set; }
        [Required(ErrorMessage = "Please enter Account Number")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "Please enter IFSCcode")]
        public string IFSCcode { get; set; }
        public string BankHolderName { get; set; }
        public string CustId { get; set; }
        public string PaymentBankCardName { get; set; }
        public string cardnumber { get; set; }
        public string paymentMode { get; set; }
        public string AccountType { get; set; }
        public string AccountHolderName { get; set; }
    }
    public class Bank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
    }
    public class TypeOfHosting
    {
        public int TypeHostingId { get; set; }
        public string TypeofHosting { get; set; }
    }

    public class BusinessDetails
    {
        public string CommanyName { get; set; }
        public string ContactPersonName { get; set; }
        public string CommanyType { get; set; }
        public string State { get; set; }
        public string RegNumber { get; set; }
        public string GSTRegNumber { get; set; }
        public string webSite { get; set; }
        public string CustId { get; set; }
        public string LineofBusiness { get; set; }
        public string Annulturnoveer { get; set; }
        public string personalName { get; set; }
        public string Designation { get; set; }
        public string BContactnumber { get; set; }
        public string ABContactnumber { get; set; }
        public string Emailid { get; set; }
        public string ERP { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string HostingProvider { get; set; }
        public string HostingPlatform { get; set; }
        public string TypeofHosting { get; set; }
        public int HostingPlatform1 { get; set; }
        public string NoOfWebSiteHos { get; set; }
        public int TypeofHosting1 { get; set; }
        public string CurrentEmailProvider { get; set; }
        public string CountofEmail { get; set; }
        public string CurrentDomainProvide { get; set; }
        public string CurrentDomainCount { get; set; }
        public string SSLCertificateCount { get; set; }

        public string OfficeAddres { get; set; }
        public string Bstate { get; set; }

    }
    
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
    public class CPCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    public class UserIntraction
    {
        public int CustId { get; set; }
        public string Intraction { get; set; }
    }
    public class CPCustomer
    {
        public int CustID { get; set; }
        public string Userid { get; set; }
    }
    public class CompanyType
    {
        public int Compid { get; set; }
        public string CompanyName { get; set; }
    }
    public class Account
    {
        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }
    }
    public class BankName
    {
        public int BankId { get; set; }
        public string bankname { get; set; }
    }
    public class PaymentType
    {
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
    }
    public class HostingPlatF
    {
        public int HostingPlatformId { get; set; }
        public string HostingPlatForm { get; set; }
    }
    public class CountryState
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
    }
}
