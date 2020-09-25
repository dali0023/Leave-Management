using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Leave_Management.Areas.Contracts;
using Leave_Management.Models;
using Leave_Management.Models.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Management.Controllers.Admin
{
    public class LeaveTypesController : Controller
    {

        // load IRepository and Automappers
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public ActionResult Index()
        {
            var leaveTypes = _repo.FindAll().ToList();
            // put value to LeaveTypeVM's all variable
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveTypes);
            return View(model);
        }

        // GET: LeaveTypes/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var leaveTypes = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leaveTypes);
            return View(model);
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        {
            try
            {
                // Check valid data or not
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // convert or map it from Source object(LeaveType) to a new object;
                var leaveTypes = _mapper.Map<LeaveType>(model);
                // Manually Add time
                leaveTypes.DateCreated = DateTime.Now;

                // add data to database
                var isSuccess = _repo.Create(leaveTypes);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View(model);
            }
        }

        // GET: LeaveTypes/Edit/5
        public ActionResult Edit(int id)
        {
            // check data exits or not
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var leaveTypes = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leaveTypes);
            return View(model);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveTypes = _mapper.Map<LeaveType>(model);
                var isSuccess = _repo.Update(leaveTypes);
                if (!isSuccess)
                {
                    ModelState.AddModelError("","Something went wrong");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int id)
        {
            // TODO: Add delete logic here
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var leaveTypes = _repo.FindById(id);
            var isSuccess = _repo.Delete(leaveTypes);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));

        }

        // POST: LeaveTypes/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, LeaveTypeVM model)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        if (!_repo.IsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        var leaveTypes = _repo.FindById(id);
        //        var isSuccess = _repo.Delete(leaveTypes);
        //        if (!isSuccess)
        //        {
        //            return BadRequest();
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}