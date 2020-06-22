using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEU_Examen.Transactions
{
    public class LibroBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(Libros a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libros.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Libros Get(int? id)
        {
            Entities db = new Entities();
            return db.Libros.Find(id);
        }

        public static void Update(Libros libro)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libros.Attach(libro);
                        db.Entry(libro).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Libros libro = db.Libros.Find(id);
                        db.Entry(libro).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Libros> List()
        {
            Entities db = new Entities();
            return db.Libros.ToList();
        }

        public static List<Libros> ListToNames()
        {
            Entities db = new Entities();
            List<Libros> result = new List<Libros>();
            db.Libros.ToList().ForEach(x =>
                result.Add(
                    new Libros
                    {
                        titulo = x.titulo,
                        id = x.id
                    }));
            return result;
        }

        private static List<Libros> GetLibros(string criterio)
        {
            //Ejemplo: criterio = 'quin'
            //Posibles resultados => Quintana, Quintero, Pulloquinga, Quingaluisa...
            Entities db = new Entities();
            return db.Libros.Where(x => x.titulo.ToLower().Contains(criterio)).ToList();
        }

        private static Libros GetLibro(string titulo)
        {
            Entities db = new Entities();
            return db.Libros.FirstOrDefault(x => x.titulo == titulo);
        }
    }
}
