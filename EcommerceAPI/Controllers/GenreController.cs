using Ecommerce.Core.DTO;
using Ecommerce.Core.IRepositories;
using Ecommerce.Core.Models;
using Ecommerce.Infastructure.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IUnitOfWork<Genre> unitOfWork;
        private readonly IMapper mapper;
        public ApiResponse response;

        public GenreController(ApplicationDbContext context, IUnitOfWork<Genre> unitOfWork, IMapper mapper)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            response = new ApiResponse();
        }

        // GET: api/genre
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<ApiResponse>> GetAllGenre(int pageSize = 2, int pageNumber = 1)
        {

            var models = await unitOfWork.genreRepository.GetAll(page_Size: pageSize, page_Number: pageNumber);

            var check = models.Any();
            if (check)
            {
                response.StatusCode = 200;
                response.IsSuccess = check;
                var mappedGenre = mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(models); // Map to GenreDTO
                response.Result = mappedGenre;
                return response;
            }
            else
            {
                response.Message = "No genre found";
                response.StatusCode = 200;
                response.IsSuccess = false;
                return response;
            }
        }
        //public async Task<ActionResult<ApiResponse>> GetAllGenre([FromQuery] string? genre_name = null, int pageSize = 2, int pageNumber = 1)
        //{
        //    Expression<Func<Genre, bool>> filter = null; // Change Movie to Genre
        //    if (!string.IsNullOrEmpty(genre_name))
        //    {
        //        filter = x => x.Name.Contains(genre_name); // Filter by Genre name
        //    }

        //    var models = await unitOfWork.genreRepository.GetAll(filter: filter, page_Size: pageSize, page_Number: pageNumber); // Call genre repository

        //    var check = models.Any();
        //    if (check)
        //    {
        //        response.StatusCode = 200;
        //        response.IsSuccess = check;
        //        var mappedGenre = mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(models); // Map to GenreDTO
        //        response.Result = mappedGenre;
        //        return response;
        //    }
        //    else
        //    {
        //        response.Message = "No genre found"; // Update message
        //        response.StatusCode = 200;
        //        response.IsSuccess = false;
        //        return response;
        //    }
        //}


        // GET: api/genre/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetById(int id)
        {
            var genre = await unitOfWork.genreRepository.GetById(id);
            if (genre == null)
            {
                return NotFound(new ApiResponse(404, "Genre not found"));
            }

            var mappedGenre = mapper.Map<GenreDTO>(genre);
            return Ok(new ApiResponse(200, result: mappedGenre));
        }

        // POST: api/genre
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateGenre(GenreDTO request)
        {
            if (request == null)
            {
                response.Message = "Invalid genre data.";
                response.StatusCode = 400;
                response.IsSuccess = false;
                return BadRequest(response);
            }

            var genre = mapper.Map<Genre>(request);
            await unitOfWork.genreRepository.Create(genre);
            await unitOfWork.Save();

            response.StatusCode = 201; // Created
            response.IsSuccess = true;
            response.Result = genre;
            return CreatedAtAction(nameof(GetById), new { id = genre.Id }, response);
        }

        // PUT: api/genre/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateGenre(int id, Create_UpdateGenreDTO request)
        {
            if (id != request.Id)
            {
                return BadRequest(new ApiResponse(400, "Genre ID mismatch"));
            }

            var existingGenre = await unitOfWork.genreRepository.GetById(id);
            if (existingGenre == null)
            {
                return NotFound(new ApiResponse(404, "Genre not found"));
            }

            var genre = mapper.Map<Genre>(request);
            unitOfWork.genreRepository.update(genre);
            await unitOfWork.Save();

            return Ok(new ApiResponse(200, "Genre updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGenre(int id)
        {
            try
            {
                // Ensure the genre exists before trying to delete it
                var genre = await unitOfWork.genreRepository.GetById(id);

                if (genre == null)
                {
                    return NotFound(new ApiResponse(404, "Genre not found."));
                }

                await unitOfWork.genreRepository.Delete(id);
                await unitOfWork.Save();

                return Ok(new ApiResponse(200, "Genre deleted successfully."));
            }
            catch (Exception ex)
            {
                // Log the exception message and stack trace (or use a logging framework)
                Console.WriteLine($"Error deleting genre: {ex.Message}\n{ex.StackTrace}");

                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new ApiResponse(500, "An error occurred while deleting the genre: " + ex.Message));
            }
        }


    }
}
