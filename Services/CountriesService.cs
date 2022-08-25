// using BookStoreApi.Models;
// using ApiRestCountries.Models;
using ApiRestCountries.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiRestCountries.Services;

public class CountriesService
{
    private readonly IMongoCollection<Country> _countriesCollection;

    public CountriesService(
        IOptions<ApiCountriesDataBaseSettings> countryStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            countryStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            countryStoreDatabaseSettings.Value.DatabaseName);

        _countriesCollection = mongoDatabase.GetCollection<Country>(
            countryStoreDatabaseSettings.Value.CollectionName);
    }

    public async Task<List<Country>> GetAsync() =>
        await _countriesCollection.Find(_ => true).ToListAsync();

    public async Task<Country?> GetAsync(string id) =>
        await _countriesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Country newBook) =>
        await _countriesCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Country updatedBook) =>
        await _countriesCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _countriesCollection.DeleteOneAsync(x => x.Id == id);
}