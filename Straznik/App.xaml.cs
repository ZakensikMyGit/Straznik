using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Straznik.Views;
using System.Windows;

namespace Straznik
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

       protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleListy.ModuleListy>();
            moduleCatalog.AddModule<ModuleEdycja.ModuleEdycja>();
        }
    }
}
