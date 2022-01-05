﻿using System;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionCreateDTO
    {
        public string Id { get; set; }
        public long DrugstoreId { get; set; }
        public long UserId { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<PromotionItemCreateDTO> PromotionItems { get; set; }
    }
}
