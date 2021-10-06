using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutDemo
{
  // right-click project, go to remove unused references
  // if you have a nuget package installed, it has unused dlls sometimes that will bloat
  // your software if unused
  // this will basically uninstall unused packages you got from nuget
  public class BetterDemo : Demo
  {

    // code cleanup (the broom near the bottom) also applies code fixes
    // based on the editor config for the profile

    // you can quick action a parameter to create null checks
    public BetterDemo(string firstName, string lastName)
    {
      if (string.IsNullOrEmpty(firstName))
      {
        throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.", nameof(firstName));
      }

      if (string.IsNullOrEmpty(lastName))
      {
        throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.", nameof(lastName));
      }

      FirstName = firstName;
      LastName = lastName;
    }

    // quick action on properties to put in block body or in getter/setter mode
    public string FirstName
    {
      get; set;
    }
    public string LastName { get; set; }

    // you can go to environment and projects, then track the current item in the solution so you can immediately jump to the file you're working on
    public void Testing()
    {

    }
  }
}
