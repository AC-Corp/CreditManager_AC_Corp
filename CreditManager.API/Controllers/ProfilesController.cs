using AutoMapper;
using CreditManager.API.Domain.Services;
using CreditManager.API.Extensions;
using CreditManager.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using CreditManager.API.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Profile = CreditManager.API.Domain.Models.Profile;

namespace CreditManager.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProfilesController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public ProfilesController(IProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProfileResource>> GetAllAsync()
        {
            var profiles = await _profileService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<CreditManager.API.Domain.Models.Profile>, IEnumerable<ProfileResource>>(profiles);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var profile = _mapper.Map<SaveProfileResource, Profile>(resource);
            var result = await _profileService.SaveAsync(profile);
            if (!result.Success)
                return BadRequest(result.Message);
            var profileResource = _mapper.Map<Profile, ProfileResource>(result.Resource);
            return Ok(profileResource);
        }
    }
}
