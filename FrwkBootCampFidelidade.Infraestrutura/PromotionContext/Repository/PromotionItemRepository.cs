using FrwkBootCampFidelidade.Dominio.Base.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Repository
{
    public class PromotionItemRepository : IPromotionItemRepository
    {
        private readonly IMongoContext _context;

        public PromotionItemRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<PromotionItem> Add(PromotionItem promotionItem)
        {
            await _context.PromotionItems.InsertOneAsync(promotionItem);

            return promotionItem;
        }

        public async Task<bool> Update(PromotionItem promotionItem)
        {
            var updateResult = await _context.PromotionItems.ReplaceOneAsync(
                filter: x => x.Id == promotionItem.Id, replacement: promotionItem);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Remove(PromotionItem promotionItem)
        {
            FilterDefinition<PromotionItem> filter = Builders<PromotionItem>.Filter.Eq(x => x.Id, promotionItem.Id);

            DeleteResult deleteResult = await _context.PromotionItems.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> RemoveById(string id)
        {
            FilterDefinition<PromotionItem> filter = Builders<PromotionItem>.Filter.Eq(x => x.Id, id);

            DeleteResult deleteResult = await _context.PromotionItems.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<PromotionItem>> GetAll()
        {
            return await _context.PromotionItems.Find(x => true).ToListAsync();
        }

        public async Task<PromotionItem> GetById(string id)
        {
            return await _context.PromotionItems.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PromotionItem>> GetPromotionItemsByPromotionId(string promotionId)
        {
            FilterDefinition<PromotionItem> filter = Builders<PromotionItem>.Filter
                .Where(x => x.PromotionId == promotionId);

            return await _context.PromotionItems.Find(filter).ToListAsync();
        }

    }
}
