namespace PrasannaNeons.DataEntities
{
    /// <summary>
    /// Base Value Object class.
    /// </summary>
    /// <typeparam name="TIdentifier">Identifier Generic Type to be assigned dynamically.</typeparam>
    public class BaseEntity<TIdentifier>
        where TIdentifier : new()
    {
        /// <summary>
        /// Gets or sets the Identifier.
        /// </summary>
        public virtual int Id { get; set; }
    }
}
