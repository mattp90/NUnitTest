using NUnit.Framework;
using System;
using System.Threading.Tasks;
using wsCommerce;

namespace AquardensNUnitTest_2.Commerce
{
    public class iReport_002 : Base001
    {
        protected iReport_001Client reportClient_001 = new iReport_001Client();
        
        [Test]
        public async Task VoucherList()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await reportClient_001.VoucherListAsync(baseRequest,
                new dcReportFilter()
                {
                    IdAnagrafica = new IdBox()
                    {
                        Id = "ACC000120220621454605180000088",
                    },
                    CodiceVoucher = new IdBox()
                    {
                        Id = "KTZ7V7LODAZSKX5"
                    } 
                });

            var esitoDetail = await reportClient_001.VoucherDetailAsync(baseRequest,
                new dcVoucherDetailRequest()
                {
                    CodiceVoucher = new IdBox()
                    {
                        Id = "KTZ7V7LODAZSKX5"
                    }                    
                });

            var esito3 = await reportClient_001.VoucherReportAsync(baseRequest,
                new dcReportFilter()
                {
                    CodiceVoucher = new IdBox()
                    {
                        Id = "KTZ7V724PZD49PV"
                    }
                    // IdAnagrafica = new IdBox()
                    // {
                    //     Id = "ACC000120220607458821350000074"
                    // }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetAcquisti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await reportClient_001.GetAcquistiAsync(baseRequest,
                new dcAcquistoFilter()
                {
                    // Dal = new DateTime(2022, 6, 20, 0, 0, 0),
                    // Al = new DateTime(2022, 6, 21, 0, 0, 0),
                    // Al = DateTime.MinValue,
                    // CodiceCUP = "",
                    // Dal = DateTime.MinValue,
                    IdAnagrafica = new IdBox()
                    {
                        Id = "ACC000120220607458821350000074",
                        IdEsterno = ""
                    },
                    LoadReservations = true,
                    TipoAcqusto = 0,
                    TipoRegalo = 0
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
