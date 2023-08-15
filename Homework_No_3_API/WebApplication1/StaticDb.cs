using WebApplication1.Models;

namespace WebApplication1
{
    public static class StaticDb
    {
        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie
            {
                Id = 1,
                Title = "Matrix",
                Description = "Epten ludnica za nase vreme",
                Genre = Models.Enum.Genre.Action,
                Year = 1999
            },
            new Movie
            {
                Id = 2,
                Title = "Oblivion",
                Description = "Fino filmce",
                Genre = Models.Enum.Genre.Action,
                Year = 2008
            },

             new Movie
            {
                Id = 3,
                Title = "As Good As it Gets",
                Description = "Bezveze e",
                Genre = Models.Enum.Genre.Comedy,
                Year = 2010
            }
        };
    }
}
