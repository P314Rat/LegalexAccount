﻿using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.Web.ViewModels
{
    public class OrderViewModel
    {
        public ClientType ClientType { get; set; }
        public Service Service { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
    }
}
