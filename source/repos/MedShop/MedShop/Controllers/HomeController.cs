﻿using MedShop.Interfaces;
using MedShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MedShop.Controllers
{
    public class HomeController : Controller
    {
        private IAllMedicines _medRep;
        
        
      
        
        public HomeController(IAllMedicines medRep)
        {
            _medRep = medRep;
        }

        
        public ViewResult Index() {
            var homeMeds = new HomeViewModel
            {
                favMeds = _medRep.getFavMeds
            };
            return View(homeMeds);
        }


    }
}
