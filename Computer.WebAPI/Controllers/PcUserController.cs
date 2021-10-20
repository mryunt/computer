using Computer.Business.Abstract;
using Computer.Business.Validation.PcUser;
using Computer.DAL.Dtos.PcUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Computer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PcUserController : ControllerBase
    {
        private readonly IPcUserService _pcUserService;
        public PcUserController(IPcUserService pcUserService)
        {
            _pcUserService = pcUserService;
        }
        [HttpGet("GetPcUserList")]
        public async Task<ActionResult<List<GetListPcUserDto>>> GetPcUser()
        {
            try
            {
                return Ok(await _pcUserService.GetPcUserList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPcUserById/{id}")]
        public async Task<ActionResult<GetPcUserDto>> GetPcUserById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Bilgisayar/Kullanıcı ID' si geçersiz!");
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var currentPcUser = await _pcUserService.GetPcUserById(id);
                if (currentPcUser == null)
                {
                    list.Add("Bilgisayar/Kullanıcı ID' si Bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentPcUser;
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddPcUser")]
        public async Task<ActionResult<string>> AddPcUser(AddPcUserDto addPcUserDto)
        {
            var list = new List<string>();
            var validator = new PcUserAddValidator();
            var validationResults = validator.Validate(addPcUserDto);
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
                var result = await _pcUserService.AddPcUser(addPcUserDto);
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
        [HttpPut("UpdatePcUser/{id}")]
        public async Task<ActionResult<string>> UpdatePcUser(int id, UpdatePcUserDto updatePcUserDto)
        {
            var list = new List<string>();
            var validator = new PcUserUpdateValidator();
            var validationResults = validator.Validate(updatePcUserDto);
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
                var result = await _pcUserService.UpdatePcUser(id, updatePcUserDto);
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
        [HttpDelete("DeletePcUser/{id}")]
        public async Task<ActionResult<string>> DeletePcUser(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _pcUserService.DeletePcUser(id);
                if (result > 0)
                {
                    list.Add("Silme İşlemi Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Bilgi Bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
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
