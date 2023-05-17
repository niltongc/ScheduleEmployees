using AutoMapper;
using EmployeeSchedule.Models.Domain;
using EmployeeSchedule.Models.DTO;

namespace EmployeeSchedule.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddUserRequestDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UpdateUserRequestDto, User>().ReverseMap();

            CreateMap<AddScheduleRequestDto, Schedule>().ReverseMap();
            CreateMap<ScheduleDto, Schedule>().ReverseMap();
            CreateMap<UpdateScheduleRequestDto, Schedule>().ReverseMap();
            //CreateMap<ScheduleDtoFormated, Schedule>().ReverseMap();

            //CreateMap<Schedule, ScheduleDtoFormated>()
            //    .ForMember(di => di.DateIn, m => m.MapFrom(a => $"{a.DateIn.AddHours(-3):G}"))
            //    .ForMember(dl => dl.DateLaunch, m => m.MapFrom(a => a.DateLaunch.HasValue ? $"{a.DateLaunch.Value.AddHours(-3):G}" : null))
            //    .ForMember(db => db.DateLaunchBack, m => m.MapFrom(a => a.DateLaunchBack.HasValue ? $"{a.DateLaunchBack.Value.AddHours(-3):G}" : null))
            //    .ForMember(ddo => ddo.DateOut, m => m.MapFrom(a => a.DateOut.HasValue ? $"{a.DateOut.Value.AddHours(-3):G}" : null)) ;

            //CreateMap<Schedule, ScheduleDtoFormated>()
            //    .ForMember(dc => dc.DateCheck, m => m.MapFrom(a => a.DateCheck.ToString("HH:mm")));
            CreateMap<Schedule, ScheduleDtoFormated>()
            //.ForMember(dc => dc.TimeCheck, m => m.MapFrom(a => a.DateCheck.TimeOfDay))
            .ForMember(dc => dc.TimeDay, m => m.MapFrom(a => a.DateCheck.Day)); 

        }

    }
}
