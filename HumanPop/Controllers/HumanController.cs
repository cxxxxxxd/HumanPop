﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using HumanPop.Services.Interfaces;
using HumanPop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;



namespace HumanPop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]    
    public class HumanController : Controller
    {        
        IHumanService _humanService;
        IIdentityService _identityService;

        public HumanController(IHumanService humanService, IIdentityService identityService)
        {
            _humanService = humanService;
            _identityService = identityService;
        }

        [Route("page")]
        [HttpGet]
        public async Task<Page<HumansViewModels>> GetHumans(int pageIndex)
        {
            var user = await _identityService.GetUser(User.Identity.Name);
            int userId = user.UserId;
            return await _humanService.GetHumans(pageIndex, userId);
        }

        [Route("human")]
        [HttpGet]
        public async Task<Human> GetHuman(int humanId)
        {
            return await _humanService.GetHuman(humanId);
        }

        [Route("human")]
        [HttpPost]
        public async Task AddHuman([FromBody] AddHumanRequest request)
        {            
            await _humanService.AddHuman(request);            
        }

        [Route("human")]
        [HttpPut]
        public async Task EditProject([FromBody] EditHumanRequest request)
        {            
            await _humanService.EditHuman(request);
        }

        [Route("human")]
        [HttpDelete]
        public async Task DeleteHuman(int humanId)
        {
            await _humanService.DeleteHuman(humanId);
        }
    }
}