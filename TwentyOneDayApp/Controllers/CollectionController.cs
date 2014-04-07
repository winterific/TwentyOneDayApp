﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwentyOneDayApp.Models;

namespace TwentyOneDayApp.Controllers
{
    public class CollectionController : BaseController
    {

        [Authorize]
        public ActionResult Index()
        {

            return View(CurrentUser);
        }


        [Authorize]
        public ActionResult Detail(int year, int month, int day)
        {
            try
            {
                var date = new DateTime(year, month, day);
            }
            catch
            {
                return HttpNotFound("No such collection found.");
            }

            var collection = CurrentUser.ContainerCollections.FirstOrDefault(
                    f => f.Date.Year == year && f.Date.Month == month && f.Date.Day == day);
            if (collection == null)
                return HttpNotFound("No such collection found.");

            return View(collection);
        }

    }
}
