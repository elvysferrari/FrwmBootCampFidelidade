﻿using System;

namespace FrwkBootCampFidelidade.Dominio.RansomContext.Entities
{
    public class Ransom
    {
        public long Id { get; set; }

        public long WalletId { get; set; }

        public long Amount { get; set; }

        public DateTime Date { get; set; }

        public string Beneficiary { get; set; }

        public string Cpf { get; set; }

        public string PixKeyType { get; set; }

        public string PixKey { get; set; }

        public string BankNumber { get; set; }

        public string Agency { get; set; }

        public string BankAccountNumber { get; set; }

        public string Operation { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
