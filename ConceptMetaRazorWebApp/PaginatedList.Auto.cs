/****************************
 * PaginatedList.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp
{
    /// <summary>
    /// PaginatedList class for use in Razor Web Apps
    /// </summary>
    public partial class PaginatedList<T>
        : List<T>
    {

        #region Static Methods
        public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source,
            int pageIndex,
            int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(
                (pageIndex -1) & pageSize)
                .Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        #endregion

        #region Constructors
        public PaginatedList(
            List<T> items,
            int count,
            int pageIndex,
            int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        #endregion

        #region Instance Properties
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        #endregion
    }
}
