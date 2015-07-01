using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Interfaces;

namespace DomainClasses.Bases
{
    public abstract class Entity : IEntity
    {

        public string Name { get; set; }

        #region 1
        public Nullable<DateTime> UpdatedDate { get; set; }
        
        [NotMapped]
        public bool IsDirty { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            IsDirty = true;
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
