using BandooDataLinkLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjivaniDataLinkLayer.Product
{
    public class ImpProduct : InfProduct
    {
        DBConnection objcon = new DBConnection();
        public List<ProductBusinessModal> getDoaminList(int catId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetProduct");
            dinsert.Parameters.AddWithValue("@ProductCatId", SqlDbType.Int).Value = catId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductBusinessModal> list1 = new List<ProductBusinessModal>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductBusinessModal pd = new ProductBusinessModal();
                // BankDetails list1 = new BankDetails();
                pd.ProductId = Convert.ToInt32(dr["ProductId"].ToString());
                pd.ProductCode = dr["ProductCode"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                pd.DomainERPCode = dr["DomainERPCode"].ToString();
                pd.DomainProviderCode = dr["DomainProviderCode"].ToString();
                pd.SACCode = dr["SACCode"].ToString();
                pd.RegistrartionPrice = (dr["RegistrartionPrice"].ToString());
                pd.RenewalPrice = (dr["RenewalPrice"].ToString());
                pd.TransferPrice = (dr["TransferPrice"].ToString());
                pd.DomainregistrationPrice = (dr["DomainregistrationPrice"].ToString());
                pd.PropductImage = (dr["PropductImage"].ToString());
                list1.Add(pd);

            }
            return list1;
        }
        public int setDomain(ProductBusinessModal pd)
        {
            SqlCommand dinsert = new SqlCommand("usp_SetProduct");

            dinsert.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = pd.ProductId;
            if (pd.ProductName.ToString() != null)
                dinsert.Parameters.AddWithValue("@ProductName", SqlDbType.VarChar).Value = pd.ProductName;

            dinsert.Parameters.AddWithValue("@ProductCatId", SqlDbType.Int).Value = 1;
            if (!string.IsNullOrWhiteSpace(pd.DomainERPCode))
                dinsert.Parameters.AddWithValue("@DomainERPCode", SqlDbType.VarChar).Value = pd.DomainERPCode;
            if (!string.IsNullOrWhiteSpace(pd.DomainProviderCode))
                dinsert.Parameters.AddWithValue("@DomainProviderCode", SqlDbType.VarChar).Value = pd.DomainProviderCode;
            if (!string.IsNullOrWhiteSpace(pd.SACCode))
                dinsert.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = pd.SACCode;

            dinsert.Parameters.AddWithValue("@RegistrartionPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.RegistrartionPrice);
            dinsert.Parameters.AddWithValue("@TransferPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.TransferPrice);
            dinsert.Parameters.AddWithValue("@RenewalPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.RenewalPrice);
            dinsert.Parameters.AddWithValue("@DomainregistrationPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.DomainregistrationPrice);
            if (!string.IsNullOrWhiteSpace(pd.PropductImage))
                dinsert.Parameters.AddWithValue("@PropductImage", SqlDbType.VarChar).Value = pd.PropductImage;


            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;

        }

        public ProductBusinessModal getProductById(int productId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetProductById");
            dinsert.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = productId;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            ProductBusinessModal List = new ProductBusinessModal();
            if (DsList.Tables[0].Rows.Count > 0)
            {
                if (DsList.Tables[0].Rows[0] != null)
                {

                    List.ProductId = Convert.ToInt32(DsList.Tables[0].Rows[0]["ProductId"]);
                    List.ProductCode = (DsList.Tables[0].Rows[0]["ProductCode"].ToString());
                    List.ProductName = DsList.Tables[0].Rows[0]["ProductName"].ToString();
                    List.DomainERPCode = DsList.Tables[0].Rows[0]["DomainERPCode"].ToString();
                    List.DomainProviderCode = DsList.Tables[0].Rows[0]["DomainProviderCode"].ToString();
                    List.SACCode = DsList.Tables[0].Rows[0]["SACCode"].ToString();
                    List.RegistrartionPrice = (DsList.Tables[0].Rows[0]["RegistrartionPrice"].ToString());
                    List.RenewalPrice = (DsList.Tables[0].Rows[0]["RenewalPrice"].ToString());
                    List.TransferPrice = (DsList.Tables[0].Rows[0]["TransferPrice"].ToString());
                    List.DomainregistrationPrice = (DsList.Tables[0].Rows[0]["DomainregistrationPrice"].ToString());

                }
            }

            return List;
        }
        public bool DeleteProduct(int productId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_DeleteProduct");
            dinsert1.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = productId;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }

        public List<ProductEmail> getEmailProductList()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetEmailProduct");

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductEmail> list1 = new List<ProductEmail>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductEmail pd = new ProductEmail();
                // BankDetails list1 = new BankDetails();
                pd.EmailProductId = Convert.ToInt32(dr["EmailProductId"].ToString());
                pd.ProductCode = dr["ProductCode"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                pd.ProductProvider = dr["ProductProvider"].ToString();
                pd.RegistrationPrice = dr["RegistrationPrice"].ToString();
                pd.SACCode = dr["SACCode"].ToString();
                pd.RenewalPrice = (dr["RenewalPrice"].ToString());
                pd.EmailImage = (dr["EmailImage"].ToString());
                list1.Add(pd);

            }
            return list1;
        }

        public ProductEmail getProductEmailById(int emailProductId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetEmailProductById");
            dinsert.Parameters.AddWithValue("@EmailProductId", SqlDbType.Int).Value = emailProductId;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            ProductEmail List = new ProductEmail();
            if (DsList.Tables[0].Rows.Count > 0)
            {
                if (DsList.Tables[0].Rows[0] != null)
                {

                    List.EmailProductId = Convert.ToInt32(DsList.Tables[0].Rows[0]["EmailProductId"]);
                    List.ProductCode = (DsList.Tables[0].Rows[0]["ProductCode"].ToString());
                    List.ProductName = DsList.Tables[0].Rows[0]["ProductName"].ToString();
                    List.ProductProvider = DsList.Tables[0].Rows[0]["ProductProvider"].ToString();
                    // List.DomainProviderCode = DsList.Tables[0].Rows[0]["DomainProviderCode"].ToString();
                    List.SACCode = DsList.Tables[0].Rows[0]["SACCode"].ToString();
                    List.RegistrationPrice = (DsList.Tables[0].Rows[0]["RegistrationPrice"].ToString());
                    List.RenewalPrice = (DsList.Tables[0].Rows[0]["RenewalPrice"].ToString());
                    List.EmailImage = (DsList.Tables[0].Rows[0]["EmailImage"].ToString());
                    //List.DomainregistrationPrice = (DsList.Tables[0].Rows[0]["DomainregistrationPrice"].ToString());

                }
            }

            return List;
        }

        public int setEmailProduct(ProductEmail pd)
        {
            SqlCommand dinsert = new SqlCommand("usp_SetEmailProduct");

            dinsert.Parameters.AddWithValue("@EmailProductId", SqlDbType.Int).Value = pd.EmailProductId;
            if (!string.IsNullOrWhiteSpace(pd.ProductName))
                dinsert.Parameters.AddWithValue("@ProductName", SqlDbType.VarChar).Value = pd.ProductName;

            dinsert.Parameters.AddWithValue("@ProductCatId", SqlDbType.Int).Value = 2;

            if (!string.IsNullOrWhiteSpace(pd.ProductProvider))
                dinsert.Parameters.AddWithValue("@ProductProvider", SqlDbType.VarChar).Value = pd.ProductProvider;
            //if (!string.IsNullOrWhiteSpace(pd.SACCode))
            dinsert.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = "978512";

            dinsert.Parameters.AddWithValue("@RegistrationPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.RegistrationPrice);

            dinsert.Parameters.AddWithValue("@RenewalPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.RenewalPrice);
            if (!string.IsNullOrWhiteSpace(pd.ProductCode))
                dinsert.Parameters.AddWithValue("@ProductCode", SqlDbType.VarChar).Value = pd.ProductCode;
            if (!string.IsNullOrWhiteSpace(pd.EmailImage))
                dinsert.Parameters.AddWithValue("@EmailImage", SqlDbType.VarChar).Value = pd.EmailImage;


            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;
        }

        public bool DeleteEmailProduct(int productId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_DeleteEmailProduct");
            dinsert1.Parameters.AddWithValue("@EmailProductId", SqlDbType.Int).Value = productId;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<SetPrice> getCPDropDown()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPDropDown");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<SetPrice> lis = new List<SetPrice>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    SetPrice objstate = new SetPrice();
                    objstate.CustId = int.Parse(dr["CustId"].ToString());
                    objstate.CustName = dr["CustName"].ToString();
                    lis.Add(objstate);
                }
            }
            return lis;
        }

        public List<SetPrice> getProductCatDropDown()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetProductCategeory");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<SetPrice> lis = new List<SetPrice>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    SetPrice objstate = new SetPrice();
                    objstate.ProductCatId = int.Parse(dr["ProductCatId"].ToString());
                    objstate.ProductCat = dr["ProductCat"].ToString();
                    lis.Add(objstate);
                }
            }
            return lis;
        }

        public List<ProductBusinessModal> getCPDoaminPriceList(string custName, string categeory)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPDomainPriceList");
            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.Int).Value = custName;
            dinsert.Parameters.AddWithValue("@Cat", SqlDbType.Int).Value = categeory;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductBusinessModal> list1 = new List<ProductBusinessModal>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductBusinessModal pd = new ProductBusinessModal();
                // BankDetails list1 = new BankDetails();
                pd.ProductId = Convert.ToInt32(dr["ProductId"].ToString());
                pd.ProductCode = dr["ProductCode"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                //pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                //pd.DomainERPCode = dr["DomainERPCode"].ToString();
                //pd.DomainProviderCode = dr["DomainProviderCode"].ToString();
                //pd.SACCode = dr["SACCode"].ToString();
                pd.RegistrartionPrice = (dr["RegistrartionPrice"].ToString());
                pd.RenewalPrice = (dr["RenewalPrice"].ToString());
                pd.TransferPrice = (dr["TransferPrice"].ToString());
                pd.DomainregistrationPrice = (dr["DomainregistrationPrice"].ToString());
                pd.PropductImage = (dr["PropductImage"].ToString());
                pd.CPName = (dr["CustName"].ToString());
                pd.CostPrice = (dr["CostPrise"].ToString());
                pd.SellingPrice = (dr["SellingPrise"].ToString());
                list1.Add(pd);

            }
            return list1;
        }

        public List<ProductEmail> getCPEmailPriceList(string custName, string categeory)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPEmailPriceList");
            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.Int).Value = custName;
            dinsert.Parameters.AddWithValue("@Cat", SqlDbType.Int).Value = categeory;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductEmail> list1 = new List<ProductEmail>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductEmail pd = new ProductEmail();
                // BankDetails list1 = new BankDetails();
                //pd.EmailProductId = Convert.ToInt32(dr["EmailProductId"].ToString());
                pd.ProductCode = dr["ProductCode"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                // pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                //  pd.ProductProvider = dr["ProductProvider"].ToString();
                pd.RegistrationPrice = dr["RegistrationPrice"].ToString();
                // pd.SACCode = dr["SACCode"].ToString();
                pd.RenewalPrice = (dr["RenewalPrice"].ToString());
                pd.EmailImage = (dr["EmailImage"].ToString());
                pd.CostPrice = (dr["CostPrise"].ToString());
                pd.SellingPrice = (dr["SellingPrise"].ToString());
                list1.Add(pd);

            }
            return list1;
        }
        public bool setProductPrice(string cat, string name, string amount)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetCPProductPriseSetUp");
            dinsert1.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = name;
            dinsert1.Parameters.AddWithValue("@Categeory", SqlDbType.VarChar).Value = cat;
            if (!string.IsNullOrWhiteSpace(amount))
                dinsert1.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(amount);
            else
                dinsert1.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(0);
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }

        public List<ProductHosting> getHostingProductList()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetHostingProduct");
            //dinsert.Parameters.AddWithValue("@CustName", SqlDbType.Int).Value = custName;
            //dinsert.Parameters.AddWithValue("@Cat", SqlDbType.Int).Value = categeory;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();
                // BankDetails list1 = new BankDetails();
                pd.HostintProductId = Convert.ToInt32(dr["HostintProductId"].ToString());
                pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                pd.HostingCatId = Convert.ToInt32(dr["HostingCatId"].ToString());
                pd.HostingSubCatId = Convert.ToInt32(dr["HostingSubCatId"].ToString());
                pd.ProductName = dr["ProductName"].ToString();
                pd.Price = dr["Price"].ToString();
                // pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                pd.DomainSize = dr["DomainSize"].ToString();
                pd.SSDDiskSapce = dr["SSDDiskSapce"].ToString();
                pd.TransferSize = dr["TransferSize"].ToString();
                pd.EmailAccount = (dr["EmailAccount"].ToString());
                pd.DatabaseSize = (dr["DatabaseSize"].ToString());
                pd.SSL = (dr["SSL"].ToString());
                pd.HostingCat = (dr["HostingCat"].ToString());
                pd.HostingSubCat = (dr["HostingSubCat"].ToString());
                pd.ProductImage = (dr["ProductImage"].ToString());
                list1.Add(pd);

            }
            return list1;
        }

        public ProductHosting getProductHostingById(int hostingProductId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetHostingProductById");
            dinsert.Parameters.AddWithValue("@HostintProductId", SqlDbType.Int).Value = hostingProductId;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            ProductHosting List = new ProductHosting();
            if (DsList.Tables[0].Rows.Count > 0)
            {
                if (DsList.Tables[0].Rows[0] != null)
                {
                    List.HostintProductId = Convert.ToInt32((DsList.Tables[0].Rows[0]["HostintProductId"].ToString()));
                    List.ProductCatId = Convert.ToInt32((DsList.Tables[0].Rows[0]["ProductCatId"].ToString()));
                    //List.HostingCatId = Convert.ToInt32((DsList.Tables[0].Rows[0]["HostingCatId"].ToString()));
                    //List.HostingSubCatId = Convert.ToInt32((DsList.Tables[0].Rows[0]["HostingSubCatId"].ToString()));
                    List.ProductName = (DsList.Tables[0].Rows[0]["ProductName"].ToString());
                    List.Price = (DsList.Tables[0].Rows[0]["Price"].ToString());
                    // pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                    List.DomainSize = (DsList.Tables[0].Rows[0]["DomainSize"].ToString());
                    List.SSDDiskSapce = (DsList.Tables[0].Rows[0]["SSDDiskSapce"].ToString());
                    List.TransferSize = (DsList.Tables[0].Rows[0]["TransferSize"].ToString());
                    List.EmailAccount = ((DsList.Tables[0].Rows[0]["EmailAccount"].ToString()));
                    List.DatabaseSize = ((DsList.Tables[0].Rows[0]["DatabaseSize"].ToString()));
                    List.SSL = ((DsList.Tables[0].Rows[0]["SSL"].ToString()));
                    List.HostingCat = ((DsList.Tables[0].Rows[0]["HostingCat"].ToString()));
                    List.HostingSubCat = ((DsList.Tables[0].Rows[0]["HostingSubCat"].ToString()));

                }
            }

            return List;
        }
        public List<HostingCategeory> getHostingCat()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetHostingCat");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<HostingCategeory> lis = new List<HostingCategeory>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    HostingCategeory objstate = new HostingCategeory();
                    objstate.HostingCatId = int.Parse(dr["HostingCatId"].ToString());
                    objstate.HostingCat = dr["HostingCat"].ToString();
                    lis.Add(objstate);
                }
            }
            return lis;
        }
        public List<HostingCategeory> getHostingSubCat()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetSubHosting");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<HostingCategeory> lis = new List<HostingCategeory>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    HostingCategeory objstate = new HostingCategeory();
                    objstate.HostingSubCatId = int.Parse(dr["HostingSubCatId"].ToString());
                    objstate.HostingSubCat = dr["HostingSubCat"].ToString();
                    lis.Add(objstate);
                }
            }
            return lis;
        }

        public int setHostingProduct(ProductHosting pd)
        {
            SqlCommand dinsert = new SqlCommand("usp_SetHostingProduct");

            dinsert.Parameters.AddWithValue("@HostintProductId", SqlDbType.Int).Value = pd.HostintProductId;
            if (!string.IsNullOrWhiteSpace(pd.ProductName))
                dinsert.Parameters.AddWithValue("@ProductName", SqlDbType.VarChar).Value = pd.ProductName;

            dinsert.Parameters.AddWithValue("@ProductCatId", SqlDbType.Int).Value = 3;

            if (!string.IsNullOrWhiteSpace(pd.HostingCat))
                dinsert.Parameters.AddWithValue("@HostingCat", SqlDbType.VarChar).Value = pd.HostingCat;
            if (!string.IsNullOrWhiteSpace(pd.HostingSubCat))
                dinsert.Parameters.AddWithValue("@HostingSubCat", SqlDbType.VarChar).Value = pd.HostingSubCat;
            if (!string.IsNullOrWhiteSpace(pd.Price))
                dinsert.Parameters.AddWithValue("@Price", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.Price);
            else
                dinsert.Parameters.AddWithValue("@Price", SqlDbType.Decimal).Value = 0;
            if (!string.IsNullOrWhiteSpace(pd.DomainSize))
                dinsert.Parameters.AddWithValue("@DomainSize", SqlDbType.VarChar).Value = (pd.DomainSize);
            if (!string.IsNullOrWhiteSpace(pd.SSDDiskSapce))
                dinsert.Parameters.AddWithValue("@SSDDiskSapce", SqlDbType.VarChar).Value = pd.SSDDiskSapce;
            if (!string.IsNullOrWhiteSpace(pd.TransferSize))
                dinsert.Parameters.AddWithValue("@TransferSize", SqlDbType.VarChar).Value = pd.TransferSize;

            if (!string.IsNullOrWhiteSpace(pd.EmailAccount))
                dinsert.Parameters.AddWithValue("@EmailAccount", SqlDbType.VarChar).Value = pd.EmailAccount;
            if (!string.IsNullOrWhiteSpace(pd.DatabaseSize))
                dinsert.Parameters.AddWithValue("@DatabaseSize", SqlDbType.VarChar).Value = pd.DatabaseSize;
            if (!string.IsNullOrWhiteSpace(pd.ProductImage))
                dinsert.Parameters.AddWithValue("@ProductImage", SqlDbType.VarChar).Value = pd.ProductImage;
            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;

        }

        public bool DeleteHOstingProduct(int productId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_DeleteHostingProduct");
            dinsert1.Parameters.AddWithValue("@HostintProductId", SqlDbType.Int).Value = productId;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<ProductHosting> getCPHostingPriceList(string custName, string categeory)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPHostingPriceList");
            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.Int).Value = custName;
            dinsert.Parameters.AddWithValue("@Cat", SqlDbType.Int).Value = categeory;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();
                // BankDetails list1 = new BankDetails();
                pd.HostintProductId = Convert.ToInt32(dr["HostintProductId"].ToString());
                //pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                //pd.HostingCatId = Convert.ToInt32(dr["HostingCatId"].ToString());
                //pd.HostingSubCatId = Convert.ToInt32(dr["HostingSubCatId"].ToString());
                pd.ProductName = dr["ProductName"].ToString();
                pd.Price = dr["Price"].ToString();
                // pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                pd.DomainSize = dr["DomainSize"].ToString();
                pd.SSDDiskSapce = dr["SSDDiskSapce"].ToString();
                pd.TransferSize = dr["TransferSize"].ToString();
                pd.EmailAccount = (dr["EmailAccount"].ToString());
                pd.DatabaseSize = (dr["DatabaseSize"].ToString());
                pd.SSL = (dr["SSL"].ToString());
                //pd.HostingCat = (dr["HostingCat"].ToString());
                //pd.HostingSubCat = (dr["HostingSubCat"].ToString());
                pd.CostPrice = (dr["CostPrise"].ToString());
                pd.SellingPrice = (dr["SellingPrise"].ToString());
                pd.ProductImage = (dr["ProductImage"].ToString());
                list1.Add(pd);

            }
            return list1;
        }
        public List<Order> getOrderList()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetOrderForDirector");
            //dinsert.Parameters.AddWithValue("@CustName", SqlDbType.Int).Value = custName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Order> list1 = new List<Order>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Order pd = new Order();
                // BankDetails list1 = new BankDetails();
                pd.OrderId = Convert.ToInt32(dr["OrderMasterId"].ToString());

                //pd.ProductCat = dr["ProductCat"].ToString();
                pd.BasePrise = dr["BasePrise"].ToString();

                pd.CGST = dr["CGST"].ToString();
                pd.SGST = dr["SGST"].ToString();
                pd.OrderDate = dr["OrderDate"].ToString();
                pd.InvoiceAmt = dr["InvoiceAmount"].ToString();
                

                list1.Add(pd);

            }
            return list1;
        }
        public List<AccountRegister> getpartialWalletAmt(string cPName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetWalletForCP");
            if (!string.IsNullOrWhiteSpace(cPName))
                dinsert.Parameters.AddWithValue("@CPName", SqlDbType.Int).Value = cPName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<AccountRegister> list1 = new List<AccountRegister>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                AccountRegister pd = new AccountRegister();
                // BankDetails list1 = new BankDetails();
                pd.WalletAmount = (dr["WalletAmount"].ToString());

                list1.Add(pd);

            }
            return list1;
        }
        public List<ChennelpartnerModel> getpartialWalletAmtLst(string cPName)
        {
            SqlCommand dinsert = new SqlCommand("usp_usp_GetWalletForCPList");
            if (!string.IsNullOrWhiteSpace(cPName))
                dinsert.Parameters.AddWithValue("@CPName", SqlDbType.Int).Value = cPName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ChennelpartnerModel> list1 = new List<ChennelpartnerModel>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ChennelpartnerModel pd = new ChennelpartnerModel();
                // BankDetails list1 = new BankDetails();
                pd.chennelpartName = (dr["CustName"].ToString());
                pd.mobileNo = (dr["MobileNo"].ToString());
                pd.EmailID = (dr["Email"].ToString());
                pd.CPId = (dr["CPId"].ToString());
                pd.CPWalletAmount = (dr["CPWalletAmount"].ToString());
                list1.Add(pd);

            }
            return list1;
        }

        public List<Order> getpartialCPOrderList(string cPName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetOrderForCP");
            dinsert.Parameters.AddWithValue("@CPName", SqlDbType.VarChar).Value = cPName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Order> list1 = new List<Order>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Order pd = new Order();
                // BankDetails list1 = new BankDetails();
                pd.OrderId = Convert.ToInt32(dr["OrderId"].ToString());

                pd.ProductCat = dr["ProductCat"].ToString();
                pd.Price = dr["Price"].ToString();
                pd.CostPrise = dr["CostPrise"].ToString();
                pd.Margin = dr["Margin"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                pd.OrderDate = dr["OrderDate"].ToString();
                pd.CustName = dr["CustName"].ToString();
                pd.MobileNo = (dr["MobileNo"].ToString());

                list1.Add(pd);

            }
            return list1;
        }
        public bool SetCustomerPriceList(string cat, string name, string amount, string productId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetCustomerwiseSetPrice");
            dinsert1.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = name;
            dinsert1.Parameters.AddWithValue("@Categeory", SqlDbType.VarChar).Value = cat;
            dinsert1.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(amount);
            dinsert1.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = Convert.ToInt32(productId); ;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public InvoicePrint getPrintBill(int orderMasterId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetBillPrint");
            dinsert.Parameters.AddWithValue("@OrderMasterId", SqlDbType.Int).Value = orderMasterId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            InvoicePrint list1 = new InvoicePrint();

            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                //DomainDNS pd = new DomainDNS();
                list1.ServiceProviderName = (dr["ServiceProviderName"].ToString());
                list1.ServiceProviderMobileNo = dr["ServiceProviderMobileNo"].ToString();
                list1.CompanyName = dr["CompanyName"].ToString();
                list1.ServiceProviderRegNo = dr["ServiceProviderRegNo"].ToString();
                list1.ServiceProviderGSTIN = dr["ServiceProviderGSTIN"].ToString();
                list1.ServiceProviderEmail = dr["ServiceProviderEmail"].ToString();
                list1.ServiceProviderAddress = dr["ServiceProviderAddress"].ToString();
                list1.ServiceProviderCity = dr["ServiceProviderCity"].ToString();
                list1.OrderId = dr["OrderMasterId"].ToString();
                list1.OrderDate = dr["OrderDate"].ToString();
                list1.CustomerId = dr["CustomerId"].ToString();
                list1.CustomerName = dr["CustomerName"].ToString();
                list1.CustomerMoNo = dr["CustomerMoNo"].ToString();
                list1.CustomerEmail = dr["CustomerEmail"].ToString();
                list1.CustomerAddress = dr["CustomerAddress"].ToString();
                list1.CustomerCity = dr["CustomerCity"].ToString();
                list1.CustomerPostalCode = dr["CustomerPostalCode"].ToString();
            }
            foreach (DataRow dr in dtList.Tables[1].Rows)
            {
                Order list12 = new Order();

                //DomainDNS pd = new DomainDNS();
                list12.ProductName = (dr["ProductName"].ToString());
                list12.Qty = "1";//dr["ServiceProviderMobileNo"].ToString();
                list12.RatePerQty = dr["RatePerQty"].ToString();
                list12.BasePrise = dr["BasePrise"].ToString();
                list12.CGST = dr["CGST"].ToString();
                list12.SGST = dr["SGST"].ToString();
                list12.Price = dr["Price"].ToString();
                list1.Productlst.Add(list12);
            }
            foreach (DataRow dr in dtList.Tables[2].Rows)
            {
                OrderMasterDetail list12 = new OrderMasterDetail();

                //DomainDNS pd = new DomainDNS();
                list12.Subtotal = (dr["BasePrise"].ToString());
                list12.CGST = dr["CGST"].ToString();
                list12.SGST = dr["SGST"].ToString();
                list12.InvoiceTotal = dr["InvoiceTotal"].ToString();

                list1.OrderDetail.Add(list12);
            }
            return list1;
        }
    }
}
