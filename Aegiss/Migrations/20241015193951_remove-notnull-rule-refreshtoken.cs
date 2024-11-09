using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aegiss.Migrations
{
    /// <inheritdoc />
    public partial class removenotnullrulerefreshtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APP_USER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false, comment: "Username para acesso à aplicação."),
                    PASSWORD = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "E-mail do usuário da aplicação."),
                    NAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Nome do usuário da aplicação."),
                    PHONE_NUMBER = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "Número de telefone do usuário aplicação."),
                    DATE_OF_BIRTH = table.Column<DateOnly>(type: "date", nullable: true, comment: "Data de nascimento do usuário da aplicação."),
                    ZIP_CODE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, defaultValue: "00000000", comment: "Cep do endereço do usuário da aplicação."),
                    STREET_NAME = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true, comment: "Rua do endereço do usuário da aplicação."),
                    STREET_NUMBER = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "Número da rua do endereço do usuário da aplicação."),
                    NEIGHBORHOOD = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true, comment: "Bairro do endereço do usuário da aplicação."),
                    CITY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "Cidade do endereço do usuário da aplicação."),
                    STATE = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true, comment: "Estado do endereço do usuário da aplicação."),
                    LAST_USERNAME_DATE_CHANGE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REFRESH_TOKEN = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())", comment: "Data de criação do usuário da aplicação.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__APP_USER__3214EC27BB249A44", x => x.ID);
                },
                comment: "Tabela que armazena os dados do usuário da aplicação.");

            migrationBuilder.CreateTable(
                name: "IMAGE_TYPE",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TYPE_DESCRIPTION = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__IMAGE_TY__3214EC27791906E4", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TABLE_MAPPING",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TABLE_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TABLE_MA__3214EC2758A49047", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EMAIL_RESETS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APP_USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    NEW_EMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    VALIDATION_TOKEN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    EXPIRES_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EMAIL_RE__3214EC27E0747D7E", x => x.ID);
                    table.ForeignKey(
                        name: "FK__EMAIL_RES__APP_U__7A672E12",
                        column: x => x.APP_USER_ID,
                        principalTable: "APP_USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LOCATION_ACCESS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APP_USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    ACCESS_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOCATION__3214EC2720E2587B", x => x.ID);
                    table.ForeignKey(
                        name: "FK__LOCATION___APP_U__7E37BEF6",
                        column: x => x.APP_USER_ID,
                        principalTable: "APP_USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PASSWORD_RESETS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APP_USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    VALIDATION_TOKEN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    EXPIRES_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PASSWORD__3214EC27C31E0FF7", x => x.ID);
                    table.ForeignKey(
                        name: "FK__PASSWORD___APP_U__75A278F5",
                        column: x => x.APP_USER_ID,
                        principalTable: "APP_USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER_CHARACTERISTICS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APP_USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    IMAGE_TYPE_ID = table.Column<short>(type: "smallint", nullable: false),
                    CHARACTERISTICS_VALUE = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USER_CHA__3214EC27143F8DB2", x => x.ID);
                    table.ForeignKey(
                        name: "FK__USER_CHAR__APP_U__07C12930",
                        column: x => x.APP_USER_ID,
                        principalTable: "APP_USER",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__USER_CHAR__IMAGE__08B54D69",
                        column: x => x.IMAGE_TYPE_ID,
                        principalTable: "IMAGE_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CHANGE_LOG",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TABLE_MAPPING_ID = table.Column<long>(type: "bigint", nullable: false),
                    RECORD = table.Column<long>(type: "bigint", nullable: false),
                    COLUMN_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CHANGE_TYPE = table.Column<short>(type: "smallint", nullable: false),
                    RESPONSIBLE = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "('0')"),
                    PREVIOUS_VALUE = table.Column<object>(type: "sql_variant", nullable: true),
                    NEW_VALUE = table.Column<object>(type: "sql_variant", nullable: true),
                    CHANGE_TIME = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHANGE_L__3214EC270AF6CF48", x => x.ID);
                    table.ForeignKey(
                        name: "FK__CHANGE_LO__TABLE__0E6E26BF",
                        column: x => x.TABLE_MAPPING_ID,
                        principalTable: "TABLE_MAPPING",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CREDENTIAL_ENTRY",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOCATION_ACCESS_ID = table.Column<long>(type: "bigint", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CREDENTI__3214EC276A385B14", x => x.ID);
                    table.ForeignKey(
                        name: "FK__CREDENTIA__LOCAT__02084FDA",
                        column: x => x.LOCATION_ACCESS_ID,
                        principalTable: "LOCATION_ACCESS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_APP_USER_CREATED_AT",
                table: "APP_USER",
                column: "CREATED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_APP_USER_EMAIL",
                table: "APP_USER",
                column: "EMAIL");

            migrationBuilder.CreateIndex(
                name: "IX_APP_USER_NAME",
                table: "APP_USER",
                column: "NAME");

            migrationBuilder.CreateIndex(
                name: "IX_APP_USER_USERNAME",
                table: "APP_USER",
                column: "USERNAME");

            migrationBuilder.CreateIndex(
                name: "UQ__APP_USER__161CF724EC31C6E4",
                table: "APP_USER",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__APP_USER__B15BE12EFCC78124",
                table: "APP_USER",
                column: "USERNAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CHANGE_LOG_CHANGE_TIME",
                table: "CHANGE_LOG",
                column: "CHANGE_TIME");

            migrationBuilder.CreateIndex(
                name: "IX_CHANGE_LOG_CHANGE_TYPE",
                table: "CHANGE_LOG",
                column: "CHANGE_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_CHANGE_LOG_COLUMN_NAME",
                table: "CHANGE_LOG",
                column: "COLUMN_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_CHANGE_LOG_RESPONSIBLE",
                table: "CHANGE_LOG",
                column: "RESPONSIBLE");

            migrationBuilder.CreateIndex(
                name: "IX_CHANGE_LOG_TABLE_MAPPING_ID",
                table: "CHANGE_LOG",
                column: "TABLE_MAPPING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CREDENTIAL_ENTRY_CREATED_AT",
                table: "CREDENTIAL_ENTRY",
                column: "CREATED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_CREDENTIAL_ENTRY_LOCATION_ACCESS_ID",
                table: "CREDENTIAL_ENTRY",
                column: "LOCATION_ACCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CREDENTIAL_ENTRY_USERNAME",
                table: "CREDENTIAL_ENTRY",
                column: "USERNAME");

            migrationBuilder.CreateIndex(
                name: "IX_EMAIL_RESETS_APP_USER_ID",
                table: "EMAIL_RESETS",
                column: "APP_USER_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__EMAIL_RE__66BC2EAC5DFA568C",
                table: "EMAIL_RESETS",
                column: "NEW_EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IMAGE_TYPE_TYPE_DESCRIPTION",
                table: "IMAGE_TYPE",
                column: "TYPE_DESCRIPTION");

            migrationBuilder.CreateIndex(
                name: "IX_LOCATION_ACCESS_ACCESS_NAME",
                table: "LOCATION_ACCESS",
                column: "ACCESS_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_LOCATION_ACCESS_APP_USER_ID",
                table: "LOCATION_ACCESS",
                column: "APP_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCATION_ACCESS_CREATED_AT",
                table: "LOCATION_ACCESS",
                column: "CREATED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_PASSWORD_RESETS_APP_USER_ID",
                table: "PASSWORD_RESETS",
                column: "APP_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_CHARACTERISTICS_APP_USER_ID",
                table: "USER_CHARACTERISTICS",
                column: "APP_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_CHARACTERISTICS_CREATED_AT",
                table: "USER_CHARACTERISTICS",
                column: "CREATED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_USER_CHARACTERISTICS_IMAGE_TYPE_ID",
                table: "USER_CHARACTERISTICS",
                column: "IMAGE_TYPE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHANGE_LOG");

            migrationBuilder.DropTable(
                name: "CREDENTIAL_ENTRY");

            migrationBuilder.DropTable(
                name: "EMAIL_RESETS");

            migrationBuilder.DropTable(
                name: "PASSWORD_RESETS");

            migrationBuilder.DropTable(
                name: "USER_CHARACTERISTICS");

            migrationBuilder.DropTable(
                name: "TABLE_MAPPING");

            migrationBuilder.DropTable(
                name: "LOCATION_ACCESS");

            migrationBuilder.DropTable(
                name: "IMAGE_TYPE");

            migrationBuilder.DropTable(
                name: "APP_USER");
        }
    }
}
