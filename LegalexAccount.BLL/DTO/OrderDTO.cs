﻿using LegalexAccount.Utility.Types;


namespace LegalexAccount.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ClientType ClientType { get; set; }
        public ServiceType ServiceType { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
