using NUnit.Framework;
using System;
using System.Threading.Tasks;
using wsCommerce;

namespace AquardensNUnitTest.Commerce
{
    public class CommerceFirmaDigitale : Base
    {
        [Test]
        public async Task GetSelfSignTexts()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await FirmaDigitaleClient.GetSelfSignTextsAsync(baseRequest,
                new dcSelfSignTextFilter()
                {
                    DataAl = null,
                    DataDal = null,
                    IdAnagrafica = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    IdDispositivo = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    IdSelfSignText = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task SetSelfSignText()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await FirmaDigitaleClient.SetSelfSignTextAsync(baseRequest,
                new dcSelfSignText()
                {
                    Anagrafica = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    DataCreazione = DateTime.MinValue,
                    DataFirma = null,
                    Firma = null,
                    IsAzienda = false,
                    Lingua = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    Logo = null,
                    SelfSignText = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    SelfSignTextRighe = new dcSelfSignTextRow[]
                    {
                        new dcSelfSignTextRow()
                        {
                            AbilitaFirmaPrivacy = false,
                            FirmaPrivacy = null,
                            IdFlagPrivacy = new IdBox()
                            {
                                Id = "",
                                IdEsterno = ""
                            },
                            SelfSignTextAnag = new dcSelfSignTextAnag[]
                            {
                                new dcSelfSignTextAnag()
                                {
                                    Descrizione = "",
                                    IsModificabile = false,
                                    TipoCampoAnag = 0,
                                    TipoValoreCampo = 0,
                                    ValoreBool = false,
                                    ValoreData = DateTime.MinValue,
                                    ValoreIntero = 0,
                                    ValoreStringa = ""
                                }
                            },
                            Testo = "",
                            TipoCampoPrivacy = 0,
                            TipoRiga = 0,
                            Titolo = "",
                            ValorePrivacy = true
                        }
                    },
                    Titolo = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
