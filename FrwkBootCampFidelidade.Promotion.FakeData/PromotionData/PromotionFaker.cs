using Bogus;

namespace FrwkBootCampFidelidade.Promotions.FakeData.PromotionData
{
    public class PromotionFaker : Faker<Dominio.PromotionContext.Entities.Promotion>
    {
        public PromotionFaker()
        {
            var id = new Faker().Random.Hexadecimal(24);
            var drugstoreId = new Faker().Random.Number(1, 999999);
            var userId = new Faker().Random.Number(1, 999999);
            RuleFor(x => x.Id, f => id);
            RuleFor(x => x.DrugstoreId, f => drugstoreId);
            RuleFor(x => x.UserId, f => userId);
            RuleFor(x => x.Active, f => f.Random.Bool());
            RuleFor(x => x.Description, f => f.Random.String(15));
            RuleFor(x => x.StartDate, f => f.Date.Past());
            RuleFor(x => x.EndDate, f => f.Date.Past());
            RuleFor(x => x.CreatedAt, f => f.Date.Past());
            RuleFor(x => x.UpdatedAt, f => f.Date.Past());
        }
    }
}
