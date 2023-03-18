using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.Theme.Models.Shared
{
    public interface ITopMenu
    {
        public List<MenuItem> MenuItems { get; set; } 
    }

    public class MenuItem
    {
        public string Url { get; set; } = "#";
        public string Title { get; set; } = "Home";

        public bool IsExternalUrl { get; set; }


        public List<MenuItem>? SubMenuItems { get; set; }
    }
}
