namespace SME.Pedagogico.Gestao.WebApp.Models.Auth
{
    public class CredentialModel
    {
        private string _Username { get; set; }
        public string Username { get { return _Username.Trim(); } set { _Username = value; } }
        public string Password { get; set; }
        public string Session { get; set; }
        public string RefreshToken { get; set; }
    }
}