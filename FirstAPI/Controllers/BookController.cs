using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
    
    public class BookController
    {
        static List<Book> books= new List<Book>();
        [HttpGet]
        public List<Book> GetBooks(){
            books.Add(new Book(){Id = 1, Name = "C# Programming", AuthorName = "Rahul"});
            books.Add(new Book(){Id = 2, Name = "Java Programming", AuthorName = "Rahul"});
            books.Add(new Book(){Id = 3, Name = "Python Programming", AuthorName = "Rahul"});
            books.Add(new Book(){Id = 4, Name = "C++ Programming", AuthorName = "Rahul"});
            books.Add(new Book(){Id = 5, Name = "C Programming", AuthorName = "Rahul"});
            return books;
        }
        [HttpPost]
        public int AddBook(Book book){
            books.Add(book);
            return 1;
        }
    }
}