using BusinessObject;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void Add(Member member) => MemberManagerment.Instance.Add(member);
        public void Update(Member member) => MemberManagerment.Instance.Update(member);
        public void Delete(string id) => MemberManagerment.Instance.Delete(id);
        public Member Get(string id) => MemberManagerment.Instance.Get(id);
        public List<Member> Search(string name) => MemberManagerment.Instance.Search(name);
        public List<Member> AllMember() => MemberManagerment.Instance.AllMember();
        public Member Login(string email, string password) => MemberManagerment.Instance.Login(email, password);
        public bool EmailExist(Member email) => MemberManagerment.Instance.ExistEmail(email);
    }
}
