using MongoDB.Driver;
using UtttApi.DataContext.Interfaces;
using UtttApi.DataContext.Repositories;
using UtttApi.DataContext.Settings;
using UtttApi.ObjectModel.Models;

namespace UtttApi.DataContext.Services
{
    /// <summary>
    /// Contains all repositories and services required to handle data
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public UtttRepository Game { get; }

        public UnitOfWork(IMongoClient client, IMongoDbSettings settings)
        {
            var utttDb = client.GetDatabase(settings.UtttDb);
            Game = new UtttRepository(utttDb.GetCollection<UtttObject>(settings.UtttCollection));
        }
    }
}