using System;
using System.Collections.Generic;
using HurCoreProj.Service.DTO;
using HurCoreProj.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace HurCoreProj.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly WebServiceHelper _webServiceHelper;

        public NewsController()
        {
            _webServiceHelper = new WebServiceHelper();
        }

        [Route("haberler")]
        public IActionResult Index()
        {
            try
            {
                var model = _webServiceHelper.GetServiceData<IEnumerable<NewContentDto>>("http://localhost:64932/api/contents");

                if (model == null)
                    return NotFound();

                return View(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("haber-{id}")]
        public IActionResult Detail(int id)
        {
            try
            {
                var model = _webServiceHelper.GetServiceData<NewDetailDto>($"http://localhost:64932/api/contents/{id}");

                if (model == null)
                    return NotFound();

                return View(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("amp/haber-{id}")]
        public IActionResult DetailWithAmp(int id)
        {
            try
            {
                var model = _webServiceHelper.GetServiceData<NewDetailDto>($"http://localhost:64932/api/contents/amp/{id}");

                if (model == null)
                    return NotFound();

                return View("Detail", model);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }

}