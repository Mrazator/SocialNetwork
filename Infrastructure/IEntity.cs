namespace Infrastructure
{
    public interface IEntity
    {
        /// <summary>
        ///     Unique id of the entity.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        ///     Name of the database table for this entity.
        /// </summary>
        string TableName { get; }
    }
}