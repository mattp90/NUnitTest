using NUnit.Framework;
using System.Threading.Tasks;
using wsAccesso;

namespace AquardensNUnitTest.Access
{
    public class Access : Base
    {
        [Test]
        public async Task Login()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await AccessClient.LoginAsync(baseRequest, 
                new dcUser()
                {
                    // UserName = "matteo.piazzi@aquest.it",
                    // UserName = "monicaferraresi90@gmail.com",
                    // Password = "Password22",
                    
                    UserName = "piazzi.matteo.test@aquest.it",
                    Password = "Password22", 
                    UserType = 200
                    
                    // UserName = "aquardens",
                    // Password = "aquardens",
                    // UserType = 400
                },
                new dcClientInfo()
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task Logout()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await AccessClient.LogoutAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task Register()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await AccessClient.RegisterAsync(baseRequest,
                new dcUser()
                {
                    Nome = "Monica",
                    Cognome = "Ferraresi",
                    // Cellulare = "123456789",
                    // CodiceFiscale = "PZZMTT90S10M172Z",
                    DataNascita = new System.DateTime(1990, 1, 1),
                    Email = "monica.ferraresi@aquest.it",
                    Password = "Password22",
                    UserName = "monica.ferraresi@aquest.it",
                    UserType = 200
                },
                new dcClientInfo()
                {
                    Device = "",
                    DeviceId = "",
                    OsName = "",
                    OsVersion = "",
                    Type = 0
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task ChangePassword()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await AccessClient.ChangePasswordAsync(baseRequest,
                "oldPassword",
                "newPassword"
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task ConfirmRegister()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await AccessClient.ConfirmRegisterAsync(baseRequest,
                new dcConfirmRequest()
                {
                    Code = "",
                    Type = 200,
                    Username = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetDispositivi()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await AccessClient.GetDispositiviAsync(baseRequest,
                1 // Tipo
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetImpianti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await AccessClient.GetImpiantiAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetPrivacyInfo()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await AccessClient.GetPrivacyInfoAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task RecoveryConfirmCode()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto
                // ,SessionId = SessionId
            };

            var result = await AccessClient.RecoveryConfirmCodeAsync(
                new dcBaseRequest()
                {
                    Impianto = Impianto
                }, 
                new dcConfirmRequest()
                {
                    Type = 200,
                    Username = "marco@maf.it"
                }
            );

            Print(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task RecoveryPassword()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await AccessClient.RecoveryPasswordAsync(baseRequest,
                new dcPasswordRequest()
                {
                    Code = "",
                    NewPassword = "",
                    Username = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
