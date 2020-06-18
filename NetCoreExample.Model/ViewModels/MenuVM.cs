using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreExample.Model.ViewModels
{
    public class MenuVM
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Descriptions { get; set; }
    }
}
