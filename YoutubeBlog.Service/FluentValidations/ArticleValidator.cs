using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class ArticleValidator : AbstractValidator<Article>  //burada FluentValidation kullanıyruz.Validasyon işlemlerini eklerken(add) ve güncellerken(update) kullanıcaz.
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithName("Başlık"); //title ı turkceleştirilmiş hale cevirmek için kullandık

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(300)
                .WithName("İçerik");


        }
    }
}
