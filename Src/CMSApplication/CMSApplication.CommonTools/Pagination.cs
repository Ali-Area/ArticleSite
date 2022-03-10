﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.CommonTools
{
    public static class Pagination
    {
        public static IEnumerable<TSource> Paging<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int rowCount)
        {
            rowCount = source.Count();
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
