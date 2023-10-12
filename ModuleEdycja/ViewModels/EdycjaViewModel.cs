using CommonUI.Events;
using CommonUI.Models;
using CommonUI.ModelServices;
using ModuleEdycja.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace ModuleEdycja.ViewModels
{
    public class EdycjaViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        private Marynarz _selectedMarynarz;
        private JednostkaPlywajaca _selectedJednPlyw;
        private FormaSluzby _selectedFormaSluzby;
        private readonly IMarynarzService _marynarzService;

        private bool _isEditing;
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        public EdycjaViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IMarynarzService marynarzService)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _eventAggregator.GetEvent<SelectedMarynarzEvent>().Subscribe(UpdateSelectedMarynarz);
            _eventAggregator.GetEvent<SelectedJednPlywEvent>().Subscribe(UpdateSelectedJednPlyw);
            _eventAggregator.GetEvent<SelectedFormaSluzbyEvent>().Subscribe(UpdateSelectedFormaSluzby);
            _marynarzService = marynarzService;

            EditCommand = new DelegateCommand(StartEditing);
            SaveCommand = new DelegateCommand(SaveChanges, CanSave).ObservesProperty(() => IsEditing);

        }

        public bool IsEditing
        {
            get {  return _isEditing; }
            set { SetProperty(ref _isEditing, value); }
        }
        private void StartEditing()
        {
            IsEditing = true;
        }
        private void SaveChanges()
        {
            if (SelectedMarynarz != null)
            {
                _marynarzService.Update(SelectedMarynarz);
            }
            IsEditing = false;
        }
        private bool CanSave()
        {
            return IsEditing;
        }

        private void UpdateSelectedMarynarz(Marynarz marynarz)
        {
            if (marynarz == null) return;
            SelectedMarynarz = marynarz;
            SelectedJednPlyw = null; // Resetuj, gdy wybrano Marynarza
            ActivateView("EdycjaMarynarzView");
        }

        public Marynarz SelectedMarynarz
        {
            get { return _selectedMarynarz; }
            set { SetProperty(ref _selectedMarynarz, value); }
        }


        private void UpdateSelectedJednPlyw(JednostkaPlywajaca jednPlyw)
        {
            if (jednPlyw == null) return;
            SelectedJednPlyw = jednPlyw;
            SelectedMarynarz = null; // Resetuj, gdy wybrano JednostkęPlywajaca
            ActivateView("EdycjaJednostkiPlywajaceView");
        }

        public JednostkaPlywajaca SelectedJednPlyw
        {
            get { return _selectedJednPlyw; }
            set { SetProperty(ref _selectedJednPlyw, value); }
        }

        private void UpdateSelectedFormaSluzby(FormaSluzby formaSluzby)
        {
            if (formaSluzby == null) return;
            SelectedFormaSluzby = formaSluzby;
            SelectedJednPlyw = null;
            SelectedMarynarz = null;
            ActivateView("EdycjaFormySluzbyView");
        }

        public FormaSluzby SelectedFormaSluzby
        {
            get { return _selectedFormaSluzby; }
            set {SetProperty (ref _selectedFormaSluzby, value); }
        }
        private void ActivateView(string viewName)
        {
            var region = _regionManager.Regions["SelectedViewRegion"];
            if (region.GetView(viewName) == null)
            {
                if (viewName == "EdycjaMarynarzView")
                    region.Add(new EdycjaMarynarzView(), viewName);
                else if (viewName == "EdycjaJednostkiPlywajaceView")
                    region.Add(new EdycjaJednostkiPlywajaceView(), viewName);
                else if (viewName == "EdycjaFormySluzbyView")
                    region.Add(new EdycjaFormySluzbyView(), viewName);
            }
            var view = region.GetView(viewName);
            region.Activate(view);
        }
    }
}
