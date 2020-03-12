using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;

namespace Mmu.IdentityProvider.TestConsole.Areas.Commands
{
    public class PkceCode : IConsoleCommand
    {
        public string Description { get; }
        public ConsoleKey Key { get; }

        public Task ExecuteAsync()
        {
            return null;
        }
    }
}