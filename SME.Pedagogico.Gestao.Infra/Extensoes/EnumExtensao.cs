﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace SME.Pedagogico.Gestao.Infra
{
    public static class EnumExtensao
    {
        /// <summary>
        ///     A generic extension method that aids in reflecting
        ///     and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }

        public static IEnumerable<EnumeradoRetornoDto> ListarDto<TEnum>()
            where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new InvalidOperationException();

            return ((TEnum[])Enum.GetValues(typeof(TEnum))).Cast<Enum>().Select(v => new EnumeradoRetornoDto
            {
                Descricao = v.GetAttribute<DisplayAttribute>().Name,
                Id = (int)Convert.ChangeType(v, Enum.GetUnderlyingType(v.GetType()))
            }).ToList();
        }

        public static string Name(this Enum enumValue)
            => enumValue.GetAttribute<DisplayAttribute>().Name;

        public static string ShortName(this Enum enumValue)
            => enumValue.GetAttribute<DisplayAttribute>().ShortName;


        public static string Description(this Enum enumValue)
           => enumValue.GetAttribute<DisplayAttribute>().Description;

        public static IEnumerable<TEnum> Listar<TEnum>()
            where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new InvalidOperationException();

            return ((TEnum[])Enum.GetValues(typeof(TEnum)));
        }


        public static Dictionary<Enum, string> ToDictionary<TEnum>()
            where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new InvalidOperationException();

            return ((TEnum[])Enum.GetValues(typeof(TEnum))).Cast<Enum>().ToDictionary(key => key, value => value.Name());
        }

        public static bool EhUmDosValores(this Enum valorEnum, params Enum[] valores)
        {
            return valores.Contains(valorEnum);
        }
    }
}
