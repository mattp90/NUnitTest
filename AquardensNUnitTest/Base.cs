using Newtonsoft.Json;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using wsAccesso;
using wsAnagrafica;
using wsCommerce;
using wsListini;
using wsReservation;
using dcEsito = wsAccesso.dcEsito;
using iElenchi_001Client = wsAnagrafica.iElenchi_001Client;

namespace AquardensNUnitTest
{
    public class Base
    {
        protected string SessionId { get; set; }
        protected string Impianto { get; set; }
        protected string UsernameSudo { get; set; }
        protected string PasswordSudo { get; set; }
        protected string UserTypeSudo { get; set; }
        protected string ZucchettiClientId { get; set; }
        protected TestContext testContextInstance;
        protected IConfiguration configurations;

        protected iAccess_001Client AccessClient;
        protected iGestione_001Client GestioneAnagraficaClient;
        protected iElenchi_001Client ElenchiAnagraficaClient;
        protected iCommerce_001Client CommerceClient;
        protected iDocumentiClient DocumentClient;
        protected iReport_001Client CommerceReportClient;
        protected iReport_002Client CommerceReport002Client;
        protected iFirmaDigitaleClient FirmaDigitaleClient;
        protected iElenchi_002Client ElenchiListiniClient;
        protected iElenchi_003Client ElenchiListini003Client;
        protected iBooking_002Client BookingClient;
        protected iBookingConfigClient BookingConfigClient;
        protected iCommonElenchi_001Client BookingCommonElenchiClient;
        protected iCommonListsClient BookingCommonListClient;
        protected iPlanningAgende_001Client BookingPlanningAgendeClient;
        protected iPlanningCommon_001Client BookingPlanningCommonClient;
        protected iPlanningCorsiClient BookingPlanningCorsiClient;
        protected iReservationConfigClient BookingReservationConfigClient;
        
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [SetUp]
        public async Task Setup()
        {
            configurations = InitConfiguration();
            InitializeClients();

            ZucchettiClientId = configurations.GetValue<string>("ZucchettiClientId");
            UsernameSudo = configurations.GetValue<string>("ZucchettiCredentials:Username");
            PasswordSudo = configurations.GetValue<string>("ZucchettiCredentials:Password");
            UserTypeSudo = configurations.GetValue<string>("ZucchettiCredentials:UserType");
            Impianto = configurations.GetValue<string>("ZucchettiImpianto");
            
            await DoLogin();
        }
        
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables() 
                .Build();
            return config;
        }

        protected void Print(object esito)
        {
            var responseJson = JsonConvert.SerializeObject(esito, Formatting.Indented);
            TestContext.WriteLine($"{responseJson}");
        }
        
        protected async Task<dcEsito> DoLogin()
        {
            var user = new dcUser()
            {
                UserName = UsernameSudo,
                Password = PasswordSudo,
                UserType = int.Parse(UserTypeSudo)
                
                // UserName = "marco.marchi@test.com",
                // Password = "Password22", 
                // UserType = 200
            };

            var clientInfo = new dcClientInfo()
            {
                Device = "smartphone",
                OsName = "Windows",
                OsVersion = "10.0"
            };

            var esito = await AccessClient.LoginAsync(new wsAccesso.dcBaseRequest()
            {
                Impianto = Impianto
            }, user, clientInfo);

            SessionId = esito.SessionId;
            return esito;
        }
        
