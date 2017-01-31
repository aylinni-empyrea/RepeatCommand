using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace RepeatCommand
{
  [ApiVersion(2, 0)]
  public class RepeatCommand : TerrariaPlugin
  {
    public RepeatCommand(Main game) : base(game)
    {
    }

    public override void Initialize()
    {
      Commands.ChatCommands.Add(new Command("repeatingcommand", NewRepeatingCommand, "repeat"));
    }

    private static void NewRepeatingCommand(CommandArgs args)
    {
      if (args.Parameters.Count < 1)
      {
        args.Player.SendErrorMessage($"Invalid usage! Usage: {Commands.Specifier}repeat (delay) (amount) <command>");
        return;
      }

      var argIndex = 0;

      var delay = 1D;
      var count = 1;

      var hasDelay = double.TryParse(args.Parameters.ElementAtOrDefault(argIndex), out delay);
      if (hasDelay) argIndex++;

      var hasCount = int.TryParse(args.Parameters.ElementAtOrDefault(argIndex), out count);
      if (hasCount) argIndex++;

      args.Parameters.RemoveRange(0, argIndex);

      var command = string.Join(" ", args.Parameters);

      if (args.Parameters.Count < 1)
      {
        args.Player.SendErrorMessage($"Invalid usage! Usage: {Commands.Specifier}repeat (delay) (amount) <command>");
        return;
      }

      new RepeatingCommand(command, args.Player, delay, count).Start();
    }

    #region Meta

    public override string Name => "RepeatCommand";
    public override string Author => "Newy";
    public override string Description => "Provides a simple command to run a command multiple times.";
    public override Version Version => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

    #endregion
  }
}