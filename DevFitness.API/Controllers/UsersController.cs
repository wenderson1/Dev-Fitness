using AutoMapper;
using DevFitness.API.Core.Entities;
using DevFitness.API.Models.InputModels;
using DevFitness.API.Models.ViewModels;
using DevFitness.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DevFitnessDbContext _dbContext;
        private readonly IMapper _mapper;
        public UsersController(DevFitnessDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //api/users método http get
        /// <summary>
        /// Retornar detalhes de usuário
        /// </summary>
        /// <param name="id">Identificador de usuário</param>
        /// <returns>Objeto de detalhes de usuário</returns>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="200">Usuário encontrado com sucesso</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            //var userViewModel = new UserViewModel(user.Id, user.FullName, user.Height, user.Weight, user.BirthDate);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return Ok(userViewModel);
        }

        // api/users metodo http post
        /// <summary>
        /// Cadastrar um usuário
        /// <remarks>
        /// Requisição de exemplo:
        /// {
            /// "fullName":"Wenderson Farias"
            /// "height":1.78,
            /// "weight":110,
            /// "birthDate:"1992-01-01 00:00:00"
        /// }
        /// </remarks>
        /// </summary>
        /// <param name="inputModel">Objetos com dados de cadastro de Usuário</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Objeto Criado com sucesso</response>
        /// <response code="400">Dados Inválido</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            //var user = new User(inputModel.FullName, inputModel.Height, inputModel.Weight, inputModel.BirthDate);
            var user = _mapper.Map<User>(inputModel);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = user.Id}, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserInputModel inputModel)
        {
            var user = _dbContext.Users
                .SingleOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            user.Update(inputModel.Height, inputModel.Weight);

            _dbContext.SaveChanges();

            return NoContent();
        }


    }
}
