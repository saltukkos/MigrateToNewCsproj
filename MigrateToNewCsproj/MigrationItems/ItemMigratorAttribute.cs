using System;
using JetBrains.Annotations;

namespace MigrationItems
{
    [BaseTypeRequired(typeof(IItemMigrator))]
    public class ItemMigratorAttribute : Attribute
    {
        
    }
}