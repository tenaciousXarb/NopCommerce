using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.NivoSliderClone.Domain;

namespace Nop.Plugin.Widgets.NivoSliderClone.Migrations
{
    [NopMigration("2023/03/10 18:47:55:1698641", "Widgets.NivoSliderClone base schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<ImageModel>();
        }
    }
}
