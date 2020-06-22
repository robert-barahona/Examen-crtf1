using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEU_Examen.Transactions
{
    public class VideoBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(Videos a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Videos.Add(a);
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

        public static Videos Get(int? id)
        {
            Entities db = new Entities();
            return db.Videos.Find(id);
        }

        public static void Update(Videos video)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Videos.Attach(video);
                        db.Entry(video).State = System.Data.Entity.EntityState.Modified;
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
                        Videos video = db.Videos.Find(id);
                        db.Entry(video).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Videos> List()
        {
            Entities db = new Entities();
            return db.Videos.ToList();
        }

        public static List<Videos> ListToNames()
        {
            Entities db = new Entities();
            List<Videos> result = new List<Videos>();
            db.Videos.ToList().ForEach(x =>
                result.Add(
                    new Videos
                    {
                        titulo = x.titulo,
                        id = x.id
                    }));
            return result;
        }

        private static List<Videos> GetVideos(string criterio)
        {
            //Ejemplo: criterio = 'quin'
            //Posibles resultados => Quintana, Quintero, Pulloquinga, Quingaluisa...
            Entities db = new Entities();
            return db.Videos.Where(x => x.titulo.ToLower().Contains(criterio)).ToList();
        }

        private static Videos GetVideo(string titulo)
        {
            Entities db = new Entities();
            return db.Videos.FirstOrDefault(x => x.titulo == titulo);
        }
    }
}
