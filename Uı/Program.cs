// See https://aka.ms/new-console-template for more information
using Core.DataAccess.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

EntityContext context = new EntityContext();
IEntityRepository<Category> dal = new EfCategoryDal(context);

foreach(var item in dal.GetAll())
{
    Console.WriteLine(item.CategoryName);
}