﻿using FrwkBootCampFidelidade.Dominio.BonificationContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Entities;

namespace FrwkBootCampFidelidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonificationController : ControllerBase
    {
        private readonly IBonification _bonification;
        public BonificationController(IBonification bonification)
        {
            _bonification = bonification;
        }

        [HttpGet]
        public async Task<List<Bonification>> GetAll()
        {
            List<Bonification> bonifications = await _bonification.GetAll().ToListAsync();
            return bonifications;
        }
    }
}
