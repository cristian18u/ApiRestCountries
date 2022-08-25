using ApiRestCountries.Models;
using ApiRestCountries.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiRestCountries.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly CountriesService _countriesService;

    public CountriesController(CountriesService countriesService) =>
        _countriesService = countriesService;

    [HttpGet]

    public async Task<List<Country>> Get() =>
        await _countriesService.GetAsync();
    static readonly HttpClient client = new HttpClient();
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Country>> Get(string id)
    {
        var book = await _countriesService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Country newCountry)
    {
        await _countriesService.CreateAsync(newCountry);

        return CreatedAtAction(nameof(Get), new { id = newCountry.Id }, newCountry);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Country updatedCountry)
    {
        var book = await _countriesService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedCountry.Id = book.Id;

        await _countriesService.UpdateAsync(id, updatedCountry);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _countriesService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _countriesService.RemoveAsync(id);

        return NoContent();
    }

    [HttpGet("filter")]
    public async Task<ActionResult<Country>> FilterName(string name)
    {
        var country = await _countriesService.FilterNameAsync(name);

        if (country is null)
        {
            return NotFound();
        }

        return country;
    }

    [HttpGet]
    [Route("load")]
    public async Task<string> Load()
    {
        string url = "https://restcountries.com/v3/all";
        HttpClient client = new HttpClient();
        var httpResponse = await client.GetAsync(url);
        var content = await httpResponse.Content.ReadAsStringAsync();
        dynamic result = JsonConvert.DeserializeObject<dynamic>(content);
        foreach (var country in result)
        {
            var pais = new Country();
            pais.Name = country.name.common;
            pais.Code = country.cca3;
            pais.Continent = country.continents[0];
            pais.Flag = country.flags[0];
            if (country.capital != null) pais.Capital = country.capital[0];
            pais.Population = country.population;
            await _countriesService.CreateAsync(pais);
        }
        return "charge database";
    }
}