using SanjivaniDataLinkLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web;
using System.Data;

namespace SanjivaniBusinessLayer
{
    public class ClsPartnerBAL
    {
        InfPartner objInfPub = new SanjivaniDataLinkLayer.ImpPartner();

        public int SaveChennelPartnerDetails(ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveChennelPartnerDetails(model, postedFile);
        }
        public int SaveCPCRegisterDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveCPCDetails(model, postedFile);
        }

        public int SaveDirectorBusinessDetails(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveDirectorBusinessDetails(model, postedFile);
        }

        public List<TypeOfHosting> GetTypeofHosting()
        {
            return objInfPub.getTypeofHosting();
        }

        public List<HostingPlatF>GetHostingPlatform()
        {
            return objInfPub.getHostingPlatform();
        }

        public int UpdateCPCRegisterDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.UpdateCPCRegisterDetails(model, postedFile);
        }
        public int UpdateDirectorBusinessRegister(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.UpdateDirectorBusinessRegister(model, postedFile);
        }

        public bool SetCPBusinessDtl(BusinessDetails bD)
        {
            return objInfPub.setCPBusinessDtl(bD);
        }

        public List<PaymentType> GetPaymentmode()
        {
            return objInfPub.getPaymentmode();
        }

        public List<Bank> GetBank()
        {
            return objInfPub.getBank();
        }

        public List<Account> GetAccountType()
        {
            return objInfPub.getAccountType();
        }
        public List<BankName> GetBankName()
        {
            return objInfPub.GetBankName();
        }

        

        public List<State> GetBindState()
        {
            return objInfPub.GetBindState();
        }
        public List<CPCategory> GetBindCPCategory()
        {
            return objInfPub.GetBindCPCategory();
        }

        public bool setCPBankDtl(BankDetails bd)
        {
            return objInfPub.SetCPBankDtl(bd);
        }
        public bool setCPCBankDtl(BankDetails bd)
        {
            return objInfPub.SetCPCBankDtl(bd);
        }
        public bool setDirectorBankDtl(BankDetails bd)
        {
            return objInfPub.SetDirectorBankDtl(bd);
        }
        

        public List<CPCchannelPartnerModel> GetBindCPCustomer()
        {
            return objInfPub.GetBindCPCustomer();
        }

        public List<CompanyType> BindCompanyType()
        {
            return objInfPub.GetBindCompanyType();
        }


        public List<ChennelpartnerModel> GetChennelPartnerList()
        {
            return objInfPub.GetChennelPartnerList();
        }
        public List<CPCchannelPartnerModel> GetCPCChannelPartnerList()
        {
            return objInfPub.GetCPCChannelPartnerList();
        }

        public int SaveUploadChennelPartnerDoc(string filename1, int CustID, int type)
        {
            return objInfPub.SaveUploadChennelPartnerDocument(filename1, CustID, type);
        }
        public int SaveUploadCPCDoc(string filename1, int CustID, int type)
        {
            return objInfPub.SaveUploadCPCDocument(filename1, CustID, type);
        }
        public int SaveUploadDirectorDoc(string filename1, int CustID, int type)
        {
            return objInfPub.SaveUploadDirectorDoc(filename1, CustID, type);
        }
        

        public CPCchannelPartnerModel GetCPCChannelEdit(string custId)
        {
            return objInfPub.GetCPCChannelList(custId);
        }
        public DirectorBusinessModel GetDirectorChannelEdit(string custId)
        {
            return objInfPub.GetDirectorChannelEdit(custId);
        }
        

        public List<DirectorBusinessModel> GetDirectorBusinessOwnerList()
        {
            return objInfPub.GetDirectorBusinessOwnerList();
        }
        public bool RejectChannalPartner(int CustId)
        {
            return objInfPub.rejectChannalPartner(CustId);
        }
        public DataTable GetLoginDetail(string id)
        {
            return objInfPub.getLoginDetail(id);
        }
        public DataSet GetFolder()
        {
            return objInfPub.getFolder();
        }

        public List<UserIntraction> GetUserIntraction(int custId)
        {
            return objInfPub.getUserIntraction(custId);
        }
        
        public bool setUserIntarction(UserIntraction usD)
        { 
            return objInfPub.SetUserIntarction(usD);

        }
        public ChennelpartnerModel GetChannalPartnerDtl(int custId)
        {
            return objInfPub.getChannalPartnerDtl(custId);
        }

        public DirectorBusinessModel GetDirectorBusinessOwners(string custId)
    {
        return objInfPub.GetDirectorBusinessOwners(custId);

    }

        public int _partialCPSave(ChennelpartnerModel model)
        {
            return objInfPub._PartialCPSave(model);
        }

        public int _partialCPCSave(CPCchannelPartnerModel model)
        {
            return objInfPub._SaveCPCPartialView(model);
        }
		
        public DataTable CheckUserIdExists(string userId)
        {
            return objInfPub.checkUserIdExists(userId);
        }

        public DataTable CheckEmailExists(string email)
        {
            return objInfPub.checkEmailExists(email);
        }

        public ChennelpartnerModel GetCPForEdit(int Custid)
        {
            return objInfPub.getCPForEdit(Custid);
        }

        public BusinessDetails _partialGetCPBusinessDtl(string custId)
        {
            return objInfPub._partialgetCPBusinessDtl(custId);
        }

        public CountryState GetCountryStateForCPPersonal(int CustId)
        {
            return objInfPub.getCountryStateForCPPersonal(CustId);
        }

        public BankDetails _partialGetCPBankDtl(string custId)
        {
            return objInfPub._partialgetCPBankDtl(custId);
        }

        public bool DeleteCP(int custId)
        {
            return objInfPub.deleteCp(custId);
        }
        public bool GetDeleteUserIntraction(int IntractionId)
        {
            return objInfPub.DeleteUserIntraction(IntractionId);
        }

        public Dashboard GetDirectorDashboard()
        {
            return objInfPub.getDirectorDashboard();
        }

        public List<Documents1> getCpDocument(int custId)
        {
            return objInfPub.GetCPDocument(custId);
        }

        public List<ProductCount> GetProductCountForDirectorDash()
        {
            return objInfPub.getProductCountForDirectorDash();
        }

        public List<Reveneue> GetDirectorReveneue()
        {
            return objInfPub.getDirectorReveneue();
        }

        public List<GHDs> getGHDList()
        {
            return objInfPub.GetGHDList();
        }

        public bool setGHD(GHDs gHD)
        {
            return objInfPub.SetGHD(gHD);
        }

        public bool ApproveCP(int CustId)
        {
            return objInfPub.approveCP(CustId);
        }
        public List<Documents1> getDirectorDocument(int custId)
        {
            return objInfPub.getDirectorDocument(custId);
        }

        public List<OrgChart> getcpOrg()
        {
            return objInfPub.GetcpOrg();
        }

        public List<OrgChart> getcpCOrg()
        {
            return objInfPub.GetcpcOrg();
        }

        public List<OrgChart> getDirectorOrg()
        {
            return objInfPub.GetDirectorOrg();
        }

        public List<OrgChart> getAffilatorOrg()
        {
            return objInfPub.GetAffilatorOrg();
        }

        public List<OrgChart> getCustomerOrg()
        {
            return objInfPub.GetCustomerOrg();
        }

        public bool DeleteGHD(int GHDId)
        {
            return objInfPub.deleteGHD(GHDId);
        }

        public List<VOCust> GetVOC()
        {
            return objInfPub.getVOC();
        }

        public bool deleteVOC(int VocDtlId)
        {
            return objInfPub.DeleteVOC(VocDtlId);
        }

        public bool SetVOC(VOCust vc)
        {
            return objInfPub.setVOC(vc);
        }

        public List<GlobalHelpdesk> getGlobaldeskImgs(int GID)
        {
            return objInfPub.getGlobaldeskImgs(GID);
        }
        public int SaveGlobalHelDskQue(GlobalHelpdesk model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveGlobalHelDskQue(model, postedFile);
        }
        
        public bool DeleteGlobalImg(int GID)
        {
            return objInfPub.deleteGlobalImg(GID);
        }

        public List<GHDTicket> GetGHDTicket()
        {
            return objInfPub.getGHDTicket();
        }

        public List<CPStorefront> GetCPBanner(string custName)
        {
            return objInfPub.getCPBanner(custName);
        }

        public bool SetCPBanner(string cPName, string filename1)
        {
            return objInfPub.setCPBanner(cPName, filename1);
        }

        public List<CPStorefront> GetCPClient(string name)
        {
            return objInfPub.getCPClient(name);
        }

        public bool SetCPClient(string cPName, string filename1)
        {
            return objInfPub.setCPClient(cPName, filename1);
        }

        public List<CPStorefront> GetCPLoginPage(string custName)
        {
            return objInfPub.getCPLoginPage(custName);
        }

        public bool SetCPLoginPage(string cPName, string filename1)
        {
            return objInfPub.setCPLoginPage(cPName, filename1);
        }

        public List<CPPeopleTalks> GetCPPeopleTalks(string custName)
        {
            return objInfPub.getCPPeopleTalks(custName);
        }

        public bool SetCPPeopleTalk(string cPName, string popleTalk, string filename1)
        {
            return objInfPub.setCPPeopleTalk(cPName, popleTalk, filename1);
        }

        public bool DeleteDirector(int custId)
        {
            return objInfPub.deleteDirector(custId);
        }

        public List<CPCchannelPartnerModel> GetCustomerList()
        {
            return objInfPub.getCustomerList();
        }

        public List<TicketTypes> GetTicketType()
        {
            return objInfPub.getTicketType();
        }

        public TicketCount GetTicketCount(string TicketTypeId)
        {
            return objInfPub.getTicketCount(TicketTypeId);
        }

        public List<GHDTicket> GetOpenTicketCount(string ticketTypeId)
        {
            return objInfPub.getOpenTicketCount(ticketTypeId);
        }

        public GHDView GetSalesGHDTicket(int TicketId)
        {
            return objInfPub.getSalesGHDTicket(TicketId);
        }

        public GHDView GetTechanicalGHDTicket(int TicketId)
        {
            return objInfPub.getTechanicalGHDTicket(TicketId);
        }

        public DataTable GetDNSSettingForTechanical(int CustomerDomainProductDnsMIdv)
        {
            return objInfPub.getDNSSettingForTechanical(CustomerDomainProductDnsMIdv);
        }

        public bool updateTicketStatus(string type, string ticketId)
        {
            return objInfPub.UpdateTicketStatus(type, ticketId);
        }

        public List<MailBox> GetDirectorMailBox()
        {
            return objInfPub.getDirectorMailBox();
        }

        public int sendmail(string msg, string email,int CustId)
        {
            return objInfPub.Sendmail(msg, email, CustId);
        }

        public List<MailBox> GetSentMailBox(int custId)
        {
            return objInfPub.getSentMailBox(custId);
        }

        public List<Orgchart> _orgChartNew(string cPName)
        {
            return objInfPub._OrgChartNew(cPName);
        }

        public List<CPStorefront> GetCompanyLogo(string name)
        {
            return objInfPub.getCompanyLogo(name);
        }

        public bool SetCompanyLogo(string cPName, string filename1)
        {
            return objInfPub.setCompanyLogo(cPName, filename1);
        }

        public List<CustomerAggrements> GetCustomerAggre()
        {
            return objInfPub.getCustomerAggre();
        }

        public bool SetCustomerAggrement(CustomerAggrements cA)
        {
            return objInfPub.setCustomerAggrement(cA);
        }

        public bool DeleteCustomerAggrem(int CustAggrementId)
        {
            return objInfPub.deleteCustomerAggrem(CustAggrementId);
        }

        public List<CPAggrements> GetCPAggre()
        {
            return objInfPub.getCPAggre();
        }

        public bool SetCPAggrement(CPAggrements cA)
        {
            return objInfPub.setCPAggrement(cA);
        }

        public bool DeleteCPAggrem(int CPAggrementId)
        {
            return objInfPub.deleteCPAggrem(CPAggrementId);
        }

        public List<Privacys> GetPrivacy()
        {
            return objInfPub.getPrivacy();
        }

        public bool SetPrivacy(Privacys cA)
        {
            return objInfPub.setPrivacy(cA);
        }

        public bool DeletePrivacy(int PrivacyId)
        {
            return objInfPub.deletePrivacy(PrivacyId);
        }

        public List<ProductAggrements> GetProductAggrement()
        {
            return objInfPub.getProductAggrement();
        }

        public bool SetProductAggrement(ProductAggrements cA)
        {
            return objInfPub.setProductAggrement(cA);
        }

        public bool DeleteProductAggrement(int ProductAggrementId)
        {
            return objInfPub.DeleteProductAggrement(ProductAggrementId);
        }

        public List<Employees> GetEmpList()
        {
            return objInfPub.getEmpList();
        }

        public List<EmpRoles> GetEmpRole()
        {
            return objInfPub.getEmpRole();
        }

        public Employees GetEmpForEdit(int CustId)
        {
            return objInfPub.getEmpForEdit(CustId);
        }

        public int _partialEmpSave(Employees model)
        {
            return objInfPub._PartialEmpSave(model);
        }

        public bool DeleteEmp(int CustId)
        {
            return objInfPub.deleteEmp(CustId);
        }

        public DataTable GetEmpCalender(string date)
        {
            return objInfPub.getEmpCalender(date);
        }

        public DataTable GetEmpAttendance(string custName, string date)
        {
            return objInfPub.getEmpAttendance(custName, date);
        }

        public bool SetEmpAttendance(EmpAttendance cA)
        {
            return objInfPub.setEmpAttendance(cA);
        }
    }
}
