﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class PageResponse<T>:Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PageResponse(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            this.Data =  data;
            this.Message= null;
            this.Errors = null;
            this.Succeeded = true;

        }

    }
}
