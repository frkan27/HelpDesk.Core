﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpDesk.Model.Entities.BaseEntities
{
    public abstract class BaseEntity<T>
    {

        [Key]
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string CreatedUserId { get; set; }
    }
}
