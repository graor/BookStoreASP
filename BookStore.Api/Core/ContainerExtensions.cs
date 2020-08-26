using BookStore.Application;
using BookStore.Application.Commands;
using BookStore.Application.Queries;
using BookStore.DataAccess;
using BookStore.Implementation.Commands;
using BookStore.Implementation.Queries;
using BookStore.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {

            //Validators
            services.AddTransient<CreateGroupValidator>();
            services.AddTransient<UpdateGroupValidator>();
            services.AddTransient<RegistrationUserValidator>();
            services.AddTransient<CreateAuthorValidator>();
            services.AddTransient<CreateGenreValidator>();
            services.AddTransient<CreateProductValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<UpdateAuthorValidator>();
            services.AddTransient<UpdateGenreValidator>();
            services.AddTransient<UpdateProductValidator>();
            services.AddTransient<OrderValidator>();
            services.AddTransient<UpdateOrderValidator>();

            services.AddTransient<UseCaseExecutor>();

            //Commands
            //Group
            services.AddTransient<ICreateGroupCommand, EfCreateGroupCommand>(); //1
            services.AddTransient<IDeleteGroupCommand, EfDeleteGroupCommand>(); //2
            services.AddTransient<IUpdateGroupCommand, EfUpdateGroupCommand>(); //3
            //User
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>(); //4
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>(); //5
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>(); //6
            //Author
            services.AddTransient<ICreateAuthorCommand, EfCreateAuthorCommand>(); //7
            services.AddTransient<IDeleteAuthorCommand, EfDeleteAuthorCommand>(); //8
            services.AddTransient<IUpdateAuthorCommand, EfUpdateAuthorCommand>(); //9
            //Genre
            services.AddTransient<ICreateGenreCommand, EfCreateGenreCommand>(); //10
            services.AddTransient<IDeleteGenreCommand, EfDeleteGenreCommand>(); //11
            services.AddTransient<IUpdateGenreCommand, EfUpdateGenreCommand>(); //12
            //Product
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>(); //13
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>(); //14
            services.AddTransient<IUpdateProductCommand, EfUpdateProductCommand>(); //15


            //Queries
            services.AddTransient<IGetGroupsQuery, EfGetGroupsQuery>(); //16

            services.AddTransient<IGetAuthorsQuery, EfGetAuthorsQuery>(); //17

            services.AddTransient<IGetGenresQuery, EfGetGenresQuery>(); //18

            services.AddTransient<IGetAuthorQuery, EfGetAuthorQuery>(); //19

            services.AddTransient<IGetGenreQuery, EfGetGenreQuery>(); //20

            services.AddTransient<IGetGroupQuery, EfGetGroupQuery>(); //21

            services.AddTransient<IGetProductQuery, EfGetProductQuery>(); //22

            services.AddTransient<IGetUserQuery, EfGetUserQuery>(); //23

            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>(); //24

            services.AddTransient<IGetProductsQuery, EfGetProductsQuery>(); //25


            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>(); //26
            services.AddTransient<IDeleteOrderCommand, EfDeleteOrderCommand>(); //27
            services.AddTransient<IUpdateOrderCommand, EfUpdateOrderCommand>(); //28


            services.AddTransient<IGetOrdersQuery, EfGetOrdersQuery>(); //29
            services.AddTransient<IGetOrderQuery, EfGetOrderQuery>(); //30
            services.AddTransient<IGetUseCaseQuery, EfGetUseCaseLogsQuery>(); //31
        }

        public static void AddJwt(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<BookStoreContext>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();


                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }
    }
}
