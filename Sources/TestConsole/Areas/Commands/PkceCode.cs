using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;

namespace Mmu.IdentityProvider.TestConsole.Areas.Commands
{
    public class PkceCode : IConsoleCommand
    {
        public Task ExecuteAsync()
        {
            return null;
        }

        public string Description { get; }
        public ConsoleKey Key { get; }
    }
}
