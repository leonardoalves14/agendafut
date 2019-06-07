using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SocietyAgendor.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.UI.Service
{
    public static class Validators
    {
        public struct Cpf
        {
            private readonly string _value;

            public readonly bool EhValido;
            private Cpf(string value)
            {
                _value = value;

                if (value == null)
                {
                    EhValido = false;
                    return;
                }

                var posicao = 0;
                var totalDigito1 = 0;
                var totalDigito2 = 0;
                var dv1 = 0;
                var dv2 = 0;

                bool digitosIdenticos = true;
                var ultimoDigito = -1;

                foreach (var c in value)
                {
                    if (char.IsDigit(c))
                    {
                        var digito = c - '0';
                        if (posicao != 0 && ultimoDigito != digito)
                        {
                            digitosIdenticos = false;
                        }

                        ultimoDigito = digito;
                        if (posicao < 9)
                        {
                            totalDigito1 += digito * (10 - posicao);
                            totalDigito2 += digito * (11 - posicao);
                        }
                        else if (posicao == 9)
                        {
                            dv1 = digito;
                        }
                        else if (posicao == 10)
                        {
                            dv2 = digito;
                        }

                        posicao++;
                    }
                }

                if (posicao > 11)
                {
                    EhValido = false;
                    return;
                }

                if (digitosIdenticos)
                {
                    EhValido = false;
                    return;
                }

                var digito1 = totalDigito1 % 11;
                digito1 = digito1 < 2
                    ? 0
                    : 11 - digito1;

                if (dv1 != digito1)
                {
                    EhValido = false;
                    return;
                }

                totalDigito2 += digito1 * 2;
                var digito2 = totalDigito2 % 11;
                digito2 = digito2 < 2
                    ? 0
                    : 11 - digito2;

                EhValido = dv2 == digito2;
            }

            public static implicit operator Cpf(string value)
                => new Cpf(value);

            public override string ToString() => _value;
        }

        public static bool ValidarCPF(Cpf sourceCPF) =>
            sourceCPF.EhValido;

        public struct Cnpj
        {
            private readonly string _value;

            public readonly bool EhValido;
            static readonly int[] Multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            static readonly int[] Multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            public Cnpj(string value)
            {
                _value = value;

                if (value == null)
                {
                    EhValido = false;
                    return;
                }

                var digitosIdenticos = true;
                var ultimoDigito = -1;
                var posicao = 0;
                var totalDigito1 = 0;
                var totalDigito2 = 0;

                foreach (var c in _value)
                {
                    if (char.IsDigit(c))
                    {
                        var digito = c - '0';
                        if (posicao != 0 && ultimoDigito != digito)
                        {
                            digitosIdenticos = false;
                        }

                        ultimoDigito = digito;
                        if (posicao < 12)
                        {
                            totalDigito1 += digito * Multiplicador1[posicao];
                            totalDigito2 += digito * Multiplicador2[posicao];
                        }
                        else if (posicao == 12)
                        {
                            var dv1 = (totalDigito1 % 11);
                            dv1 = dv1 < 2
                                ? 0
                                : 11 - dv1;

                            if (digito != dv1)
                            {
                                EhValido = false;
                                return;
                            }

                            totalDigito2 += dv1 * Multiplicador2[12];
                        }
                        else if (posicao == 13)
                        {
                            var dv2 = (totalDigito2 % 11);

                            dv2 = dv2 < 2
                                ? 0
                                : 11 - dv2;

                            if (digito != dv2)
                            {
                                EhValido = false;
                                return;
                            }
                        }

                        posicao++;
                    }
                }

                EhValido = (posicao == 14) && !digitosIdenticos;
            }

            public static implicit operator Cnpj(string value)
                => new Cnpj(value);

            public override string ToString()
                => _value;
        }

        public static bool ValidarCNPJ(Cnpj cnpj)
            => cnpj.EhValido;
    }

    public class CPFAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var funcionario = (FuncionarioModel)validationContext.ObjectInstance;
            var cpf = (string)value;

            if (!Validators.ValidarCPF(cpf))
                return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-validacaocpf", GetErrorMessage());
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);
            return true;
        }

        protected string GetErrorMessage()
        {
            return "CPF inválido!";
        }
    }
}
