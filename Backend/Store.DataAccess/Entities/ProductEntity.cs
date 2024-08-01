﻿namespace Store.DataAccess.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Guid ImageID { get; set; }
        public ImageEntity? Image { get; set; }
    }
}
