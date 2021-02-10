using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<T>> Create(T entity);
        Task<ActionResult<T>> Update(T entity);
        Task<ActionResult<T>> Delete(int id);
        bool Login(string login, string password);
    }
}
