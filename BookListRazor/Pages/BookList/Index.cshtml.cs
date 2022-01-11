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
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork<Book> _unitOfWork;

        public IndexModel(IUnitOfWork<Book> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Book> Books { get; set; }
        public void OnGet()
        {
            Books = _unitOfWork.EntityRepository.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            id = 0;
            var book = _unitOfWork.EntityRepository.GetById(id);
            if (book == null)
            {
                //return RedirectToPage("/Error");
                throw new Exception($"Book with Id {id} canot be found");
            } 

            _unitOfWork.EntityRepository.Delete(book);
            _unitOfWork.Save();
            return RedirectToPage("Index");
        }
    }
}
