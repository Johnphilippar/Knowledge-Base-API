using CLEAN_Domain_CORE.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLEAN_Domain_CORE.Commands
{
    public abstract class Command : Message
    {

        public DateTime TimeStamp { get; protected set; }
        protected Command()
        {
            TimeStamp = DateTime.Now;
        }

    }
}
