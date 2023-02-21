using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public Member Login(string email, string password);
        public bool EmailExist(Member email);
        public void Add(Member member);
        public void Update(Member member);
        public void Delete(string id);
        public List<Member> Search(string name);
        public List<Member> AllMember();
        public Member Get(string id);
    }
}
