using System;

namespace Web.BootCampFidelidade.HttpAggregator.Models.DTO
{
    public class BonificationDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
