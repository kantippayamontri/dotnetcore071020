using AutoMapper;
using dotnetcore31_071020.Dtos.Character;
using dotnetcore31_071020.Models;

namespace dotnetcore31_071020
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){

            CreateMap<Character , GetCharacterDto>();
            CreateMap<AddCharacterDto , Character>();
           
        }
    }
}