using Microsoft.EntityFrameworkCore.Migrations;

namespace BookAPI.Migrations
{
    public partial class VD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name:"Booksc",
            //     columns: table =>new
            //     {
            //         Id=table.Column<int>(type:"int",nullable:false)
            //             .Annotation("SqlServer:Identity","1,1"),
            //         Title=table.Column<string>(type:"varchar(100)",nullable:true),
            //         Description= table.Column<string>(type:"varchar(100)",nullable:true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Books", x => x.Id);
            //     }
            // );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "Books");
        }
    }
}
