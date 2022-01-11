using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using BookListRazor.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork<Book> _unitOfWork;

        public EditModel(IUnitOfWork<Book> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Book Book { get; set; }
        public IActionResult OnGet(int id)
        {
            Book = _unitOfWork.EntityRepository.GetById(id);
            if (Book == null)
            {
                return NotFound(id);
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EntityRepository.Update(Book);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
