using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore31_071020.Dtos.Character;
using dotnetcore31_071020.Models;
using dotnetcore31_071020.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore31_071020.Controllers
{
    [ApiController]
    [Route("[controller]")] //use name of controller like '/Character'
    public class CharacterController : ControllerBase
    {


        //get -> get data from service dont send data via get method
        //post -> add or create an obj -> save to database
        //put -> update an object
        //delete -> erase data from database

        /*
        CRUD
        create -> post
        read -> get
        update -> put
        delete -> delete
        */

        /*
                        Dependecy injection
            controller ------------------------> Service ----------------------> database

        */

        private readonly ICharacterService _characterService;

        public CharacterController( //constructor parameter must public
            ICharacterService characterService
        )
        {
            this._characterService = characterService;
        }


        [HttpGet("GetAll")] //use route like '/GetAll'
        public async Task<IActionResult> Get() //if name is Get you dont have to type [HTTPGET] but can not have Get name in 2 function
        {
            return Ok(await this._characterService.GetAllCharacters());
        }

        [HttpGet("{id}")] //use route like '/GetFirst'
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await this._characterService.GetCharacterById(id));
        }

        [HttpPost("add-character")]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        { //add in postman via body -> json
            return Ok(await this._characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updateCharacter)
        { //add in postman via body -> json

            ServiceResponse<GetCharacterDto> response = await this._characterService.updateCharacter(updateCharacter);
            if(response.Data != null){
                return Ok( response );
            }else{
                return NotFound(response);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id){
            ServiceResponse<List<GetCharacterDto>> response = await this._characterService.deleteCharacter(id);
            if(response.Data != null){
                return Ok(response);
            }else{
                return NotFound(response);
            }
        }
        
    }
}