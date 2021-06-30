using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassSoap;

namespace SoapServer.Services
{
    public class MathService : IMathService
    {
        public double CalcTaxa(double pValorCarta, double pTaxa, int pPrazo)
        {
            return ((pValorCarta * pTaxa / 100) + pValorCarta) / pPrazo;
        }
    }
}
