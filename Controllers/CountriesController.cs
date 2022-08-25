// using BookStoreApi.Models;
using ApiRestCountries.Models;
using ApiRestCountries.Services;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
// using ApiRestCountries.Models;


// using MongoDB.Bson.IO;
// using System.Net.Http;
// using System.Text;

namespace ApiRestCountries.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly CountriesService _countriesService;

    public CountriesController(CountriesService countriesService) =>
        _countriesService = countriesService;

    [HttpGet]
    // public dynamic listartCliente()  //este es por query params listar?name=cristian
    // {
    //     // ya esto es dentro del get
    //     return "soy cristian el mejor de esta vaina";
    // }

    // public async Task<List<Country>> Get() => //quitada de momento
    //     await _countriesService.GetAsync();
    //     public string Code { get; set; } = null!;
    // public string Name { get; set; } = null!;
    // public string Continent { get; set; } = null!;
    // public string Flag { get; set; } = null!;
    // public string Capital { get; set; } = null!;
    // public string Population { get; set; } = null!;
    public async Task<IActionResult> Get() // dentro del task <lo que devuelve el return el tipo> 
    {
        var cris = new Country

        // var newContry = new List<Country>
        // new Country
        {
            // Id = "cadf",
            Code = "xac",
            Name = "colombia",
            Continent = "sub america",
            Flag = "asdcvsdf",
            Capital = "bogota",
            Population = "1235",
        };
        await _countriesService.CreateAsync(cris);
        return CreatedAtAction(nameof(Get), new { id = cris.Id }, cris);
    }
    static readonly HttpClient client = new HttpClient();

    [HttpGet]
    [Route("load")]
    public async Task<dynamic> Load()
    // public async Task<Country> Load()
    {
        string url = "https://restcountries.com/v3/alpha/col";
        HttpClient client = new HttpClient();
        var httpResponse = await client.GetAsync(url);
        var content = await httpResponse.Content.ReadAsStringAsync();
        dynamic result = JsonConvert.DeserializeObject<dynamic>(content);
        // Console.WriteLine(result[0]);
        // dynamic cri = result;
        // Console.WriteLine(cri[0].name.common);

        // var pais = new Country
        // {

        // };
        var pais = new Country();
        pais.Name = result[0].name.common;
        pais.Code = result[0].cca3;
        pais.Continent = result[0].continents[0];
        pais.Flag = result[0].flags[0];
        pais.Capital = result[0].capital[0];
        pais.Population = result[0].population;

        // };

        Console.WriteLine(pais);
        return pais;

    }
    [HttpGet]
    [Route("charge")]
    public async Task<string> Charge()
    {
        string url = "https://restcountries.com/v3/all";
        HttpClient client = new HttpClient();
        var httpResponse = await client.GetAsync(url);
        var content = await httpResponse.Content.ReadAsStringAsync();
        dynamic result = JsonConvert.DeserializeObject<dynamic>(content);
        foreach (var country in result)
        {
            // Console.Write(country);
            var pais = new Country();
            pais.Name = country.name.common;
            pais.Code = country.cca3;
            pais.Continent = country.continents[0];
            pais.Flag = country.flags[0];
            if (country.capital != null) pais.Capital = country.capital[0];
            pais.Population = country.population;
            Console.WriteLine(pais.Name);
            await _countriesService.CreateAsync(pais);
            IActionResult prueba = CreatedAtAction(nameof(Get), new { id = pais.Id }, pais);
            Console.Write(prueba);
        }
        return "charge database";
    }


    // [HttpGet("{id:length(24)}")]
    // public async Task<ActionResult<Book>> Get(string id)
    // {
    //     var book = await _booksService.GetAsync(id);

    //     if (book is null)
    //     {
    //         return NotFound();
    //     }

    //     return book;
    // }

    // [HttpPost]
    // public async Task<IActionResult> Post(Country newContry)
    // {
    //     await _countriesService.CreateAsync(newContry);

    //     return CreatedAtAction(nameof(Get), new { id = newContry.Id }, newContry);
    // }

    // [HttpPut("{id:length(24)}")]
    // public async Task<IActionResult> Update(string id, Book updatedBook)
    // {
    //     var book = await _booksService.GetAsync(id);

    //     if (book is null)
    //     {
    //         return NotFound();
    //     }

    //     updatedBook.Id = book.Id;

    //     await _booksService.UpdateAsync(id, updatedBook);

    //     return NoContent();
    // }

    // [HttpDelete("{id:length(24)}")]
    // public async Task<IActionResult> Delete(string id)
    // {
    //     var book = await _booksService.GetAsync(id);

    //     if (book is null)
    //     {
    //         return NotFound();
    //     }

    //     await _booksService.RemoveAsync(id);

    //     return NoContent();
    // }
}