﻿//using System;
//using System.Linq;
//using AutoMapper;
//using Exebite.DataAccess.Entities;
//using Exebite.Model;

//namespace Exebite.DataAccess.AutoMapper
//{
//    public class ExebiteMapper : Mapper, IMapper
//    {
//        public ExebiteMapper(IServiceProvider provider)
//            : base(new MapperConfiguration(cfg =>
//             {
//                 //cfg.ConstructServicesUsing(x => provider.GetService(x));

//                 //cfg.CreateMap(typeof(CustomerEntity), typeof(Customer));
//                 //cfg.CreateMap(typeof(OrderEntity), typeof(Order)).ReverseMap();
//                 //cfg.CreateMap(typeof(FoodEntity), typeof(Food));
//                 //cfg.CreateMap(typeof(RestaurantEntity), typeof(Restaurant));
//                 //cfg.CreateMap(typeof(LocationEntity), typeof(Location));
//                 //cfg.CreateMap(typeof(RecipeEntity), typeof(Recipe));
//                 //cfg.CreateMap<RecipeEntity, Recipe>().ForMember(r => r.SideDish, v => v.MapFrom(c => c.FoodEntityRecipeEntities.Select(re => re.FoodEntity).ToList()));
//                 //cfg.CreateMap(typeof(MealEntity), typeof(Meal));
//                 ////cfg.CreateMap<MealEntity, Meal>().ForMember(f => f.Foods, v => v.MapFrom(c => c.FoodEntityMealEntities.Select(fl => fl.FoodEntity).ToList())); // Populate Food list from helper property for many-to-many
//                 //cfg.CreateMap(typeof(CustomerAliasesEntities), typeof(CustomerAliases));
//                 //cfg.CreateMap(typeof(Customer), typeof(CustomerEntity));
//                 //cfg.CreateMap<Customer, CustomerEntity>().ForMember(i => i.LocationId, option => option.MapFrom(c => c.Location.Id));
//                 ////cfg.CreateMap(typeof(Order), typeof(OrderEntity));
//                 //cfg.CreateMap(typeof(Food), typeof(FoodEntity)).ConvertUsing<IFoodToFoodEntityConverter>();
//                 //cfg.CreateMap(typeof(Restaurant), typeof(RestaurantEntity));
//                 //cfg.CreateMap(typeof(Location), typeof(LocationEntity));
//                 //cfg.CreateMap(typeof(Recipe), typeof(RecipeEntity)).ConvertUsing<IRecipeToRecipeEntityConverter>();
//                 //cfg.CreateMap(typeof(Meal), typeof(MealEntity)).ConvertUsing<IMealToMealEntityConverter>();
//                 //cfg.CreateMap(typeof(CustomerAliases), typeof(CustomerAliasesEntities));


//                 //cfg.CreateMap(typeof(Customer), typeof(CustomerEntity));
//                 //cfg.CreateMap<Customer, CustomerEntity>().ForMember(i => i.LocationId, option => option.MapFrom(c => c.Location.Id));
//                 //cfg.CreateMap(typeof(Order), typeof(OrderEntity));
//                 //cfg.CreateMap(typeof(Food), typeof(FoodEntity)).ConvertUsing<FoodToFoodEntityConverter>();
//                 //cfg.CreateMap(typeof(Restaurant), typeof(RestaurantEntity));
//                 //cfg.CreateMap(typeof(Location), typeof(LocationEntity));
//                 //cfg.CreateMap(typeof(Recipe), typeof(RecipeEntity)).ConvertUsing<RecipeToRecipeEntityConverter>();
//                 //cfg.CreateMap(typeof(Meal), typeof(MealEntity)).ConvertUsing<MealToMealEntityConverter>();
//                 //cfg.CreateMap(typeof(CustomerAliases), typeof(CustomerAliasesEntities));

//                 // view models converters
//                 // cfg.CreateMap(typeof(Location), typeof(LocationViewModel));
//                 // cfg.CreateMap(typeof(Restaurant), typeof(RestaurantViewModel));
//                 // cfg.CreateMap(typeof(Location), typeof(CreateLocationModel));
//                 // cfg.CreateMap(typeof(Location), typeof(CreateLocationModel)).Reverse();

//             }))
//        {
//            AssertConfigurationIsValid();
//        }
//    }
//}