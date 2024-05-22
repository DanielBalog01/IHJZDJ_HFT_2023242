﻿using System.Linq;
using IHJZDJ_HFT_2023242.Models;
using System.Collections.Generic;

namespace IHJZDJ_HFT_2023242.Logic.Interfaces
{
    public interface IOwner
    {
        void Create(Owner item);
        void Delete(int id);
        Owner Read(int id);
        IEnumerable<Owner> ReadAll();
        void Update(Owner item);
    }
}
