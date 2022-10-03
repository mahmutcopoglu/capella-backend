using Application.DataTransferObject;
using Application.Repositories;
using Application.Repositories.ProductAbstract;
using Application.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class ClassificationService : IClassificationService
    {
        private readonly IClassificationReadRepository _classificationReadRepository;
        private readonly IClassificationWriteRepository _classificationWriteRepository;
        private readonly IClassificationAttributeReadRepository _classificationAttributeReadRepository;
        private readonly IClassificationAttributeWriteRepository _classificationAttributeWriteRepository;
        private readonly IClassificationAttributeValueWriteRepository _classificationAttributeValueWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IUnitReadRepository _unitReadRepository;

        public ClassificationService(IClassificationReadRepository classificationReadRepository, IClassificationWriteRepository classificationWriteRepository,
            IClassificationAttributeWriteRepository classificationAttributeWriteRepository, ICategoryReadRepository categoryReadRepository,IClassificationAttributeReadRepository classificationAttributeReadRepository,
            IUnitReadRepository unitReadRepository, IProductReadRepository productReadRepository, IClassificationAttributeValueWriteRepository classificationAttributeValueWriteRepository)
        {
            _classificationReadRepository = classificationReadRepository;
            _classificationWriteRepository = classificationWriteRepository;
            _classificationAttributeReadRepository = classificationAttributeReadRepository;
            _classificationAttributeWriteRepository = classificationAttributeWriteRepository;
            _classificationAttributeValueWriteRepository = classificationAttributeValueWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _productReadRepository = productReadRepository;
            _unitReadRepository = unitReadRepository;
        }
        public async Task<bool> saveClassification(ClassificationDto classificationDto)
        {
            Classification classification = new();

            classification.Name = classificationDto.Name;
            classification.Code = Guid.NewGuid().ToString();
            classification.DataType = (Domain.Enums.DataType)classificationDto.DataType;
            using(var transaction = await _classificationWriteRepository.DbTransactional())
            {
                var category = new HashSet<Category>();
                foreach (var item in classificationDto.Categories)
                {
                    var cat = _categoryReadRepository.GetWhere(x => x.Code == item.Code).FirstOrDefault();
                    category.Add(cat);
                }
                classification.Categories = category;

                var classificationAttributes = new HashSet<ClassificationAttribute>();

                classification.ClassificationAttributes = classificationAttributes;

                var result = await _classificationWriteRepository.AddAsync(classification);
                if (!result)
                {
                    return false;
                }

                foreach (var item in classificationDto.ClassificationAttribute)
                {
                    Unit unit = new();
                    unit = _unitReadRepository.GetWhere(x => x.Code == item.Code).FirstOrDefault();
                    bool Attributeresult = await saveClassificationAttribute(classification, unit);
                    if (!Attributeresult)
                    {
                        return false;
                    }
                }


                transaction.CommitAsync();


            }
            return true;

        }

        public async Task<bool> saveClassificationAttribute(Classification classification, Unit unit)
        {
            ClassificationAttribute classificationAttribute = new();
            classificationAttribute.Code = Guid.NewGuid().ToString();
            classificationAttribute.Unit = unit;
            classificationAttribute.Classifications.Add(classification);
            return await _classificationAttributeWriteRepository.AddAsync(classificationAttribute);
        }

        public async Task<bool> saveClassificationAttributeValue(ClassificationAttributeValueDto classificationAttributeValueDto)
        {
            ClassificationAttributeValue classificationAttributeValue = new();
            var classificationAttributeCode = classificationAttributeValueDto.ClassificationAttribute.Code;
            ClassificationAttribute classificationAttribute = new();
            classificationAttribute = _classificationAttributeReadRepository.GetWhere(x => x.Code == classificationAttributeCode).FirstOrDefault();
            classificationAttributeValue.ClassificationAttribute = classificationAttribute;
            Product product = new();
            var productCode = classificationAttributeValueDto.ProductCode;
            product = _productReadRepository.GetWhere(x => x.Code == productCode).FirstOrDefault();
            classificationAttributeValue.Products.Add(product);
            return await _classificationAttributeValueWriteRepository.AddAsync(classificationAttributeValue);
        }
    }
}
