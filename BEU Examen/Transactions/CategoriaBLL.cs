using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEU_Examen.Transactions
{
    public class CategoriaBLL
    {
        public static List<Categorias> List()
        {
            Entities db = new Entities();
            return db.Categorias.ToList();
        }
    }
}
