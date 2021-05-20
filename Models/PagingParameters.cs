using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Models
{
    public class PagingParameters
    {
        const int maxPageSize = 50;
        const int minPageNumber = 1;

        private int _pageSize = 10;
        private int _PageNumber = 1;

        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public int PageNumber
        {
            get => _PageNumber;
            set
            {
                _PageNumber = (value < minPageNumber) ? minPageNumber : value;
            }
        }
    }
}
