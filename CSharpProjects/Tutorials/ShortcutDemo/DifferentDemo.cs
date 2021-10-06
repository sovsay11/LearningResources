using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutDemo
{
  // editor config is probably what is causing the rule enforcement for styling
  // right-click the project, go to add, add a new editor config, this is what enforces styling rules and syntax, what's not allowed and allowed
  public class DifferentDemo : Demo
  {
    // you can alt-enter or ctrl . properties to generate constructors for you, with the parameters added
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DifferentDemo(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
    }
  }
}
