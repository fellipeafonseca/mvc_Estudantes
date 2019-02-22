//using ExemploMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace ExemploMVC.Controllers
{
    public class TurmaController : Controller
    {

        Turma turma;
        //
        // GET: /Turma/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //Get:Turma/Index/(id)


        public ActionResult Index()
        {
            // Turma = new Turma();

            List<Turma> teste = Turma.ListarTurma();


            return View(teste);
        }



        //Get:Turma/obter/(id)
        //public ActionResult Obter(long id)
        //{

        //    Turma Turma = new Turma();
        //    Turma.Codigo = id;
        //    Turma.Nome = "Turma" + id.ToString();
        //    Turma.Telefone = 33333333 + id;


        //    return View(Turma);

        //}



        public ActionResult Criar()
        {

            return View();

        }


        [HttpPost]

        public ActionResult Criar(Turma t)
        {


            t.GravarTurma();

            return View(t);

        }




        public ActionResult Editar(long id)
        {

            //Fake não vai apagar
            //Turma Turma = new Turma();
            //Turma.Codigo = id;
            //Turma.Nome = "ddvsd" + id.ToString();
            //Turma.Telefone = 1222+id;


            List<Turma> teste = Turma.ListarTurma();

            //  Turma c = new Turma();

            //  List<Turma> Turmas;
            // Turma.ListarTurma();

            foreach (Turma c in teste)
                if (c.Codigo == id)
                    return View(c);

            return null;
        }



        [HttpPost]
        public ActionResult Editar(Turma c)
        {
            //nhibernateDeletar(Turma);

            //List<Turma> teste = new List<Turma>();

            //for (int i = 0; i < 5; i++)
            //{
            //    Turma c = new Turma();
            //    c.Codigo = i;
            //    c.Nome = "Turma" + i.ToString();

            //    c.Telefone = 222222 + i;
            //    teste.Add(c);
            //}
            turma = new Turma();
           
            
            turma.AtualizarTurma(c);

            List<Turma> teste = Turma.ListarTurma();




            return View("Index", teste);
        }


        public ActionResult Deletar(long id)
        {
            List<Turma> l = Turma.ListarTurma();

            foreach (Turma c in l)
                if (c.Codigo == id)
                    return View(c);


            return null;
        }




        [HttpPost]
        public ActionResult Deletar(Turma c)
        {
            //nhibernateDeletar(Turma);

            turma = new Turma();
            turma.DeletarTurma(c);

            List<Turma> l = Turma.ListarTurma();
            //  List<Turma> teste;

            //for (int i = 0; i < 5; i++)
            //{
            //    Turma c = new Turma();
            //    c.Codigo = i;
            //    c.Nome = "Turma" + i.ToString();

            //    c.Telefone = 222222 + i;
            //    teste.Add(c);
            //}

            //return View("Index",teste);
            return View("Index", l);

        }



    }
}

