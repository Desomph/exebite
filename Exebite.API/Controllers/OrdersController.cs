﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Exebite.API.Models;
using Exebite.Business;
using Exebite.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exebite.API.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMenuService _menuService;
        private readonly IOrderService _orderService;
        private readonly IFoodService _foodService;
        private readonly IMapper _exebiteMapper;

        public OrdersController(ICustomerService customerService, IMenuService menuService, IOrderService orderService, IFoodService foodService, IMapper exebiteMapper)
        {
            _customerService = customerService;
            _menuService = menuService;
            _orderService = orderService;
            _foodService = foodService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listOfOrders = _orderService.GetAllOrders();
            return Ok(_exebiteMapper.Map<IEnumerable<OrderModel>>(listOfOrders));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(_exebiteMapper.Map<OrderModel>(order));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var createdOrder = _orderService.CreateOrder(_exebiteMapper.Map<Order>(model));

            return Ok(createdOrder.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateOrderModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Order currentOrder = _orderService.GetOrderById(id);
            if (currentOrder == null)
            {
                return NotFound();
            }

            _exebiteMapper.Map(model, currentOrder);
            var updatedOrder = _orderService.UpdateOrder(currentOrder);
            return Ok(updatedOrder.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}