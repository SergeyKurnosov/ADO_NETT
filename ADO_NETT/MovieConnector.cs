using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NETT
{
	internal class MovieConnector:Connector
	{
		public MovieConnector(string connectorString):base(connectorString) { }

		public void InsertMovie()
		{
			Console.Write("Название фильма: ");
			string movie_name = Console.ReadLine();
			Console.Write("Дата выхода ");
			string release_date = Console.ReadLine();
			Console.Write("Режисер : ");
			string director = Console.ReadLine();

			Insert
				(
				"Movies",
				"movie_id,movie_name,release_date,director",
				$"{Convert.ToInt32(Scalar("SELECT MAX(movie_id) FROM Movies")) + 1},N'{movie_name}',N'{release_date}',{GetDirectorID(director)}"
				);

			Select
				(
				"movie_name,release_date,first_name,last_name",
				"Movies,Directors",
				"director=director_id"
				);

		}

		public int GetDirectorID(string full_name)
		{
			return Convert.ToInt32(
				Scalar
				(
					$"SELECT director_id FROM Directors WHERE first_name=N'{full_name.Split(' ').First()}' AND last_name=N'{full_name.Split(' ').Last()}'"
				)
			);
		}

		public void InsertDirector()
		{
			Console.Write("Введите имя: ");
			string first_name = Console.ReadLine();

			Console.Write("Введите фамилию: ");
			string last_name = Console.ReadLine();

			Insert(
				"Directors",
				"director_id,first_name,last_name",
				$"{Convert.ToInt32(Scalar("SELECT MAX(director_id) FROM Directors")) + 1},N'{first_name}',N'{last_name}'"
				);

			Select("*", "Directors");

		}

		public void SelectDirectors()
		{
			Select("*", "Directors");
		}

		public void SelectMovies()
		{
			Select("*", "Movies");
		}

	}
}
