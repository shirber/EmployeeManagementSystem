using Microsoft.AspNetCore.Mvc;
using shira.core.DTOs;
using shira.core.Entities;
using shira.core.services;
using AutoMapper;

namespace shira.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkHourController : ControllerBase
    {
        private readonly IWorkHourService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkHourController> _logger;

        public WorkHourController(IWorkHourService service, IMapper mapper, ILogger<WorkHourController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkHourDTO>> Get()
        {
            _logger.LogInformation("GET /api/workhour - כל הרשומות");
            var result = await _service.GetAllAsync();
            return _mapper.Map<IEnumerable<WorkHourDTO>>(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkHourDTO>> Get(int id)
        {
            _logger.LogInformation($"GET /api/workhour/{id} - בקשה לרשומה בודדת");
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();

            return _mapper.Map<WorkHourDTO>(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post(WorkHourDTO dto)
        {
            try
            {
                _logger.LogInformation("POST /api/workhour - יצירת רשומה חדשה");
                var entity = _mapper.Map<WorkHour>(dto);
                await _service.AddAsync(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה ביצירת רשומת WorkHour");
                return StatusCode(500, "שגיאה בשרת");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(WorkHourDTO dto)
        {
            try
            {
                _logger.LogInformation("PUT /api/workhour - עדכון רשומה");
                var entity = _mapper.Map<WorkHour>(dto);
                await _service.UpdateAsync(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בעדכון WorkHour");
                return StatusCode(500, "שגיאה בשרת");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"DELETE /api/workhour/{id} - מחיקת רשומה");
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה במחיקת WorkHour");
                return StatusCode(500, "שגיאה בשרת");
            }
        }
    }
}
