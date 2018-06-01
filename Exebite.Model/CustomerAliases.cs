﻿namespace Exebite.Model
{
    public class CustomerAliases
    {
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public string Alias { get; set; }
    }
}
