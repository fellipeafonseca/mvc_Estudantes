using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using FluentNHibernate.Mapping;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using Model;

namespace Model
{
    public class NHibernateUtil
    {


        private static readonly ISessionFactory fabricaDeSessao;
        private const String CodSessaoAtual = "nhibernate.current_session";



        static NHibernateUtil()
        {

            try
            {
                //Configuration cfg = new Configuration();
                //cfg.Configure().AddAssembly("Model");
                //fabricaDeSessao = cfg.BuildSessionFactory();



                fabricaDeSessao = Fluently.Configure().Mappings(m => m.FluentMappings.AddFromAssemblyOf
                    <Turma>()).BuildSessionFactory();




            }

            catch (Exception)
            {

                throw;
            }

        }



        #region Métodos

        public static ISession AbrirSessao()
        {

            return fabricaDeSessao.OpenSession();
        }


        public void FecharSessao()
        {
            ISession sessao = fabricaDeSessao.GetCurrentSession();
            if (sessao != null)
            {

                sessao.Close();

            }

        }

        public static void FecharFabricaSessao()
        {
            if (fabricaDeSessao != null || fabricaDeSessao.IsClosed)
            {
                fabricaDeSessao.Close();
            }


        }



        # endregion





    }
}
