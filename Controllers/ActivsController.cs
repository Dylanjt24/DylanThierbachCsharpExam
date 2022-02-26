using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DylanThierbachCsharpExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DylanThierbachCsharpExam.Controllers
{
    public class ActivsController : Controller
    {
        private readonly ILogger<ActivsController> _logger;

        private DylanThierbachCsharpExamContext db;
        public ActivsController(DylanThierbachCsharpExamContext context)
        {
            db = context;
        }

        public int? uid
        {
            get { return HttpContext.Session.GetInt32("Uid");}
        }

        public bool IsLoggedIn
        {
            get { return uid != null;}
        }

        [HttpGet("/activs")]
        public IActionResult Index()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index", "Home");
            ViewBag.AllActivs = db.Activs
            .Include(a => a.Creator)
            .Include(a => a.ActivParticipants)
            .OrderBy(a => a.Date)
            .ThenBy(a => a.Time)
            // .Where(a => a.Date > DateTime.Now)
            .ToList();
            return View();
        }

        [HttpGet("/activs/new")]
        public IActionResult New()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost("/activs/create")]
        public IActionResult Create(Activ newActiv)
        {
            if (!ModelState.IsValid)
                return View("New");

            newActiv.UserId = (int)uid;
            db.Activs.Add(newActiv);
            db.SaveChanges();
            return RedirectToAction("Show", new {activId = newActiv.ActivId});
        }

        [HttpGet("/activs/{activId:int}")]
        public IActionResult Show(int activId)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index", "Home");
            
            Activ activ = db.Activs
            .Include(a => a.Creator)
            .Include(a => a.ActivParticipants)
            .ThenInclude(ap => ap.User)
            .FirstOrDefault(a => a.ActivId == activId);

            return View(activ);
        }

        [HttpPost("/activs/{activId:int}/delete")]
        public IActionResult Delete(int activId)
        {
            Activ dbActiv = db.Activs.FirstOrDefault(a => a.ActivId == activId);

            if (dbActiv != null)
            {
                db.Activs.Remove(dbActiv);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost("/activs/{activId:int}/participate")]
        public IActionResult Participate(int activId)
        {
            Participant isParticipating = db.Participants
            .FirstOrDefault(p => p.UserId == (int)uid && p.ActivId == activId);

            if (isParticipating == null)
            {
                Participant newParticipant = new Participant
                {
                    UserId = (int)uid,
                    ActivId = activId
                };
                db.Participants.Add(newParticipant);
            }
            else
            {
                db.Participants.Remove(isParticipating);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
