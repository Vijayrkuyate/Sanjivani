using SanjivaniDataLinkLayer.CPDashBorad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanjivaniDataLinkLayer.CPDashBorad;
using SanjivaniModalView;

namespace SanjivaniBusinessLayer
{
  public  class ClsCCPDashboard
    {
        InfCPDashBoard objInfCPDash = new ImpCPDashboard();

        public int getCpDashCount(int CPCustID)
        {
            return objInfCPDash.getCpDashCount(CPCustID);
        }

        public  List<ChennelpartnerModel> GetCPCustomerList(int CPCustId)
        {
            return objInfCPDash.getCPCustomerList(CPCustId);
        }

        public int SetPersonalDeatil(ChennelpartnerModel model)
        {
            return objInfCPDash.SetPersonalDeatil(model);
        }

        public ChennelpartnerModel GetCPForEdit(int CPCustId)
        {
            return objInfCPDash.GetCPForEdit(CPCustId);
        }

        public List<ProductBusinessModal> getCpProdcutList(int ProductId)
        {
            return objInfCPDash.getCpProdcutList(ProductId);
        }
       
    }
}
