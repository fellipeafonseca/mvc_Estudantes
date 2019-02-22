using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
namespace Model.Mappers
{
    class EstudantesMapper:ClassMap<Estudante>
    {

         public EstudantesMapper()
    {
        Id(x => x.Codigo);
        Map(x => x.Nome);
        Map(x => x.Email);
        Map(x => x.Idade);
        Map(x => x.Sexo);
        Map(x => x.Senha);

     ////   HasMany(x => x.Curso).Not.LazyLoad().Cascade.None().PropertyRef("Curso");




        HasManyToMany(x => x.Curso).Cascade.None().Table("EstudanteCursos").
        ParentKeyColumn("CodigoEstudante").ChildKeyColumn("CodigoCurso").Not.LazyLoad();

        HasOne(x => x.FichaFinanceira).Not.LazyLoad().Cascade.SaveUpdate().PropertyRef("Estudante");
             //Cascade Save or Update Adcionar aqui qdo salavr estudante

        //Turma
             //Tirei Unique
        References(x => x.Turma).Not.LazyLoad().Cascade.None().Column("CodigoTurma");



    }
    }
}
