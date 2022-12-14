using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Service.IServices
{
    public interface IBanServices
    {
        public IEnumerable<Ban> GetAllBan();

        public Ban GetBan(string id);
    }
}
