using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    custo_comida = table.Column<decimal>(type: "decimal", nullable: false),
                    custo_bebida = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    cargo = table.Column<string>(type: "varchar(255)", nullable: false),
                    setor = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "convidados",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    funcionario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_convidados", x => x.id);
                    table.ForeignKey(
                        name: "FK_convidados_funcionarios_funcionario_id",
                        column: x => x.funcionario_id,
                        principalTable: "funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participantes_evento",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    evento_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    funcionario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    convidado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    valor_comida = table.Column<decimal>(type: "decimal", nullable: false),
                    valor_bebida = table.Column<decimal>(type: "decimal", nullable: false),
                    convidado_bebida_inclusa = table.Column<bool>(type: "bit", nullable: false),
                    funcionario_bebida_inclusa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participantes_evento", x => x.id);
                    table.ForeignKey(
                        name: "FK_participantes_evento_convidados_convidado_id",
                        column: x => x.convidado_id,
                        principalTable: "convidados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_participantes_evento_eventos_evento_id",
                        column: x => x.evento_id,
                        principalTable: "eventos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_participantes_evento_funcionarios_funcionario_id",
                        column: x => x.funcionario_id,
                        principalTable: "funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "id", "custo_bebida", "custo_comida", "data", "descricao" },
                values: new object[] { new Guid("95321295-7909-43bd-87bd-e82bf9dcc212"), 100m, 100m, new DateTime(2021, 7, 13, 19, 30, 10, 50, DateTimeKind.Local).AddTicks(533), "Churras ano que vem" });

            migrationBuilder.InsertData(
                table: "funcionarios",
                columns: new[] { "id", "cargo", "email", "nome", "setor" },
                values: new object[,]
                {
                    { new Guid("8965db97-cdde-44bb-ae95-3f984ea3ad87"), "Dev .Net", "geovane@gmail.com", "Geovane Paz", "TI" },
                    { new Guid("de74899d-b13e-4e5d-b556-28a0d60259ab"), "Dev .Net", "jonas@gmail.com", "Jonas", "TI" },
                    { new Guid("b0c9f66e-acd8-4040-972e-2c41c442490f"), "Dev .Net", "rodrigo@gmail.com", "Rodrigo", "TI" },
                    { new Guid("5197dc3e-a92b-43d5-bdea-a4d6e8222507"), "Dev .Net", "roger@gmail.com", "Roger", "TI" }
                });

            migrationBuilder.InsertData(
                table: "convidados",
                columns: new[] { "id", "email", "funcionario_id", "nome" },
                values: new object[] { new Guid("1b850052-f464-44e4-809f-fbdc3402bf0f"), "deise@gmail.com", new Guid("8965db97-cdde-44bb-ae95-3f984ea3ad87"), "Deise - Irmã Geovane" });

            migrationBuilder.InsertData(
                table: "convidados",
                columns: new[] { "id", "email", "funcionario_id", "nome" },
                values: new object[] { new Guid("7e14a59d-effa-45c7-bf2c-edd8c31856fc"), "maria@gmail.com", new Guid("de74899d-b13e-4e5d-b556-28a0d60259ab"), "Maria - Namorada Jonas" });

            migrationBuilder.InsertData(
                table: "participantes_evento",
                columns: new[] { "id", "convidado_bebida_inclusa", "convidado_id", "evento_id", "funcionario_bebida_inclusa", "funcionario_id", "valor_bebida", "valor_comida" },
                values: new object[] { new Guid("cd00cd05-525b-4718-893b-b14b86bf6620"), false, null, new Guid("95321295-7909-43bd-87bd-e82bf9dcc212"), true, new Guid("b0c9f66e-acd8-4040-972e-2c41c442490f"), 10m, 10m });

            migrationBuilder.InsertData(
                table: "participantes_evento",
                columns: new[] { "id", "convidado_bebida_inclusa", "convidado_id", "evento_id", "funcionario_bebida_inclusa", "funcionario_id", "valor_bebida", "valor_comida" },
                values: new object[] { new Guid("a3b57570-6a6c-4b98-84fe-796bdd160656"), true, new Guid("1b850052-f464-44e4-809f-fbdc3402bf0f"), new Guid("95321295-7909-43bd-87bd-e82bf9dcc212"), true, new Guid("8965db97-cdde-44bb-ae95-3f984ea3ad87"), 20m, 20m });

            migrationBuilder.InsertData(
                table: "participantes_evento",
                columns: new[] { "id", "convidado_bebida_inclusa", "convidado_id", "evento_id", "funcionario_bebida_inclusa", "funcionario_id", "valor_bebida", "valor_comida" },
                values: new object[] { new Guid("53600bed-d144-4955-aa6c-9f5ee7a58a32"), false, new Guid("7e14a59d-effa-45c7-bf2c-edd8c31856fc"), new Guid("95321295-7909-43bd-87bd-e82bf9dcc212"), false, new Guid("de74899d-b13e-4e5d-b556-28a0d60259ab"), 0m, 20m });

            migrationBuilder.CreateIndex(
                name: "IX_convidados_funcionario_id",
                table: "convidados",
                column: "funcionario_id");

            migrationBuilder.CreateIndex(
                name: "IX_participantes_evento_convidado_id",
                table: "participantes_evento",
                column: "convidado_id");

            migrationBuilder.CreateIndex(
                name: "IX_participantes_evento_evento_id",
                table: "participantes_evento",
                column: "evento_id");

            migrationBuilder.CreateIndex(
                name: "IX_participantes_evento_funcionario_id",
                table: "participantes_evento",
                column: "funcionario_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "participantes_evento");

            migrationBuilder.DropTable(
                name: "convidados");

            migrationBuilder.DropTable(
                name: "eventos");

            migrationBuilder.DropTable(
                name: "funcionarios");
        }
    }
}
