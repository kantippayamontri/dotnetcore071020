using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetcore31_071020.Dtos.Character;
using dotnetcore31_071020.Models;

namespace dotnetcore31_071020.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters(); //Task for asynchronous function
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> updateCharacter(UpdateCharacterDto updateCharacterDto);
        Task<ServiceResponse<List<GetCharacterDto>>> deleteCharacter(int id);

    }
}