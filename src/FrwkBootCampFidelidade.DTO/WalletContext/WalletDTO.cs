﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FrwkBootCampFidelidade.DTO.WalletContext
{
    public class WalletDTO
    {
        public int Id { get; set; }
        public int DrugstoreId { get; set; }
        public int UserId { get; set; }
        public string CPF { get; set; }
        public int WalletTypeId { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
    }
}
