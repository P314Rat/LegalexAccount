﻿namespace Application.Core.DTO
{
    public class CalendarEventDTO
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? SpecialistName { get; set; }
        public string? Color { get; set; }
    }

}
