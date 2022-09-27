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
            var category = _mapper.Map<Category>(classificationDto.Categories);
            foreach (var item in classificationDto.Categories)
            {
                Classification classification = new()
                {
                    Name = classificationDto.Name,
                    Code = Guid.NewGuid().ToString(),
                    DataType = (Domain.Enums.DataType)classificationDto.DataType,
                    Categories = new HashSet<CategoriesClassifications>()
                    {
                        new()
                        {
                            CategoryId = item.ParentCategoryId;
                        }
                    }

                };
            }
           
        }
    }
}
