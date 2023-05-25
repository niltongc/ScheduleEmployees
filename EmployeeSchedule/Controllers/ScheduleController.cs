using AutoMapper;
using EmployeeSchedule.Models.Domain;
using EmployeeSchedule.Models.DTO;
using EmployeeSchedule.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EmployeeSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository scheduleRepository;
        private readonly IMapper mapper;

        public ScheduleController(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            this.scheduleRepository = scheduleRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDate([FromBody] AddScheduleRequestDto addScheduleRequestDto)
        {
           
            var scheduleDomainModel = mapper.Map<Schedule>(addScheduleRequestDto);

            scheduleDomainModel = await scheduleRepository.CreateDateAsync(scheduleDomainModel);

            var scheduleDtoModel = mapper.Map<ScheduleDto>(scheduleDomainModel);

            return Ok(scheduleDtoModel);
        }

        [HttpPut]
        [Route("{ids}")]
        public async Task<IActionResult> CreateOtherDates([FromRoute] List<int> ids, [FromBody] List<UpdateScheduleRequestDto> updateScheduleRequestDto)
        {
            var scheduleDomainModel = mapper.Map<List<Schedule>>(updateScheduleRequestDto);

            var updatedSchedules = await scheduleRepository.UpdateDateAsync(ids, scheduleDomainModel);

            if (updatedSchedules == null) 
            {
                return NotFound();
            }

            var scheduelDto = mapper.Map<ScheduleDto>(updatedSchedules);

            return Ok(scheduelDto);

        }
        [HttpGet]
        [Route("day/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            var scheduleDomainModel = await scheduleRepository.GetById(id);

            if (scheduleDomainModel == null) 
            {
                return NotFound();
            }

            var scheduleDtoModel = mapper.Map<ScheduleDto>(scheduleDomainModel);

            return Ok(scheduleDtoModel);

        }

        [HttpGet]
        [Route("all/{userId}")]
        public async Task<IActionResult> GetUserRecords([FromRoute] int userId)
        {
            var scheduleDomainModel = await scheduleRepository.GetByUserId(userId);

            if(scheduleDomainModel == null)
            {
                return NotFound();
            }

            var scheduleDtoModel = mapper.Map<List<ScheduleDtoFormated>>(scheduleDomainModel);

            
            var groupedScheduleDtoModel = scheduleDtoModel
                .GroupBy(s => s.DateCheck.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    ScheduleDtoFormated = g.ToList()
                }).ToList();

            return Ok(groupedScheduleDtoModel);

        }

        
    }
}
