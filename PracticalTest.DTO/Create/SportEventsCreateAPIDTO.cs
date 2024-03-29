﻿namespace PracticalTest.DTO.Create
{
    public class SportEventsCreateAPIDTO
    {
        public string eventDate { get; set; } = DateTime.Now.ToString("yyyy/dd/MM");
        public string eventType { get; set; }
        public string eventName { get; set; }
        public int organizerId { get; set; }
    }
}
