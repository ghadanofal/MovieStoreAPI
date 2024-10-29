using Ecommerce.Core.IRepositories;
using Ecommerce.Core.Models;
using Ecommerce.Infastructure.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ecommerce.Core.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Server.HttpSys;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IUnitOfWork<Movie> unitOfWork;
        private readonly IMapper mapper;
        public ApiResponse response;

        public MovieController(ApplicationDbContext context, IUnitOfWork<Movie> unitOfWork, IMapper mapper)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            response = new ApiResponse();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<ApiResponse>> GetAllMovie([FromQuery] string? genre_name = null, int pageSize = 2, int pageNumber = 1)
        {
            Expression<Func<Movie, bool>> filter = null;
            if (!string.IsNullOrEmpty(genre_name))
            {
                filter = x => x.Genres.Name.Contains(genre_name);
            }
            var models = await unitOfWork.movieRepository.GetAll(filter: filter, page_Size: pageSize, page_Number: pageNumber,
                includeProperity: "Genres");
            var check = models.Any();
            if (check)
            {
                response.StatusCode = 200;
                response.IsSuccess = check;
                var mappedMovie = mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(models);
                response.Result = mappedMovie;
                return response;
            }
            else
            {
                response.Message = "No movie found";
                response.StatusCode = 200;
                response.IsSuccess = false;
                return response;
            }
        }

        [HttpGet("get_id")]
        public async Task<ActionResult<ApiResponse>> GetById([FromQuery] int id)
        {


            var model = await unitOfWork.movieRepository.GetById(id);
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new ApiValidationResponse(new List<string> { "Invalid id", "try positive id" }, 400));
                }
                else if (model == null)
                {
                    var x = model.ToString();
                    return NotFound(new ApiResponse(400, "Movie not found"));
                }

                var mappedMovie = mapper.Map<Movie, MovieDTO>(model); // Adjusted mapping
                return Ok(new ApiResponse(200, result: mappedMovie));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new ApiValidationResponse(new List<string> { "internal server error", ex.Message },
                                  StatusCodes.Status500InternalServerError));
            }
        }



        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateMovie(Create_UpdateMovieDTO request)
        {
            //igenericRepo.CreateProduct(request);
            // iproductRepo.CreateProduct(request);
            //await unitOfWork.productRepository.CreateProduct(request);
            //await unitOfWork.Save();
            ////context.SaveChanges();

            //return Ok();
            if (request == null)
            {
                response.Message = "Invalid movie data.";
                response.StatusCode = 400;
                response.IsSuccess = false;
                return BadRequest(response);
            }

            var movie = mapper.Map<Movie>(request);
            await unitOfWork.movieRepository.Create(movie);
            await unitOfWork.Save();

            response.StatusCode = 200;
            response.IsSuccess = true;
            response.Result = movie;
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> updateMovie(Movie request)
        {
            //igenericRepo.updateProduct(request);
            //iproductRepo.updateProduct(request);
            unitOfWork.movieRepository.update(request);
            await unitOfWork.Save();
            //context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            // Ensure the movie exists before trying to delete it
            var movieExists = await unitOfWork.movieRepository.GetById(id) != null;
            if (!movieExists)
            {
                return NotFound(new ApiResponse(404, "Movie not found."));
            }

            unitOfWork.movieRepository.Delete(id);
            await unitOfWork.Save();
            return Ok(new ApiResponse(200, "Movie deleted successfully."));
        }


        [HttpGet("movieById/({genre_id})")]

        public async Task<ActionResult<ApiResponse>> GetAllMovieById(int genre_id)
        {
            var movies = await unitOfWork.movieRepository.GetAllMovieByGenreId(genre_id);
            var check = movies.Any();
            if (check)
            {
                response.StatusCode = 200;
                response.IsSuccess = check;
                var mappedmovie = mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movies);
                response.Result = mappedmovie;
                return response;
            }
            else
            {
                response.Message = "No movie found";
                response.StatusCode = 200;
                response.IsSuccess = false;
                return response;
            }

        }

    }
}