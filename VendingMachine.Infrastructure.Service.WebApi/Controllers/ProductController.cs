using System;
using System.Collections.Generic;
using System.Web.Http;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Interfaces;
using VendingMachine.Infrastructure.Data;
using WebApi.OutputCache.V2;

namespace VendingMachine.Infrastructure.Service.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private const int DEFAULT_TIME_SPAN = 3600;

        protected IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet, CacheOutput(ClientTimeSpan = DEFAULT_TIME_SPAN, ServerTimeSpan = DEFAULT_TIME_SPAN)]
        public IEnumerable<Product> Get()
        {
            return _repository.Get();
        }

        [HttpGet, Route("{id:int}"), CacheOutput(ClientTimeSpan = DEFAULT_TIME_SPAN, ServerTimeSpan = DEFAULT_TIME_SPAN)]
        public Product Get(int id)
        {
            return _repository.Get(id);
        }
    }
}