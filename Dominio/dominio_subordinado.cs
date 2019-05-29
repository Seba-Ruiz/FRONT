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


    }
}