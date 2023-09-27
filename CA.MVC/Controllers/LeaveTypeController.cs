using CA.MVC.Contracts;
using CA.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CA.MVC.Controllers
{
    [Authorize]
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        // GET: LeaveTypeController1
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypesAsync();
            return View(leaveTypes);
        }

        // GET: LeaveTypeController1/Details/5
        public async Task<ActionResult> Details(Guid Id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetailsAsync(Id);
            return View(leaveType);
        }

        // GET: LeaveTypeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM collection)
        {
            try
            {
                await _leaveTypeService.CreateLeaveType(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypeController1/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetailsAsync(Id);
            return View(leaveType);
        }

        // POST: LeaveTypeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, LeaveTypeVM collection)
        {
            try
            {
                await _leaveTypeService.UpdateLeaveTypeAsync(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypeController1/Delete/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetailsAsync(Id);
            return View(leaveType);
        }

        // POST: LeaveTypeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid Id, LeaveTypeVM leaveTypeVM)
        {
            try
            {
                await _leaveTypeService.DeleteLeaveTypeAsync(Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
