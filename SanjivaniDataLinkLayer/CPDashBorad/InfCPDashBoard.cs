using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanjivaniModalView;

namespace SanjivaniDataLinkLayer.CPDashBorad
{
    public interface InfCPDashBoard
    {
        int getCpDashCount(int cPCustID);
        List<ChennelpartnerModel> getCPCustomerList(int CPCustID);
        int SetPersonalDeatil(ChennelpartnerModel model);
        ChennelpartnerModel GetCPForEdit(int cPCustId);
        List<ProductBusinessModal> getCpProdcutList(int ProductId);
    }
}
