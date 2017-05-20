namespace CarShop.WebApp.Controllers.Api
{
    using System;
    using System.Web.Http;

    using CarShop.Contracts;
    using CarShop.Models.Entities;
    using CarShop.Services.Repositories;

    [RoutePrefix("api/cocacola")]
    public class BrandsController : ApiController
    {
        private readonly IUnitOfWork uow;

        public BrandsController()
        {
            this.uow = new UnitOfWork();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult CocaColaGet()
        {
            return this.Ok(this.uow.Brands.Find(c => true));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IHttpActionResult CocaColaGetById(Guid id)
        {
            throw new Exception("FAILED!!!!");
            ////var brand = this.uow.Brands.Get(id);
            ////if (brand == null)
            ////{
            ////    return this.NotFound();
            ////}

            ////return this.Ok(brand);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CocaColaAdd(Brand brand)
        {
            this.uow.Brands.Add(brand);
            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(Brand brand)
        {
            this.uow.Brands.Update(brand);
            return this.Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IHttpActionResult Delete(Guid id)
        {
            this.uow.Brands.Remove(id);
            return this.Ok();
        }
    }
}