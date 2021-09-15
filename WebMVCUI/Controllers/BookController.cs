using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVCUI.Models.ViewModels;

namespace WebMVCUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _bookService.GetAll().Data;

            BookViewModels bookViewModels = new BookViewModels()
            {
                BookForGetAllDtos = result
            };
            return View(bookViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("add")]
        public IActionResult Add(BookForAddDto bookForAddDto)
        {
            var result = _bookService.Add(bookForAddDto);
            return RedirectToAction("Index", result);
        }



        public IActionResult EditPage(int id)
        {
            var updatedBook = _bookService.GetById(id).Data;
            
            return View(updatedBook);
        }
        [HttpPost("edit")]
        public IActionResult Edit(BookForAddDto bookForUpdateDto)
        {
            _bookService.Update(bookForUpdateDto);
            return RedirectToAction("Index");
        }




        public IActionResult Delete(BookForDeleteDto bookForDeleteDto)
        {
            var deletedBook= _bookService.GetById(bookForDeleteDto.Id);
            if (!deletedBook.Success)
            {
                return BadRequest(deletedBook.Data);
            }
            _bookService.Delete(deletedBook.Data);
            return RedirectToAction("Index");
        }

        public IActionResult AdditionalInfo(int id)
        {
            var info = _bookService.GetById(id).Data;
            return View(info);
        }
    }
}
