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
        [Route("{id}")]
        public async Task<IActionResult> CreateOtherDates([FromRoute] int id, [FromBody] UpdateScheduleRequestDto updateScheduleRequestDto)
        {
            var scheduleDomainModel = mapper.Map<Schedule>(updateScheduleRequestDto);

            scheduleDomainModel = await scheduleRepository.UpdateDateAsync(id, scheduleDomainModel);

            if (scheduleDomainModel == null) 
            {
                return NotFound();
            }

            var scheduelDto = mapper.Map<ScheduleDto>(scheduleDomainModel);

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
        public async Task<IActionResult> GetUserRecords([FromRoute] int userId, int mouth)
        {
            var scheduleDomainModel = await scheduleRepository.GetByUserId(userId,mouth);

            if(scheduleDomainModel == null)
            {
                return NotFound();
            }

            var scheduleDtoModel = mapper.Map<List<ScheduleDtoFormated>>(scheduleDomainModel);

            
            var groupedScheduleDtoModel = scheduleDtoModel
                .GroupBy(s => s.TimeDay)
                .Select(g => new
                {
                    TimeDay = g.Key,
                    ScheduleDtoFormated = g.ToList()
                }).ToList();

            return Ok(groupedScheduleDtoModel);

        }

        //[HttpGet]
        //public IActionResult Teste(DateTime date)
        //{
        //    date com espaco sem o T

        //    date = DateTime.UtcNow;
        //    var d = date.AddHours(-3).ToString("dd/MM/yyyy HH:mm");
        //    var d2 = date.ToString("dd/MM/yyyy");

        //    var date2 = DateTime.UtcNow.ToString(CultureInfo.CreateSpecificCulture("pt-BR"));
        //    //if (date2.Contains(d2))
        //    //    return NotFound();

        //    return Ok($"{date:g}");
        //}
    }
}
