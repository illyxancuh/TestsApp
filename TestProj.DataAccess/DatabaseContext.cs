﻿using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProj.DataAccess.Attributes;
using TestProj.DataAccess.Entities;

namespace TestProj.DataAccess
{
    public class DatabaseContext
    {
        private readonly MongoClient _mongoClient;

        private readonly IMongoDatabase _database;

        public DatabaseContext(IConfiguration configuration)
        {
            _mongoClient = new MongoClient(configuration.GetConnectionString("MongoConnection"));
            _database = _mongoClient.GetDatabase("TestsDB");
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAll<TEntity>()
        {
            return await _database.GetCollection<TEntity>(GetCollectionName<TEntity>())
                .AsQueryable<TEntity>()
                .ToListAsync<TEntity>();
        }

        public void Add<TEntity>(TEntity entity)
        {
            _database.GetCollection<TEntity>(GetCollectionName<TEntity>()).InsertOne(entity);
        }

        public void UpdateUserTests(string userName, IEnumerable<Test> tests)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Login", userName);
            var update = Builders<BsonDocument>.Update.Set(nameof(User.Tests), tests);

            _database.GetCollection<BsonDocument>(GetCollectionName<User>())
                .UpdateOne(filter, update);
        }

        public async Task<TEntity> GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter)
        {
            return await _database.GetCollection<TEntity>(GetCollectionName<TEntity>())
                .AsQueryable<TEntity>()
                .FirstOrDefaultAsync(filter);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter)
        {
            return await _database.GetCollection<TEntity>(GetCollectionName<TEntity>())
                .AsQueryable<TEntity>()
                .Where(filter)
                .ToListAsync();
        }

        private string GetCollectionName<TEntity>()
        {
            Type entityType = typeof(TEntity);
            CollectionName attribute = entityType.GetCustomAttributes(false).OfType<CollectionName>().FirstOrDefault();
            if (attribute == null)
            {
                return entityType.Name;
            }
            return attribute.Name;
        }
    }
}
