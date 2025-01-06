﻿using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Models.CaseAggregate
{
    public class Case : BaseEntity<int>
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public int? EstimatedDaysToEnd { get; set; } = null;

        public Guid CustomerId { get; set; }
        public User Customer { get; set; }

        public Guid AssigneeId { get; set; } // Всегда ненулевое
        public User Assignee { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsArchived { get; set; } = false; // Флаг архивирования
        public DateTime? ArchivedAt { get; set; } // Дата архивирования
    }
}
