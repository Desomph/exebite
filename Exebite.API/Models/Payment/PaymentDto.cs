﻿namespace Exebite.API.Models
{
    public class PaymentDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public decimal Amount { get; set; }
    }
}