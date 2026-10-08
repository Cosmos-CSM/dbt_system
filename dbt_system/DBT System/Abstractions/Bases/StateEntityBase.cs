using CSM_Database_Core;

using DBT_System.Abstractions.Interfaces;

namespace DBT_System.Abstractions.Bases {
    /// <summary>
    /// Represents a state entity base class that extends EntityBase and adds a State property.
    /// </summary>
    public abstract class StateEntityBase
     : EntityBase, IStateReference
    {
        /// <inheritdoc/>
        public long State { get; set; }
    }

}
