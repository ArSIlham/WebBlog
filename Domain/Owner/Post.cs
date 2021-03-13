using System;
using System.Collections.Generic;
using System.Text;
using WebApplication13.Domain.Bases;

namespace Domain.Owner
{
    public class Post : BaseEntity<Guid>
    {

        public string PostName { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PostDate { get; set; }
        public int ShowingCount { get; set; }
        public int Comments { get; set; }
        public string UserId { get; set; }


    }
}
