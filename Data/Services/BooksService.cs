using libreria_JSVE.Data.ViewModels;
using System;
using libreria_JSVE.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace libreria_JSVE.Data.Models.Services
{
    public class BooksService
    {
        private AppDebContext _context;
        public BooksService(AppDebContext context)
        {
            _context = context;
        }
        //Método que nos permite  agregar un nuevo libro en la BD

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateAdded = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                ConverUrl = book.ConverUrl,
                DateRead = DateTime.Now

            };
            _context.Books.Add(_book);
            _context.SaveChanges();

        }
        //Método que nos permite obtener una lista de todos los libro en la BD
        public List<Book> GetAllBks() => _context.Books.ToList();
        //Método que nos permite obtener el libro que estamos pidiendo de la BD
        public Book GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);
        //Método que nos permite modificar el libro que estamos pidiendo de la BD
        public Book UpdateBookById(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if(_book == null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateAdded = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.ConverUrl = book.ConverUrl;

                _context.SaveChanges();
            }
            return _book;
        }
        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if( _book != null)
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }
    }
}
