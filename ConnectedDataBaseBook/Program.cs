using ConnectedDataBaseBook.Data;
using ConnectedDataBaseBook.Models;
using System;
using System.Collections.Generic;

namespace ConnectedDataBaseBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //var authors = new Authors
            //{
                
            //};
            var authorsDataAccess = new AuthorsDataAccess();
            var data = authorsDataAccess.SelectAllAuthors();
        }
    }
}
