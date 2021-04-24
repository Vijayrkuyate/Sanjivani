using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjivaniModalView
{
   public class DirectorBusinessModel
    {
        public string CustId { get; set; }
        public string RegiDate { get; set; }
        [Required(ErrorMessage = "Please enter User name.")]
        public string OwnerID { get; set; }
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
        public string AspUserId { get; set; }
        public string ParentId { get; set; }
        public string CustCategroryId { get; set; }
        public BankDetails ObjBackDetails { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
