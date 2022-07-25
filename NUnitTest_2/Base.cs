using Newtonsoft.Json;
using NUnit.Framework;
using System.Threading.Tasks;
using wsAccesso;

namespace AquardensNUnitTest_2
{
    public class Base
    {
        protected string SessionId { get; set; }
        protected const string Impianto = "1303";
        protected iAccessClient AccessClient = new iAccessClient();

        private TestContext testContextInstance;
        
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
            await DoLogin();
        }

        protected void Print(string message)
        {
            TestContext.WriteLine($"{message}");
        }

        protected void Print(object obj)
        {
            string jsonObject = JsonConvert.SerializeObject(obj, Formatting.Indented);
            TestContext.WriteLine($"{jsonObject}");
        }
        
        protected async Task<dcEsito> DoLogin()
        {
            var user = new dcUser()
            {
                UserName = "aquardens",
                Password = "aquardens",
                // UserName = "silvio.berlusconi@forzaitalia.it",
                // Password = "S1lv101910!",
                // UserType = 200
            };
            dcClientInfo clientInfo = new dcClientInfo();
            var esitoLogin = await AccessClient.LoginAsync(Impianto, user, clientInfo);
            SessionId = esitoLogin.SessionId;
            return esitoLogin;
        }
        
        [OneTimeTearDown]
        public void TearDownClientBase()
        {
            AccessClient.Close();
        }
    }
}