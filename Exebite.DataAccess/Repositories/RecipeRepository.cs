﻿using System.Collections.Generic;
using System.Linq;
using Exebite.DataAccess.Entities;
using Exebite.DataAccess.Migrations;
using Exebite.Model;

namespace Exebite.DataAccess.Repositories
{
    public class RecipeRepository : DatabaseRepository<Recipe, RecipeEntity>, IRecipeRepository
    {
        private IFoodOrderingContextFactory _factory;

        public RecipeRepository(IFoodOrderingContextFactory factory)
            : base(factory)
        {
            _factory = factory;
        }

        public List<Recipe> GetRecipesForFood(Food food)
        {
            using (var context = _factory.Create())
            {
                var entities = context.FoodEntityRecipeEntity.Where(fe => fe.FoodEntityId == food.Id).Select(r => r.RecipeEntity).ToList();
                return entities.Select(r => AutoMapperHelper.Instance.GetMappedValue<Recipe>(r, context)).ToList();
            }
        }

        public List<Recipe> GetRecipesForMainCourse(Food mainCourse)
        {
            using (var context = _factory.Create())
            {
                var entities = context.Recipes.Where(r => r.MainCourseId == mainCourse.Id);
                return entities.Select(r => AutoMapperHelper.Instance.GetMappedValue<Recipe>(r, context)).ToList();
            }
        }

        public override Recipe Insert(Recipe entity)
        {
            using (var context = _factory.Create())
            {
                var recipeEntity = AutoMapperHelper.Instance.GetMappedValue<RecipeEntity>(entity, context);
                var resultEntity = context.Attach(recipeEntity).Entity;
                context.SaveChanges();
                var result = AutoMapperHelper.Instance.GetMappedValue<Recipe>(resultEntity, context);
                return result;
            }
        }

        public override Recipe Update(Recipe entity)
        {
            using (var context = _factory.Create())
            {
                var recipeEntity = AutoMapperHelper.Instance.GetMappedValue<RecipeEntity>(entity, context);
                foreach (var fre in recipeEntity.FoodEntityRecipeEntities)
                {
                    context.Attach(fre);
                }

                var old = context.Recipes.Find(entity.Id);
                context.Entry(old).CurrentValues.SetValues(recipeEntity);
                context.SaveChanges();

                var resultEntity = context.Recipes.FirstOrDefault(r => r.Id == entity.Id);
                var result = AutoMapperHelper.Instance.GetMappedValue<Recipe>(resultEntity, context);
                return result;
            }
        }
    }
}
