using BooksNotBoobs.Enums;
using BooksNotBoobs.Interfaces;

namespace BooksNotBoobs.Services
{
    public class UrlImgService:IUrlImgService
    {
        public string GetRandomUrl() 
        {
            var rnd = new Random();
            var RandomUrl = (ImgCollection)rnd.Next(0, 3);

            switch ((int)RandomUrl) 
            {
                case 0: return "~/img/1st-book.jpg";
                case 1: return "~/img/2nd-book.jpg";
                case 2: return "~/img/3th-book.jpg";
            }

            return string.Empty;
        }

      
    }
}
