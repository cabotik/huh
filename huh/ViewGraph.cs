using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace huh
{
   public class ViewGraph
   {
        public List<GraphField> graphs { get; set; }


        public ViewGraph(List<GraphField> fields)
        {
            graphs = new List<GraphField>();
            graphs.AddRange(fields);
        }
    }
}
