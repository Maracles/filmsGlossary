using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace filmsGlossary.ViewModels
{
    class practiceClasses
    {
    }

    
    // Test class only
    public class FilmTerm
    {
        public FilmTerm() { }

        public FilmTerm(string termName, string termDescription)
        {
            Name = termName;
            Description = termDescription;
         
        }

        public string Name { get; set; }
        public string Description { get; set; }

        ////Overridge the ToString method.
        //public override string ToString()
        //{
        //    return Name + " by " + Description;
        //}
    }
}
