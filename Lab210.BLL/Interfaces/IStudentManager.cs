﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab210.BLL.Interfaces
{
    public interface IStudentManager
    {
        Task<List<string>> ModifyStudent();
    }
}
