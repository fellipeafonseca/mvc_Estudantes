using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
namespace Model.Mappers
{
    class FichaFinanceirasMapper:ClassMap<FichaFinanceira>
    {

          public FichaFinanceirasMapper()
        {

            Id(x=>x.Codigo);
            Map(x=>x.Bloqueio);
            Map(x=>x.DataInicio);
            Map(x => x.Valor);

              //Unique tirei
            References(x => x.Estudante).Not.LazyLoad().Cascade.None().Column("CodigoEstudante");
    }
    }
}
