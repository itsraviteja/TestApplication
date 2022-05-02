using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Repository;
using Test.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepository _departrepos;
        public DepartmentController(IDepartmentRepository departrepos)
        {
            _departrepos = departrepos;
        }
        // GET: api/<DepartmentController>
        [Authorize]
        [HttpPost]
        [Route("GetDepartmemtById")]
        public async Task<DepartmemtModel> GetDepartmemtById()
        {
            DepartmemtModel getDetailsResponse = new DepartmemtModel();
            try
            {
                if (ModelState.IsValid)
                {
                    getDetailsResponse = await _departrepos.GetDepartmemtById();
                }
            }
            catch (Exception Ex)
            {
                Ex = null;

            }

            return getDetailsResponse;
        }


        [Authorize]
        [HttpPost]
        [Route("AddUpdateOrDeleteDetails")]
        public async Task<DepartmemtModel> AddUpdateOrDeleteDepartmentDetailsAsync(string name)
        {
            DepartmemtModel addUpdateOrDeleteDetailsResponse = new DepartmemtModel();
            try
            {
                if (ModelState.IsValid)
                {
                    addUpdateOrDeleteDetailsResponse = await _departrepos.AddUpdateOrDeleteDepartmentDetailsAsync(name);
                }
            }
            catch (Exception Ex)
            {
                Ex = null;

            }

            return addUpdateOrDeleteDetailsResponse;
        }
    }
}
