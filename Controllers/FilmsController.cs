using Microsoft.AspNetCore.Mvc;
using DotnetMoviesAppRazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DotnetMoviesAppRazor.Infrastructure.Services.FilmsService;
using DotnetMoviesAppRazor.Infrastructure.Services;
using DotnetMoviesAppRazor.Models.ViewModel;

namespace DotnetMoviesAppRazor.Controllers
{
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly FilmsService _filmsService;

        public FilmsController(FilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        [HttpGet("/Api/Films")]
        public async Task<ActionResult<IEnumerable<FilmViewModel>>> GetFilms(SearchCriteria criterion, string searchString, int sortOption)
        {
            return Ok(await _filmsService.GetFilms(criterion, searchString, sortOption));
        }
    }
}
