﻿using AutoMapper;
using ContactDB;
using System;
using System.ComponentModel;

namespace ContactApp.Models
{
    public class ContactModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private static MapperConfiguration mapperConfiguration = new MapperConfiguration(t => t.CreateMap<ContactModel, ContactRepository.Models.ContactModel>().ReverseMap());
        private static IMapper mapper = mapperConfiguration.CreateMapper();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        //public string[] UserList { get; set; } 

        private string nameError { get; set; }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // IDataErrorInfo interface
        public string Error => "Never Used";

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = "";

                            if (Name == null || string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";
                            }
                            else if (Name.Length > 12)
                            {
                                NameError = "Name cannot be longer than 12 characters.";
                            }

                            return NameError;
                        }
                }

                return null;
            }
        }

        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }

        public ContactModel Clone()
        {
            var clonedOne = (ContactModel)MemberwiseClone();
            //clonedOne.UserList = (string[])UserList.Clone(); //use this format for reference based objects (Array, List, etc)

            return clonedOne;
        }
        public ContactRepository.Models.ContactModel ToRepositoryModel()
        {
            //using automapper
            var repositoryModel = mapper.Map<ContactRepository.Models.ContactModel>
                (this);

            return repositoryModel;
        }

        public static ContactModel ToModel(ContactRepository.Models.ContactModel respositoryModel)
        {
            //Only possible because we did reverse map
            var contactModel = mapper.Map<ContactModel>(respositoryModel);
            

            return contactModel;
        }
    }
}