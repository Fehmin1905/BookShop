using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BookValidator:AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.AuthorName).NotEmpty();
            RuleFor(b => b.BookName).NotEmpty();
            RuleFor(b => b.Description).MinimumLength(5);
            RuleFor(b => b.Price).GreaterThanOrEqualTo(10).When(b => b.BookCategoryId == 1);
            RuleFor(b => b.Language).Must(StartWithCapital).WithMessage("Language must be start with capital letter.");

            
        }
        private bool StartWithCapital(string language)
        {
            var result = language.Substring(0, 1);
            if (result.Any(char.IsUpper))
            {
                return true;
            }
            return false;
        }
    }
}
