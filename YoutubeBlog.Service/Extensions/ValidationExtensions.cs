using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeBlog.Service.Extensions
{
	public static class ValidationExtensions
	{
        public static void AddToTheModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
        public static void AddToModelIdentityState(this IdentityResult result, ModelStateDictionary modelState) // IdentityResult ekledılk
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError("",error.Description);
            }
        }
    }
}
