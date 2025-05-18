using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Dal.Entities
{
    public class Account
    {
        public long AccountId { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public List<Post> Posts { get; set; }
        public  List <Comment> Comments { get; set; }
    }
}

