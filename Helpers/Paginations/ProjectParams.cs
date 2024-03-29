﻿namespace Helpers.Paginations
{
    public class ProjectParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
        public int OwnerId { get; set; }

        public string OrderBy { get; set; }
    }
}
