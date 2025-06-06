﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities.Constants;

namespace EcommerceApp.Domain.Entities
{
    public class Orders : BaseEntity
    {
        public string UserId { get; set; }

        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
