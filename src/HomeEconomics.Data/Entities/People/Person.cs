using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using HomeEconomics.Types.Enumerations;
using HomeEconomics.Types.People;
using MongoDB.Bson.Serialization.Attributes;

namespace HomeEconomics.Data.Entities.People
{
    public class Person : Entity, IPerson
    {
        public Person()
        {
            Families = new List<IFamily>();
        }

        private ObservableCollection<IFamily> _families;
        public string[] Names { get; set; }
        public Sex Sex { get; set; }
        public DateTimeOffset Birthdate { get; set; }

        public IList<IFamily> Families
        {
            get { return _families; }
            set
            {
                _families = new ObservableCollection<IFamily>(value);
                _families.CollectionChanged += FamiliesOnCollectionChanged;
            }
        }

        private void FamiliesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.OldItems != null)
                foreach (IFamily family in args.OldItems)
                {
                    var person = family.Members.FirstOrDefault(m => m.Id == this.Id);
                    if (person != null)
                        family.Members.Remove(person);
                }

            if (args.NewItems != null)
                foreach (IFamily family in args.NewItems)
                {
                    var person = family.Members.FirstOrDefault(f => f.Id == this.Id);
                    if (person == null)
                        family.Members.Add(this);
                }
        }
    }
}
