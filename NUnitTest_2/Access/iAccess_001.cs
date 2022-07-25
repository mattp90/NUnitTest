using NUnit.Framework;
using System.Threading.Tasks;
using wsAccesso;

namespace AquardensNUnitTest_2.Access
{
    public class iAccess_001 : Base001
    {
        protected iAccess_001Client accessClient = new iAccess_001Client();

        [Test]
        public async Task Login()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await accessClient.LoginAsync(baseRequest, 
                new dcUser()
                {
                    Cellulare = "",
                    CodiceFiscale = "",
                    Cognome = "",
                    DataNascita = System.DateTime.MinValue,
                    Email = "",
                    Nome = "",
                    Password = "Password22",
                    UserName = "filippo.filippi@test.com",
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
        public async Task Logout()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await accessClient.LogoutAsync(baseRequest);

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

            var esito = await accessClient.RegisterAsync(baseRequest,
                new dcUser()
                {
                    Nome = "Vasco",
                    Cognome = "Rossi",
                    Cellulare = "123456789",
                    CodiceFiscale = "PZZMTT90S10M172Z",
                    DataNascita = new System.DateTime(1990, 1, 1),
                    Email = "vasco.rossi@test.com",
                    Password = "Password22",
                    UserName = "vasco.rossi@test.com",
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

            var esito = await accessClient.ChangePasswordAsync(baseRequest,
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

            var esito = await accessClient.ConfirmRegisterAsync(baseRequest,
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

            var esito = await accessClient.GetDispositiviAsync(baseRequest,
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

            var esito = await accessClient.GetImpiantiAsync(baseRequest);

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

            var esito = await accessClient.GetPrivacyInfoAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task RecoveryConfirmCode()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await accessClient.RecoveryConfirmCodeAsync(baseRequest, 
                new dcConfirmRequest()
                {
                    Code = "",
                    Type = 0,
                    Username = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task RecoveryPassword()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await accessClient.RecoveryPasswordAsync(baseRequest,
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
