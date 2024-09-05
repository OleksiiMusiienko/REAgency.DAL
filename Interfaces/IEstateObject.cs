﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.DAL.Entities.Object;

namespace REAgency.DAL.Interfaces
{
    public interface IEstateObject
    {
        Task<IEnumerable<EstateObject>> GetAll();
        Task<EstateObject> Get(int id);
        Task<IEnumerable<EstateObject>> GetAllByEmployeeId(int id);
        Task Create(EstateObject estateObject);
        void Update(EstateObject estateObject);
        Task Delete(int id);
    }
}