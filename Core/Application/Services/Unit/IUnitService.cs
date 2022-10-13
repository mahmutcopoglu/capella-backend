using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Unit
{
    public interface IUnitService
    {
        Task<bool> saveUnit(UnitDto unitDto);
    }
}
