﻿
using System;
using System.ComponentModel.DataAnnotations;
using Gamerent.Models;

namespace Gamerent.Dtos
{
    public class CustomerDto
    {
        
            public int Id { get; set; }

            [Required]
            [StringLength(255)]
            public string Name { get; set; }

            public bool IsSubscribedToNewsletter { get; set; }

            public byte MembershipTypeId { get; set; }

            
            public DateTime? Birthdate { get; set; }
        }
}