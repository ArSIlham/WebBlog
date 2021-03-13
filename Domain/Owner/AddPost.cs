using System;
using System.Collections.Generic;
using System.Text;
using WebApplication13.Domain.Bases;

namespace Domain.Owner
{
    public class AddPost : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
