using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BancoMusica
{
    public class Paginacao<T>:List<T>
    {
        public int Pageindex { get; private set; }
        public int TotalPages { get; private set; }

        public Paginacao(List<T> itens, int count, int pageIndex, int pageSize) 
        {
            pageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(itens);
        }

        public bool HasPreviousPage => Pageindex > 1;
        public bool HasNextPage => Pageindex < TotalPages;

        public static async Task<Paginacao<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Paginacao<T>(items, count, pageIndex, pageSize);
        }
    }
}
