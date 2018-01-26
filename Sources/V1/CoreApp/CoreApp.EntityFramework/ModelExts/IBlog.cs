using System.Collections.Generic;

namespace CoreApp.EntityFramework.Models
{
    public interface IBlog
    {
        long Id { get; set; }
        string Url { get; set; }
    }
}