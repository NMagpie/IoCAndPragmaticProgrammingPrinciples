﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13._IoC_And_Pragmatic_Programming_Principles.Stuff
{
    /// <summary>
    /// Represents a single conference session
    /// </summary>
    public class Session
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }

        public Session(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}