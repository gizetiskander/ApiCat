using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCat.Model
{
    public class CountModel
    {
        public int count { get; set; }
        public List<EntryModel> entries { get; set; }

    }
}
