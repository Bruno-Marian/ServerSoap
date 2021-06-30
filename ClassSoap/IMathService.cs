using System.ServiceModel;

namespace ClassSoap
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        double CalcTaxa(double pValorCarta, double pTaxa, int pPrazo);
    }
}
