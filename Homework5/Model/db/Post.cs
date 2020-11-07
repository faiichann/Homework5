using System;
using System.Collections.Generic;

namespace Homework5.Model.db
{
    public partial class Post
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPost { get; set; }
        public DateTime? UserDate { get; set; }
    }
}
