using App3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        #region Instances

        private string _NuevoIngreso = String.Empty;
        private ObservableCollection<PersonModel> _listPersonList = new ObservableCollection<PersonModel>();
        private ObservableCollection<PersonModel> _listPersonListFiltro = new ObservableCollection<PersonModel>();
        private bool _tieneFiltro = false;
        private bool _noTieneFiltro = true;
        private string _NuevoFiltro = String.Empty;

        public bool tieneFiltro
        {
            get { return _tieneFiltro; }
            set { _tieneFiltro = value; OnPropertyChanged("tieneFiltro"); }
        }

        public bool noTieneFiltro
        {
            get { return _noTieneFiltro; }
            set { _noTieneFiltro = value; OnPropertyChanged("noTieneFiltro"); }
        }

        public ObservableCollection<PersonModel> listPersonList
        {
            get { return _listPersonList; }
            set { _listPersonList = value; OnPropertyChanged("listPersonList"); }
        }

        public ObservableCollection<PersonModel> listPersonListFiltro
        {
            get { return _listPersonListFiltro; }
            set { _listPersonListFiltro = value; OnPropertyChanged("listPersonListFiltro"); }
        }
        public string NuevoIngreso { 
           get { return _NuevoIngreso; }
           set { _NuevoIngreso = value; OnPropertyChanged("NuevoIngreso"); }
        }

        public string NuevoFiltro {
            get { return _NuevoFiltro; }
            set { _NuevoFiltro = value; OnPropertyChanged("NuevoFiltro"); }
        }

        public ICommand AgregarPersonaCommand { get; set; }

        public ICommand FiltroCommand { get; set; }
        #endregion 

        public PersonViewModel()
        {
            AgregarPersonaCommand = new Command(AgregarPersona);
            FiltroCommand = new Command(Filtrar);
        }



        private void AgregarPersona() {  //método de agregar persona
            listPersonList.Add(new PersonModel() { Nombre = NuevoIngreso, Apellido = "Rodriguez", Descripcion = "Descripción" });
        }

        private void Filtrar() { //método filtrar
            ObservableCollection<PersonModel> listaPersonasAux = listPersonList;

            if (NuevoFiltro.Equals("") || NuevoFiltro == null)
            {
                tieneFiltro = false;
                noTieneFiltro = true;
            }
            else {
                tieneFiltro = true;
                noTieneFiltro = false;
                var listaFiltrada = (from a in listPersonList where a.Nombre == NuevoFiltro select a).ToList();
                listPersonListFiltro = new ObservableCollection<PersonModel>(listaFiltrada as List<PersonModel>);
            }
        }


        

     

        #region Notified Region
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName) {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));           
            }
        }

        #endregion


    }
}
