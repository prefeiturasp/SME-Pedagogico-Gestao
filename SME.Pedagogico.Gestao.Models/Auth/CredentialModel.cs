namespace SME.Pedagogico.Gestao.WebApp.Models.Auth
{
    public class CredentialModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Session { get; set; }
        public string RefreshToken { get; set; }
    }
}