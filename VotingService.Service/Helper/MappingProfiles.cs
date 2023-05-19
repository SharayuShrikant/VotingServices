using AutoMapper;
using VotingService.Dto;
using VotingService.Models;
namespace VotingService.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserModel, UserGetDto>();
            CreateMap<UserLoginDto, UserModel>();

            CreateMap<UserModel, UserPublicGetDto>();

            CreateMap<PollModel, PollGetDto>();
            CreateMap<PollPostDto, PollModel>();

            CreateMap<QueryModel, QueryGetDto>();
            CreateMap<QueryPostDto, QueryModel>();

            CreateMap<SolutionModel, SolutionGetDto>();
            CreateMap<SolutionPostDto, SolutionModel>();

            CreateMap<PollModel, PollGetDto>();
            CreateMap<PollPostDto, PollModel>();

            CreateMap<PollQueryModel, PollQueryGetDto>();
            CreateMap<PollQueryPostDto, PollQueryModel>();

            CreateMap<ResponseModel, ResponseGetDto>();
            CreateMap<ResponsePostDto, ResponseModel>();
        }
    }
}
