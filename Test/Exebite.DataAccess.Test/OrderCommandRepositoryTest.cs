﻿using System;
using System.Collections.Generic;
using System.Linq;
using Either;
using Exebite.Common;
using Exebite.DataAccess.Context;
using Exebite.DataAccess.Entities;
using Exebite.DataAccess.Repositories;
using Exebite.DataAccess.Test.BaseTests;
using Exebite.DataAccess.Test.Mocks;
using Optional.Xunit;
using static Exebite.DataAccess.Test.RepositoryTestHelpers;

namespace Exebite.DataAccess.Test
{
    public sealed class OrderCommandRepositoryTest : CommandRepositoryTests<OrderCommandRepositoryTest.Data, int, OrderInsertModel, OrderUpdateModel>
    {
        private readonly IGetDateTime _dateTime;

        public OrderCommandRepositoryTest()
        {
            _dateTime = new GetDateTimeStub();
        }

        protected override IEnumerable<Data> SampleData =>
                      Enumerable.Range(1, int.MaxValue).Select(content => new Data
                      {
                          Id = content,
                          CustomerId = content,
                          MealId = content,
                          Note = $"Note {content}",
                          Price = 3.4m * content,
                          Date = _dateTime.Now()
                      });

        protected override IDatabaseCommandRepository<int, OrderInsertModel, OrderUpdateModel> CreateSut(IFoodOrderingContextFactory factory)
        {
            return CreateOrderCommandRepositoryInstance(factory);
        }

        protected override int GetId(Either<Error, int> newObj)
        {
            return newObj.RightContent();
        }

        protected override void InitializeStorage(IFoodOrderingContextFactory factory, int count)
        {
            using (var context = factory.Create())
            {
                var location = new LocationEntity
                {
                    Id = 1,
                    Name = "location name",
                    Address = "Address"
                };

                context.Locations.Add(location);

                var customers = Enumerable.Range(1, count + 6).Select(x => new CustomerEntity
                {
                    Id = x,
                    Name = "Customer name ",
                    AppUserId = "AppUserId",
                    Balance = 99.99m,
                    LocationId = 1,
                });
                context.Customers.AddRange(customers);

                var meals = Enumerable.Range(1, count + 6).Select(x => new MealEntity
                {
                    Id = x,
                    Price = 3.2m * x
                });
                context.Meals.AddRange(meals);

                var orders = Enumerable.Range(1, count).Select(x => new OrderEntity
                {
                    Id = x,
                    CustomerId = x,
                    Date = _dateTime.Now().AddHours(x),
                    MealId = x,
                    Note = "note ",
                    Price = 10.5m * x
                });
                context.Orders.AddRange(orders);

                context.SaveChanges();
            }
        }

        protected override OrderInsertModel ConvertToInput(Data data)
        {
            return new OrderInsertModel
            {
                CustomerId = data.CustomerId,
                MealId = data.MealId,
                Note = data.Note,
                Price = data.Price,
                Date = data.Date
            };
        }

        protected override OrderUpdateModel ConvertToUpdate(Data data)
        {
            return new OrderUpdateModel
            {
                CustomerId = data.CustomerId,
                MealId = data.MealId,
                Note = data.Note,
                Price = data.Price,
                Date = data.Date
            };
        }

        protected override OrderInsertModel ConvertToInvalidInput(Data data)
        {
#pragma warning disable RETURN0001 // Do not return null
            return null;
#pragma warning restore RETURN0001 // Do not return null
        }

        protected override OrderUpdateModel ConvertToInvalidUpdate(Data data)
        {
#pragma warning disable RETURN0001 // Do not return null
            return null;
#pragma warning restore RETURN0001 // Do not return null
        }

        protected override int GetUnExistingId()
        {
            return 99999;
        }

        public sealed class Data
        {
            public int? Id { get; set; }

            public decimal Price { get; set; }

            public DateTime Date { get; set; }

            public string Note { get; set; }

            public int MealId { get; set; }

            public int CustomerId { get; set; }
        }
    }
}