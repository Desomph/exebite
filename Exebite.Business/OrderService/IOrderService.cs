﻿using System;
using System.Collections.Generic;
using Exebite.Model;

namespace Exebite.Business
{
    public interface IOrderService
    {
        /// <summary>
        /// Gets all orders from database
        /// </summary>
        /// <returns>List of all orders</returns>
        List<Order> GetAllOrders();

        /// <summary>
        /// Gets <see cref="Order"/> by Id
        /// </summary>
        /// <param name="orderId">Id of order</param>
        /// <returns>Order with given Id</returns>
        Order GetOrderById(int orderId);

        /// <summary>
        /// Gets all orders placed by <see cref="Customer"/>
        /// </summary>
        /// <param name="customerId">Id of customer</param>
        /// <returns>List of all cutomers order</returns>
        List<Order> GetAllOrdersForCustomer(int customerId);

        /// <summary>
        /// Get all orders for given <see cref="Restaurant"/>
        /// </summary>
        /// <param name="restorauntId">Id of restaurant</param>
        /// <returns>List of orders for given restaurant</returns>
        List<Order> GetAllOrdersForRestoraunt(int restorauntId);

        /// <summary>
        /// Gets all orders for given date
        /// </summary>
        /// <param name="date">Date to get orders for</param>
        /// <returns>List of orders placed on given date</returns>
        List<Order> GetOrdersForDate(DateTime date);

        /// <summary>
        /// Place new order in database
        /// </summary>
        /// <param name="order">New <see cref="Order"/></param>
        /// <returns>New order from database</returns>
        Order PlaceOreder(Order order);

        /// <summary>
        /// Update order data
        /// </summary>
        /// <param name="order"><see cref="Order"/> with new data</param>
        /// <returns>Updated order from database</returns>
        Order EditOrder(Order order);

        /// <summary>
        /// Cancel order
        /// </summary>
        /// <param name="orderId">Id of order</param>
        void CancelOrder(int orderId);
    }
}
