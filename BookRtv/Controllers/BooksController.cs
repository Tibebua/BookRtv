using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookRtv.Data;
using BookRtv.Data.Repository;
using BookRtv.Data.Specification;
using BookRtv.Dtos;
using BookRtv.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookRtv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IGenericRepository<Book> _bookRepo;
        private readonly IGenericRepository<Author> _authorRepo;
        private readonly IGenericRepository<Category> _catRepo;
        private readonly IMapper _mapper;

        public BooksController(IGenericRepository<Book> bookRepo, 
            IGenericRepository<Author> authorRepo, IGenericRepository<Category> catRepo,
            IMapper mapper)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _catRepo = catRepo;
            _mapper = mapper;
        }


        // Get all books
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BookToReturnDto>>> GetBooksAsync()
        {
            var spec = new BooksWithAuthorsAndCatsSpecification();

            var books = await _bookRepo.GetAllWithSpecification(spec);

            return Ok(_mapper.Map<IReadOnlyList<Book>,IReadOnlyList<BookToReturnDto>>(books));
        }

        //Get book
        [HttpGet("{id}")]
        public async Task<ActionResult<BookToReturnDto>> GetBook(int id)
        {
            var spec = new BooksWithAuthorsAndCatsSpecification(id); 

            var book = await _bookRepo.GetEntityWithSpecification(spec);

            return _mapper.Map<Book,BookToReturnDto>(book);
        }

       //Get Authors
       [HttpGet("authors")]
        public async Task<ActionResult<IReadOnlyList<Author>>> GetAuthorsAsync()
        { 
            return Ok(await _authorRepo.GetAllAsync());
        }


    }
}
