using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [CodeReview("Ahmad Hakroosh","16/07/1991",true)]
    public class A
    {
    }
   
    [CodeReview("Israel Israeli", "01/01/1850", true)]
    [CodeReview("Code Reviewer", "09/12/1993", true)]
    [CodeReview("Code Tester", "19/09/1970", false)]
    public class B
    {
    }

    [CodeReview("Tooty Fruity", "31/12/1948", true)]
    public class C
    {
    }
}
