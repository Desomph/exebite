﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Exebite.DataAccess.Entities;
using Exebite.DataAccess.Migrations;
using Exebite.Model;

namespace Exebite.DataAccess.Repositories
{
    public class RestaurantRepository : DatabaseRepository<Restaurant, RestaurantEntity, RestaurantQueryModel>, IRestaurantRepository
    {
        public RestaurantRepository(IFoodOrderingContextFactory factory, IMapper mapper)
            : base(factory, mapper)
        {
        }

        public Restaurant GetByName(string name)
        {
            if (name == string.Empty)
            {
                throw new System.ArgumentException("Name can't be empty");
            }

            using (var context = _factory.Create())
            {
                var restaurantEntity = context.Restaurants.Where(r => r.Name == name).FirstOrDefault();
                if (restaurantEntity == null)
                {
                    return null;
                }

                return _mapper.Map<Restaurant>(restaurantEntity);
            }
        }

        public override Restaurant Insert(Restaurant entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(nameof(entity));
            }

            using (var context = _factory.Create())
            {
                var restaurantEntity = _mapper.Map<RestaurantEntity>(entity);

                var addedEntity = context.Restaurants.Add(restaurantEntity).Entity;
                context.SaveChanges();
                return _mapper.Map<Restaurant>(addedEntity);
            }
        }

        public override Restaurant Update(Restaurant entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(nameof(entity));
            }

            using (var context = _factory.Create())
            {
                var restaurantEntity = _mapper.Map<RestaurantEntity>(entity);

                var dbRestaurant = context.Restaurants.FirstOrDefault(r => r.Id == entity.Id);
                context.Entry(dbRestaurant).CurrentValues.SetValues(restaurantEntity);

                List<FoodEntity> foodList = context.Foods.Where(f => f.Restaurant.Id == dbRestaurant.Id).ToList();

                // clear old menu
                dbRestaurant.DailyMenu.Clear();

                // bind daily food entities
                for (int i = 0; i < restaurantEntity.DailyMenu.Count; i++)
                {
                    var tmpfood = foodList.FirstOrDefault(f => f.Name == restaurantEntity.DailyMenu[i].Name);
                    if (tmpfood != null)
                    {
                        dbRestaurant.DailyMenu.Add(tmpfood);
                    }
                    else
                    {
                        restaurantEntity.DailyMenu[i].Restaurant = dbRestaurant;
                        dbRestaurant.DailyMenu.Add(restaurantEntity.DailyMenu[i]);
                    }
                }

                context.SaveChanges();

                var resultEntity = context.Restaurants.FirstOrDefault(r => r.Id == entity.Id);
                return _mapper.Map<Restaurant>(resultEntity);
            }
        }

        public override IList<Restaurant> Query(RestaurantQueryModel queryModel)
        {
            if (queryModel == null)
            {
                throw new System.ArgumentException("queryModel can't be null");
            }

            using (var context = _factory.Create())
            {
                var query = context.Restaurants.AsQueryable();

                if (queryModel.Id != null)
                {
                    query = query.Where(x => x.Id == queryModel.Id.Value);
                }

                var results = query.ToList();
                return _mapper.Map<IList<Restaurant>>(results);
            }
        }
    }
}