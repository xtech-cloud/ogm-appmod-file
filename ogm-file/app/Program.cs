using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OGM.Module.File;
using XTC.oelMVCS;

namespace app
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RootForm rootForm = new RootForm();

            Logger logger = new ConsoleLogger();
            Config config = new SampleConfig();
            config.Merge("");
            Framework framework = new Framework();
            framework.setLogger(logger);
            framework.setConfig(config);
            framework.Initialize();

            AppFacade appFacade = new AppFacade();
            appFacade.rootForm = rootForm;
            framework.getStaticPipe().RegisterFacade(AppFacade.NAME, appFacade);
            AppView appView = new AppView();
            framework.getStaticPipe().RegisterView(AppView.NAME, appView);

            // ע��ģ�鴰��
            FormRoot formRoot = new FormRoot(framework);
            formRoot.Register();
            // ע��ģ���߼�
            ModuleRoot moduleRoot = new ModuleRoot(framework);
            moduleRoot.Register();

            framework.Setup();

            Application.Run(rootForm);

            moduleRoot.Cancel();
            formRoot.Cancel();

            framework.Dismantle();
            framework.Release();
        }
    }
}