﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models.Entities
{
    public class Post : BaseEntity
    {
        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        [StringLength(300, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Title { get; set; }

        [StringLength(1500, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Content { get; set; }

        [StringLength(8000, ErrorMessage = "{0} can have a max of {1} characters")]
        public string LinkOrImageUrl { get; set; }

        public PostType PostType { get; set; }


    }
}
