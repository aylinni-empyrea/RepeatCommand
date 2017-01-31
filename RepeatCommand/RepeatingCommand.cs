using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TShockAPI;

namespace RepeatCommand
{
  internal class RepeatingCommand
  {
    internal string CommandString;
    internal double Delay;
    internal int RepeatCount;

    private int ExecutionCount;
    private TSPlayer ExecutingPlayer;

    internal RepeatingCommand(string commandString, TSPlayer executingPlayer, double delay, int repeatCount)
    {
      CommandString = commandString;
      Delay = delay.Equals(0D) ? 1D : delay;
      RepeatCount = repeatCount.Equals(0) ? 1 : repeatCount;
      ExecutingPlayer = executingPlayer;
    }

    internal void Start() => Task.Factory.StartNew(ExecuteLoop);

    private async void ExecuteLoop()
    {
      if (RepeatCount == 1)
      {
        await Task.Delay(TimeSpan.FromSeconds(Delay));
        Commands.HandleCommand(ExecutingPlayer, CommandString);
        return;
      }

      for (var i = 0; i < RepeatCount; i++)
      {
        Commands.HandleCommand(ExecutingPlayer, CommandString);
        await Task.Delay(TimeSpan.FromSeconds(Delay));
      }
    }
  }
}