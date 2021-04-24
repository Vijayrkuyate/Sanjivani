using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SanjivaniModalView
{
   public class DirectorBusinessModel
    {
        public string CustId { get; set; }
        public string DINId { get; set; }
        public string RegiDate { get; set; }
        [Required(ErrorMessage = "Please enter User name.")]
        //public string OwnerID { get; set; }
        public string UserId { get; set; }
        public string pwd { get; set; }
        [Required(ErrorMessage = "Please enter Confirm Password.")]
        public string Cpwd { get; set; }
        [Required(ErrorMessage = "Please enter Channel Partner Name")]
        public string OwnerName { get; set; }
        [Required]
        public string mobileNo { get; set; }
        public string AlterMobileNo { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AspUserId { get; set; }
        public string ParentId { get; set; }
        public string CustCategroryId { get; set; }
        public string HolderName { get; set; }
        public int PostedCode { get; set; }
        public string StatusId { get; set; }
        public BankDetails ObjBackDetails { get; set; }
    }
    public class Dashboard
    {
        public string CP { get; set; }
        public string CPC { get; set; }
        public string Director { get; set; }
        public string Customer { get; set; }
        public string Freelancer { get; set; }
        public string Affilate { get; set; }
    }
    public class GHDs
    {
        public string GHDId { get; set; }
        public string GHD { get; set; }
        public string Link { get; set; }
      
    }
    public class OrgChart
    {
        public string Name { get; set; }
        public string ProfilePic { get; set; }
       

    }
    public class VOCust
    {
        public string VocId { get; set; }
        public string Voc { get; set; }

        public string VocDtlId { get; set; }
        public string Ans { get; set; }
    }
    public class GlobalHelpdesk
    {
        public int ImgId { get; set; }

        public int GID { get; set; }
        public string Name { get; set; }
        public HttpPostedFileBase[] files { get; set; }
        public string imagfile { get; set; }
    }
    public class TicketCount
    {
        public string Sales { get; set; }
        public string Billing { get; set; }
        public string Techanical { get; set; }
        public string Compliaint { get; set; }
        public string Openticket { get; set; }
        public string SystemTicketClose { get; set; }
        public string Ticketpool { get; set; }
        public string TotalTicket { get; set; }

    }
    public class TicketTypes
    {
        public int TicketTypeId { get; set; }
        public string TicketType { get; set; }
     
    }
    public class GHDTicket
    {
        public int SalesTicketId { get; set; }
        public int TicketId { get; set; }
        public int TicketTypeId { get; set; }
        public string TicketCat { get; set; }
        public string TicketSubCat { get; set; }
        public string TicketStatus { get; set; }
        public string ProductName { get; set; }
        public string Department { get; set; }
        public string CustName { get; set; }
        public string MobileNo { get; set; }
        public string OrderDate { get; set; }
        public string ProductPrise { get; set; }
        public string AdminPrice { get; set; }
        public string Price { get; set; }
        public int WithdrawalId { get; set; }
        public int CPId { get; set; }
        public string TicNo { get; set; }
        public string Amount { get; set; }
        public string WithdrawDate { get; set; }
        public string Status { get; set; }
        public string ApproveDate { get; set; }
    }
    public class CPStorefront
    {
        public string CustName { get; set; }
        public int CPBannerId { get; set; }
        public int CPId { get; set; }
        public string BannerImage { get; set; }
        public HttpPostedFileBase[] files { get; set; }
    }
    public class CPPeopleTalks
    {
        public string CustName { get; set; }
        public int PeopleTalksId { get; set; }
        public int CPId { get; set; }
        public string PeoplesTalk { get; set; }
        public string PeopleImage { get; set; }
        public HttpPostedFileBase[] files { get; set; }
    }
    public class Reveneue
    {
        public string TotalRevenue { get; set; }
        public string TodaysRevenue { get; set; }
        public string WeekRevenue { get; set; }
        public string MonthRevenue { get; set; }
        public string YearRevenue { get; set; }
    }
    public class ProductCount
    {
        public string Domain { get; set; }
        public string gsuite { get; set; }
      
    }
    public class GHDView
    {
        public string CustomerDomainProductDnsMId { get; set; }
        public string TicketId { get; set; }
        public string TicketCat { get; set; }
        public string ProductName { get; set; }
        public string CreationDate { get; set; }
        public string ExpirationDate { get; set; }
        public string DeletionDate { get; set; }
        public string CustName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string ProductPrice { get; set; }
        public string RenewalPrice { get; set; }
        public string TransferPrice { get; set; }
        public string DomainregistrationPrice { get; set; }
        public string DNSTypeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string TTL { get; set; }
        public string Protocol { get; set; }
        public string Priority { get; set; }
        public string Weight { get; set; }
        public string Port { get; set; }
        public string Target { get; set; }
        public string ProductCode { get; set; }
        public string DomainEPPCOde { get; set; }
        public string DNS { get; set; }
        public string SACCode { get; set; }
    }
    public class MailBox
    {
        public int MailBoxId { get; set; }
        public string Message { get; set; }
        public string CustName { get; set; }
        public string Date { get; set; }
        public string UserId { get; set; }
        List<AttachFiles> AttachFile = new List<AttachFiles>();
    }
    public class AttachFiles
    {
        public int DirectorAttchId { get; set; }
        public string AttachFile { get; set; }
    }
    public class Orgchart
    {
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostedCode { get; set; }
        public string CustCategeory { get; set; }
        public string ProfilePhoto { get; set; }
    }
    public class CSR
    {
        public int CSRId { get; set; }
        public string Title { get; set; }
        public int CSRDtlId { get; set; }
        public string FileName { get; set; }
      
    }
    public class CustomerAggrements
    {
        public int CustomerAggrementId { get; set; }
        public string CustomerAggrement { get; set; }

    }
    public class CPAggrements
    {
        public int CPAggrementId { get; set; }
        public string CPAggrement { get; set; }

    }
    public class Privacys
    {
        public int PrivacyId { get; set; }
        public string Privacy { get; set; }
    }
    public class ProductAggrements
    {
        public int ProductAggrementId { get; set; }
        public string ProductAggrement { get; set; }
    }
    public class Employees
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
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(ErrorMessage = "Please enter Channel Partner Name")]
        public string chennelpartName { get; set; }
        [Required]
        public string mobileNo { get; set; }
        public string AlterMobileNo { get; set; }
        public string EmailID { get; set; }
        public string EmpRole { get; set; }
        public string CPId { get; set; }
        public string Address { get; set; }
        public int PostedCode { get; set; }

        public string State { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StatusId { get; set; }
        public string CommanyName { get; set; }
        public string AspUserId { get; set; }
        public string ParentId { get; set; }
        public string CustCategroryId { get; set; }
        public string CustId { get; set; }
        public string CPWalletAmount { get; set; }
       
        public HttpPostedFileBase ImageFile { get; set; }
    }
    public class EmpRoles
    {
        public int EmpRoleId { get; set; }
        public string EmpRole { get; set; }
    }
    public class EmpAttendance
    {
        public int AttendaceId { get; set; }
        public int CustId { get; set; }
        public string chennelpartName { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
    public class Calendera
    {
        public string Mon { get; set; }
        public string Tue { get; set; }
        public string Wed { get; set; }
        public string Thu { get; set; }
        public string Fri { get; set; }
        public string Sat { get; set; }
        public string Sun { get; set; }
    }
}
