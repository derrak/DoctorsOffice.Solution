using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class SpecialtiesController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public SpecialtiesController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Specialty> model = _db.Specialties.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Specialty Specialty)
    {
      _db.Specialties.Add(Specialty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDoctor = _db.Specialties
          .Include(Specialty => Specialty.JoinEntities)
          .ThenInclude(join => join.Specialty)
          .FirstOrDefault(Specialty => Specialty.SpecialtyId == id);
      return View(thisDoctor);
    }
    public ActionResult Edit(int id)
    {
      var thisDoctor = _db.Specialties.FirstOrDefault(Specialty => Specialty.SpecialtyId == id);
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult Edit(Specialty Specialty)
    {
      _db.Entry(Specialty).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisDoctor = _db.Specialties.FirstOrDefault(Specialty => Specialty.SpecialtyId == id);
      return View(thisDoctor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDoctor = _db.Specialties.FirstOrDefault(Specialty => Specialty.SpecialtyId == id);
      _db.Specialties.Remove(thisDoctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}