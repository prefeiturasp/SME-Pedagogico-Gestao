namespace SME.Pedagogico.Gestao.Data.DTO
{
    public struct ResetPasswordDTO
    {
        public string Username { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordRepeat { get; set; }
        public string OldPassword { get; set; }
        public string DataPosse { get; set; }
        public string Key { get; set; }
    }
}
