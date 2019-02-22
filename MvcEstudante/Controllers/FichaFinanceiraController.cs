//using ExemploMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace ExemploMVC.Controllers
{
    public class FichaFinanceiraController : Controller
    {

        FichaFinanceira FichaFinanceira;
        //
        // GET: /FichaFinanceira/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //Get:FichaFinanceira/Index/(id)


        public ActionResult Index()
        {
            // FichaFinanceira = new FichaFinanceira();

            List<FichaFinanceira> teste = FichaFinanceira.ListarFichaFinanceira();
           

            return View(teste);
        }



        //Get:FichaFinanceira/obter/(id)
        //public ActionResult Obter(long id)
        //{

        //    FichaFinanceira FichaFinanceira = new FichaFinanceira();
        //    FichaFinanceira.Codigo = id;
        //    FichaFinanceira.Nome = "FichaFinanceira" + id.ToString();
        //    FichaFinanceira.Telefone = 33333333 + id;


        //    return View(FichaFinanceira);

        //}



        public ActionResult Criar()
        {

            return View();

        }


        [HttpPost]

        public ActionResult Criar(FichaFinanceira fichaFinanceira)
        {


            FichaFinanceira.GravarFichaFinanceira(fichaFinanceira);

            return View(FichaFinanceira);

        }




        public ActionResult Editar(long id)
        {

            //Fake não vai apagar
            //FichaFinanceira FichaFinanceira = new FichaFinanceira();
            //FichaFinanceira.Codigo = id;
            //FichaFinanceira.Nome = "ddvsd" + id.ToString();
            //FichaFinanceira.Telefone = 1222+id;


            List<FichaFinanceira> teste = FichaFinanceira.ListarFichaFinanceira();

            //  FichaFinanceira c = new FichaFinanceira();

            //  List<FichaFinanceira> FichaFinanceiras;
            // FichaFinanceira.ListarFichaFinanceira();

            foreach (FichaFinanceira c in teste)
                if (c.Codigo == id)
                    return View(c);

            return null;
        }



        [HttpPost]
        public ActionResult Editar(FichaFinanceira c)
        {
            //nhibernateDeletar(FichaFinanceira);

            //List<FichaFinanceira> teste = new List<FichaFinanceira>();

            //for (int i = 0; i < 5; i++)
            //{
            //    FichaFinanceira c = new FichaFinanceira();
            //    c.Codigo = i;
            //    c.Nome = "FichaFinanceira" + i.ToString();

            //    c.Telefone = 222222 + i;
            //    teste.Add(c);
            //}
            FichaFinanceira = new FichaFinanceira();
            FichaFinanceira.AtualizarFichaFinanceira(c);

            List<FichaFinanceira> teste = FichaFinanceira.ListarFichaFinanceira();




            return View("Index", teste);
        }


        public ActionResult Deletar(long id)
        {
            List<FichaFinanceira> l = FichaFinanceira.ListarFichaFinanceira();

            foreach (FichaFinanceira c in l)
                if (c.Codigo == id)
                    return View(c);


            return null;
        }




        [HttpPost]
        public ActionResult Deletar(FichaFinanceira c)
        {
            //nhibernateDeletar(FichaFinanceira);

            FichaFinanceira = new FichaFinanceira();
            FichaFinanceira.DeletarFichaFinanceira(c);

            List<FichaFinanceira> l = FichaFinanceira.ListarFichaFinanceira();
            //  List<FichaFinanceira> teste;

            //for (int i = 0; i < 5; i++)
            //{
            //    FichaFinanceira c = new FichaFinanceira();
            //    c.Codigo = i;
            //    c.Nome = "FichaFinanceira" + i.ToString();

            //    c.Telefone = 222222 + i;
            //    teste.Add(c);
            //}

            //return View("Index",teste);
            return View("Index", l);

        }



    }
}

