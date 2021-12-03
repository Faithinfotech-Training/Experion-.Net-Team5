using CMSApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public interface IMedicineRepo
    {
        Task<int> AddMedicine(TbllMedicines medicine);

        Task<List<TbllMedicines>> GetMedicines();

        Task<TbllMedicines> UpdateMedicine(TbllMedicines staff);

        Task<ActionResult<TbllMedicines>> GetMedicineById(int medicineId);
    }
}
