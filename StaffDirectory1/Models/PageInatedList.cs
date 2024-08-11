﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StaffDirectory.Models
{
    public class PageInatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AcNumber { get; set; }
        public string HomeRoom { get; set; }
        public string Enrollment { get; set; }
        public string StaffStatus { get; set; }
        public string TeacherCode { get; set; }


        public PageInatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PageInatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PageInatedList<T>(items, count, pageIndex, pageSize);
        }  
        
    }
    
}