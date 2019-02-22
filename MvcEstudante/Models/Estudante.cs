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
    public class Estudante
    {

        #region Propriedades;
        private Int64 codigo;
        private Int16 idade;
        private String email;
        private String sexo;
        private String senha;
        private String nome;
        private Turma turma;
        private IList<Curso> curso;
        private FichaFinanceira fichaFinanceira;

      

        private List<Int64> codigosCursos;

        private string auxCodigos;

        public virtual string AuxCodigos
        {
            get { return auxCodigos; }
            set { auxCodigos = value; }
        }



        public virtual List<Int64> CodigosCursos
        {

          

            get {return codigosCursos;}
            set
            {


                codigosCursos = value;


                curso = new List<Curso>();

                codigosCursos.ForEach(id => curso.Add(new Curso() { Codigo = id }

                    ));
            }
            //   codigosCursos = value; }
        }

      
  
        # endregion



        #region Salvar, Editar , Excluir

        public virtual void GravarEstudante()
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Save(this);
                transaction.Commit();
            }

        }




        public static List<Estudante> ListarEstudante()
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            {
                return session.CreateCriteria<Estudante>().List<Estudante>().ToList();//Retorna um tipo Ilist, e ele retorna um tipo List
            }

        }


        //public List<Estudante> ListarEstudante(string condicao)
        //{
        //    using (ISession session = NHibernateUtil.AbrirSessao())
        //    {
        //        return session.CreateCriteria<Estudante>().Add(Restrictions.IsNull("Kit.Codigo")).List<Estudante>().ToList();//Retorna um tipo Ilist, e ele retorna um tipo List


        //        //   Restrictions.Eq = Restrição de Equaldade
        //    }

        //}






        //public Estudante CarregarEstudante(Int64 codigo)
        //{

        //    using (ISession session = NHibernateUtil.AbrirSessao())
        //    {
        //        return session.Get<Estudante>(codigo);
        //    }



        //}

        public virtual void DeletarEstudante(Estudante Estudante)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Delete(Estudante);
                transaction.Commit();
            }



        }

        public virtual void AtualizarEstudante(Estudante Estudante)
        {
            using (ISession session = NHibernateUtil.AbrirSessao())
            using (ITransaction transaction = session.BeginTransaction())
            {
                //Ou update
                session.Merge(Estudante);
                transaction.Commit();

            }



        }

        #endregion





        # region Construtor
        public Estudante()
        {

        }

        #endregion


        # region Propriedades
        public virtual Turma Turma
        {
            get { return turma; }
            set { turma = value; }
        }
        public virtual String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public virtual IList<Curso> Curso
        {
            get { return curso; }
            set { curso = value; }
        }
    
        public virtual FichaFinanceira FichaFinanceira
        {
            get { return fichaFinanceira; }
            set { fichaFinanceira = value; }
        }
        public virtual String Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public virtual String Email
        {
            get { return email; }
            set { email = value; }
        }
        public virtual Int64 Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public virtual Int16 Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        public virtual String Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public override string ToString()
        {
            return Codigo + ", " + Nome + ", " + Email + ", " + Idade + ", " + Sexo + ", " 
                + Turma +", "+Senha+", "+Curso;
        }

        #endregion

    }


}
