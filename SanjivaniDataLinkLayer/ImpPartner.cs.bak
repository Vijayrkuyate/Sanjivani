using BandooDataLinkLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Data.SqlClient;
using System.Data;
using SanjivaniModalView;
using System.Web;
using System.IO;

namespace SanjivaniDataLinkLayer
{
    public class ImpPartner : InfPartner
    {
        DBConnection objcon = new DBConnection();

        public List<State> GetBindState()
        {
            SqlCommand dinsert = new SqlCommand("Sp_BindState");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<State> lis = new List<State>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    State objstate = new State();
                    objstate.StateId = int.Parse(dr["StateId"].ToString());
                    objstate.StateName = dr["State"].ToString();
                    lis.Add(objstate);
                }
            }
            return lis;
        }
        public List<CPCategory> GetBindCPCategory()
        {
            SqlCommand dinsert = new SqlCommand("Sp_BindCpCategory");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<CPCategory> list = new List<CPCategory>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    CPCategory objCPCategory = new CPCategory();
                    objCPCategory.CategoryId = int.Parse(dr["CategoryId"].ToString());
                    objCPCategory.CategoryName = dr["CategoryName"].ToString();
                    list.Add(objCPCategory);
                }
            }
            return list;
        }
        public List<CPCchannelPartnerModel> GetBindCPCustomer()
        {
            SqlCommand dinsert = new SqlCommand("Sp_ChannelPartnerCustomerList");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<CPCchannelPartnerModel> list = new List<CPCchannelPartnerModel>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    CPCchannelPartnerModel objCPCust = new CPCchannelPartnerModel();
                    objCPCust.CpCustomer = (dr["CustId"].ToString());
                    objCPCust.CpCustomerName = dr["UserId"].ToString();
                    list.Add(objCPCust);
                }
            }
            return list;
        }

        public List<CompanyType> GetBindCompanyType()
        {
            SqlCommand dinsert = new SqlCommand("Sp_CompanyType");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<CompanyType> list = new List<CompanyType>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    CompanyType objCompanyType = new CompanyType();
                    objCompanyType.Compid = int.Parse(dr["Compid"].ToString());
                    objCompanyType.CompanyName = dr["CompanyName"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;
        }
        public List<ChennelpartnerModel> GetChennelPartnerList()
        {
            SqlCommand dinsert = new SqlCommand("Sp_ChhenelPartnerList");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<ChennelpartnerModel> list = new List<ChennelpartnerModel>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    ChennelpartnerModel objChennelpartnerList = new ChennelpartnerModel();

                    objChennelpartnerList.StatusId = (dr["StatusId"].ToString());
                    objChennelpartnerList.chennelpartName = dr["CustName"].ToString();
                    objChennelpartnerList.mobileNo = dr["MobileNo"].ToString();
                    objChennelpartnerList.EmailID = dr["Email"].ToString();
                    objChennelpartnerList.CommanyName = dr["CompanyName"].ToString();
                    objChennelpartnerList.CustId = dr["CustId"].ToString();
                    objChennelpartnerList.CPId = dr["CPId"].ToString();

                    list.Add(objChennelpartnerList);
                }
            }
            return list;
        }
        public List<CPCchannelPartnerModel> GetCPCChannelPartnerList()
        {
            SqlCommand dinsert = new SqlCommand("Sp_CPCChannelPartnerList");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<CPCchannelPartnerModel> list = new List<CPCchannelPartnerModel>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    CPCchannelPartnerModel objCPCChennelpartnerList = new CPCchannelPartnerModel();
                    objCPCChennelpartnerList.CustId = Convert.ToString(dr["CustId"]);
                    objCPCChennelpartnerList.RegiDate = (dr["RegistrationDate"].ToString());
                    objCPCChennelpartnerList.UserId = dr["UserId"].ToString();
                    objCPCChennelpartnerList.mobileNo = dr["MobileNo"].ToString();
                    objCPCChennelpartnerList.EmailID = dr["Email"].ToString();
                    objCPCChennelpartnerList.Address = dr["Address"].ToString();
                    objCPCChennelpartnerList.StatusId = dr["StatusId"].ToString();
                    list.Add(objCPCChennelpartnerList);
                }
            }
            return list;
        }

        public int SaveChennelPartnerDetails(ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {

            SqlCommand dinsert = new SqlCommand("Sp_InsertPartnerDetails");
            if (model.UserName.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserName;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;
            if (!string.IsNullOrWhiteSpace(model.CustId))
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Convert.ToInt32(model.CustId);
            else
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Convert.ToInt32(0);
            dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;

            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;

            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = model.State;

            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.chennelpartName;
            dinsert.Parameters.AddWithValue("@CPCategeoryId", SqlDbType.VarChar).Value = model.CpCategory;
            dinsert.Parameters.AddWithValue("@ParentId", SqlDbType.Int).Value = model.ParentId;
            dinsert.Parameters.AddWithValue("@AspUserId", SqlDbType.NVarChar).Value = model.AspUserId;
            dinsert.Parameters.AddWithValue("@CustCategroryId", SqlDbType.Int).Value = model.CustCategroryId;
            //dinsert.Parameters.AddWithValue("@DomainAddress", SqlDbType.NVarChar).Value = model.Address;
            var Result = objcon.GetExcuteScaler(dinsert);

            if (Result != null)
            {
                SqlCommand dinsert1 = new SqlCommand("Sp_SaveBankDetails");
                dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Result;

                dinsert1.Parameters.AddWithValue("@BankName", SqlDbType.VarChar).Value = model.ObjBackDetails.BankName;

                dinsert1.Parameters.AddWithValue("@AccountNo", SqlDbType.VarChar).Value = model.ObjBackDetails.AccountNumber;

                dinsert1.Parameters.AddWithValue("@IFSCCode", SqlDbType.VarChar).Value = model.ObjBackDetails.IFSCcode;

                dinsert1.Parameters.AddWithValue("@CardName", SqlDbType.VarChar).Value = model.ObjBackDetails.PaymentBankCardName;

                dinsert1.Parameters.AddWithValue("@FourDigitCardNo", SqlDbType.VarChar).Value = model.ObjBackDetails.cardnumber;

                dinsert1.Parameters.AddWithValue("@PaymentModeId", SqlDbType.Int).Value = model.ObjBackDetails.paymentMode;

                dinsert1.Parameters.AddWithValue("@AccountTypeId", SqlDbType.Int).Value = model.ObjBackDetails.AccountType;
                var Result1 = objcon.GetExcuteScaler(dinsert1);
            }
            if (Result != null)
            {
                SqlCommand dinsert1 = new SqlCommand("Sp_SaveBusinessDetails");
                dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Result;

                dinsert1.Parameters.AddWithValue("@CompanyName", SqlDbType.VarChar).Value = model.ObjBusinessDetails.CommanyName;

                dinsert1.Parameters.AddWithValue("@CompanyType", SqlDbType.VarChar).Value = model.ObjBusinessDetails.CommanyType;

                dinsert1.Parameters.AddWithValue("@CompRegNo", SqlDbType.VarChar).Value = model.ObjBusinessDetails.RegNumber;

                dinsert1.Parameters.AddWithValue("@CompGSTNo", SqlDbType.VarChar).Value = model.ObjBusinessDetails.GSTRegNumber;

                dinsert1.Parameters.AddWithValue("@CompWebsite", SqlDbType.VarChar).Value = model.ObjBusinessDetails.webSite;

                dinsert1.Parameters.AddWithValue("@LineOfBusiness", SqlDbType.VarChar).Value = model.ObjBusinessDetails.LineofBusiness;

                dinsert1.Parameters.AddWithValue("@AnnualTurnOver", SqlDbType.Decimal).Value = model.ObjBusinessDetails.Annulturnoveer;

                dinsert1.Parameters.AddWithValue("@ContactPersonName", SqlDbType.VarChar).Value = model.ObjBusinessDetails.CommanyName;

                dinsert1.Parameters.AddWithValue("@DesignationId", SqlDbType.Int).Value = model.ObjBusinessDetails.Designation;

                dinsert1.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = model.ObjBusinessDetails.BContactnumber;

                dinsert1.Parameters.AddWithValue("@AlternatContactNo", SqlDbType.VarChar).Value = model.ObjBusinessDetails.ABContactnumber;

                dinsert1.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = model.ObjBusinessDetails.Emailid;

                dinsert1.Parameters.AddWithValue("@CurrentERP", SqlDbType.VarChar).Value = model.ObjBusinessDetails.ERP;

                dinsert1.Parameters.AddWithValue("@HostingPlatForm", SqlDbType.VarChar).Value = model.ObjBusinessDetails.HostingPlatform;

                dinsert1.Parameters.AddWithValue("@TypeOfHosting", SqlDbType.VarChar).Value = model.ObjBusinessDetails.TypeofHosting;

                dinsert1.Parameters.AddWithValue("@NoOfWebSiteHosted", SqlDbType.Int).Value = model.ObjBusinessDetails.NoOfWebSiteHos;

                dinsert1.Parameters.AddWithValue("@CurrentEmailProvider", SqlDbType.VarChar).Value = model.ObjBusinessDetails.CurrentEmailProvider;

                dinsert1.Parameters.AddWithValue("@CountOfEmail", SqlDbType.Int).Value = model.ObjBusinessDetails.CountofEmail;

                dinsert1.Parameters.AddWithValue("@CurrentDomailProvider", SqlDbType.VarChar).Value = model.ObjBusinessDetails.CurrentDomainProvide;

                dinsert1.Parameters.AddWithValue("@CountOfDomain", SqlDbType.Int).Value = model.ObjBusinessDetails.CurrentDomainCount;

                dinsert1.Parameters.AddWithValue("@CountOfSSL", SqlDbType.Int).Value = model.ObjBusinessDetails.SSLCertificateCount;

                dinsert1.Parameters.AddWithValue("@OfficeAddress", SqlDbType.VarChar).Value = model.ObjBusinessDetails.OfficeAddres;

                dinsert1.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = model.ObjBusinessDetails.Bstate;

                var Result1 = objcon.GetExcuteScaler(dinsert1);


            }
            return Result;

        }
        public List<BankName> GetBankName()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetBank");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<BankName> list = new List<BankName>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    BankName objBankName = new BankName();
                    objBankName.BankId = int.Parse(dr["BankId"].ToString());
                    objBankName.bankname = dr["BankName"].ToString();
                    list.Add(objBankName);
                }
            }
            return list;
        }
        public int SaveCPCDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            SqlCommand dinsert = new SqlCommand("Sp_SaveCPCRegistrationDetails");
            if (model.UserId.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserId;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;

            dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;

            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;

            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = model.State;

            dinsert.Parameters.AddWithValue("@CustomerName", SqlDbType.VarChar).Value = model.CustomerName;
            dinsert.Parameters.AddWithValue("@CPCategeoryId", SqlDbType.VarChar).Value = model.CpCategory;
            dinsert.Parameters.AddWithValue("@ParentId", SqlDbType.Int).Value = model.ParentId;
            dinsert.Parameters.AddWithValue("@AspUserId", SqlDbType.NVarChar).Value = model.AspUserId;
            dinsert.Parameters.AddWithValue("@CustCategroryId", SqlDbType.Int).Value = model.CustCategroryId;
            //dinsert.Parameters.AddWithValue("@DomainAddress", SqlDbType.NVarChar).Value = model.Address;
            var Result = objcon.GetExcuteScaler(dinsert);
            if (Result != null)
            {
                SqlCommand dinsert1 = new SqlCommand("Sp_SaveBankDetails");
                dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Result;

                dinsert1.Parameters.AddWithValue("@BankName", SqlDbType.VarChar).Value = model.ObjBackDetails.BankName;

                dinsert1.Parameters.AddWithValue("@AccountNo", SqlDbType.VarChar).Value = model.ObjBackDetails.AccountNumber;

                dinsert1.Parameters.AddWithValue("@IFSCCode", SqlDbType.VarChar).Value = model.ObjBackDetails.IFSCcode;

                dinsert1.Parameters.AddWithValue("@CardName", SqlDbType.VarChar).Value = model.ObjBackDetails.PaymentBankCardName;

                dinsert1.Parameters.AddWithValue("@FourDigitCardNo", SqlDbType.VarChar).Value = model.ObjBackDetails.cardnumber;

                dinsert1.Parameters.AddWithValue("@PaymentModeId", SqlDbType.Int).Value = model.ObjBackDetails.paymentMode;

                dinsert1.Parameters.AddWithValue("@AccountTypeId", SqlDbType.Int).Value = model.ObjBackDetails.AccountType;
                var Result1 = objcon.GetExcuteScaler(dinsert1);
            }
            return Result;
        }

        public int SaveDirectorBusinessDetails(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            SqlCommand dinsert = new SqlCommand("Sp_InsertDirectorDetails");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = model.CustId;
            if (model.UserId.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserId;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;

            dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;

            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;
            dinsert.Parameters.AddWithValue("@Country", SqlDbType.VarChar).Value = model.Country;
            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = model.State;
            dinsert.Parameters.AddWithValue("@City", SqlDbType.VarChar).Value = model.City;
            dinsert.Parameters.AddWithValue("@PostedCode", SqlDbType.Int).Value = model.PostedCode;
            
            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.OwnerName;
            dinsert.Parameters.AddWithValue("@ParentId", SqlDbType.Int).Value = model.ParentId;
            dinsert.Parameters.AddWithValue("@AspUserId", SqlDbType.NVarChar).Value = model.AspUserId;
            dinsert.Parameters.AddWithValue("@CustCategroryId", SqlDbType.Int).Value = model.CustCategroryId;
            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;
        }
        public ChennelpartnerModel getChannalPartnerDtl(int custId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartner");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            ChennelpartnerModel list = new ChennelpartnerModel();

            if (dtList.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Tables[0].Rows)
                {


                    list.RegiDate = (dr["RegistrationDate"].ToString());
                    list.CPId = dr["CPId"].ToString();
                    list.CpCategory = dr["CPCategeoryId"].ToString();
                    list.UserName = dr["UserId"].ToString();
                    list.pwd = dr["Password"].ToString();
                    list.Cpwd = dr["Password"].ToString();
                    list.CustId = dr["CustId"].ToString();
                    list.chennelpartName = dr["CustName"].ToString();
                    list.mobileNo = dr["MobileNo"].ToString();
                    list.AlterMobileNo = dr["AlternateMobileNo"].ToString();
                    list.EmailID = dr["Email"].ToString();
                    list.Address = dr["Address"].ToString();
                    list.State = dr["StateId"].ToString();
                    // list.Address = dr["ParentId"].ToString();
                    // list.CustCategroryId = dr["CustomerType"].ToString();
                    list.CustCategroryId = dr["CustCategroryId"].ToString();
                    // objCPCChennelpartnerList.Address = dr["CustCategroryId"].ToString();

                }
                foreach (DataRow dr in dtList.Tables[1].Rows)
                {

                    BankDetails list1 = new BankDetails();
                    list1.BankName = (dr["BankName"].ToString());
                    list1.AccountNumber = dr["AccountNo"].ToString();
                    list1.IFSCcode = dr["IFSCCode"].ToString();
                    list1.PaymentBankCardName = dr["CardName"].ToString();
                    list1.cardnumber = dr["FourDigitCardNo"].ToString();
                    list1.paymentMode = dr["PaymentModeId"].ToString();
                    list1.AccountType = dr["AccountTypeId"].ToString();
                    list.ObjBackDetails = list1;
                    // objCPCChennelpartnerList.Address = dr["CustCategroryId"].ToString();

                }
                foreach (DataRow dr in dtList.Tables[2].Rows)
                {

                    BusinessDetails list1 = new BusinessDetails();
                    list1.CommanyName = (dr["CompanyName"].ToString());
                    list1.CommanyType = dr["CompanyType"].ToString();
                    list1.RegNumber = dr["CompRegNo"].ToString();
                    list1.GSTRegNumber = dr["CompGSTNo"].ToString();
                    list1.webSite = dr["CompWebsite"].ToString();
                    list1.LineofBusiness = dr["LineOfBusiness"].ToString();
                    list1.Annulturnoveer = dr["AnnualTurnOver"].ToString();
                    list1.personalName = dr["ContactPersonName"].ToString();
                    list1.Designation = dr["DesignationId"].ToString();
                    list1.BContactnumber = dr["ContactNo"].ToString();
                    list1.ABContactnumber = dr["AlternatContactNo"].ToString();
                    list1.Emailid = dr["EmailId"].ToString();
                    list1.ERP = dr["CurrentERP"].ToString();
                    list1.HostingPlatform = dr["HostingPlatForm"].ToString();
                    list1.TypeofHosting = dr["TypeOfHosting"].ToString();
                    list1.NoOfWebSiteHos = dr["NoOfWebSiteHosted"].ToString();
                    list1.CurrentEmailProvider = dr["CurrentEmailProvider"].ToString();
                    list1.CountofEmail = dr["CountOfEmail"].ToString();
                    list1.CurrentEmailProvider = dr["CurrentDomailProvider"].ToString();
                    list1.CurrentDomainCount = dr["CountOfDomain"].ToString();
                    list1.SSLCertificateCount = dr["CountOfSSL"].ToString();
                    list1.OfficeAddres = dr["OfficeAddress"].ToString();
                    list1.Bstate = dr["StateId"].ToString();
                    list.ObjBusinessDetails = list1;

                }
            }
            return list;
        }
        public bool rejectChannalPartner(int custId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_RejectChannelPartner");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;

            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public DataSet getFolder()
        {
            DataSet ds = new DataSet();
            SqlCommand dinsert = new SqlCommand("usp_getFolderAndFile");
            ds = objcon.GetDsByCommand(dinsert);
            return ds;
        }
        public List<UserIntraction> getUserIntraction(int custId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetUserintraction");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<UserIntraction> list = new List<UserIntraction>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    UserIntraction objCompanyType = new UserIntraction();
                    objCompanyType.IntractionId = Convert.ToInt32(dr["IntractionId"]);
                    objCompanyType.Intraction = (dr["Intraction"].ToString());
                    objCompanyType.Date = (dr["CreateDate"].ToString());
                    // objCompanyType.AccountType = dr["AccountType"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;
        }

     
        public bool SetUserIntarction(UserIntraction usD)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetUserIntarction");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = usD.CustID;
            dinsert1.Parameters.AddWithValue("@Intraction", SqlDbType.VarChar).Value = usD.Intraction;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public DataTable getLoginDetail(string id)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetLoginDetail");
            dinsert.Parameters.AddWithValue("@UserId", SqlDbType.NVarChar).Value = id;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            return dtList;
        }
        public int UpdateCPCRegisterDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            SqlCommand dinsert = new SqlCommand("Sp_InsertPartnerDetails");
            if (model.CustId.ToString() != "")
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = model.CustId;
            if (model.UserId.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserId;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;

            dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;
            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;
            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.VarChar).Value = model.State;
            dinsert.Parameters.AddWithValue("@Country", SqlDbType.VarChar).Value = model.Country;
            dinsert.Parameters.AddWithValue("@City", SqlDbType.VarChar).Value = model.City;

            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.CustomerName;
            dinsert.Parameters.AddWithValue("@CPCategeoryId", SqlDbType.VarChar).Value = model.CpCategory;
            dinsert.Parameters.AddWithValue("@ParentId", SqlDbType.Int).Value = model.ParentId;
            dinsert.Parameters.AddWithValue("@AspUserId", SqlDbType.NVarChar).Value = model.AspUserId;
            dinsert.Parameters.AddWithValue("@CustCategroryId", SqlDbType.Int).Value = model.CustCategroryId;
            dinsert.Parameters.AddWithValue("@Postedcode", SqlDbType.VarChar).Value = model.PostedCode;
            //dinsert.Parameters.AddWithValue("@DomainAddress", SqlDbType.NVarChar).Value = model.Address;
            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;
        }

        public int SaveUploadChennelPartnerDocument(string fileName, int CustID, int type)
        {
            SqlCommand dinsert1 = new SqlCommand("Sp_uploadUserDocuments");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            dinsert1.Parameters.AddWithValue("@fileName", SqlDbType.VarChar).Value = fileName;
            dinsert1.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = type;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;
        }
        public int SaveUploadCPCDocument(string fileName, int CustID, int type)
        {
            SqlCommand dinsert1 = new SqlCommand("Sp_uploadCPCUserDocuments");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            dinsert1.Parameters.AddWithValue("@fileName", SqlDbType.VarChar).Value = fileName;
            dinsert1.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = type;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;
        }
        public int SaveUploadDirectorDoc(string fileName, int CustID, int type)
        {
            SqlCommand dinsert1 = new SqlCommand("Sp_uploadCPCUserDocuments");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            dinsert1.Parameters.AddWithValue("@fileName", SqlDbType.VarChar).Value = fileName;
            dinsert1.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = type;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;
        }

        public CPCchannelPartnerModel GetCPCChannelList(string CustID)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartner");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            CPCchannelPartnerModel List = new CPCchannelPartnerModel();
            if (DsList.Tables[0].Rows.Count>0)
            {

                List.CustId = Convert.ToString(DsList.Tables[0].Rows[0]["CustId"]);
                List.RegiDate = (DsList.Tables[0].Rows[0]["RegistrationDate"].ToString());
                List.UserId = DsList.Tables[0].Rows[0]["UserId"].ToString();
                List.mobileNo = DsList.Tables[0].Rows[0]["MobileNo"].ToString();
                List.EmailID = DsList.Tables[0].Rows[0]["Email"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.pwd = DsList.Tables[0].Rows[0]["Password"].ToString();
                List.Cpwd = DsList.Tables[0].Rows[0]["Password"].ToString();
                List.CustomerName = DsList.Tables[0].Rows[0]["CustName"].ToString();
                List.AlterMobileNo = DsList.Tables[0].Rows[0]["AlternateMobileNo"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.CustCategroryId = DsList.Tables[0].Rows[0]["CustCategroryId"].ToString();
                List.CpCategory = Convert.ToString(DsList.Tables[0].Rows[0]["CPCategeoryId"]);
                List.CpCustomer = Convert.ToString(DsList.Tables[0].Rows[0]["ParentId"]);
                List.State = Convert.ToString(DsList.Tables[0].Rows[0]["StateId"]);
                List.PostedCode = Convert.ToString(DsList.Tables[0].Rows[0]["PostedCode"]);
                List.ObjBackDetails = getBankDetailsdata(CustID);
            }
            return List;
        }

        public DirectorBusinessModel GetDirectorChannelEdit(string CustID)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartner");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            DirectorBusinessModel List = new DirectorBusinessModel();
            if (DsList.Tables[0].Rows[0] != null)
            {

                List.CustId = Convert.ToString(DsList.Tables[0].Rows[0]["CustId"]);
                List.RegiDate = (DsList.Tables[0].Rows[0]["RegistrationDate"].ToString());
                List.UserId = DsList.Tables[0].Rows[0]["UserId"].ToString();
                List.mobileNo = DsList.Tables[0].Rows[0]["MobileNo"].ToString();
                List.EmailID = DsList.Tables[0].Rows[0]["Email"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.pwd = DsList.Tables[0].Rows[0]["Password"].ToString();
                List.Cpwd = DsList.Tables[0].Rows[0]["Password"].ToString();
                List.OwnerName = DsList.Tables[0].Rows[0]["CustName"].ToString();
                List.AlterMobileNo = DsList.Tables[0].Rows[0]["AlternateMobileNo"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.CustCategroryId = DsList.Tables[0].Rows[0]["CustCategroryId"].ToString();
                List.State = Convert.ToString(DsList.Tables[0].Rows[0]["StateId"]);
                List.PostedCode= Convert.ToInt32(DsList.Tables[0].Rows[0]["PostedCode"]);
                List.Country= Convert.ToString(DsList.Tables[0].Rows[0]["Country"]);
                List.City = Convert.ToString(DsList.Tables[0].Rows[0]["City"]);
                List.ObjBackDetails = getBankDetailsdata(CustID);
            }
            return List;
        }


        public List<DirectorBusinessModel> GetDirectorBusinessOwnerList()
        {

            SqlCommand dinsert = new SqlCommand("Sp_DirectorBusinessOwnerList");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<DirectorBusinessModel> List = new List<DirectorBusinessModel>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    DirectorBusinessModel objDirectorBusinessList = new DirectorBusinessModel();
                    objDirectorBusinessList.CustId = Convert.ToString(dr["CustId"]);
                    objDirectorBusinessList.RegiDate = (dr["RegistrationDate"].ToString());
                    objDirectorBusinessList.UserId = dr["UserId"].ToString();
                    objDirectorBusinessList.mobileNo = dr["MobileNo"].ToString();
                    objDirectorBusinessList.EmailID = dr["Email"].ToString();
                    objDirectorBusinessList.Address = dr["Address"].ToString();
                    objDirectorBusinessList.StatusId = Convert.ToString(dr["StatusId"]);
                    List.Add(objDirectorBusinessList);
                }
            }
            return List;
        }


        public BankDetails getBankDetailsdata(string CustID)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartner");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            BankDetails ObjBackDetails = new BankDetails();
            if (DsList.Tables[1].Rows.Count != 0)
            {
               
                ObjBackDetails.BankName1 = Convert.ToInt32(DsList.Tables[1].Rows[0]["BankName"]);

                ObjBackDetails.BankName = DsList.Tables[1].Rows[0]["BankName"].ToString();
                ObjBackDetails.AccountNumber = Convert.ToString(DsList.Tables[1].Rows[0]["AccountNo"]);
                ObjBackDetails.IFSCcode = Convert.ToString(DsList.Tables[1].Rows[0]["IFSCCode"]);
                ObjBackDetails.PaymentBankCardName = Convert.ToString(DsList.Tables[1].Rows[0]["CardName"]);
                ObjBackDetails.cardnumber = Convert.ToString(DsList.Tables[1].Rows[0]["FourDigitCardNo"]);
                ObjBackDetails.paymentMode = Convert.ToString(DsList.Tables[1].Rows[0]["PaymentModeId"]);
                ObjBackDetails.AccountType = Convert.ToString(DsList.Tables[1].Rows[0]["AccountTypeId"]);
                ObjBackDetails.AccountHolderName = Convert.ToString(DsList.Tables[1].Rows[0]["AccountHolderName"]);
                ObjBackDetails.PaymentBankCardName = Convert.ToString(DsList.Tables[1].Rows[0]["PaymentBankCardName"]);
            }
            return ObjBackDetails;
        }

        public List<Account> getAccountType()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetAccountype");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<Account> list = new List<Account>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    Account objCompanyType = new Account();
                    objCompanyType.AccountTypeId = int.Parse(dr["AccountTypeId"].ToString());
                    objCompanyType.AccountType = dr["AccountType"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;
        }
        public List<PaymentType> getPaymentmode()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetPaymentMode");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<PaymentType> list = new List<PaymentType>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    PaymentType objCompanyType = new PaymentType();
                    objCompanyType.PaymentModeId = int.Parse(dr["PaymentModeId"].ToString());
                    objCompanyType.PaymentMode = dr["PaymentMode"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;
        }
        public List<HostingPlatF> getHostingPlatform()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetHostingPlatform");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<HostingPlatF> list = new List<HostingPlatF>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    HostingPlatF objCompanyType = new HostingPlatF();
                    objCompanyType.HostingPlatformId = int.Parse(dr["HostingPlatformId"].ToString());
                    objCompanyType.HostingPlatForm = dr["HostingPlatForm"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;
        }
        public List<TypeOfHosting> getTypeofHosting()
        {
            SqlCommand dinsert = new SqlCommand("usp_TypeOfHosting");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<TypeOfHosting> list = new List<TypeOfHosting>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    TypeOfHosting objCompanyType = new TypeOfHosting();
                    objCompanyType.TypeHostingId = int.Parse(dr["TypeHostingId"].ToString());
                    objCompanyType.TypeofHosting = dr["TypeofHosting"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;
        }
        public int UpdateDirectorBusinessRegister(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            SqlCommand dinsert = new SqlCommand("Sp_InsertDirectorDetails");
            if (model.CustId.ToString() != "")
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = model.CustId;
            if (model.UserId.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserId;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;

            dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;
            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;
            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.VarChar).Value = model.State;
            dinsert.Parameters.AddWithValue("@Country", SqlDbType.VarChar).Value = model.Country;
            dinsert.Parameters.AddWithValue("@City", SqlDbType.VarChar).Value = model.City;

            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.OwnerName;
            dinsert.Parameters.AddWithValue("@ParentId", SqlDbType.Int).Value = model.ParentId;
            dinsert.Parameters.AddWithValue("@AspUserId", SqlDbType.NVarChar).Value = model.AspUserId;
            dinsert.Parameters.AddWithValue("@CustCategroryId", SqlDbType.Int).Value = model.CustCategroryId;
            dinsert.Parameters.AddWithValue("@PostedCode", SqlDbType.NVarChar).Value = model.PostedCode;
            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;
        }

        public DirectorBusinessModel GetDirectorBusinessOwners(string CustId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartner");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustId;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            DirectorBusinessModel List = new DirectorBusinessModel();
            if (DsList.Tables[0].Rows[0] != null)
            {

                List.CustId = Convert.ToString(DsList.Tables[0].Rows[0]["CustId"]);
                List.RegiDate = (DsList.Tables[0].Rows[0]["RegistrationDate"].ToString());
                List.UserId = DsList.Tables[0].Rows[0]["UserId"].ToString();
                List.mobileNo = DsList.Tables[0].Rows[0]["MobileNo"].ToString();
                List.EmailID = DsList.Tables[0].Rows[0]["Email"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.pwd = DsList.Tables[0].Rows[0]["Password"].ToString();
                List.OwnerName = DsList.Tables[0].Rows[0]["CustName"].ToString();
                List.AlterMobileNo = DsList.Tables[0].Rows[0]["AlternateMobileNo"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.CustCategroryId = DsList.Tables[0].Rows[0]["CustCategroryId"].ToString();
                List.State = Convert.ToString(DsList.Tables[0].Rows[0]["StateId"]);
                List.ObjBackDetails = getBankDetailsdata(CustId);
            }
            return List;
        }
        public int _PartialCPSave(ChennelpartnerModel model)
        {
            SqlCommand dinsert = new SqlCommand("Sp_InsertPartnerDetails");
            if (model.UserName.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserName;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;
            if (!string.IsNullOrWhiteSpace(model.CustId))
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Convert.ToInt32(model.CustId);
            else
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Convert.ToInt32(0);
            if (!string.IsNullOrWhiteSpace(model.AlterMobileNo))
                dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;

            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;
            dinsert.Parameters.AddWithValue("@PostedCode", SqlDbType.Int).Value = model.PostedCode;

            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.VarChar).Value = model.State;
            dinsert.Parameters.AddWithValue("@City", SqlDbType.VarChar).Value = model.City;
            dinsert.Parameters.AddWithValue("@Country", SqlDbType.VarChar).Value = model.Country;
            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.chennelpartName;
            dinsert.Parameters.AddWithValue("@CPCategeoryId", SqlDbType.VarChar).Value = model.CpCategory;
            dinsert.Parameters.AddWithValue("@ParentId", SqlDbType.Int).Value = model.ParentId;
            dinsert.Parameters.AddWithValue("@AspUserId", SqlDbType.NVarChar).Value = model.AspUserId;
            dinsert.Parameters.AddWithValue("@CustCategroryId", SqlDbType.Int).Value = model.CustCategroryId;
            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;
        }
        public int _SaveCPCPartialView(CPCchannelPartnerModel model)
        {
            SqlCommand dinsert = new SqlCommand("Sp_InsertPartnerDetails");
            if (model.UserId.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserId;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;
            if (!string.IsNullOrWhiteSpace(model.CustId))
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Convert.ToInt32(model.CustId);
            else
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Convert.ToInt32(0);
            if (!string.IsNullOrWhiteSpace(model.AlterMobileNo))
                dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;

            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;

            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.VarChar).Value = model.State;
            dinsert.Parameters.AddWithValue("@City", SqlDbType.VarChar).Value = model.City;
            dinsert.Parameters.AddWithValue("@Country", SqlDbType.VarChar).Value = model.Country;
            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.CpCustomerName;
            dinsert.Parameters.AddWithValue("@CPCategeoryId", SqlDbType.VarChar).Value = model.CpCategory;
            dinsert.Parameters.AddWithValue("@ParentId", SqlDbType.Int).Value = model.ParentId;
            dinsert.Parameters.AddWithValue("@AspUserId", SqlDbType.NVarChar).Value = model.AspUserId;
            dinsert.Parameters.AddWithValue("@CustCategroryId", SqlDbType.Int).Value = model.CustCategroryId;
            dinsert.Parameters.AddWithValue("@PostedCode", SqlDbType.VarChar).Value = model.PostedCode;

            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;
        }


        public bool setCPBusinessDtl(BusinessDetails bD)
        {
            SqlCommand dinsert1 = new SqlCommand("Sp_SaveBusinessDetails");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = bD.CustId;

            dinsert1.Parameters.AddWithValue("@CompanyName", SqlDbType.VarChar).Value = bD.CommanyName;

            dinsert1.Parameters.AddWithValue("@CompanyType", SqlDbType.VarChar).Value = bD.CommanyType;

            dinsert1.Parameters.AddWithValue("@CompRegNo", SqlDbType.VarChar).Value = bD.RegNumber;

            dinsert1.Parameters.AddWithValue("@CompGSTNo", SqlDbType.VarChar).Value = bD.GSTRegNumber;

            dinsert1.Parameters.AddWithValue("@CompWebsite", SqlDbType.VarChar).Value = bD.webSite;

            dinsert1.Parameters.AddWithValue("@LineOfBusiness", SqlDbType.VarChar).Value = bD.LineofBusiness;

            dinsert1.Parameters.AddWithValue("@AnnualTurnOver", SqlDbType.Decimal).Value = bD.Annulturnoveer;

            dinsert1.Parameters.AddWithValue("@ContactPersonName", SqlDbType.VarChar).Value = bD.CommanyName;

            dinsert1.Parameters.AddWithValue("@DesignationId", SqlDbType.Int).Value = bD.Designation;

            dinsert1.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = bD.BContactnumber;

            dinsert1.Parameters.AddWithValue("@AlternatContactNo", SqlDbType.VarChar).Value = bD.ABContactnumber;

            dinsert1.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = bD.Emailid;

            dinsert1.Parameters.AddWithValue("@CurrentERP", SqlDbType.VarChar).Value = bD.ERP;

            dinsert1.Parameters.AddWithValue("@HostingPlatForm", SqlDbType.VarChar).Value = bD.HostingPlatform;

            dinsert1.Parameters.AddWithValue("@TypeOfHosting", SqlDbType.VarChar).Value = bD.TypeofHosting;

            dinsert1.Parameters.AddWithValue("@NoOfWebSiteHosted", SqlDbType.Int).Value = bD.NoOfWebSiteHos;

            dinsert1.Parameters.AddWithValue("@CurrentEmailProvider", SqlDbType.VarChar).Value = bD.CurrentEmailProvider;

            dinsert1.Parameters.AddWithValue("@CountOfEmail", SqlDbType.Int).Value = bD.CountofEmail;

            dinsert1.Parameters.AddWithValue("@CurrentDomailProvider", SqlDbType.VarChar).Value = bD.CurrentDomainProvide;

            dinsert1.Parameters.AddWithValue("@CountOfDomain", SqlDbType.Int).Value = bD.CurrentDomainCount;

            dinsert1.Parameters.AddWithValue("@CountOfSSL", SqlDbType.Int).Value = bD.SSLCertificateCount;

            dinsert1.Parameters.AddWithValue("@OfficeAddress", SqlDbType.VarChar).Value = bD.OfficeAddres;
            dinsert1.Parameters.AddWithValue("@PostedCode", SqlDbType.VarChar).Value = bD.PostedCode1;

            dinsert1.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = bD.Bstate;

            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            // Session["Tab"] = "2";
            return Result1;
        }
        public bool SetCPBankDtl(BankDetails bd)
        {
            SqlCommand dinsert1 = new SqlCommand("Sp_SaveBankDetails");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = bd.CustId;

            dinsert1.Parameters.AddWithValue("@BankName", SqlDbType.VarChar).Value = bd.BankName;

            dinsert1.Parameters.AddWithValue("@AccountNo", SqlDbType.VarChar).Value = bd.AccountNumber;

            dinsert1.Parameters.AddWithValue("@IFSCCode", SqlDbType.VarChar).Value = bd.IFSCcode;
            if (bd.paymentMode == null)
                dinsert1.Parameters.AddWithValue("@PaymentModeId", SqlDbType.Int).Value = 0;
            else
                dinsert1.Parameters.AddWithValue("@PaymentModeId", SqlDbType.Int).Value = bd.paymentMode;
            dinsert1.Parameters.AddWithValue("@FourDigitCardNo", SqlDbType.Int).Value = bd.cardnumber;
            dinsert1.Parameters.AddWithValue("@PaymentBankCardName", SqlDbType.VarChar).Value = bd.PaymentBankCardName;
            dinsert1.Parameters.AddWithValue("@AccountHolderName", SqlDbType.VarChar).Value = bd.AccountHolderName;
            dinsert1.Parameters.AddWithValue("@AccountTypeId", SqlDbType.VarChar).Value = bd.AccountType;
            
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }

        public bool SetCPCBankDtl(BankDetails bd)
        {
            SqlCommand dinsert1 = new SqlCommand("Sp_SaveBankDetails");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = bd.CustId;

            dinsert1.Parameters.AddWithValue("@BankName", SqlDbType.VarChar).Value = bd.BankName1;

            dinsert1.Parameters.AddWithValue("@AccountNo", SqlDbType.VarChar).Value = bd.AccountNumber;

            dinsert1.Parameters.AddWithValue("@IFSCCode", SqlDbType.VarChar).Value = bd.IFSCcode;

            dinsert1.Parameters.AddWithValue("@PaymentModeId", SqlDbType.Int).Value = bd.paymentMode;

            dinsert1.Parameters.AddWithValue("@AccountTypeId", SqlDbType.Int).Value = bd.AccountType;
            dinsert1.Parameters.AddWithValue("@AccountHolderName", SqlDbType.VarChar).Value = bd.AccountHolderName;
            dinsert1.Parameters.AddWithValue("@PaymentBankCardName", SqlDbType.VarChar).Value = bd.PaymentBankCardName;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public bool SetDirectorBankDtl(BankDetails bd)
        {
            SqlCommand dinsert1 = new SqlCommand("Sp_SaveBankDetails");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = bd.CustId;

            dinsert1.Parameters.AddWithValue("@BankName", SqlDbType.VarChar).Value = bd.BankName1;

            dinsert1.Parameters.AddWithValue("@AccountNo", SqlDbType.VarChar).Value = bd.AccountNumber;

            dinsert1.Parameters.AddWithValue("@IFSCCode", SqlDbType.VarChar).Value = bd.IFSCcode;

            dinsert1.Parameters.AddWithValue("@PaymentModeId", SqlDbType.Int).Value = bd.paymentMode;

            dinsert1.Parameters.AddWithValue("@AccountTypeId", SqlDbType.Int).Value = bd.AccountType;
            dinsert1.Parameters.AddWithValue("@AccountHolderName", SqlDbType.VarChar).Value = bd.AccountHolderName;
            dinsert1.Parameters.AddWithValue("@FourDigitCardNo", SqlDbType.VarChar).Value = bd.cardnumber;
            dinsert1.Parameters.AddWithValue("@PaymentBankCardName", SqlDbType.VarChar).Value = bd.PaymentBankCardName;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        
        public DataTable checkUserIdExists(string userId)
        {
            SqlCommand dinsert = new SqlCommand("usp_CheckUserIDExists");
            dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = userId;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            return dtList;
        }
        public DataTable checkEmailExists(string email)
        {
            SqlCommand dinsert = new SqlCommand("usp_CheckEmailExists");
            dinsert.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = email;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            return dtList;
        }
        public List<Bank> getBank()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetBank");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<Bank> list = new List<Bank>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    Bank objCompanyType = new Bank();
                    objCompanyType.BankId = int.Parse(dr["BankId"].ToString());
                    objCompanyType.BankName = dr["BankName"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;

        }
        public ChennelpartnerModel getCPForEdit(int custid)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPPersonalDtlEdit");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custid;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            ChennelpartnerModel list = new ChennelpartnerModel();

            if (dtList.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Tables[0].Rows)
                {


                    list.RegiDate = (dr["RegistrationDate"].ToString());
                    list.CPId = dr["CPId"].ToString();
                    list.CpCategory = dr["CPCategeoryId"].ToString();
                    list.UserName = dr["UserId"].ToString();
                    list.pwd = dr["Password"].ToString();
                    list.Cpwd = dr["Password"].ToString();
                    list.CustId = dr["CustId"].ToString();
                    list.chennelpartName = dr["CustName"].ToString();
                    list.mobileNo = dr["MobileNo"].ToString();
                    list.AlterMobileNo = dr["AlternateMobileNo"].ToString();
                    list.EmailID = dr["Email"].ToString();
                    list.Address = dr["Address"].ToString();
                    list.State = dr["StateId"].ToString();
                    // list.Address = dr["ParentId"].ToString();
                    // list.CustCategroryId = dr["CustomerType"].ToString();
                    list.CustCategroryId = dr["CustCategroryId"].ToString();
                    list.PostedCode = Convert.ToInt32(dr["PostedCode"]);
                    // objCPCChennelpartnerList.Address = dr["CustCategroryId"].ToString();

                }
            }
            return list;
        }
        public BusinessDetails _partialgetCPBusinessDtl(string custId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartnerBusinessDtlForEdit");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            BusinessDetails list1 = new BusinessDetails();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {


                list1.CommanyName = (dr["CompanyName"].ToString());
                list1.CommanyType = dr["CompanyType"].ToString();
                list1.RegNumber = dr["CompRegNo"].ToString();
                list1.GSTRegNumber = dr["CompGSTNo"].ToString();
                list1.webSite = dr["CompWebsite"].ToString();
                list1.LineofBusiness = dr["LineOfBusiness"].ToString();
                list1.Annulturnoveer = dr["AnnualTurnOver"].ToString();
                list1.personalName = dr["ContactPersonName"].ToString();
                list1.Designation = dr["DesignationId"].ToString();
                list1.BContactnumber = dr["ContactNo"].ToString();
                list1.ABContactnumber = dr["AlternatContactNo"].ToString();
                list1.Emailid = dr["EmailId"].ToString();
                list1.ERP = dr["CurrentERP"].ToString();
                list1.HostingPlatform1 = Convert.ToInt32(dr["HostingPlatForm"].ToString());
                list1.TypeofHosting1 = Convert.ToInt32(dr["TypeOfHosting"].ToString());
                list1.NoOfWebSiteHos = dr["NoOfWebSiteHosted"].ToString();
                list1.CurrentEmailProvider = dr["CurrentEmailProvider"].ToString();
                list1.CountofEmail = dr["CountOfEmail"].ToString();
                list1.CurrentDomainProvide = dr["CurrentDomailProvider"].ToString();
                list1.CurrentDomainCount = dr["CountOfDomain"].ToString();
                list1.SSLCertificateCount = dr["CountOfSSL"].ToString();
                list1.OfficeAddres = dr["OfficeAddress"].ToString();
                list1.Bstate = dr["StateId"].ToString();
                list1.Country = Convert.ToString(dr["Country"]);
                list1.City = Convert.ToString(dr["City"]);
                list1.State = Convert.ToString(dr["State"]);
                list1.PostedCode1 = Convert.ToString(dr["postedcode"]);
            }
            return list1;
        }
        public CountryState getCountryStateForCPPersonal(int custId)
        {
            SqlCommand dinsert = new SqlCommand("usp_getcountryStateCPPersonalDtl");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            CountryState list = new CountryState();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {

                    list.StateId = (dr["StateId"].ToString());
                    list.Country = dr["Country"].ToString();
                    list.City = dr["City"].ToString();

                }
            }
            return list;
        }
        public BankDetails _partialgetCPBankDtl(string custId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartnerBankDtl");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            BankDetails list1 = new BankDetails();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                // BankDetails list1 = new BankDetails();
                list1.BankName1 = Convert.ToInt32(dr["BankName"].ToString());
                list1.AccountNumber = dr["AccountNo"].ToString();
                list1.IFSCcode = dr["IFSCCode"].ToString();
                list1.PaymentBankCardName = dr["CardName"].ToString();
                list1.cardnumber = dr["FourDigitCardNo"].ToString();
                list1.paymentMode = dr["PaymentModeId"].ToString();
                list1.AccountType = dr["AccountTypeId"].ToString();
                list1.AccountHolderName = dr["AccountHolderName"].ToString();
                list1.PaymentBankCardName = dr["PaymentBankCardName"].ToString();
                //list.ObjBackDetails = list1;
                // objCPCChennelpartnerList.Address = dr["CustCategroryId"].ToString();

            }
            return list1;
        }
        public bool deleteCp(int custId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_DeleteCP");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public bool DeleteUserIntraction(int IntractionId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_GetUserintractionDelete");
            dinsert1.Parameters.AddWithValue("@IntractionId", SqlDbType.Int).Value = IntractionId;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<Documents1> GetCPDocument(int custId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetUserDocument");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Documents1> list = new List<Documents1>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                Documents1 list1 = new Documents1();
               
                list1.Description = dr["Description"].ToString();
                list1.Document = dr["Document"].ToString();
                list.Add(list1);

            }
            return list;
        }
        public List<Documents1> getDirectorDocument(int custId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetUserDocument");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Documents1> list = new List<Documents1>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Documents1 list1 = new Documents1();
                list1.Description = dr["Description"].ToString();
                list1.Document = dr["Document"].ToString();
                list.Add(list1);
            }
            return list;
        }

        
        public bool approveCP(int custId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetApproveCP");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public Dashboard getDirectorDashboard()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetDirectorDashboard");
            
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            Dashboard list1 = new Dashboard();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                // BankDetails list1 = new BankDetails();
                list1.CP = (dr["CP"].ToString());
                list1.CPC = dr["CPC"].ToString();
                list1.Customer = dr["Customer"].ToString();
                list1.Director = dr["Director"].ToString();
                list1.Freelancer = dr["Freelancer"].ToString();
                list1.Affilate = dr["Affilate"].ToString();
            

            }
            return list1;
        }

        public List<GHDs> GetGHDList()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetGHD");
           
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<GHDs> list = new List<GHDs>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                GHDs list1 = new GHDs();

                list1.GHDId = dr["GHDId"].ToString();
                list1.GHD = dr["GHD"].ToString();
                list1.Link = dr["Link"].ToString();
                list.Add(list1);

            }
            return list;

        }
        public bool SetGHD(GHDs gHD)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetGHD");
            dinsert1.Parameters.AddWithValue("@GHDId", SqlDbType.Int).Value = 0;
            dinsert1.Parameters.AddWithValue("@GHD", SqlDbType.VarChar).Value = gHD.GHD;
            dinsert1.Parameters.AddWithValue("@Link", SqlDbType.NVarChar).Value = gHD.Link;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<OrgChart> GetcpOrg()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPOrgChart");

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<OrgChart> list = new List<OrgChart>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                OrgChart list1 = new OrgChart();

                list1.Name = dr["CustName"].ToString();
                list1.ProfilePic = dr["ProfilePic"].ToString();
               
                list.Add(list1);

            }
            return list;
        }
        public List<OrgChart> GetcpcOrg()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPCOrgChart");

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<OrgChart> list = new List<OrgChart>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                OrgChart list1 = new OrgChart();

                list1.Name = dr["CustName"].ToString();
                list1.ProfilePic = dr["ProfilePic"].ToString();

                list.Add(list1);

            }
            return list;
        }
        public List<OrgChart> GetCustomerOrg()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCustomerOrgChart");

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<OrgChart> list = new List<OrgChart>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                OrgChart list1 = new OrgChart();

                list1.Name = dr["CustName"].ToString();
                list1.ProfilePic = dr["ProfilePic"].ToString();

                list.Add(list1);

            }
            return list;
        }
        public List<OrgChart> GetDirectorOrg()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetDirectorOrgChart");

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<OrgChart> list = new List<OrgChart>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                OrgChart list1 = new OrgChart();

                list1.Name = dr["CustName"].ToString();
                list1.ProfilePic = dr["ProfilePic"].ToString();

                list.Add(list1);

            }
            return list;
        }

        public List<OrgChart> GetAffilatorOrg()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetAffilatorOrgChart");

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<OrgChart> list = new List<OrgChart>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                OrgChart list1 = new OrgChart();

                list1.Name = dr["CustName"].ToString();
                list1.ProfilePic = dr["ProfilePic"].ToString();

                list.Add(list1);

            }
            return list;
        }
        public bool deleteGHD(int GHDId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_DeleteGHD");
            dinsert1.Parameters.AddWithValue("@GHDId", SqlDbType.Int).Value = GHDId;

            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public bool DeleteVOC(int VocDtlId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_DeleteVOC");
            dinsert1.Parameters.AddWithValue("@VocDtlId", SqlDbType.Int).Value = VocDtlId;

            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public bool setVOC(VOCust vc)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetVoc");
            dinsert1.Parameters.AddWithValue("@Voc", SqlDbType.VarChar).Value = vc.Voc;
            dinsert1.Parameters.AddWithValue("@Ans", SqlDbType.VarChar).Value = vc.Ans;
            dinsert1.Parameters.AddWithValue("@VocDtlId", SqlDbType.Int).Value = Convert.ToInt32(vc.VocDtlId);
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<VOCust> getVOC()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetVOC");

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<VOCust> list = new List<VOCust>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                VOCust list1 = new VOCust();

                list1.Voc = dr["Voc"].ToString();
                list1.VocDtlId = dr["VocDtlId"].ToString();
                list1.Ans = dr["Ans"].ToString();
                list1.VocId = dr["VocId"].ToString();
                list.Add(list1);

            }
            return list;
        }
        public List<GlobalHelpdesk> getGlobaldeskImgs(int GID)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetGlobalImage");
            dinsert.Parameters.AddWithValue("@GID", SqlDbType.Int).Value = GID;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<GlobalHelpdesk> list = new List<GlobalHelpdesk>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                GlobalHelpdesk list1 = new GlobalHelpdesk();
                list1.ImgId = Convert.ToInt32(dr["ImgId"]);
                list1.GID = Convert.ToInt32(dr["GID"]);
                list1.Name = dr["Question"].ToString();
                list1.imagfile = Convert.ToString(dr["Filepath"]);
                list.Add(list1);

            }
            return list;
        }

        public int SaveGlobalHelDskQue(GlobalHelpdesk model, HttpPostedFileBase[] postedFile)
        {
            SqlCommand dinsert = new SqlCommand("usp_saveglobalhelpdeskque1");

            if (model.files != null)
                dinsert.Parameters.AddWithValue("@Filepath", SqlDbType.VarChar).Value = model.files[0].FileName;
            else
                dinsert.Parameters.AddWithValue("@Filepath", SqlDbType.VarChar).Value = DBNull.Value;


            if (model.Name.ToString() != "")
                dinsert.Parameters.AddWithValue("@Question", SqlDbType.VarChar).Value = model.Name;
            else
                dinsert.Parameters.AddWithValue("@Question", SqlDbType.VarChar).Value = DBNull.Value; ;

            var Result = objcon.InsrtUpdtDlt(dinsert);
            return 1;
        }
        //public int UploadGlobalHelpImg(string fileName, int value)
        //{
        //    SqlCommand dinsert1 = new SqlCommand("usp_saveglobalhelpdeskImg");
        //    dinsert1.Parameters.AddWithValue("@GID", SqlDbType.Int).Value = value;
        //    dinsert1.Parameters.AddWithValue("@Filepath", SqlDbType.VarChar).Value = fileName;
        //    var Result1 = objcon.GetExcuteScaler(dinsert1);
        //    return Result1;
        //}

        public bool deleteGlobalImg(int ImgId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_DeleteGlobalImg");
            dinsert1.Parameters.AddWithValue("@ImgId", SqlDbType.Int).Value = ImgId;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
    }
}

