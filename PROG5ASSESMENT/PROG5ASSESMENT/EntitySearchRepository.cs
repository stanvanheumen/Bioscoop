using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROG5ASSESMENT {
	public class EntitySearchRepository {

		private EntityContext dbContext;

		public EntitySearchRepository ( ) {
            dbContext = new EntityContext();
        }

		public List<Film> GetFilmsWith ( String find ) {
			find = find.ToLower( );
			return dbContext.Films.Where( b => b.Naam.ToLower( ).Contains( find ) ).ToList( );
		}

	}
}