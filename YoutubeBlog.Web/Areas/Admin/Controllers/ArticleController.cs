using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.DTOs.Article;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;
        private readonly IToastNotification toast;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IToastNotification toast)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [Authorize(Roles =$" {RoleConsts.Admin}, {RoleConsts.SuperAdmin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        [Authorize(Roles = $" {RoleConsts.Admin}, {RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> DeletedArticle()
        {
            var articles = await articleService.GetAllArticlesWithCategoryDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        [Authorize(Roles = $" {RoleConsts.Admin}, {RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }
        [HttpPost]
        [Authorize(Roles = $" {RoleConsts.Admin}, {RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            var map = mapper.Map<Article>(articleAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articleService.CreateArticleAsync(articleAddDto);
                toast.AddSuccessToastMessage(Messages.Article.Add(articleAddDto.Title), new ToastrOptions { Title = "İşlem Başarılı" });

                //baslıkta success yazırmak yerıne Başarılı! basarılı yazdırıp içersine de göstermek istedigimiz mesajı ResultMessegas teki olusturdugumuz messages sınıfından eklemiş olduk 
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToTheModelState(this.ModelState);
                var categories = await categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleAddDto { Categories = categories });
            }
        }
        [HttpGet]
        [Authorize(Roles = $" {RoleConsts.Admin}, {RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Update(Guid articleId) //update o makalenın ıd si gelmesi gerekiyor. ondan guid articleId dedik // burda guncellenecek olan article nin bilgilerini ekrana yazdırıp id sini alıyoruz
        {
            var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            var articleUpdateDto = mapper.Map<ArticleUpdateDto>(article);
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }
        [HttpPost]
        [Authorize(Roles = $" {RoleConsts.Admin}, {RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto)   //bu method ta guncelleme işleminin yapılacagı yer olacak 
        {
            var map = mapper.Map<Article>(articleUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var title = await articleService.UpdateArticleAsync(articleUpdateDto);
                toast.AddSuccessToastMessage(Messages.Article.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToTheModelState(this.ModelState);

            }
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            articleUpdateDto.Categories = categories;
            return View(articleUpdateDto);
        }
        //delete işlemi için herhangi bir view olusturmıcaz. yeniden add işlemindeki gibi listenin cuncellenmıs halını sisteme göstericez yanı httppost işlemi olmayacak.

        [Authorize(Roles = $" {RoleConsts.Admin}, {RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            var title = await articleService.SafeDeleteArticleAsync(articleId);
            toast.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions() { Title = "İşlem başarılı" });
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
            //1- public async Task<IActionResult> Delete(Guid articleId) actionu olusturdukta sonra buna hemen gidip bir service yazıcaz.
            //2-servıcede olusturdugumuz metotu cagırıcaz. serviste yazdıgımız metotun ınterfacesını olusturmayı unutmuyoruz. yoksa oluşturdugumuz metotu burada cagıramıyoruz.
        }
        [Authorize(Roles = $" {RoleConsts.Admin}, {RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> UndoDelete(Guid articleId)
        {
            var title = await articleService.UndoDeleteArticleAsync(articleId);
            toast.AddSuccessToastMessage(Messages.Article.UndoDelete(title), new ToastrOptions() { Title = "İşlem başarılı" });
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}
