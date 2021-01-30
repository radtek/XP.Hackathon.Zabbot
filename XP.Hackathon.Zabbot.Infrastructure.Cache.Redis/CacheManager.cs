using XP.Hackathon.Zabbot.Interface.Cache;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Infraestructure.Cache.Redis
{
    public class RedisService : ICacheService
    {
        public readonly ConnectionMultiplexer redis = null;
        private readonly int REDIS_DATABASE = 1; //int.Parse(AppSettings.Redis.Database);

        public RedisService()
        {

            var config = new ConfigurationOptions
            {
                Password = AppSettings.Redis.Password,
                AbortOnConnectFail = false,
                AllowAdmin = true,
                ConnectTimeout = 5000,
                ResponseTimeout = 5000,
                //DefaultDatabase = REDIS_DATABASE
            };

            config.EndPoints.Add(AppSettings.Redis.Server);
            this.redis = ConnectionMultiplexer.Connect(config);
        }

        public IDatabase Database { get { return this.redis.GetDatabase(); } }

        public async Task<ResultBase> Push(string key, object value)
        {
            return await Push(key, value, TimeSpan.FromHours(1));
        }

        /// <summary>
        /// save key/value from cache.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The values</param>
        /// <param name="expiration"></param>
        public async Task<ResultBase> Push(string key, object value, TimeSpan expiration)
        {
            var result = new ResultBase();

            try
            {
                var json = JsonConvert.SerializeObject(value, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                Database.StringSet(key, json, expiration);

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex;
            }

            return result;
        }

        /// <summary>
        /// Tet the key/value from cache.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<Result<Object>> Get(string key)
        {
            var result = new Result<Object>();

            try
            {
                var obj = Database.StringGet(key);
                if (!obj.HasValue)
                {
                    result.Success = false;
                    return result;
                }

                result.Success = true;
                result.Objects.Add(obj);

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex;
            }

            return result;
        }

        public async Task<Result<Object>> Get(string key, Type type)
        {
            var result = new Result<Object>();

            try
            {
                var obj = Database.StringGet(key);
                if (!obj.HasValue)
                {
                    return null;
                }

                var deserialize = JsonConvert.DeserializeObject(obj, type);

                result.Success = true;
                result.Objects.Add(deserialize);

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex;
            }

            return result;
        }

        /// <summary>
        /// get the keys/values from cache.
        /// </summary>
        /// <param name="prefix_key"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<object> GetObjects(string prefix_key, Type type)
        {
            foreach (var ep in redis.GetEndPoints())
            {
                var server = redis.GetServer(ep);
                //var keys = server.Keys(database: REDIS_DATABASE, pattern: prefix_key + "*").ToArray();
            }

            return new List<object>();
        }

        /// <summary>
        /// Clear all databases keys/values.
        /// </summary>
        public async Task<ResultBase> FlushAll()
        {
            var result = new ResultBase();

            try
            {
                foreach (var endpoint in redis.GetEndPoints())
                {
                    var server = redis.GetServer(endpoint);
                    await server.FlushAllDatabasesAsync();
                }

                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex;
            }

            return result;
        }
    }
}
