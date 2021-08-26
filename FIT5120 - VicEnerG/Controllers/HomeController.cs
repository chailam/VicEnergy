﻿using FIT5120___VicEnerG.Models;
using GeoJSON.Net.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FIT5120___VicEnerG.Controllers
{
    public class HomeController : Controller
    {
        private VicEnerG_ModelContainer db = new VicEnerG_ModelContainer();

        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public ActionResult Intro()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}