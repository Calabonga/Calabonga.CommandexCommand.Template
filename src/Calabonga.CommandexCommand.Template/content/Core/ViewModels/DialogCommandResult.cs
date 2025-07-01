using Calabonga.Commandex.Engine.Dialogs;
using System.Windows;

namespace Commandex.DialogCommand.Core.ViewModels;

public partial class COMMAND-NAMEResult : DefaultDialogResult
{
    public COMMAND-NAMEResult()
    {
        Title = "COMMAND-NAME created from Commandex Template";
    }

    #region UI Style

    public override WindowStyle WindowStyle => WindowStyle.SingleBorderWindow;

    public override ResizeMode ResizeMode => ResizeMode.CanResize;

    public override SizeToContent SizeToContent => SizeToContent.Manual;

    public override double Height => 768;

    public override double Width => 1024;

    #endregion
}