        public void InitializeClients()
        {
            AccessClient = new iAccess_001Client(iAccess_001Client.EndpointConfiguration.BasicHttpBinding_iAccess_001, 
                configurations.GetValue<string>("UrlsClient:UrlAccesso"));
            ElenchiAnagraficaClient =
                new iElenchi_001Client(iElenchi_001Client.EndpointConfiguration.BasicHttpBinding_iElenchi_001,
                    configurations.GetValue<string>("UrlsClient:UrlAnagrafica"));

            GestioneAnagraficaClient = new iGestione_001Client(
                iGestione_001Client.EndpointConfiguration.BasicHttpBinding_iGestione_001, configurations.GetValue<string>("UrlsClient:UrlAnagrafica"));

            CommerceClient = new iCommerce_001Client(iCommerce_001Client.EndpointConfiguration.BasicHttpBinding_iCommerce_001,
                    configurations.GetValue<string>("UrlsClient:UrlCommerce"));

            CommerceReportClient = new iReport_001Client(iReport_001Client.EndpointConfiguration.BasicHttpBinding_iReport_001,
                configurations.GetValue<string>("UrlsClient:UrlCommerce"));
                
            DocumentClient = new iDocumentiClient(iDocumentiClient.EndpointConfiguration.BasicHttpBinding_iDocumenti,
                configurations.GetValue<string>("UrlsClient:UrlCommerce"));
            
            CommerceReport002Client = new iReport_002Client(iReport_002Client.EndpointConfiguration.BasicHttpBinding_iReport_002, 
                configurations.GetValue<string>("UrlsClient:UrlCommerce"));
            
            FirmaDigitaleClient = new iFirmaDigitaleClient(iFirmaDigitaleClient.EndpointConfiguration.BasicHttpBinding_iFirmaDigitale, 
                configurations.GetValue<string>("UrlsClient:UrlCommerce"));
            
            ElenchiListiniClient = new iElenchi_002Client(iElenchi_002Client.EndpointConfiguration.BasicHttpBinding_iElenchi_002,
                    configurations.GetValue<string>("UrlsClient:UrlListini"));

            ElenchiListini003Client = new iElenchi_003Client(iElenchi_003Client.EndpointConfiguration.BasicHttpBinding_iElenchi_003,
                configurations.GetValue<string>("UrlsClient:UrlListini"));

            BookingClient = new iBooking_002Client(iBooking_002Client.EndpointConfiguration.BasicHttpBinding_iBooking_002,
                configurations.GetValue<string>("UrlsClient:UrlReservation"));

            BookingConfigClient = new iBookingConfigClient(iBookingConfigClient.EndpointConfiguration.BasicHttpBinding_iBookingConfig,
                configurations.GetValue<string>("UrlsClient:UrlReservation"));
            
            BookingCommonElenchiClient = new iCommonElenchi_001Client(iCommonElenchi_001Client.EndpointConfiguration.BasicHttpBinding_iCommonElenchi_001,
                configurations.GetValue<string>("UrlsClient:UrlReservation"));
            
            BookingCommonListClient = new iCommonListsClient(iCommonListsClient.EndpointConfiguration.BasicHttpBinding_iCommonLists,
                configurations.GetValue<string>("UrlsClient:UrlReservation"));
            
            BookingPlanningAgendeClient = new iPlanningAgende_001Client(iPlanningAgende_001Client.EndpointConfiguration.BasicHttpBinding_iPlanningAgende_001,
                configurations.GetValue<string>("UrlsClient:UrlReservation"));
            
            BookingPlanningCommonClient = new iPlanningCommon_001Client(iPlanningCommon_001Client.EndpointConfiguration.BasicHttpBinding_iPlanningCommon_001,
                configurations.GetValue<string>("UrlsClient:UrlReservation"));
            
            BookingPlanningCorsiClient = new iPlanningCorsiClient(iPlanningCorsiClient.EndpointConfiguration.BasicHttpBinding_iPlanningCorsi,
                configurations.GetValue<string>("UrlsClient:UrlReservation"));
            
            BookingReservationConfigClient = new iReservationConfigClient(iReservationConfigClient.EndpointConfiguration.BasicHttpBinding_iReservationConfig,
                configurations.GetValue<string>("UrlsClient:UrlReservation"));
        }
        
        [OneTimeTearDown]
        public async Task TearDownClientBase()
        {
            await AccessClient.CloseAsync();
            await GestioneAnagraficaClient.CloseAsync();
            await ElenchiAnagraficaClient.CloseAsync();
            await CommerceClient.CloseAsync();
            await DocumentClient.CloseAsync();
            await CommerceReportClient.CloseAsync();
            await CommerceReport002Client.CloseAsync();
            await FirmaDigitaleClient.CloseAsync();
            await ElenchiListiniClient.CloseAsync();
            await ElenchiListini003Client.CloseAsync();
            await BookingClient.CloseAsync();
            await BookingConfigClient.CloseAsync();
            await BookingCommonElenchiClient.CloseAsync();
            await BookingCommonListClient.CloseAsync();
            await BookingPlanningAgendeClient.CloseAsync();
            await BookingPlanningCommonClient.CloseAsync();
            await BookingPlanningCorsiClient.CloseAsync();
            await BookingReservationConfigClient.CloseAsync();
        }
    }
}