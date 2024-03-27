using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13._IoC_And_Pragmatic_Programming_Principles.Stuff
{
    public interface IRepository
    {
        int SaveSpeaker(SpeakerDTO speaker);
    }
}