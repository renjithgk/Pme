﻿using Pme.Models;
using Pme.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Pme.Controllers
{
    public class PmeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDetailsByAppMapId(string appMapId)
        {
            if (appMapId.Length > 0)
            {
                //Check db and retrieve data
                return Json(new { AppMapPackageId = appMapId, Version = "MyVersion", ProgrameCode = "MyCode", ProgrameVersionCode = "MyProgrameVersionCode" });
            }
            else
            {
                return Json(new { AppMapPackageId = appMapId, Version = "Invalid", ProgrameCode = "Invalid", ProgrameVersionCode = "Invalid" });
            }
        }

        public ActionResult Create()
        {
            var viewModel = new PmeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(PmeViewModel viewModel, IEnumerable<HttpPostedFileBase> files)
        {
            var pme = new Pme.Models.Pme();
            pme.ProgrameCode = viewModel.ProgrameCode;
            pme.ProgrameVersionCode = viewModel.ProgrameVersionCode;
            pme.Version = viewModel.Version;
            pme.AppMapPackageId = viewModel.AppMapPackageId;

            var pmeDetails = new List<PmeDetail>();

            foreach (var item in files)
            {
                var reader = new StreamReader(item.InputStream);
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var pmeDetail = new PmeDetail();
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    pmeDetail.Clocking = values[0];
                    pmeDetail.Cpu = values[1];
                    pmeDetail.Maximum = values[2];
                    pmeDetail.Memory = values[3];
                    pmeDetail.Minimum = values[4];
                    pmeDetail.Threshold = values[5];
                    pmeDetails.Add(pmeDetail);
                }
            }

            DAL.PmeContext context = new DAL.PmeContext();
            context.Save(pme, pmeDetails);

            return View();
        }
    }
}