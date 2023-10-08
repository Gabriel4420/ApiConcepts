using ApiConcepts.Data.Collections;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace ApiConcepts.Data {
	public class MongoDB {

		public IMongoDatabase Database { get;}
		public MongoDB(IConfiguration configuration) {
			try {
				var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
				var client  = new MongoClient(settings);
				Database = client.GetDatabase(configuration["NomeBanco"]);
				MapClasses();
			}
			catch (Exception ex) {

				throw new MongoException("It was not possible to connect to MongoDB", ex);
			}
		}

		private void MapClasses() {
			var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
			ConventionRegistry.Register("camelCase", conventionPack, t => true);

			if (!BsonClassMap.IsClassMapRegistered(typeof(Infectado))) {
				BsonClassMap.RegisterClassMap<Infectado>(i => { 
					i.AutoMap(); i.SetIgnoreExtraElements(true); 
				});
			}
		}

	}
}

