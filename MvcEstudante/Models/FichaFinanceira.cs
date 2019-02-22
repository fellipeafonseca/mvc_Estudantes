using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using Model;

namespace Model
{
    public class FichaFinanceira
    {
        private Int64 codigo;
        private DateTime dataInicio;
        private bool bloqueio;
        private Estudante estudante;
        private decimal valor;



        #region Salvar Editar Excluir
        public virtual void GravarFichaFinanceira(FichaFinanceira ficha)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Save(ficha);
                transaction.Commit();
            }

        }


        public static List<FichaFinanceira> ListarFichaFinanceira()
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            {
                return session.CreateCriteria<FichaFinanceira>().List<FichaFinanceira>().ToList();//Retorna um tipo Ilist, e ele retorna um tipo List
            }

        }


        //public List<FichaFinanceira> ListarFichaFinanceira(string condicao)
        //{
        //    using (ISession session = NHibernateUtil.AbrirSessao())
        //    {
        //        return session.CreateCriteria<FichaFinanceira>().Add(Restrictions.IsNull("Kit.Codigo")).List<FichaFinanceira>().ToList();//Retorna um tipo Ilist, e ele retorna um tipo List


        //        //   Restrictions.Eq = Restrição de Equaldade
        //    }

        //}





        //public FichaFinanceira CarregarFichaFinanceira(Int64 codigo)
        //{

        //    using (ISession session = NHibernateUtil.AbrirSessao())
        //    {
        //        return session.Get<FichaFinanceira>(codigo);
        //    }



        //}

        public virtual void DeletarFichaFinanceira(FichaFinanceira FichaFinanceira)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Delete(FichaFinanceira);
                transaction.Commit();
            }



        }

        public virtual void AtualizarFichaFinanceira(FichaFinanceira FichaFinanceira)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Update(FichaFinanceira);
                transaction.Commit();

            }



        }



        #endregion



        public virtual decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }


        public FichaFinanceira()
        {
           
        }




        public virtual Estudante Estudante
        {
            get { return estudante; }
            set { estudante = value; }
        }



        public virtual bool Bloqueio
        {
            get { return bloqueio; }
            set { bloqueio = value; }
        }

        public virtual DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }


        public virtual Int64 Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        public override string ToString()
        {
            return Codigo + ", " + Estudante.Codigo + ", " + DataInicio + ", " + Bloqueio;
        }

    }
}
