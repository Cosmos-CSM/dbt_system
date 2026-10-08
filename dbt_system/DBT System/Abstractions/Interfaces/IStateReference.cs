namespace DBT_System.Abstractions.Interfaces {
    /// <summary>
    /// Refers to an entity that has a state property, 
    /// allowing for tracking and managing the state of the entity within the system.
    /// </summary>
    public interface IStateReference
    {
        /// <summary>
        /// State of the entity, represented as a long integer. 
        /// This property can be used to track the current state or status of the entity 
        /// within the system and outside [CSM System] db.
        /// </summary>
        long State { get; set; }
    }
}
