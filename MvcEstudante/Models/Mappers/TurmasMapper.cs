using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
namespace Model.Mappers
{
    public class TurmasMapper:ClassMap<Turma>
    {


        public TurmasMapper()
        {

            Id(x => x.Codigo);
            Map(x => x.Nome);
            Map(x => x.DataInicio);


            //Erro Aqui
            HasMany(x => x.Estudante).Not.LazyLoad().Cascade.None().Inverse().KeyColumn("CodigoTurma");

        }

    }
}
