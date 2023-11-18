using AutoMapper;
using CFBSharp.Model;
using CollegeFootballApp.Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GameDto, Game>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Season, opt => opt.MapFrom(src => src.Season))
            .ForMember(dest => dest.Week, opt => opt.MapFrom(src => src.Week))
            .ForMember(dest => dest.SeasonType, opt => opt.MapFrom(src => src.SeasonType))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.HasValue ? src.StartDate.Value.ToString("o") : null))
            .ForMember(dest => dest.StartTimeTbd, opt => opt.MapFrom(src => src.StartTimeTbd))
            .ForMember(dest => dest.Completed, opt => opt.MapFrom(src => src.Completed))
            .ForMember(dest => dest.NeutralSite, opt => opt.MapFrom(src => src.NeutralSite))
            .ForMember(dest => dest.ConferenceGame, opt => opt.MapFrom(src => src.ConferenceGame))
            .ForMember(dest => dest.Attendance, opt => opt.MapFrom(src => src.Attendance))
            .ForMember(dest => dest.VenueId, opt => opt.MapFrom(src => src.VenueId))
            .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue))
            .ForMember(dest => dest.HomeId, opt => opt.MapFrom(src => src.HomeId))
            .ForMember(dest => dest.HomeTeam, opt => opt.MapFrom(src => src.HomeTeam))
            .ForMember(dest => dest.HomeConference, opt => opt.MapFrom(src => src.HomeConference))
            .ForMember(dest => dest.HomeDivision, opt => opt.MapFrom(src => src.HomeDivision))
            .ForMember(dest => dest.HomePoints, opt => opt.MapFrom(src => src.HomePoints))
            .ForMember(dest => dest.HomeLineScores, opt => opt.MapFrom(src => src.HomeLineScores))
            .ForMember(dest => dest.HomePostWinProb, opt => opt.MapFrom(src => (decimal?)src.HomePostWinProb))
            .ForMember(dest => dest.HomePregameElo, opt => opt.MapFrom(src => src.HomePregameElo))
            .ForMember(dest => dest.HomePostgameElo, opt => opt.MapFrom(src => src.HomePostgameElo))
            .ForMember(dest => dest.AwayId, opt => opt.MapFrom(src => src.AwayId))
            .ForMember(dest => dest.AwayTeam, opt => opt.MapFrom(src => src.AwayTeam))
            .ForMember(dest => dest.AwayConference, opt => opt.MapFrom(src => src.AwayConference))
            .ForMember(dest => dest.AwayDivision, opt => opt.MapFrom(src => src.AwayDivision))
            .ForMember(dest => dest.AwayPoints, opt => opt.MapFrom(src => src.AwayPoints))
            .ForMember(dest => dest.AwayLineScores, opt => opt.MapFrom(src => src.AwayLineScores))
            .ForMember(dest => dest.AwayPostWinProb, opt => opt.MapFrom(src => (decimal?)src.AwayPostWinProb))
            .ForMember(dest => dest.AwayPregameElo, opt => opt.MapFrom(src => src.AwayPregameElo))
            .ForMember(dest => dest.AwayPostgameElo, opt => opt.MapFrom(src => src.AwayPostgameElo))
            .ForMember(dest => dest.ExcitementIndex, opt => opt.MapFrom(src => (decimal?)src.ExcitementIndex))
            .ForMember(dest => dest.Highlights, opt => opt.MapFrom(src => src.Highlights))
            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes)).ReverseMap();
        }
    }
}
