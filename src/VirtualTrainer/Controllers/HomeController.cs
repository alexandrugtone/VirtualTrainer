﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VirtualTrainer.Models;
using Microsoft.EntityFrameworkCore;
using VirtualTrainer.Data;
using VirtualTrainer.Models.GymViewModels;

namespace VirtualTrainer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SaliFitnessContext _context;

        public HomeController(ILogger<HomeController> logger, SaliFitnessContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            //call functions
            TotalValue();
            CurrentDayValue();
            UsersNumber();
            return View();
        }

        public async Task<ActionResult> UserSubStats()
        {
            IQueryable<GymGroup> data =
                from user in _context.Users
                group user by user.UserSubscription.StartDate into dateGroup
                //group user by starting date into dateGroup
                select new GymGroup()
                {
                    SubscriptionDate = dateGroup.Key,
                    UserCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public async Task<ActionResult> NrUserOnSub()
        {
            IQueryable<NrUserOnSub> data = from user in _context.Users
                                           group user by user.UserSubscription.IdsubscriptionNavigation.SubName into nameGroup
                                           select new NrUserOnSub()
                                           {
                                               subName = nameGroup.Key,
                                               UserCount = nameGroup.Count()
                                           };
            return View(await data.AsNoTracking().ToListAsync());
        }

        private void TotalValue()
        {
            var allInvoices = _context.Invoices.ToArray();
            int sum = 0;
            foreach(var invoice in allInvoices)
            {
                int x = Int32.Parse(invoice.Value);
                sum+= x;
            }
            ViewBag.TotalSum = sum;
        }

        private void CurrentDayValue()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var allInvoices = _context.Invoices.Where(dd => dd.IssuedDate.ToString() == date).ToArray();
            int sum = 0;
            foreach (var invoice in allInvoices)
            {
                int x = Int32.Parse(invoice.Value);
                sum += x;
            }
            ViewBag.CurrentDaySum = sum;
        }

        private void UsersNumber()
        {
            var date = DateTime.Now;
            var stringDate = DateTime.Now.ToString("yyyy-MM-dd");
            var allUsers = _context.UserSubscriptions.ToArray();
            var activeUsers = allUsers.Where(us => us.EndDate > date).ToArray();
            var nonactiveUsers = allUsers.Where(us => us.EndDate < date).ToArray();
            var todayUsers = allUsers.Where(us => us.StartDate.ToString("yyyy-MM-dd") == stringDate).ToArray();
            int sumActive = 0;
            foreach(var user in activeUsers)
            {
                sumActive += 1;
            }
            ViewBag.ActiveUsers = sumActive;

            int sumInactive = 0;
            foreach(var nuser in nonactiveUsers)
            {
                sumInactive += 1;
            }
            ViewBag.InactiveUsers = sumInactive;

            int sumCurrUsers = 0;
            foreach (var user in todayUsers)
            {
                sumCurrUsers += 1;
            }
            ViewBag.TodaysUsers = sumCurrUsers;
        }
    }
}
