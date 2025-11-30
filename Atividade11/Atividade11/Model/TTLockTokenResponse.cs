using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade11.Model
{
    public class TTLockTokenResponse
    {
        public string Access_Token { get; set; }
        public int uid { get; set; }
        public int Expires_In { get; set; }
        public string Refresh_Token { get; set; }
    }
}
