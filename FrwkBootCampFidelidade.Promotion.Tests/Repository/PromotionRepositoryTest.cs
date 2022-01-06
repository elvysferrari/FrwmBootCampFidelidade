﻿using FluentAssertions;
using FrwkBootCampFidelidade.Dominio.Base.Interfaces;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Interfaces;
using FrwkBootCampFidelidade.Infraestrutura.Data.Context;
using FrwkBootCampFidelidade.Infraestrutura.Data.PromotionContext.Repository;
using FrwkBootCampFidelidade.Promotions.FakeData.PromotionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FrwkBootCampFidelidade.Promotion.Tests.Repository
{
    public class PromotionRepositoryTest
    {
        private readonly IMongoContext _mongoContext;
        private readonly IPromotionRepository _promotionRepository;

        public PromotionRepositoryTest()
        {
            _mongoContext = new MongoContext("mongodb://localhost:27017", "testeBd");
            _promotionRepository = new PromotionRepository(_mongoContext);
        }

        private async Task RemoveAllCollection()
        {
            var promotions = await _promotionRepository.GetAll();
            foreach (var promotion in promotions)
            {
                await _promotionRepository.Remove(promotion);
            }
        }

        private async Task<IEnumerable<Dominio.PromotionContext.Entities.Promotion>> InsertDefaultInCollection()
        {
            var promotions = new PromotionFaker().Generate(100);
            foreach (var promotion in promotions)
            {
                promotion.CreatedAt = DateTime.Now;
                promotion.UpdatedAt = DateTime.Now;
                await _promotionRepository.Add(promotion);
            }
            return promotions;
        }

        [Fact]
        public async Task GetAll_Empty()
        {
            await RemoveAllCollection();

            var result = await _promotionRepository.GetAll();
            result.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetAll_NotEmpty()
        {
            await RemoveAllCollection();
            var promotions = await InsertDefaultInCollection();

            var result = await _promotionRepository.GetAll();

            result.Should().BeEquivalentTo(promotions);
        }

        [Fact]
        public async Task GetPromotionByDateRange_Empty()
        {
            await RemoveAllCollection(); 

            var result = await _promotionRepository.GetPromotionByDateRange(
                new Dominio.PromotionContext.Entities.Promotion());

            result.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetPromotionByDateRange_NotEmpty()
        {
            await RemoveAllCollection();
            var promotions = await InsertDefaultInCollection();

            var result = await _promotionRepository.GetPromotionByDateRange(promotions.First());

            result.Should().BeEquivalentTo(promotions.Where(x => x.StartDate >= promotions.First().StartDate &&
                                             x.EndDate >= promotions.First().EndDate &&
                                             x.UserId == promotions.First().UserId &&
                                             x.DrugstoreId == promotions.First().DrugstoreId));
        }

        public async Task GetPromotionToday_Empty()
        {
            await RemoveAllCollection();

            var result = await _promotionRepository.GetPromotionToday(
                new Dominio.PromotionContext.Entities.Promotion());

            result.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetPromotionToday_NotEmpty()
        {
            await RemoveAllCollection();
            var promotions = await InsertDefaultInCollection();

            var result = await _promotionRepository.GetPromotionToday(promotions.First());

            result.Should().BeEquivalentTo(promotions.Where(x => x.StartDate == DateTime.Now &&
                                                                 x.EndDate == DateTime.Now &&
                                                                 x.UserId == promotions.First().UserId &&
                                                                 x.DrugstoreId == promotions.First().DrugstoreId));
        }

        [Fact]
        public async Task GetById_Empty()
        {
            await RemoveAllCollection();

            var result = await _promotionRepository.GetById("aaaaaaaaaaaaaaaaaaaaaaaa");

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetById_NotEmpty()
        {
            await RemoveAllCollection();
            var promotions = await InsertDefaultInCollection();

            var result = await _promotionRepository.GetById(promotions.First().Id);

            result.Should().BeEquivalentTo(promotions.First());
        }
    }
}
