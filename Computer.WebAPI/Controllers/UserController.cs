using Computer.Business.Abstract;
using Computer.Business.Validation.User;
using Computer.DAL.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Computer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUserList")]
        public async Task<ActionResult<List<GetListUserDto>>> GetUserList()
        {
            try
            {
                return Ok(await _userService.GetUserList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<GetUserDto>> GetUserById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Kullanıcı ID Geçersiz!");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            try
            {
                var currentUser = await _userService.GetUserById(id);
                if (currentUser == null)
                {
                    list.Add("Kullanıcı Bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentUser;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult<AddUserDto>> AddUser(AddUserDto addUserDto)
        {
            var list = new List<string>();
            var validator = new UserAddValidator();
            var validationResults = validator.Validate(addUserDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            try
            {
                var result = await _userService.AddUser(addUserDto);
                if (result > 0)
                {
                    list.Add("Ekleme İşlemi Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else
                {
                    list.Add("Ekleme İşlemi Başarısız!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult<UpdateUserDto>> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var list = new List<string>();
            var validator = new UserUpdateValidator();
            var validationResults = validator.Validate(updateUserDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            try
            {
                var result = await _userService.UpdateUser(id, updateUserDto);
                if (result > 0)
                {
                    list.Add("Güncelleme İşlemi Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else
                {
                    list.Add("Güncelleme İşlemi Başarısız!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _userService.DeleteUser(id);
                if (result > 0)
                {
                    list.Add("Silme İşlemi Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else
                {
                    list.Add("Silme İşlemi Başarısız!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
