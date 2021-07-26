using ImageManipulation.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using AllowAnonymous = System.Web.Http.AllowAnonymousAttribute;
using ImageManipulation.Model;
using ImageManipulation.BLL;

namespace ImageManipulation.Controllers
{
    public class ImageFilterController : Controller
    {
        //method left anonymous for web api for now..
        [AllowAnonymous]
        [HttpPost]
        public JsonResult HandleImageFilters([FromBody]List<ImageWithEffects> imageWithEffects)
        {
            string status = Share.ReturnStatus.success.ToString();
            List<string> listOfPaths = new ImageFilterBLL().HandleImageFilters(imageWithEffects);
            return Json(new { data = listOfPaths, status });
        }
    }
}