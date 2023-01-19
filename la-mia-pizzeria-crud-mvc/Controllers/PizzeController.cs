using la_mia_pizzeria_crud_mvc.Database;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class PizzeController : Controller
    {

        public IActionResult Index()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizze> ListaDellePizze = db.Pizza.ToList<Pizze>();
                return View("Index", ListaDellePizze);
            }

        }

        public IActionResult Details(int id)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {

                Pizze pizzeTrovate = db.Pizza
                    .Where(PizzaNelDB => PizzaNelDB.Id == id)
                    .FirstOrDefault();



                if (pizzeTrovate != null)
                {
                    return View(pizzeTrovate);
                }

                return NotFound("La pizza con l'id inserito non esiste!");

            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Crea");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizze formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Crea", formData);
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                db.Pizza.Add(formData);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizze PizzaToUpdate = db.Pizza.Where(Pizza => Pizza.Id == id).FirstOrDefault();

                if (PizzaToUpdate == null)
                {
                    return NotFound("La pizza non è stata trovata");
                }

                return View("Update", PizzaToUpdate);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Pizze formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", formData);
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizze PizzaToUpdate = db.Pizza.Where(Pizza => Pizza.Id == formData.Id).FirstOrDefault();

                if (PizzaToUpdate != null)
                {
                    PizzaToUpdate.Pizza = formData.Pizza;
                    PizzaToUpdate.Descrizione = formData.Descrizione;
                    PizzaToUpdate.Immagine = formData.Immagine;
                    PizzaToUpdate.Prezzo = formData.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("La Pizza che volevi modificare non è stata trovata!");
                }
            }

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizze PizzaToDelete = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (PizzaToDelete != null)
                {
                    db.Pizza.Remove(PizzaToDelete);
                    db.SaveChanges();

                    return Index();
                }
                else
                {
                    return NotFound("La pizza da eliminare non è stata trovata!");
                }
            }
        }
    }
}