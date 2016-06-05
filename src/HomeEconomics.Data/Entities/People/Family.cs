using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using HomeEconomics.Types.People;

namespace HomeEconomics.Data.Entities.People
{
    public class Family : Entity, IFamily
    {
        public Family()
        {
            Members = new List<IPerson>();
        }

        private ObservableCollection<IPerson> _members;
        public DateTimeOffset Birthdate { get; set; }

        public IList<IPerson> Members
        {
            get { return _members; }
            set
            {
                _members = new ObservableCollection<IPerson>(value);
                _members.CollectionChanged += MembersOnCollectionChanged;
            }
        }

        private void MembersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.OldItems != null)
                foreach (IPerson member in args.OldItems)
                {
                    var me = member.Families.FirstOrDefault(f => f.Id == this.Id);
                    if (me != null)
                        member.Families.Remove(me);
                }

            if (args.NewItems != null)
                foreach (IPerson member in args.NewItems)
                {
                    var me = member.Families.FirstOrDefault(f => f.Id == this.Id);
                    if (me == null)
                        member.Families.Add(this);
                }
        }
    }
} 