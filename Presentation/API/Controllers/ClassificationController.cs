using Application.DataTransferObject;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private readonly IClassificationReadRepository _classificationReadRepository;
        private readonly IClassificationWriteRepository _classificationWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public ClassificationController(IClassificationReadRepository classificationReadRepository, IClassificationWriteRepository classificationWriteRepository, IMapper mapper, ICategoryReadRepository categoryReadRepository)
        {
            _classificationReadRepository = classificationReadRepository;
            _classificationWriteRepository = classificationWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        [HttpPost("/classification")]
        public async Task<IActionResult> AddClassification([FromBody] ClassificationDto classificationDto)
        {
            Classification classification = new();

            classification.Name = classificationDto.Name;
            classification.Code = Guid.NewGuid().ToString();
            classification.DataType = (Domain.Enums.DataType)classificationDto.DataType;

            var category = new HashSet<Category>();
            foreach(var item in classificationDto.Categories)
            {
                var cat = _categoryReadRepository.GetWhere(x => x.Code == item.Code).FirstOrDefault();
                category.Add(cat);
            }

            classification.Categories = category;

            var result = await _classificationWriteRepository.AddAsync(classification);
            if (!result)
            {
                return BadRequest();
            }
            else
            {
                return Ok(classification);
            }

        }
    }
}
