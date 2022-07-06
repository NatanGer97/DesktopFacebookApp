using System;
using System.Windows.Forms;
using FacebookWrapper;

// $G$ THE-001 (-4) grade 96 on patterns selection / accuracy in implementation / description / document / diagrams (50%) (see comments in document)
namespace BasicFacebookFeatures
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Clipboard.SetText("design.patterns20cc");
            FacebookService.s_UseForamttedToStrings = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FacebookAppFormFactory.CreateFacebookAppForm(eFormTypes.FormLogin));
        }
    }
}