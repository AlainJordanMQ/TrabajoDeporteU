using System;
using System.Collections.Generic;
using System.Text;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;

namespace Trabajo.DAL
{
    public class RepositorioDeDeporte//: IRepositorio<Deporte>
    {
        /*
        private string DBName = "Deporte";
        private string TableName = "Equipo";
        public List<Deporte> Read
        {
            get
            {
                List<Deporte> datos = new List<Deporte>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Deporte>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Create(Deporte entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Deporte>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Deporte>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Deporte entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Deporte>(TableName);
                    coleccion.Update(entidadModificada);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }*/
    }
}
