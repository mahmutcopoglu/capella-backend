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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;

        }
      
        [HttpPost("/category")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.Code = Guid.NewGuid().ToString();
            var result = await _categoryWriteRepository.AddAsync(category);
            if (!result)
            {
                return BadRequest();
            }
            else
            {
                return Ok(category);
            }
        }
        

        [HttpGet("/category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryReadRepository.GetWhereWithInclude(x=>x.Id==id,true,x=>x.SubCategories,x=>x.ParentCategory).FirstOrDefaultAsync();
            return Ok(category);
        }

        [HttpGet("/categories")]
        public async Task<IActionResult> CategoryList()
        {
            List<Category> categories = await _categoryReadRepository.GetAllWithInclude(true, x => x.SubCategories, x => x.ParentCategory).ToListAsync();
            return Ok(categories);
        }

    }
}
