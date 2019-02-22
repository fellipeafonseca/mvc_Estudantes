using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace Model
{
    public class Autentica
    {


        public Estudante Autenticar(string usuario,string senha)
        {
              List<Estudante> lista=Estudante.ListarEstudante();

              foreach (Estudante e in lista)
                  if (e.Email.Equals(usuario) && e.Senha.Equals(senha))
                      return e;

              return null;

        }



    }
}