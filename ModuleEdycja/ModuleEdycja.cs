using ModuleEdycja.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleEdycja
{
    public class ModuleEdycja : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleEdycja(IRegionManager regionManager)
        {
            _regionManager = regionManager;  
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // Rejestracja głównego widoku z regionem w ShellWindow
            _regionManager.RegisterViewWithRegion("ShellWindowRegionModuleEdycja", typeof(EdycjaView));

            // Rejestracja widoków szczegółowych z regionami w EdycjaView
            _regionManager.RegisterViewWithRegion("SelectedViewRegion", typeof(EdycjaMarynarzView));
            _regionManager.RegisterViewWithRegion("SelectedViewRegion", typeof(EdycjaJednostkiPlywajaceView));
            _regionManager.RegisterViewWithRegion("SelectedViewRegion", typeof(EdycjaFormySluzbyView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterSingleton<MarynarzeService, MarynarzeService>();
            //containerRegistry.RegisterSingleton<JednostkaPlywajacaService, JednostkaPlywajacaService>();
            //containerRegistry.RegisterSingleton<FormaSluzbyService, FormaSluzbyService>();
        }
    }
}
