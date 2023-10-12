using CommonUI.Events;
using CommonUI.Models;
using CommonUI.ModelServices;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleListy.ViewModels
{

    public class ListViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggragator;

        private ObservableCollection<Marynarz> _marynarze;
        private ObservableCollection<JednostkaPlywajaca> _jednostki;
        private ObservableCollection<FormaSluzby> _formySluzby;

        public ListViewModel(IEventAggregator eventAggregator, MarynarzService marynarzService, JednostkaPlywajacaService jednPlywService, FormaSluzbyService formaSluzbyService)
        {
            _eventAggragator = eventAggregator;

            Marynarze = new ObservableCollection<Marynarz>();
            Jednostki = new ObservableCollection<JednostkaPlywajaca>();
            FormySluzby = new ObservableCollection<FormaSluzby>();

            LoadListMarynarzy();
            LoadListJednostki();
            LoadListFormySluzby();
        }

        #region OCollection
        public ObservableCollection<Marynarz> Marynarze
        {
            get { return _marynarze; }
            set { SetProperty(ref _marynarze, value); }
        }
        public ObservableCollection<JednostkaPlywajaca> Jednostki
        {
            get { return _jednostki; }
            set { SetProperty(ref _jednostki, value); }
        }
        public ObservableCollection<FormaSluzby> FormySluzby
        {
            get { return _formySluzby; }
            set { SetProperty(ref _formySluzby, value); }
        }
        #endregion

        #region LoadList
        private void LoadListFormySluzby()
        {
            var formySluzby = new FormaSluzbyService();
            FormySluzby = new ObservableCollection<FormaSluzby>(formySluzby.GetAll());
        }

        private void LoadListJednostki()
        {
            var jednPlywService = new JednostkaPlywajacaService();
            Jednostki = new ObservableCollection<JednostkaPlywajaca>(jednPlywService.GetAll());
        }

        private void LoadListMarynarzy()
        {
            var marynarzService = new MarynarzService();
            Marynarze = new ObservableCollection<Marynarz>(marynarzService.GetAll());
        }
        #endregion

        // wyświetlanie danych w innym oknie
        private Marynarz _selectedMarynarz;

        public Marynarz SelectedMarynarz
        {
            get { return _selectedMarynarz; }
            set
            {
                SetProperty(ref _selectedMarynarz, value);
                OnSelectedMarynarzChanged();
            }
        }

        private void OnSelectedMarynarzChanged()
        {
            if (_selectedMarynarz != null)
            {
                _eventAggragator.GetEvent<SelectedMarynarzEvent>().Publish(_selectedMarynarz);
            }
        }

        private JednostkaPlywajaca _selectedJednPlyw;

        public JednostkaPlywajaca SelectedJednPlyw
        {
            get { return _selectedJednPlyw; }
            set
            {
                SetProperty(ref _selectedJednPlyw, value);
                OnSelectedjednPlywChanged();
            }
        }

        private void OnSelectedjednPlywChanged()
        {
            if (_selectedJednPlyw != null)
            {
                _eventAggragator.GetEvent<SelectedJednPlywEvent>().Publish(_selectedJednPlyw);
            }
        }

        private FormaSluzby _selectedFormaSluzby;

        public FormaSluzby SelectedFormaSluzby
        {
            get { return _selectedFormaSluzby; }
            set
            {
                SetProperty(ref _selectedFormaSluzby, value);
                OnSelectedFormaSluzbyChanged();
            }
        }

        private void OnSelectedFormaSluzbyChanged()
        {
            if (_selectedFormaSluzby != null)
            {
                _eventAggragator.GetEvent<SelectedFormaSluzbyEvent>().Publish(_selectedFormaSluzby);
            }
        }
    }
}

