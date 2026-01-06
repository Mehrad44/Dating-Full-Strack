using System;
using API.Entities;
using API.Intefaces;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AdminController(UserManager<AppUser> userManager , IUnitOfWork uow, IPhotoService photoService ) : BaseApiController
{
    [Authorize(Policy = "RequireAdminRole")]
    [HttpGet("users-with-roles")]
    public async Task<ActionResult> GetUsersWithRoles()
    {
        var users = await userManager.Users.ToListAsync();
        var userList = new List<object>();

        foreach ( var user in users)
        {
            var roles = await userManager.GetRolesAsync(user);

            userList.Add(new
            {
                user.Id,
                user.Email,
                Roles = roles.ToList()
            });

         
        }

           return Ok(userList);
    }

    [Authorize(Policy = "RequireAdminRole")]
    [HttpPost("edit-roles/{userId}")]
    public async Task<ActionResult> EditRoles(string userId ,[FromQuery] string roles)
    {
        if (string.IsNullOrEmpty(roles)) return BadRequest("You must select at least one role");

        var selectRoles = roles.Split(",").ToArray();

        var user = await userManager.FindByIdAsync(userId);

        if(user == null) return BadRequest("Could not retrive user");

        var userRoles = await userManager.GetRolesAsync(user);

        var result = await userManager.AddToRolesAsync(user , selectRoles.Except(userRoles));

        if(!result.Succeeded) return BadRequest("Failed to add to roles");

        result = await userManager.RemoveFromRolesAsync(user, userRoles.Except(selectRoles));


        if(!result.Succeeded) return BadRequest("Failed to remove from roles"); ;


        return Ok(await userManager.GetRolesAsync(user));   


    }

    [Authorize(Policy = "ModeratePhotoRole")]
    [HttpGet("photos-to-moderate")]
    public async Task<ActionResult<IEnumerable<Photo>>> GetPhotosForModeration()
    {
       return Ok(await uow.PhotoRepository.GetUnapprovedPhotos());
    }

    [Authorize(Policy = "ModeratePhotoRole")]
    [HttpPost("approve-photo/{photoId}")]
    public async Task<ActionResult> ApprovePhoto(int photoId)
    {
        var photo = await uow.PhotoRepository.GetPhotoById(photoId);
        if (photo == null) return BadRequest("Could not get photo from db");

        var member = await uow.MemeberRepository.GetMemberForUpdate(photo.MemberId);
        if (member == null) return BadRequest("Could not get member");

        photo.IsApproved = true;

        if (member.ImageUrl == null)
        {
            member.ImageUrl = photo.Url;
            member.User.ImageUrl = photo.Url;
        }

        await uow.Complete();
        return Ok();
    }


    [Authorize(Policy = "ModeratePhotoRole")]
    [HttpPost("reject-photo/{photoId}")]
    public async Task<ActionResult> RejectPhoto(int photoId)
    {
        var photo = await uow.PhotoRepository.GetPhotoById(photoId);
        if (photo == null) return BadRequest("Could not get photo from db");

        if (photo.PublicId != null)
        {
            var result = await photoService.DeletPhooAsync(photo.PublicId);
            if (result.Result == "ok")
            {
                uow.PhotoRepository.RemovePhoto(photo);
            }
        }
        else
        {
            uow.PhotoRepository.RemovePhoto(photo);
        }

        await uow.Complete();
        return Ok();
    }




}
