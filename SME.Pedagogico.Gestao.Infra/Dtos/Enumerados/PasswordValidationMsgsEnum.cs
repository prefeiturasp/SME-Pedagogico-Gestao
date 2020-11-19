using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Infra
{
    public class PasswordValidationMsgsEnum : BaseEnum<PasswordValidationMsgsEnum, string>
    {
        public static PasswordValidationMsgsEnum WRONG_OLD_PASSWORD = 
            new PasswordValidationMsgsEnum(1, "Sua antiga senha foi digitada errado.");
        public static PasswordValidationMsgsEnum PASSWORDS_CONFIRMATION_DIFF = 
            new PasswordValidationMsgsEnum(2, "Para criar sua nova senha os dois campos devem ser iguais.");
        public static PasswordValidationMsgsEnum PASSWORD_INSUFFICIENT_COMPLEXITY = 
            new PasswordValidationMsgsEnum(3, "Sua senha deve ter, ao menos, 8 caracteres. Dos quais, pelo menos uma letra maiúscula, uma letra minúscula, um número e um caracter especial.");

        protected PasswordValidationMsgsEnum(int code, string text) : base(code, text)
        {
        }
    }
}
