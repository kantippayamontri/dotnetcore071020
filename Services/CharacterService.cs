using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnetcore31_071020.Data;
using dotnetcore31_071020.Dtos.Character;
using dotnetcore31_071020.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore31_071020.Services
{
    public class CharacterService : ICharacterService
    {

        /*private static List<Character> characters = new List<Character>{
             new Character(),
             new Character { Id=1 , Name = "SAM" },
             new Character { Id=2, Name = "FIRST" , Class = RPGClass.Mage }
         };*/

        private readonly IMapper _mapper;
        private readonly Datacontext _datacontext;


        public CharacterService(
            IMapper mapper,
            Datacontext datacontext
        )
        {
            this._mapper = mapper;
            this._datacontext = datacontext;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter) //use aync keyword to asynchronous function
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            // character.Id = characters.Max(c => c.Id) + 1;
            // characters.Add(character);
            // serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            await this._datacontext.Character.AddAsync(character);
            await this._datacontext.SaveChangesAsync();
            serviceResponse.Data = (this._datacontext.Character.Select(c => this._mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            //serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            List<Character> _characterlist = await this._datacontext.Character.ToListAsync();
            serviceResponse.Data = (_characterlist.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            //FirstOrDefault return null -> not found , First -> return exception -> not found 
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            // serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            Character _character = await this._datacontext.Character.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = this._mapper.Map<GetCharacterDto>(_character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> updateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {

                //Character character = characters.FirstOrDefault(c => c.Id == updateCharacterDto.Id);
                Character character = await this._datacontext.Character.FirstOrDefaultAsync(c => c.Id == updateCharacterDto.Id);
                character.Id = updateCharacterDto.Id;
                character.Name = updateCharacterDto.Name;
                character.Intelligence = updateCharacterDto.Intelligence;
                character.HitPoints = updateCharacterDto.HitPoints;
                character.Strength = updateCharacterDto.Strength;
                character.Class = updateCharacterDto.Class;

                this._datacontext.Character.Update(character);
                await this._datacontext.SaveChangesAsync();

                serviceResponse.Data = this._mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> deleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                // Character character = characters.First(c => c.Id == id);
                // characters.Remove(character);
                // serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
                Character _character = await this._datacontext.Character.FirstOrDefaultAsync(c => c.Id == id);
                this._datacontext.Character.Remove(_character);
                await this._datacontext.SaveChangesAsync();
                serviceResponse.Data = (this._datacontext.Character.Select(c => this._mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}