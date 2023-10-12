using CommonUI.ModelServices;
using ModuleListy.ViewModels;
using ModuleListy.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleListy
{
    public class ModuleListy : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleListy(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<MarynarzService, MarynarzService>();
            containerRegistry.RegisterSingleton<JednostkaPlywajacaService, JednostkaPlywajacaService>();
            containerRegistry.RegisterSingleton<FormaSluzbyService, FormaSluzbyService>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ShellWindowRegionModuleListy", typeof(ListView));

        }
    }
}