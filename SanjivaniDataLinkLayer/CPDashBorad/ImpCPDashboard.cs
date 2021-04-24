using BandooDataLinkLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanjivaniModalView;

namespace SanjivaniDataLinkLayer.CPDashBorad
{
   
    public  class ImpCPDashboard:InfCPDashBoard
    {
        DBConnection objcon = new DBConnection();
        public int getCpDashCount(int cPCustID)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_GetCPDashBoard");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPCustID;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;
        }
        public List<ChennelpartnerModel> getCPCustomerList(int CPCustID)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPCListForCPDashBoard");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CPCustID;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<ChennelpartnerModel> list = new List<ChennelpartnerModel>();
            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    ChennelpartnerModel objChennelpartnerList = new ChennelpartnerModel();
                    objChennelpartnerList.UserName = Convert.ToString(dr["UserId"]);
                    objChennelpartnerList.ParentId = (dr["ParentId"].ToString());
                    objChennelpartnerList.StatusId = (dr["StatusId"].ToString());
                    objChennelpartnerList.chennelpartName = Convert.ToString(dr["CustName"]);
                    objChennelpartnerList.mobileNo = dr["MobileNo"].ToString();
                    objChennelpartnerList.EmailID =Convert.ToString(dr["Email"]);
                    objChennelpartnerList.Address = dr["Address"].ToString();
                    objChennelpartnerList.CustId = dr["CustId"].ToString();
                    if(dr["CPId"]!=null)
                    objChennelpartnerList.CPId =Convert.ToString(dr["CPId"]);
                    else
                        objChennelpartnerList.CPId = "0";
                    list.Add(objChennelpartnerList);
                }
            }
            return list;
        }

        public int SetPersonalDeatil(ChennelpartnerModel model)
        {
            SqlCommand dinsert = new SqlCommand("Sp_InsertPartnerDetails");
            if (model.UserName.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserName;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;
           
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
            dinsert.Parameters.AddWithValue("@AspUserId", SqlDbType.VarChar).Value = model.AspUserId;

            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;
        }

        public ChennelpartnerModel GetCPForEdit(int CPCustId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartner");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CPCustId;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            ChennelpartnerModel List = new ChennelpartnerModel();
            if (DsList.Tables[0].Rows.Count>0)
            {

                List.CustId = Convert.ToString(DsList.Tables[0].Rows[0]["CustId"]);
                List.UserName = DsList.Tables[0].Rows[0]["UserId"].ToString();
                List.mobileNo = DsList.Tables[0].Rows[0]["MobileNo"].ToString();
                List.EmailID = DsList.Tables[0].Rows[0]["Email"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.pwd = DsList.Tables[0].Rows[0]["Password"].ToString();
                List.Cpwd = DsList.Tables[0].Rows[0]["Password"].ToString();
                List.AlterMobileNo = DsList.Tables[0].Rows[0]["AlternateMobileNo"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.CpCategory = Convert.ToString(DsList.Tables[0].Rows[0]["CPCategeoryId"]);
                List.ParentId = Convert.ToString(DsList.Tables[0].Rows[0]["ParentId"]);
                List.Country= Convert.ToString(DsList.Tables[0].Rows[0]["Country"]);
                List.State = Convert.ToString(DsList.Tables[0].Rows[0]["StateId"]);
                List.City = Convert.ToString(DsList.Tables[0].Rows[0]["City"]);
                List.PostedCode = Convert.ToInt32(DsList.Tables[0].Rows[0]["PostedCode"]);
                List.chennelpartName= Convert.ToString(DsList.Tables[0].Rows[0]["CustName"]);
            }
            return List;
        }

        public List<ProductBusinessModal> getCpProdcutList(int ProductId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetProduct");
            dinsert.Parameters.AddWithValue("@ProductCatId", SqlDbType.Int).Value = ProductId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductBusinessModal> list = new List<ProductBusinessModal>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                ProductBusinessModal list1 = new ProductBusinessModal();

                list1.ProductCode = dr["ProductCode"].ToString();
                list1.ProductName = dr["ProductName"].ToString();
                list1.DomainregistrationPrice = dr["DomainregistrationPrice"].ToString();
                list1.TransferPrice = dr["TransferPrice"].ToString();
                list.Add(list1);
            }
            return list;
        }
    }
}
