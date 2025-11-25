using API.Data;
using API.Entities;
using API.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   [Authorize]
    public class MembersController(IMemeberRepository memberRepository) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            return Ok( await memberRepository.GetMembersAsync());
        }
 
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>>  GetMmeber(string id)
        {
            var memebr = await memberRepository.GetMemberByIdAsync(id);

            if (memebr == null)
            {
                return NotFound();
            }

            return memebr;
        }

        [HttpGet("{id}/photos")] 
        public async Task<ActionResult<IReadOnlyList<Photo>>> GetMemberPhotos(string id)
        {
            return Ok(await memberRepository.GetPhotosForMemberAsync(id));
        }                                                                                                                                                                                                                                                                                                        

    }
}
