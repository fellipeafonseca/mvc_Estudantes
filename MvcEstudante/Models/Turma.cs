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
    public class Turma
    {
        private Int64 codigo;
        private String nome;
        private IList<Estudante> estudante;
        private DateTime dataInicio;
        private IList<Curso> cursos;

     


        #region Salvar, Editar, Excluir


        public virtual void GravarTurma()
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Save(this);
                transaction.Commit();
            }

        }


        public static List<Turma> ListarTurma()
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            {
                return session.CreateCriteria<Turma>().List<Turma>().ToList();//Retorna um tipo Ilist, e ele retorna um tipo List
            }

        }


        //public List<Turma> ListarTurma(string condicao)
        //{
        //    using (ISession session = NHibernateUtil.AbrirSessao())
        //    {
        //        return session.CreateCriteria<Turma>().Add(Restrictions.IsNull("Kit.Codigo")).List<Turma>().ToList();//Retorna um tipo Ilist, e ele retorna um tipo List


        //        //   Restrictions.Eq = Restrição de Equaldade
        //    }

        //}






        //public Turma CarregarTurma(Int64 codigo)
        //{

        //    using (ISession session = NHibernateUtil.AbrirSessao())
        //    {
        //        return session.Get<Turma>(codigo);
        //    }



        //}

        public virtual void DeletarTurma(Turma Turma)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Delete(Turma);
                transaction.Commit();
            }



        }

        public virtual void AtualizarTurma(Turma Turma)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Update(Turma);
                transaction.Commit();

            }



        }


        #endregion


        public Turma()
        {


        }


        public virtual IList<Curso> Cursos
        {
            get { return cursos; }
            set { cursos = value; }
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
        public  virtual IList<Estudante> Estudante
        {
            get { return estudante; }
            set { estudante = value; }
        }


        public virtual String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
    

        public override string ToString()
        {
            return Codigo + ", " + Nome + ", " +DataInicio;
        }

    }
}
