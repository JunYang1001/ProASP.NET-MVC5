﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage ="Please enter your name")]
        public string  Name { get; set; }
        [Required(ErrorMessage ="Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="Please enter a vaild eamil address")]
        public string Eamil { get; set; }
        [Required(ErrorMessage ="Please enter your phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Please specify whether you'll attend")]
        public bool WillAtend { get; set; }
    }
}