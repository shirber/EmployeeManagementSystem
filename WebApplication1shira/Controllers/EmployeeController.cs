using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shira.core.DTOs;
using shira.core.Entities;
using shira.core.services;

namespace shira.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IemployeeServices _service;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IemployeeServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public EmployeeController(IemployeeServices service, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> Get()
        {
            _logger.LogInformation("GET /api/employee - קריאה לכל העובדים");
            var employees = await _service.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> Get(int id)
        {
            var emp = await _service.GetByIdAsync(id);
            if (emp == null) return NotFound();
            return _mapper.Map<EmployeeDTO>(emp);
        }

        [HttpPost]
        public async Task<ActionResult> Post(EmployeeDTO empDto)
        {
            try
            {
                _logger.LogInformation("POST /api/employee - ניסיון להוספת עובד");
                var emp = _mapper.Map<Employee>(empDto);
                await _service.AddAsync(emp);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה ב-POST /api/employee");
                return StatusCode(500, "שגיאה בשרת");
            }
        }


        [HttpPut]
        public async Task<ActionResult> Put(EmployeeDTO empDto)
        {
            try
            {
                _logger.LogInformation("PUT /api/employee - ניסיון לעדכון פרטי עובד");
                var emp = _mapper.Map<Employee>(empDto);
                await _service.UpdateAsync(emp);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה ב-PUT /api/employee");
                return StatusCode(500, "שגיאה בשרת");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DELETE /api/employee - ניסיון למחיקת פרטי עובד");
                await _service.DeleteAsync(id);
                return Ok();
            }


            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה ב-DELETE /api/employee");
                return StatusCode(500, "שגיאה בשרת");
            }
        }
    }
}
