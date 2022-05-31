using Lab210.BLL.Interfaces;
using Lab210.DAL;
using Lab210.DAL.Interfaces;
using Lab210.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab210.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentV2Controller : ControllerBase
    {
        private readonly IStudentManager _studentManager;

        public StudentV2Controller(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        [HttpGet("get-modify")]
        public async Task<IActionResult> GetModify()
        {
            var list = await _studentManager.ModifyStudent();
            return Ok(list);
        }

    }
}
