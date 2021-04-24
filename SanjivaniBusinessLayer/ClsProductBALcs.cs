using SanjivaniDataLinkLayer.Product;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SanjivaniBusinessLayer
{
    public class ClsProductBALcs
    {
        InfProduct objInfPub = new ImpProduct();

        public List<ProductBusinessModal> GetDoaminList(int catId)
        {
            return objInfPub.getDoaminList(catId);
        }

        public int SetDomain(ProductBusinessModal pd)
        {
            return objInfPub.setDomain(pd);
        }

        public ProductBusinessModal GetProductById(int ProductId)
        {
            return objInfPub.getProductById(ProductId);
        }

        public bool deleteProduct(int productId)
        {
            return objInfPub.DeleteProduct(productId);
        }

        public List<ProductEmail> GetEmailProductList()
        {
            return objInfPub.getEmailProductList();
        }

        public ProductEmail GetProductEmailById(int EmailProductId)
        {
            return objInfPub.getProductEmailById(EmailProductId);
        }

        public int SetEmailProduct(ProductEmail pd)
        {
            return objInfPub.setEmailProduct(pd);
        }

        public bool deleteEmailProduct(int productId)
        {
            return objInfPub.DeleteEmailProduct(productId);
        }

        public List<SetPrice> GetCPDropDown()
        {
            return objInfPub.getCPDropDown();
        }

        public List<SetPrice> GetProductCatDropDown()
        {
            return objInfPub.getProductCatDropDown();
        }

        public List<ProductBusinessModal> GetCPDoaminPriceList(string custName, string categeory)
        {
            return objInfPub.getCPDoaminPriceList(custName, categeory);
        }

        public bool SetProductPrice(string cat, string name, string amount)
        {
            return objInfPub.setProductPrice(cat, name, amount);
        }

        public List<ProductEmail> GetCPEmailPriceList(string custName, string categeory)
        {
            return objInfPub.getCPEmailPriceList(custName, categeory);
        }

        public List<ProductHosting> GetHostingProductList()
        {
            return objInfPub.getHostingProductList();
        }

        public ProductHosting GetProductHostingById(int HostingProductId)
        {
            return objInfPub.getProductHostingById(HostingProductId);
        }

        public List<HostingCategeory> GetHostingCat()
        {
            return objInfPub.getHostingCat();
        }

        public List<HostingCategeory> GetHostingSubCat()
        {
            return objInfPub.getHostingSubCat();
        }

        public int SetHostingProduct(ProductHosting pd)
        {
            return objInfPub.setHostingProduct(pd);
        }

        public bool deleteHOstingProduct(int productId)
        {
            return objInfPub.DeleteHOstingProduct(productId);
        }

        public List<ProductHosting> GetCPHostingPriceList(string custName, string categeory)
        {
            return objInfPub.getCPHostingPriceList(custName, categeory);
        }

        public List<Order> GetOrderList()
        {
            return objInfPub.getOrderList();
        }

        public List<AccountRegister> GetpartialWalletAmt(string cPName)
        {
            return objInfPub.getpartialWalletAmt(cPName);
        }

        public List<ChennelpartnerModel> GetpartialWalletAmtLst(string cPName)
        {
            return objInfPub.getpartialWalletAmtLst(cPName);
        }

        public List<Order> GetpartialCPOrderList(string cPName)
        {
            return objInfPub.getpartialCPOrderList(cPName);
        }

        public bool setCustomerPriceList(string cat, string name, string amount, string productId)
        {
            return objInfPub.SetCustomerPriceList(cat, name, amount, productId);
        }

        public InvoicePrint GetBillingDtl(int OrderMasterId)
        {
            return objInfPub.getPrintBill(OrderMasterId);
        }
    }
}
