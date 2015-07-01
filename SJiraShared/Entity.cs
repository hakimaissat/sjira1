using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SJiraShared
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get;  set; }

        protected Entity(TId id)
        {
            if (object.Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            }

            this.Id = id;
        }

        // EF requires an empty constructor
        protected Entity()
        {
        }

        // For simple entities, this may suffice
        // As Evans notes earlier in the course, equality of Entities is frequently not a simple operation
        public override bool Equals(object otherObject)
        {
            var entity = otherObject as Entity<TId>;
            if (entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(otherObject);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Entity<TId> other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }

        #region 1
        public Nullable<DateTime> ModifiedDate { get; set; }
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
