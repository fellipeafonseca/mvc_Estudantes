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
    public class Curso
    {
        private Int64 codigo;
        private String nome;
        private int cargaHoraria;
        private DateTime dataInicio;
        private IList<Estudante> estudante;

        #region Salvar,Listar, Deletar
      
        
        public virtual void GravarCurso(Curso curso)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Save(curso);
                transaction.Commit();
            }

        }


        public static List<Curso> ListarCurso()
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            {
                return session.CreateCriteria<Curso>().List<Curso>().ToList();//Retorna um tipo Ilist, e ele retorna um tipo List
            }

        }


        public virtual List<Curso> ListarCurso(string condicao)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            {
                return session.CreateCriteria<Curso>().Add(Restrictions.IsNull("Kit.Codigo")).List<Curso>().ToList();//Retorna um tipo Ilist, e ele retorna um tipo List


                //   Restrictions.Eq = Restrição de Equaldade
            }

        }







        public virtual Curso CarregarCurso(Int64 codigo)
        {

            using (ISession session = NHibernateUtil.AbrirSessao())
            {
                return session.Get<Curso>(codigo);
            }



        }

        public virtual void DeletarCurso(Curso Curso)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Delete(Curso);
                transaction.Commit();
            }



        }

        public virtual void AtualizarCurso(Curso Curso)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Update(Curso);
                transaction.Commit();

            }



        }


        #endregion

       


        public Curso()
        {
      
        

        }


        public virtual Int64 Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public virtual IList<Estudante> Estudante
        {
            get { return estudante; }
            set { estudante = value; }
        }

        public virtual String Nome
        {
            get { return nome; }
            set { nome = value; }
        }


        public virtual int CargaHoraria
        {
            get { return cargaHoraria; }
            set { cargaHoraria = value; }
        }
        public virtual DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }


        public override string ToString()
        {
            return Nome+", "+CargaHoraria+", "+DataInicio ;
        }
    }
}
