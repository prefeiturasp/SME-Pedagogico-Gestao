using System;

namespace SME.Pedagogico.Gestao.Data.Functionalities
{
    public static class NumberExtensions
    {
        public static bool IsNull(this int value) =>
            value == 0;

        public static bool IsNotNull(this int value) =>
            value != 0;

        public static bool IsNull(this long value) =>
            value == 0;

        public static bool IsNotNull(this long value) =>
            value != 0;
    }
}
