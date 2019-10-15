using CalculadoraDeFreteSimulado.API.Context;
using CalculadoraDeFreteSimulado.API.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CalculadoraDeFreteSimulado.API.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CalculoFreteContext _calculoFreteContext;

        public RepositoryBase(CalculoFreteContext calculoFreteContext)
        {
            _calculoFreteContext = calculoFreteContext;
        }
    }
}
