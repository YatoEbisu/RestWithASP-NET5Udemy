using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parser(O origin);
        List<D> Parser(List<O> origin);

    }
}
