using Application.DataTransferObject;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {

        private readonly IClassificationService _classificationService;

        public ClassificationController(IClassificationService classificationService)
        {
            _classificationService = classificationService;
        }

        [HttpPost("/classification")]
        public async Task<IActionResult> AddClassification([FromBody] ClassificationDto classificationDto)
        {
           
           var result = await _classificationService.saveClassification(classificationDto);

           if (!result)
           {
                return BadRequest();
           }
           else
           {
                return Ok(true);
           }

        }

        //[HttpGet("/classification")]
        //public async Task<IActionResult> ClassificationList()
        //{
        //    List<Classification> classification = await _classificationReadRepository.GetAll().ToListAsync();
        //    return Ok(classification);
        //}

        //[HttpGet("/classification/{id}")]
        //public async Task<IActionResult> ClassificationGetById(int id)
        //{
        //    var classificationGetId = await _classificationReadRepository.GetByIdAsync(id);
        //    return Ok(classificationGetId);
        //}

    }
}
