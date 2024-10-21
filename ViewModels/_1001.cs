using System.Collections.Generic;
using System.IO;
using System.Linq;
using Repositories;

namespace Controller
{
	public class _1001
	{
		public int Music => 1001;
		public int Paintings => 1001;
		public int Photographs => 1001;
		public int Songs => 1001;
		public int Games => 1001;
		public int Books => GetBooksCount();
		public int Comics => GetComicsCount();
		public int Movies => GetMoviesCount();
		public int TVShows => GetTVShowsCount();

		private readonly IDatasource _datasource;
		private readonly List<string> _movies1001List = [];
		private readonly List<string> _tvShows1001List = [];

		public _1001(IDatasource datasource)
		{
			_datasource = datasource;

			var imdbListPath = Path.Combine(Paths.Data, "Imdb");
			_movies1001List = Fill1001List(imdbListPath, "1001 Movies You Must See Before You Die.csv");
			_tvShows1001List = Fill1001List(imdbListPath, "1001 TV Shows You Must Watch Before you Die.csv");
		}

		public int GetBooksCount()
		{
			return _datasource.GetDoneList<BookItem>()
				.Count(o => o.is1001)
				+ 1; // Watchmen;
		}

		public int GetComicsCount()
		{
			return _datasource.GetDoneList<ComicItem>().Count(o => o._1001);
		}

		public int GetMoviesCount()
		{
			return _datasource.GetDoneList<MovieItem>()
				.Select(o => o.ExternalID)
				.Count(Is1001)
				+ 2; // Riget, Dekalog
		}

		public int GetTVShowsCount()
		{
			return _datasource.GetDoneList<TVShowItem>()
				.Select(o => o.ExternalID)
				.Count(Is1001);
		}

		public bool Is1001(string imdbSource)
		{
			return _movies1001List.Any(i => i == imdbSource)
				|| _tvShows1001List.Any(i => i == imdbSource);
		}

		private List<string> Fill1001List(string listFolderPath, string listName)
		{
			var result = _datasource.GetList<Movie>(Path.Combine(listFolderPath, listName));
			return result.Select(o => o.ExternalID).ToList();
		}
	}
}