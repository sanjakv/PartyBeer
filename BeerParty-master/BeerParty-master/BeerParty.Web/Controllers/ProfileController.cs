﻿using BeerParty.BL.Dto;
using BeerParty.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BeerParty.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : BaseController
    {
        private readonly ApplicationContext _context;

        public ProfileController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("get-profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = long.TryParse(userIdString, out var parsedUserId) ? parsedUserId : (long?)null;

            if (userId == null)
            {
                return Unauthorized("Пользователь не авторизован");
            }

            var profile = await _context.Profiles
                .Where(p => p.UserId == userId)
                .Select(p => new
                {
                    p.FirstName,
                    p.LastName,
                    p.Bio,
                    p.Location,
                    p.DateOfBirth,
                    p.Gender,
                    p.LookingFor, // Добавлено для отображения цели поиска
                    PhotoUrl = p.PhotoUrl ?? "default_photo_url"
                })
                .SingleOrDefaultAsync();

            if (profile == null)
            {
                return NotFound("Профиль не найден");
            }

            return Ok(profile);
        }

        [HttpPut("update-profile")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateProfile([FromForm] ProfileUpdateDto model)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(userIdString, out var userId))
            {
                return Unauthorized("Пользователь не авторизован");
            }

            var profile = await _context.Profiles.SingleOrDefaultAsync(p => p.UserId == userId);
            if (profile == null)
            {
                return NotFound("Профиль не найден");
            }

            // Обновление полей профиля
            if (!string.IsNullOrEmpty(model.FirstName))
            {
                profile.FirstName = model.FirstName;
            }

            if (!string.IsNullOrEmpty(model.LastName))
            {
                profile.LastName = model.LastName;
            }

            if (!string.IsNullOrEmpty(model.Bio))
            {
                profile.Bio = model.Bio;
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                profile.Location = model.Location;
            }

            if (model.DateOfBirth != default(DateTime))
            {
                profile.DateOfBirth = model.DateOfBirth;
            }

            if (model.Gender.HasValue)
            {
                profile.Gender = model.Gender.Value;
            }

            // Обновление цели поиска
            if (model.Preference.HasValue)
            {
                profile.LookingFor = model.Preference.Value; // Присвоение цели поиска
            }

            // Обработка загрузки фото
            if (model.Photo != null && model.Photo.Length > 0)
            {
                try
                {
                    var firstNameInitial = profile.FirstName.Substring(0, 1).ToUpper();
                    var lastNameInitial = profile.LastName.Substring(0, 1).ToUpper();

                    var fileName = $"{firstNameInitial}{lastNameInitial}_{userId}{Path.GetExtension(model.Photo.FileName)}";
                    var userFolder = Path.Combine(Directory.GetCurrentDirectory(), "..", "BeerParty.Data", "Uploads", "ProfilePictures", userId.ToString());
                    var filePath = Path.Combine(userFolder, fileName);

                    if (!Directory.Exists(userFolder))
                    {
                        Directory.CreateDirectory(userFolder);
                    }

                    if (!string.IsNullOrEmpty(profile.PhotoUrl))
                    {
                        var oldPhotoPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "BeerParty.Data", "Uploads", "ProfilePictures", userId.ToString(), Path.GetFileName(profile.PhotoUrl));
                        if (System.IO.File.Exists(oldPhotoPath))
                        {
                            System.IO.File.Delete(oldPhotoPath);
                        }
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Photo.CopyToAsync(stream);
                    }

                    profile.PhotoUrl = $"{Request.Scheme}://{Request.Host}/uploads/ProfilePictures/{userId}/{fileName}";
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Ошибка при загрузке фото: {ex.Message}");
                }
            }

            // Обновление интересов
            profile.Interests.Clear();
            if (model.InterestIds != null && model.InterestIds.Any())
            {
                foreach (var interestId in model.InterestIds)
                {
                    var interest = await _context.Interests.FindAsync(interestId);
                    if (interest != null)
                    {
                        profile.Interests.Add(interest);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return Ok("Профиль обновлён");
        }

    }
}
