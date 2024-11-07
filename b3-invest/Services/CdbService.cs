using calculo_b3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using calculo_b3.Models;

namespace calculo_b3.Services
{
    public class CdbService : ICdbService
    {
        private const double CDI = 0.009;
        private const double TB = 1.08;  


        public CdbResponse CalculaCDB(CdbRequest cdbRequest)
        {
            CdbResponse cdbResponse = new CdbResponse();

            if (cdbRequest.ValorInicial <= 0)
            {
                cdbResponse.Erro = true;
                cdbResponse.MsgErro =  "Valor inicial deve ser positivo.";
                return cdbResponse;
            }
            if (cdbRequest.Meses <= 1)
            {
                cdbResponse.Erro = true;
                cdbResponse.MsgErro = "Prazo deve ser maior que 1.";
                return cdbResponse;
            }

            cdbResponse.Erro = false;
            cdbResponse.ValorBruto = CalculaBruto(cdbRequest.ValorInicial, cdbRequest.Meses);
            double rendimento = cdbResponse.ValorBruto - cdbRequest.ValorInicial;
            double imposto = CalculaImposto(cdbRequest.Meses);
            cdbResponse.ValorLiquido = cdbResponse.ValorBruto -  (rendimento * imposto);

            return cdbResponse;
        }

        private double CalculaBruto(double ValorInicial, int Meses)
        {
            double valor = ValorInicial;
            for (int i = 0; i < Meses; i++)
            {
                valor *= (1 + (CDI * TB));
            }
            return valor;
        }

        private double CalculaImposto(int Meses)
        {
            if (Meses <= 6)
                return 0.225;
            if (Meses <= 12)
                return 0.20;
            if (Meses <= 24)
                return 0.175;
            return 0.15;
        }

    }
}