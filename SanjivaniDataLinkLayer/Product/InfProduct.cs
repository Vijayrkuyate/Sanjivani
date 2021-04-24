using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanjivaniModalView;

namespace SanjivaniDataLinkLayer.Product
{
    public interface InfProduct
    {
        List<ProductBusinessModal> getDoaminList(int catId);
        int setDomain(ProductBusinessModal pd);
        ProductBusinessModal getProductById(int productId);
        bool DeleteProduct(int productId);
        List<ProductEmail> getEmailProductList();
        ProductEmail getProductEmailById(int emailProductId);
        int setEmailProduct(ProductEmail pd);
        bool DeleteEmailProduct(int productId);
        List<SetPrice> getCPDropDown();
        List<SetPrice> getProductCatDropDown();
        List<ProductBusinessModal> getCPDoaminPriceList(string custName, string categeory);
        bool setProductPrice(string cat, string name, string amount);
        List<ProductEmail> getCPEmailPriceList(string custName, string categeory);
        List<ProductHosting> getHostingProductList();
        ProductHosting getProductHostingById(int hostingProductId);
        List<HostingCategeory> getHostingCat();
        List<HostingCategeory> getHostingSubCat();
        int setHostingProduct(ProductHosting pd);
        bool DeleteHOstingProduct(int productId);
        List<ProductHosting> getCPHostingPriceList(string custName, string categeory);
        List<Order> getOrderList();
        List<AccountRegister> getpartialWalletAmt(string cPName);
        List<ChennelpartnerModel> getpartialWalletAmtLst(string cPName);
        List<Order> getpartialCPOrderList(string cPName);
        bool SetCustomerPriceList(string cat, string name, string amount, string productId);
        InvoicePrint getPrintBill(int orderMasterId);
    }
}
