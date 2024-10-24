using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPedidos.Migrations
{
    /// <inheritdoc />
    public partial class migracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaProduto",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProduto", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRole = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SubcategoriaProduto",
                columns: table => new
                {
                    SubcategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSubcategoria = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcategoriaProduto", x => x.SubcategoriaId);
                    table.ForeignKey(
                        name: "FK_SubcategoriaProduto_CategoriaProduto_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaProduto",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Convenio",
                columns: table => new
                {
                    ConvenioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeConvenio = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenio", x => x.ConvenioId);
                    table.ForeignKey(
                        name: "FK_Convenio_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailEnvio",
                columns: table => new
                {
                    EmailEnvioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Setor = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailEnvio", x => x.EmailEnvioId);
                    table.ForeignKey(
                        name: "FK_EmailEnvio_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeHospital = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.HospitalId);
                    table.ForeignKey(
                        name: "FK_Hospital_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMedico = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.MedicoId);
                    table.ForeignKey(
                        name: "FK_Medico_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePaciente = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Paciente_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ConfimarSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoProduto = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    DescricaoProduto = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    SubcategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produto_SubcategoriaProduto_SubcategoriaId",
                        column: x => x.SubcategoriaId,
                        principalTable: "SubcategoriaProduto",
                        principalColumn: "SubcategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataProcedimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ConvenioId = table.Column<int>(type: "int", nullable: false),
                    MedicosId = table.Column<int>(type: "int", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Emergencial = table.Column<bool>(type: "bit", nullable: false),
                    Observações = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedido_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "ConvenioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospital",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Medico_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "Medico",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosItens",
                columns: table => new
                {
                    PedidosItensId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutosId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosItens", x => x.PedidosItensId);
                    table.ForeignKey(
                        name: "FK_PedidosItens_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosItens_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Convenio_RoleId",
                table: "Convenio",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailEnvio_RoleId",
                table: "EmailEnvio",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_RoleId",
                table: "Hospital",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_RoleId",
                table: "Medico",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_RoleId",
                table: "Paciente",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ConvenioId",
                table: "Pedido",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_HospitalId",
                table: "Pedido",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_MedicosId",
                table: "Pedido",
                column: "MedicosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PacienteId",
                table: "Pedido",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItens_PedidoId",
                table: "PedidosItens",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItens_ProdutosId",
                table: "PedidosItens",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_SubcategoriaId",
                table: "Produto",
                column: "SubcategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoriaProduto_CategoriaId",
                table: "SubcategoriaProduto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RoleId",
                table: "Usuario",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailEnvio");

            migrationBuilder.DropTable(
                name: "PedidosItens");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Convenio");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "SubcategoriaProduto");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "CategoriaProduto");
        }
    }
}
