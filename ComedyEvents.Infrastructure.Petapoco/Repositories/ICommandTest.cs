using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyEvents.Infrastructure.Petapoco.Repositories
{
    public interface ICommandTest
    {
        string GetEvents { get; }

    }

    public class CommandTest : ICommandTest
    {
        public string GetEvents => "SELECT * FROM dbo.Event";
    }
}
