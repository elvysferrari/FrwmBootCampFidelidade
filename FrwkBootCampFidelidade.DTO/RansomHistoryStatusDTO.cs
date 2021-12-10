using System;

namespace FrwkBootCampFidelidade.DTO
{
    public class RansomHistoryStatusDTO
    {
        public int Id { get; set; }
        public object wallet { get; set; }
        public decimal value { get; set; }
        public DateTime date { get; set; }
    }
}
