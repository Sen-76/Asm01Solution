using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class MemberManagerment
    {
        private static MemberManagerment instance = null;
        private static readonly object instanceLock = new object();
        public static MemberManagerment Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new MemberManagerment();
                }
                return instance;
            }
        }
        public bool ExistEmail(Member member)
        {
            List<string> list = new List<string>();
            try
            {
                var context = new SaleManagerWPFContext();
                list = context.Members.Where(x => x.MemberId != member.MemberId).Select(x => x.Email).ToList();
                if (list.Contains(member.Email))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Member Login(string email, string password)
        {
            Member member;
            try
            {
                var context = new SaleManagerWPFContext();
                member = context.Members.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public List<Member> AllMember()
        {
            List<Member> member;
            try
            {
                var context = new SaleManagerWPFContext();
                member = context.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public void Add(Member member)
        {
            try
            {
                if (!ExistEmail(member))
                {
                    var context = new SaleManagerWPFContext();
                    context.Members.Add(member);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Member Get(string id)
        {
            Member member;
            try
            {
                var context = new SaleManagerWPFContext();
                member = context.Members.Where(x => x.MemberId == int.Parse(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public void Update(Member member)
        {
            Member memberUpdate = new Member();
            try
            {
                if (!ExistEmail(member))
                {
                    using (var context = new SaleManagerWPFContext())
                    {
                        memberUpdate = context.Members.Where(x => x.MemberId == member.MemberId).FirstOrDefault();
                        if (memberUpdate!=null)
                        {
                            memberUpdate.Email = member.Email;
                            memberUpdate.Password = member.Password;
                            memberUpdate.City = member.City;
                            memberUpdate.CompanyName = member.CompanyName;
                            memberUpdate.Country = member.Country;
                            context.Members.Update(memberUpdate);
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(string id)
        {
            var context = new SaleManagerWPFContext();
            Member member = context.Members.Where(x => x.MemberId == int.Parse(id)).FirstOrDefault();
            if (member != null)
            {
                context.Members.Remove(member);
                context.SaveChanges();
            }
        }
        public List<Member> Search(string name)
        {
            List<Member> member;
            try
            {
                var context = new SaleManagerWPFContext();
                member = context.Members.Where(x => x.Email.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
    }
}
