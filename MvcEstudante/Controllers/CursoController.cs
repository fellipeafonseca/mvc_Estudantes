//using ExemploMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace ExemploMVC.Controllers
{
    public class CursoController : Controller
    {

        Curso curso;
        //
        // GET: /Curso/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //Get:Curso/Index/(id)
        
        
        public ActionResult Index()
        {
           // Curso = new Curso();

          //  Curso = new Curso();

            List<Curso> teste =Curso.ListarCurso() ;
            
        
            return View(teste);
        }
        
        
        
        //Get:Curso/obter/(id)
        public ActionResult Obter(long id){

            Curso Curso = new Curso();
            Curso.Codigo = id;
            Curso.Nome = "Curso"+ id.ToString();
          //  Curso.Telefone = 33333333+id;


            return View(Curso);

        }


      
        public ActionResult Criar()
        {

            return View();

        }


       [HttpPost]
       
        public ActionResult Criar(Curso c)
        {
            curso = new Curso();

            curso.GravarCurso(c);

            return View(c);  

        }


      

       public ActionResult Editar(long id)
       {

           //Fake não vai apagar
           //Curso Curso = new Curso();
           //Curso.Codigo = id;
           //Curso.Nome = "ddvsd" + id.ToString();
           //Curso.Telefone = 1222+id;


           List<Curso> teste = Curso.ListarCurso();

         //  Curso c = new Curso();

            //  List<Curso> Cursos;
           // Curso.ListarCurso();

           foreach(Curso c in teste)
               if(c.Codigo==id)
                return View(c);

           return null;
       }



        [HttpPost]
       public ActionResult Editar(Curso c)
       {
           //nhibernateDeletar(Curso);

           //List<Curso> teste = new List<Curso>();

           //for (int i = 0; i < 5; i++)
           //{
           //    Curso c = new Curso();
           //    c.Codigo = i;
           //    c.Nome = "Curso" + i.ToString();

           //    c.Telefone = 222222 + i;
           //    teste.Add(c);
           //}
          curso = new Curso();

           curso.AtualizarCurso(c);

            List<Curso> teste = Curso.ListarCurso();





           return View("Index", teste);
       }


        public ActionResult Deletar(long id)
        {
            List<Curso> l = Curso.ListarCurso();

            foreach (Curso c in l)
                if (c.Codigo == id)
                    return View(c);
            
            
            return null;
        }




        [HttpPost]
       public ActionResult Deletar(Curso c)
       {
           //nhibernateDeletar(Curso);

           //Curso = new Curso();
           //Curso.DeletarCurso(c);

         
            //  List<Curso> teste;

           //for (int i = 0; i < 5; i++)
           //{
           //    Curso c = new Curso();
           //    c.Codigo = i;
           //    c.Nome = "Curso" + i.ToString();

           //    c.Telefone = 222222 + i;
           //    teste.Add(c);
           //}

           //return View("Index",teste);

           curso = new Curso();
           curso.DeletarCurso(c);

           List<Curso> l = Curso.ListarCurso();
            return View("Index",l);

       }



    }
}

