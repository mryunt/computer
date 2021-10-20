using Computer.Business.Abstract;
using Computer.Business.Validation.Pc;
using Computer.DAL.Dtos.Pc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Computer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PcController : ControllerBase
    {
        private readonly IPcService _pcService;
        public PcController(IPcService pcService)
        {
            _pcService = pcService;
        }
        [HttpGet("GetPcList")]
        public async Task<ActionResult<List<GetListPcDto>>> GetPcList()
        {
            try
            {
                return Ok(await _pcService.GetPcList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPcById/{id}")]
        public async Task<ActionResult<GetPcDto>> GetPcById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Bilgisayar ID' si Geçersiz!");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            try
            {
                var currentPc = await _pcService.GetPcById(id);
                if (currentPc == null)
                {
                    list.Add("Bilgisayar Bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentPc;
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddPc")]
        public async Task<ActionResult<string>> AddPc(AddPcDto addPcDto)
        {
            var list = new List<string>();
            var validator = new PcAddValidator();
            var validationResults = validator.Validate(addPcDto);
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
                var result = await _pcService.AddPc(addPcDto);
                if (result > 0)
                {
                    list.Add("Kayıt İşlemi Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else
                {
                    list.Add("Kayıt İşlemi Başarısız!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdatePc/{id}")]
        public async Task<ActionResult<string>> UpdatePc(int id, UpdatePcDto updatePcDto)
        {
            var list = new List<string>();
            var validator = new PcUpdateValidator();
            var validationResults = validator.Validate(updatePcDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add("Güncelleme İşlemi Başarısız!");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            try
            {
                var result = await _pcService.UpdatePc(id, updatePcDto);
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
        [HttpDelete("DeletePc/{id}")]
        public async Task<ActionResult<string>> DeletePc(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _pcService.DeletePc(id);
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
