using System;
using HurCoreProj.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HurCoreProj.Controllers
{
    [Route("api/[controller]")]
    public class ContentsController : Controller
    {
        private readonly INewService _newService;

        public ContentsController(INewService newService)
        {
            _newService = newService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_newService.GetNewList());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException($"{nameof(id)} parametresi 0'dan büyük olmalı.");

                return Ok(_newService.GetNewById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("amp/{id}")]
        public IActionResult GetWithAmpById(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException($"{nameof(id)} parametresi 0'dan büyük olmalı.");

                return Ok(_newService.GetNewById(id, true));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}