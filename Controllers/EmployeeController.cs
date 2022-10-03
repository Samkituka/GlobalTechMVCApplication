using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalTech.DataAccess.Models;
using GlobalTech.DataAccess.Context;

namespace GlobalTechMVCApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly GlobalTechDbContext _globalTechDbContext;

        public EmployeeController(GlobalTechDbContext globalTechDbContext)
        {
            _globalTechDbContext = globalTechDbContext;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _globalTechDbContext.Employees.ToListAsync());
        }


        // GET: Employee/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
                return View(_globalTechDbContext.Employees.Find(id));
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EmployeeId,FullName,EmpCode,Position,OfficeLocation")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeId == 0)
                    _globalTechDbContext.Add(employee);
                else
                    _globalTechDbContext.Update(employee);
                await _globalTechDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _globalTechDbContext.Employees.FindAsync(id);
            _globalTechDbContext.Employees.Remove(employee);
            await _globalTechDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
