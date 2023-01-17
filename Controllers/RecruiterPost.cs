﻿using MergeMe.Model;
using MergeMe.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace MergeMe.Controllers
{
    public class RecruiterPost
    {
        public static string Template => "/recruiter";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(RecruiterRequest recruiterRequest, UserManager<IdentityUser> userManager)
        {
            var recruiter = new IdentityUser { UserName = recruiterRequest.email, Email = recruiterRequest.email };
            var result = userManager.CreateAsync(recruiter, recruiterRequest.password).Result;

            if(!result.Succeeded)
            {
                return Results.ValidationProblem(result.Errors.ConvertToProblemToDetails());
            }

            var recruiterClaims = new List<Claim>
            {
                new Claim("FirstName", recruiterRequest.firstName),
                new Claim("LastName", recruiterRequest.lastName)
            };

            var claimResult = userManager.AddClaimsAsync(recruiter, recruiterClaims).Result;

            if(!claimResult.Succeeded)
            {
                return Results.ValidationProblem(result.Errors.ConvertToProblemToDetails());
            }

            return Results.Created($"/recruiter/{recruiter.Id}", recruiter.Id);
        }
    }
}