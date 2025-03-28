﻿using EntityLayer.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Traversal.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
