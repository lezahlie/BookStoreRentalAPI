using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using BooksApi.Models;

namespace BooksApi.Services
{
    public class ToyService
    {
        private readonly IMongoCollection<Toy> _toys;

        public ToyService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _toys = database.GetCollection<Toy>(settings.ToysCollectionName);
        }

        public List<Toy> Get() =>
            _toys.Find(toy => true).ToList();


        public Toy Get(string id) =>
            _toys.Find<Toy>(toy => toy.ToyId == id).FirstOrDefault();

        public List<Toy> GetByCategory(string category) =>
             _toys.Find(toy => true && toy.Category.ToLower() == category.ToLower()).ToList();
   
        public Toy Create(Toy toy)
        {
            _toys.InsertOne(toy);
            return toy;
        }

        public void Update(string id, Toy toyIn) =>
            _toys.ReplaceOne(toy => toy.ToyId == id, toyIn);

        public void Remove(Toy toyIn) =>
            _toys.DeleteOne(toy => toy.ToyId == toyIn.ToyId);

        public void Remove(string id) => 
            _toys.DeleteOne(toy => toy.ToyId == id);
        
    }
}