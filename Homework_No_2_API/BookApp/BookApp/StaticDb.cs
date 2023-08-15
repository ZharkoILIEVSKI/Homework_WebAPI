using BookApp.Models;
using System.Collections.Generic;

namespace BookApp
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book
            {
                Title = "Vozot v'sneg",
                Author = "Bosko Simjanovski"
            },

            new Book
            {
                Title = "Dalecno minato",
                Author = "Trajko Smakjoski"
            },

            new Book
            {
                Title = "Segasnost",
                Author = "Daniel Oljakovski"
            }
        };
    }
}
