﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.ToDoListItem
{
    public class ToDoListItemViewModel
    {
        private ToDoListItemViewModel()
        {
            Name = default!;
            Completed = false;
            BusinessName = default!;
        }

        [JsonConstructor]
        public ToDoListItemViewModel(string name, bool completed, string businessName)
        {
            Name = name;
            Completed = completed;
            BusinessName = businessName!;
        }

        public string Name { get; set; }

        public bool Completed { get; set; }

        public string BusinessName { get; set; }
    }
}
