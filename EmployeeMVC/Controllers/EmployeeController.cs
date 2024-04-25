using EmployeeMVC.Models.DTOs;
using EmployeeMVC.Services;
using EmployeeMVC.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        //private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service)
        {
           
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
			List<EmployeeDTO> list = new();


			var response = await _service.GetAllAsync();
			if (response != null && response
			.IsSuccess)
			{
				//json to object
				list = JsonConvert.DeserializeObject<List<EmployeeDTO>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		public async Task<IActionResult> Details(int id)
        {
			EmployeeDTO employee = new();


			var response = await _service.GetAsync(id);
			if (response != null && response
			.IsSuccess)
			{
				//json to object
				employee = JsonConvert.DeserializeObject<EmployeeDTO>(Convert.ToString(response.Result));
			}
            return PartialView("DetailsPartialView", employee);
		}

		public async Task<IActionResult> AddEmployee()
        {

			return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeCreateDTO dto)
        {
            if (ModelState.IsValid)
            {

                var response = await _service.CreateAsync(dto);
                if (response != null && response.IsSuccess)
                {

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(dto);
        }



		public async Task<IActionResult> UpdateEmployee(int id)
		{
			var response = await _service.GetAsync(id);
			if (response != null && response.IsSuccess)
			{

				EmployeeDTO model = JsonConvert.DeserializeObject<EmployeeDTO>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO dto)
        {
            if (ModelState.IsValid)
            {
                EmployeeUpdateDTO model = new EmployeeUpdateDTO
                {
                    Id = dto.Id,
                    Gender = (int)dto.Gender,
                    FirstAppointment = dto.FirstAppointment,
                    JobRole = (int)dto.JobRole,
                    Name = dto.Name,
                    StartDate = dto.StartDate,
                    Notes = dto.Notes

                };
                var response = await _service.UpdateAsync(model);
                if (response != null && response.IsSuccess)
                {

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(dto);

        }

		public async Task<IActionResult> DeleteEmployee(int id)
		{
			var response = await _service.GetAsync(id);
			if (response != null && response.IsSuccess)
			{
                await _service.RemoveAsync(id);

                return RedirectToAction("Index");
			}
			return NotFound();
		}


	}
}
