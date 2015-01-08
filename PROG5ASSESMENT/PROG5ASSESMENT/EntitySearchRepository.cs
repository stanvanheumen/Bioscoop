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
		public List<Gast> GetGuestsWith ( String find ) {
			find = find.ToLower( );
			return dbContext.Gasten.Where( b => b.Voornaam.ToLower( ).Contains( find ) || b.Achternaam.ToLower( ).Contains( find ) || b.TussenVoegsel.ToLower( ).Contains( find ) ).ToList( );
		}
		public List<Korting> GetDiscountWith ( String find ) {
			find = find.ToLower( );
			return dbContext.Kortingen.Where( b => b.KortingsCode.ToLower( ).Contains( find ) ).ToList( );
		}

		public List<Reservering> GetReservationWith ( String find ) {
			find = find.ToLower( );
			return dbContext.Reserveringen.Where( b => b.Film.Naam.ToLower( ).Contains( find ) ||
				b.Factuuradres.ToLower().Contains(find)).ToList( );
		}

		public List<Zaal> GetRoomsWith ( String find ) {
			find = find.ToLower( );
			return dbContext.Zalen.Where( b => b.Naam.ToLower( ).Contains( find ) ).ToList( );
		}

	}
}