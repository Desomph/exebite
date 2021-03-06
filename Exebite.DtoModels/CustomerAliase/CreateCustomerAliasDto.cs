﻿using System.ComponentModel.DataAnnotations;

namespace Exebite.DtoModels
{
    public class CreateCustomerAliasDto
    {
        [Required]
        public string Alias { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int RestaurantId { get; set; }
    }
}
