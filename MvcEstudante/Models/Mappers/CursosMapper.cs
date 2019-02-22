using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
namespace Model.Mappers
{
    public class CursosMapper:ClassMap<Curso>
    {

     public CursosMapper()
     {
         Table("Cursos");
         Id(x => x.Codigo);
         Map(x => x.CargaHoraria);
         Map(x => x.DataInicio);
         Map(x => x.Nome);

         //HasMany(x => x.Estudante).Not.LazyLoad().Cascade.None().PropertyRef("Estudante");




         HasManyToMany(x => x.Estudante).Cascade.None().Table("EstudanteCursos").
             ParentKeyColumn("CodigoCurso").ChildKeyColumn("CodigoEstudante").Not.LazyLoad();


     }
    }
}
