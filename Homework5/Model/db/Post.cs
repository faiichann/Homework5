using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework5.Model.db
{
    public partial class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPost { get; set; }
        public DateTime? UserDate { get; set; }
    }
}
