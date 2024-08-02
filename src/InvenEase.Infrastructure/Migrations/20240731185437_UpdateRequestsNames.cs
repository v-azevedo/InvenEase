using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenEase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRequestsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemRequestIds");

            migrationBuilder.DropTable(
                name: "RequestItems");

            migrationBuilder.DropTable(
                name: "RequestOrderIds");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.CreateTable(
                name: "ItemRequisitionIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    RequisitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRequisitionIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRequisitionIds_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Urgency = table.Column<int>(type: "integer", nullable: false),
                    RequesterDelivered = table.Column<bool>(type: "boolean", nullable: false),
                    RequesterId = table.Column<Guid>(type: "uuid", nullable: false),
                    StockistId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionItems",
                columns: table => new
                {
                    RequisitionItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequisitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionItems", x => new { x.RequisitionItemId, x.RequisitionId });
                    table.ForeignKey(
                        name: "FK_RequisitionItems_Requisitions_RequisitionId",
                        column: x => x.RequisitionId,
                        principalTable: "Requisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionOrderIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequisitionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionOrderIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitionOrderIds_Requisitions_RequisitionId",
                        column: x => x.RequisitionId,
                        principalTable: "Requisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisitionIds_ItemId",
                table: "ItemRequisitionIds",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionItems_RequisitionId",
                table: "RequisitionItems",
                column: "RequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionOrderIds_RequisitionId",
                table: "RequisitionOrderIds",
                column: "RequisitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemRequisitionIds");

            migrationBuilder.DropTable(
                name: "RequisitionItems");

            migrationBuilder.DropTable(
                name: "RequisitionOrderIds");

            migrationBuilder.DropTable(
                name: "Requisitions");

            migrationBuilder.CreateTable(
                name: "ItemRequestIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRequestIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRequestIds_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RequesterDelivered = table.Column<bool>(type: "boolean", nullable: false),
                    RequesterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    StockistId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Urgency = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestItems",
                columns: table => new
                {
                    RequestItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestItems", x => new { x.RequestItemId, x.RequestId });
                    table.ForeignKey(
                        name: "FK_RequestItems_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestOrderIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOrderIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOrderIds_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequestIds_ItemId",
                table: "ItemRequestIds",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_RequestId",
                table: "RequestItems",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrderIds_RequestId",
                table: "RequestOrderIds",
                column: "RequestId");
        }
    }
}
