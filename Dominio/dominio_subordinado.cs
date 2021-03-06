﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Dominio
{
    public class dominio_subordinado
    {
        public void Guardar(WEB_Subordinado a)
        {
            try
            {
                using (var ctx = new FRONTEntities())
                {
                    if (a.id_subordinado > 0) //Registro que ya existe
                    {
                        ctx.Entry(a).State = EntityState.Modified;
                    }
                    else // Registro que es nuevo
                    {
                        ctx.Entry(a).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public List<WEB_Subordinado> Listar()
        {
            var tel = new List<WEB_Subordinado>();
            try
            {
                using (var ctx = new FRONTEntities())

                    tel = ctx.WEB_Subordinado
                        .Where(x => x.estado == true)
                        .ToList();
            }
            catch (Exception E)
            {

                throw E;
            }
            return tel;
        }

        public List<WEB_Subordinado> ListarSinEstado()
        {
            var tel = new List<WEB_Subordinado>();
            try
            {
                using (var ctx = new FRONTEntities())

                    tel = ctx.WEB_Subordinado
                        .ToList();
            }
            catch (Exception E)
            {

                throw E;
            }
            return tel;
        }

        public List<WEB_Subordinado> ObtenerPorIDServicio(int id)
        {
            var tel = new List<WEB_Subordinado>();
            try
            {
                using (var ctx = new FRONTEntities())

                    tel = ctx.WEB_Subordinado.Where(x=>x.servicio_id==id)
                        .ToList();
            }
            catch (Exception E)
            {

                throw E;
            }
            return tel;
        }

        public WEB_Subordinado ObtenerPorID(int id)
        {
            var sub = new WEB_Subordinado();
            try
            {
                using (var ctx = new FRONTEntities())

                    sub = ctx.WEB_Subordinado.Where(x => x.id_subordinado == id)
                        .FirstOrDefault();
            }
            catch (Exception E)
            {

                throw E;
            }
            return sub;
        }

        public WEB_Subordinado ObtenerPorDNI(int? id)
        {
            var sub = new WEB_Subordinado();
            try
            {
                using (var ctx = new FRONTEntities())

                    sub = ctx.WEB_Subordinado.Where(x => x.dni == id)
                        .FirstOrDefault();
            }
            catch (Exception E)
            {

                throw E;
            }
            return sub;
        }

        public string ObtenerNombrePorId(int id)
        {
            try
            {
                using (var ctx = new FRONTEntities())
                {
                    string sub = (from s in ctx.WEB_Subordinado
                                  where s.id_subordinado == id
                                  select s.nombre + " " + s.apellido).FirstOrDefault();
                    return sub;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string ObtenerServicioPorId(int id)
        {
            try
            {
                using (var ctx = new FRONTEntities())
                {
                    string srv = (from a in ctx.WEB_Subordinado
                                  join b in ctx.WEB_Servicio on a.servicio_id equals b.idservicio
                                  where a.id_subordinado == id
                                  select b.servicio).FirstOrDefault();

                    return srv;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string ObtenerMacPorSubordinado(int id)
        {
            try
            {
                using (var ctx = new FRONTEntities())
                {
                    string mac = (from a in ctx.WEB_Subordinado
                                  join b in ctx.WEB_Equipo on a.id_subordinado equals b.subordinado_id
                                  where a.id_subordinado == id
                                  select b.mac).FirstOrDefault();

                    return mac;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
