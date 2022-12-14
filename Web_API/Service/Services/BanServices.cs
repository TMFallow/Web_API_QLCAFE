using Data.Models;
using Repo.IRepository;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BanServices : IBanServices
    {
        private readonly IRepository<Ban> ban;

        public BanServices(IRepository<Ban> ban)
        {
            this.ban = ban;
        }

        public IEnumerable<Ban> GetAllBan()
        {
            return ban.GetAll();
        }

        public Ban GetBan(string id)
        {
            return ban.Get(id);
        }
    }
}
