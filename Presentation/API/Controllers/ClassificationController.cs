using Application.DataTransferObject;
using Application.Repositories;
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
        private readonly IClassificationReadRepository _classificationReadRepository;
        private readonly IClassificationWriteRepository _classificationWriteRepository;
        private readonly IClassificationAttributeWriteRepository _classificationAttributeWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IUnitReadRepository _unitReadRepository;
        private readonly IMapper _mapper;

        public ClassificationController(IClassificationReadRepository classificationReadRepository, IClassificationWriteRepository classificationWriteRepository,
            IMapper mapper, ICategoryReadRepository categoryReadRepository, IUnitReadRepository unitReadRepository, IClassificationAttributeWriteRepository classificationAttributeWriteRepository)
        {
            _classificationReadRepository = classificationReadRepository;
            _classificationWriteRepository = classificationWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _classificationAttributeWriteRepository = classificationAttributeWriteRepository;
            _unitReadRepository = unitReadRepository;
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

            var classificationAttributes = new HashSet<ClassificationAttribute>();

            classification.ClassificationAttributes = classificationAttributes;

            var result = await _classificationWriteRepository.AddAsync(classification);

            ClassificationAttribute classificationAttribute = new();

            Unit unit = new();

            bool attributeResult = false;
            foreach (var item in classificationDto.ClassificationAttribute)
            {
                unit = _unitReadRepository.GetWhere(x => x.Code == item.Code).FirstOrDefault();
                classificationAttribute.Unit = unit;
                var classifications = new HashSet<Classification>();
                classifications.Add(classification);
                classificationAttribute.Code = Guid.NewGuid().ToString();
                classificationAttribute.Classifications = classifications;
                attributeResult = await _classificationAttributeWriteRepository.AddAsync(classificationAttribute);
            }

            if (!attributeResult)
            {
                return BadRequest();
            }
            else
            {
                return Ok(classification);
            }

        }

        [HttpGet("/classification")]
        public async Task<IActionResult> ClassificationList()
        {
            List<Classification> classification = await _classificationReadRepository.GetAll().ToListAsync();
            return Ok(classification);
        }

        [HttpGet("/classification/{id}")]
        public async Task<IActionResult> ClassificationGetById(int id)
        {
            var classificationGetId = await _classificationReadRepository.GetByIdAsync(id);
            return Ok(classificationGetId);
        }

    }
}
