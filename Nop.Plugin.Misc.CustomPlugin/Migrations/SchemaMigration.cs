using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.CustomPlugin.Models;

namespace Nop.Plugin.Misc.CustomPlugin.Migrations
{
    [NopMigration("2023/03/10 13:24:55:1687541", "Misc.CustomPlugin base schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<ConfigureModel>();
        }
    }
}