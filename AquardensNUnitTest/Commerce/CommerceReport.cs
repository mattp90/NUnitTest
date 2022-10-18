using NUnit.Framework;
using System;
using System.Threading.Tasks;
using wsCommerce;

namespace AquardensNUnitTest.Commerce
{
    public class CommerceReport : Base
    {
        [Test]
        public async Task VoucherList()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var result = await CommerceReportClient.VoucherListAsync(baseRequest,
                new dcReportFilter()
                {
                    // IdAnagrafica = new IdBox()
                    // {
                    //     Id = "ACC000120221003461500330000031"
                    // }
                    CodiceVoucher = new IdBox()
                    {
                        Id = "KTZ7V7IYD6ER0ZA"
                    }
                }
            );

            var esitoDetail = await CommerceReportClient.VoucherDetailAsync(baseRequest,
                new dcVoucherDetailRequest()
                {
                    CodiceVoucher = new IdBox()
                    {
                        Id = "KTZ7V7IWQAWDMKX"
                    }                    
                });

            var esito3 = await CommerceReportClient.VoucherReportAsync(baseRequest,
                new dcReportFilter()
                {
                    CodiceVoucher = new IdBox()
                    {
                        Id = "KTZ7V798U8B6YSW"
                    }
                    // IdAnagrafica = new IdBox()
                    // {
                    //     Id = "ACC000120220607458821350000074"
                    // }
                }
            );

            Print(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAcquisti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var a = await DocumentClient.GetDocumentiAsync(baseRequest,
                new dcDocumentoFilter()
                {
                    Impianto = "1303",
                    DaData = new DateTime(1990, 1, 1),
                    AData = new DateTime(2023, 1, 1),
                    // TipiDocumento = new string[]{ "FAT"},
                    IdAnagrafica = new IdBox()
                    {
                        Id = "ACC000120220805400720160000037"
                    }
                });
            
            Print(a);
            
            var esito = await CommerceReportClient.GetAcquistiAsync(baseRequest,
                new dcAcquistoFilter()
                {
                    // Dal = new DateTime(2022, 6, 20, 0, 0, 0),
                    // Al = new DateTime(2022, 6, 21, 0, 0, 0),
                    // Al = DateTime.MinValue,
                    // CodiceCUP = "",
                    // Dal = DateTime.MinValue,
                    IdAnagrafica = new IdBox()
                    {
                         Id = "ACC000120220805400720160000037"
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
