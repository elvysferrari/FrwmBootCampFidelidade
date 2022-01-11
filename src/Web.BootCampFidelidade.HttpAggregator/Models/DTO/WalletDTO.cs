namespace Web.BootCampFidelidade.HttpAggregator.Models.DTO
{
    public class WalletDTO
    {
        public int Id { get; set; }
        public int DrugstoreId { get; set; }
        public int UserId { get; set; }
        public int WalletTypeId { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
    }
}
