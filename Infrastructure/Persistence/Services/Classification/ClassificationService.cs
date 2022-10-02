using Application.DataTransferObject;
using Application.Repositories;
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
        private readonly IClassificationAttributeWriteRepository _classificationAttributeWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IUnitReadRepository _unitReadRepository;

        public ClassificationService(IClassificationReadRepository classificationReadRepository, IClassificationWriteRepository classificationWriteRepository,
            IClassificationAttributeWriteRepository classificationAttributeWriteRepository, ICategoryReadRepository categoryReadRepository,
            IUnitReadRepository unitReadRepository)
        {
            _classificationReadRepository = classificationReadRepository;
            _classificationWriteRepository = classificationWriteRepository;
            _classificationAttributeWriteRepository = classificationAttributeWriteRepository;
            _categoryReadRepository = categoryReadRepository;
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
    }
}
