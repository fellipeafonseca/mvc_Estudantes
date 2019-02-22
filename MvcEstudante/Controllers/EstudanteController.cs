//using ExemploMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace ExemploMVC.Controllers
{
    public class EstudanteController : Controller
    {
       
        Estudante estudante;
        //
        // GET: /Estudante/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //Get:Estudante/Index/(id)


        public ActionResult Index()
        {
            // Estudante = new Estudante();

            List<Estudante> teste = Estudante.ListarEstudante();


            return View(teste);
        }


        public ActionResult Login()
        {

            return View();


        }

[HttpPost]
        public ActionResult Login(Estudante estudante)
        {

          //  return Detalhar(estudante.Codigo);

            Autentica au = new Autentica();

            Estudante e = au.Autenticar(estudante.Email, estudante.Senha);


              if(e!=null)
              {
                  ViewBag.Curso = e.Curso;
                //  return Detalhar(e.Codigo);
                  return View("Detalhar", e);

              }

              else
              {
                 
                  //erro

                  return null;
              }

        }

        //Get:Estudante/obter/(id)
        public ActionResult Detalhar(long id)
        {

            List<Estudante> listEst = Estudante.ListarEstudante();

            foreach (Estudante e in listEst)
                if (e.Codigo == id){


                    ViewBag.Curso = e.Curso;
                    return View(e);


                }

            return View("");

        
        }



        public ActionResult Criar()
        {


            ViewBag.Turma = Turma.ListarTurma();
            ViewBag.Curso = Curso.ListarCurso();




            



            return View();

        }


        [HttpPost]

        public ActionResult Criar(Estudante estudante)
        {



            var n = estudante.AuxCodigos.Split(',');

            estudante.Curso = new List<Curso>();
            foreach (var c in n)
            {
                Curso cc= new Curso();
                cc.Codigo=Convert.ToInt32(c);

             
                estudante.Curso.Add(cc);
              
            }
            

           estudante.GravarEstudante(); //GravarEstudante(estudante);
           estudante.FichaFinanceira = new FichaFinanceira();
           estudante.FichaFinanceira.DataInicio = DateTime.Now;
           estudante.FichaFinanceira.Bloqueio = false;
           estudante.FichaFinanceira.Valor = 122;
           estudante.FichaFinanceira.Estudante = estudante;


           estudante.FichaFinanceira.GravarFichaFinanceira(estudante.FichaFinanceira);

            return View(estudante);

        }




        public ActionResult Editar(long id)
        {

            //Fake não vai apagar
            //Estudante Estudante = new Estudante();
            //Estudante.Codigo = id;
            //Estudante.Nome = "ddvsd" + id.ToString();
            //Estudante.Telefone = 1222+id;


            List<Estudante> teste = Estudante.ListarEstudante();

            //  Estudante c = new Estudante();

            //  List<Estudante> Estudantes;
            // Estudante.ListarEstudante();

            foreach (Estudante c in teste)
                if (c.Codigo == id)
                    return View(c);

            return null;
        }



        [HttpPost]
        public ActionResult Editar(Estudante c)
        {
            //nhibernateDeletar(Estudante);

            //List<Estudante> teste = new List<Estudante>();

            //for (int i = 0; i < 5; i++)
            //{
            //    Estudante c = new Estudante();
            //    c.Codigo = i;
            //    c.Nome = "Estudante" + i.ToString();

            //    c.Telefone = 222222 + i;
            //    teste.Add(c);
            //}
           //e = new Estudante();
            estudante = new Estudante();
            estudante.AtualizarEstudante(c);

            List<Estudante> teste = Estudante.ListarEstudante();




            return View("Index", teste);
        }


        public ActionResult Deletar(long id)
        {
            List<Estudante> l = Estudante.ListarEstudante();

            foreach (Estudante c in l)
                if (c.Codigo == id)
                    return View(c);


            return null;
        }




        [HttpPost]
        public ActionResult Deletar(Estudante c)
        {
            //nhibernateDeletar(Estudante);

          //  Estudante = new Estudante();
            estudante.DeletarEstudante(c);

            List<Estudante> l = Estudante.ListarEstudante();
            //  List<Estudante> teste;

            //for (int i = 0; i < 5; i++)
            //{
            //    Estudante c = new Estudante();
            //    c.Codigo = i;
            //    c.Nome = "Estudante" + i.ToString();

            //    c.Telefone = 222222 + i;
            //    teste.Add(c);
            //}

            //return View("Index",teste);
            return View("Index", l);

        }



    }
}

