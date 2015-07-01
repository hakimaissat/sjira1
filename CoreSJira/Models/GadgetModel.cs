using System;
using System.Collections.Generic;
namespace SJiraCore.Models
{
    public class GadgetModel
    {
        public GadgetModel()
        {

        }

        public int GadgetId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public Nullable<int> Sequense { get; set; }

        public string GadgetType { get; set; }
        public string MenuAction { get; set; }
        public string MenuIcon { get; set; }

    }
}
