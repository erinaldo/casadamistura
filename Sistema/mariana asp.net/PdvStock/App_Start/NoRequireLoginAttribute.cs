using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PdvStock
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NoRequireLoginAttribute : Attribute
    {
    }
}