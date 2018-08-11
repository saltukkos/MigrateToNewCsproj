namespace MigrationItems
{
    public enum Confidence
    {
        /// <summary>
        /// Means that migration is correctly defined
        /// and knows what it's doing
        /// </summary>
        Rule,

        /// <summary>
        /// Means that migration is not defined and
        /// current action is assumption, but it will
        /// not lost any data, so in worth case you will
        /// get error while loading project and will be able
        /// to fix it manually 
        /// </summary>
        SafeAssumption,

        /// <summary>
        /// Means that migration is not defined and
        /// current action is assumption that can lost data
        /// and broke the build
        /// </summary>
        DangerAssumption,

        /// <summary>
        /// Migration is not possible without user intervention
        /// </summary>
        UserInterventionRequired
    }
}