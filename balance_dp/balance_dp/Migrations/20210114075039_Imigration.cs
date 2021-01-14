using Microsoft.EntityFrameworkCore.Migrations;

namespace balance_dp.Migrations
{
    public partial class Imigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlastFurnace",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    list1_C20_Dailyproductivity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C21_CockCUMsuption = table.Column<float>(type: "REAL", nullable: false),
                    list1_C23_EffectVolume = table.Column<float>(type: "REAL", nullable: false),
                    list1_C24_HeatLoses_ofBlastFurnace = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlastFurnace", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BlastFurnaceGas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    list1_C61_GasTemperature = table.Column<float>(type: "REAL", nullable: false),
                    list1_C62_CO2_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C63_CO_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C64_H2_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C66_DustExit = table.Column<float>(type: "REAL", nullable: false),
                    list1_C67_FeO_Capacity = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlastFurnaceGas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BlowingParams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    list1_C32_BlowingConsumptionPerMinute = table.Column<float>(type: "REAL", nullable: false),
                    list1_C33_HotBlowingTemperature = table.Column<float>(type: "REAL", nullable: false),
                    list1_C34_BlowingMoistureTechReport = table.Column<float>(type: "REAL", nullable: false),
                    list1_C35_NaturalBlowingConsumption = table.Column<float>(type: "REAL", nullable: false),
                    list1_C37_PersentOxygenInBlowing = table.Column<float>(type: "REAL", nullable: false),
                    list1_C38_SpecificConsuptionNaturalGas = table.Column<float>(type: "REAL", nullable: false),
                    list1_C39_CH4Consuption = table.Column<float>(type: "REAL", nullable: false),
                    list1_C40_C2H6Comsuption = table.Column<float>(type: "REAL", nullable: false),
                    list1_C41_C3H8Comsuption = table.Column<float>(type: "REAL", nullable: false),
                    list1_C42_CO2Comsuption = table.Column<float>(type: "REAL", nullable: false),
                    list1_C43_C_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C44_H2_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C46_limestoneWaterCapacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C47_limestoneWeightLoss = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlowingParams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CastIronElementsPercent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    list1_C9_Si = table.Column<float>(type: "REAL", nullable: false),
                    list1_C10_Mn = table.Column<float>(type: "REAL", nullable: false),
                    list1_C11_S = table.Column<float>(type: "REAL", nullable: false),
                    list1_C12_P = table.Column<float>(type: "REAL", nullable: false),
                    list1_C13_Ti = table.Column<float>(type: "REAL", nullable: false),
                    list1_C14_Cr = table.Column<float>(type: "REAL", nullable: false),
                    list1_C15_V = table.Column<float>(type: "REAL", nullable: false),
                    list1_С16_C = table.Column<float>(type: "REAL", nullable: false),
                    list1_C17_CastIronTemperature = table.Column<float>(type: "REAL", nullable: false),
                    list1_C18_CastIronHeatCapacity = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastIronElementsPercent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COCKsAsh",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    list2_A46_Fe = table.Column<float>(type: "REAL", nullable: false),
                    list2_B46_Cao = table.Column<float>(type: "REAL", nullable: false),
                    list2_C46_Sio2 = table.Column<float>(type: "REAL", nullable: false),
                    list2_D46_Al2O3 = table.Column<float>(type: "REAL", nullable: false),
                    list2_E46_MgO = table.Column<float>(type: "REAL", nullable: false),
                    list2_F46_P = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCKsAsh", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COCKsComposition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    list2_A42_AhsCocks = table.Column<float>(type: "REAL", nullable: false),
                    list2_B42_SulfurCocks = table.Column<float>(type: "REAL", nullable: false),
                    list2_C42_LiquidCocks = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCKsComposition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FlusModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    list2_B33flusConsuption = table.Column<float>(type: "REAL", nullable: false),
                    list2_C33_CaO_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list2_D33_SiO2_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list2_E33_Al2O3_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list2_F33_MgO_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list2_G33_TiO2Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list2_H33_MnO_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list2_I33_P_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list2_J33_S_Capacity = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlusModels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MaterialConsuption",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    A8_Fe = table.Column<float>(type: "REAL", nullable: false),
                    B8_FeO = table.Column<float>(type: "REAL", nullable: false),
                    C8_Fe2O3 = table.Column<float>(type: "REAL", nullable: false),
                    D8_SiO2 = table.Column<float>(type: "REAL", nullable: false),
                    E8_AlO3 = table.Column<float>(type: "REAL", nullable: false),
                    F8_CaO = table.Column<float>(type: "REAL", nullable: false),
                    G8_MgO = table.Column<float>(type: "REAL", nullable: false),
                    H8_P = table.Column<float>(type: "REAL", nullable: false),
                    I8_S = table.Column<float>(type: "REAL", nullable: false),
                    J8_MnO = table.Column<float>(type: "REAL", nullable: false),
                    K8_Zn = table.Column<float>(type: "REAL", nullable: false),
                    L8_Pmpp = table.Column<float>(type: "REAL", nullable: false),
                    M8_H20 = table.Column<float>(type: "REAL", nullable: false),
                    N8_TiO2 = table.Column<float>(type: "REAL", nullable: false),
                    O8_Cr = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialConsuption", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Slag",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    list1_C49_SlagOutput = table.Column<float>(type: "REAL", nullable: false),
                    list1_C50_SulfurCapacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C51_HeatCapacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C53_CaO_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C54_SiO2_Caacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C55_Al2O3_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C56_MgO_Capacity = table.Column<float>(type: "REAL", nullable: false),
                    list1_C58_TiO2_Capacity = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slag", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ZHRM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    c69 = table.Column<float>(type: "REAL", nullable: false),
                    c70 = table.Column<float>(type: "REAL", nullable: false),
                    c71 = table.Column<float>(type: "REAL", nullable: false),
                    c72_waterCapacity = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZHRM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COCKsParamsPersent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CocksCompositID = table.Column<int>(type: "INTEGER", nullable: true),
                    CocksAshID = table.Column<int>(type: "INTEGER", nullable: true),
                    list1_C29_WaterCOCKs = table.Column<float>(type: "REAL", nullable: false),
                    list1_C30_FeoCOCKs = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCKsParamsPersent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COCKsParamsPersent_COCKsAsh_CocksAshID",
                        column: x => x.CocksAshID,
                        principalTable: "COCKsAsh",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCKsParamsPersent_COCKsComposition_CocksCompositID",
                        column: x => x.CocksCompositID,
                        principalTable: "COCKsComposition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LimestoneID = table.Column<int>(type: "INTEGER", nullable: true),
                    FluospatID = table.Column<int>(type: "INTEGER", nullable: true),
                    QuartziteID = table.Column<int>(type: "INTEGER", nullable: true),
                    SlugID = table.Column<int>(type: "INTEGER", nullable: true),
                    ReserveID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flus_FlusModels_FluospatID",
                        column: x => x.FluospatID,
                        principalTable: "FlusModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flus_FlusModels_LimestoneID",
                        column: x => x.LimestoneID,
                        principalTable: "FlusModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flus_FlusModels_QuartziteID",
                        column: x => x.QuartziteID,
                        principalTable: "FlusModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flus_FlusModels_ReserveID",
                        column: x => x.ReserveID,
                        principalTable: "FlusModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flus_FlusModels_SlugID",
                        column: x => x.SlugID,
                        principalTable: "FlusModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InputParametrsList1",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CastIronID = table.Column<int>(type: "INTEGER", nullable: true),
                    BlastFurID = table.Column<int>(type: "INTEGER", nullable: true),
                    CockParamID = table.Column<int>(type: "INTEGER", nullable: true),
                    FurnaceGasID = table.Column<int>(type: "INTEGER", nullable: true),
                    blowingID = table.Column<int>(type: "INTEGER", nullable: true),
                    slagID = table.Column<int>(type: "INTEGER", nullable: true),
                    zhrmID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputParametrsList1", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InputParametrsList1_BlastFurnace_BlastFurID",
                        column: x => x.BlastFurID,
                        principalTable: "BlastFurnace",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputParametrsList1_BlastFurnaceGas_FurnaceGasID",
                        column: x => x.FurnaceGasID,
                        principalTable: "BlastFurnaceGas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputParametrsList1_BlowingParams_blowingID",
                        column: x => x.blowingID,
                        principalTable: "BlowingParams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputParametrsList1_CastIronElementsPercent_CastIronID",
                        column: x => x.CastIronID,
                        principalTable: "CastIronElementsPercent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputParametrsList1_COCKsParamsPersent_CockParamID",
                        column: x => x.CockParamID,
                        principalTable: "COCKsParamsPersent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputParametrsList1_Slag_slagID",
                        column: x => x.slagID,
                        principalTable: "Slag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputParametrsList1_ZHRM_zhrmID",
                        column: x => x.zhrmID,
                        principalTable: "ZHRM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InputParametrsList2",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    flusID = table.Column<int>(type: "INTEGER", nullable: true),
                    materialConsID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputParametrsList2", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InputParametrsList2_Flus_flusID",
                        column: x => x.flusID,
                        principalTable: "Flus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputParametrsList2_MaterialConsuption_materialConsID",
                        column: x => x.materialConsID,
                        principalTable: "MaterialConsuption",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inputs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "TEXT", nullable: true),
                    InputIndicatorsID = table.Column<int>(type: "INTEGER", nullable: true),
                    InputData2ID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inputs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inputs_InputParametrsList1_InputIndicatorsID",
                        column: x => x.InputIndicatorsID,
                        principalTable: "InputParametrsList1",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inputs_InputParametrsList2_InputData2ID",
                        column: x => x.InputData2ID,
                        principalTable: "InputParametrsList2",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COCKsParamsPersent_CocksAshID",
                table: "COCKsParamsPersent",
                column: "CocksAshID");

            migrationBuilder.CreateIndex(
                name: "IX_COCKsParamsPersent_CocksCompositID",
                table: "COCKsParamsPersent",
                column: "CocksCompositID");

            migrationBuilder.CreateIndex(
                name: "IX_Flus_FluospatID",
                table: "Flus",
                column: "FluospatID");

            migrationBuilder.CreateIndex(
                name: "IX_Flus_LimestoneID",
                table: "Flus",
                column: "LimestoneID");

            migrationBuilder.CreateIndex(
                name: "IX_Flus_QuartziteID",
                table: "Flus",
                column: "QuartziteID");

            migrationBuilder.CreateIndex(
                name: "IX_Flus_ReserveID",
                table: "Flus",
                column: "ReserveID");

            migrationBuilder.CreateIndex(
                name: "IX_Flus_SlugID",
                table: "Flus",
                column: "SlugID");

            migrationBuilder.CreateIndex(
                name: "IX_InputParametrsList1_BlastFurID",
                table: "InputParametrsList1",
                column: "BlastFurID");

            migrationBuilder.CreateIndex(
                name: "IX_InputParametrsList1_blowingID",
                table: "InputParametrsList1",
                column: "blowingID");

            migrationBuilder.CreateIndex(
                name: "IX_InputParametrsList1_CastIronID",
                table: "InputParametrsList1",
                column: "CastIronID");

            migrationBuilder.CreateIndex(
                name: "IX_InputParametrsList1_CockParamID",
                table: "InputParametrsList1",
                column: "CockParamID");

            migrationBuilder.CreateIndex(
                name: "IX_InputParametrsList1_FurnaceGasID",
                table: "InputParametrsList1",
                column: "FurnaceGasID");

            migrationBuilder.CreateIndex(
                name: "IX_InputParametrsList1_slagID",
                table: "InputParametrsList1",
                column: "slagID");

            migrationBuilder.CreateIndex(
                name: "IX_InputParametrsList1_zhrmID",
                table: "InputParametrsList1",
                column: "zhrmID");

            migrationBuilder.CreateIndex(
                name: "IX_InputParametrsList2_flusID",
                table: "InputParametrsList2",
                column: "flusID");

            migrationBuilder.CreateIndex(
                name: "IX_InputParametrsList2_materialConsID",
                table: "InputParametrsList2",
                column: "materialConsID");

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_InputData2ID",
                table: "Inputs",
                column: "InputData2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_InputIndicatorsID",
                table: "Inputs",
                column: "InputIndicatorsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inputs");

            migrationBuilder.DropTable(
                name: "InputParametrsList1");

            migrationBuilder.DropTable(
                name: "InputParametrsList2");

            migrationBuilder.DropTable(
                name: "BlastFurnace");

            migrationBuilder.DropTable(
                name: "BlastFurnaceGas");

            migrationBuilder.DropTable(
                name: "BlowingParams");

            migrationBuilder.DropTable(
                name: "CastIronElementsPercent");

            migrationBuilder.DropTable(
                name: "COCKsParamsPersent");

            migrationBuilder.DropTable(
                name: "Slag");

            migrationBuilder.DropTable(
                name: "ZHRM");

            migrationBuilder.DropTable(
                name: "Flus");

            migrationBuilder.DropTable(
                name: "MaterialConsuption");

            migrationBuilder.DropTable(
                name: "COCKsAsh");

            migrationBuilder.DropTable(
                name: "COCKsComposition");

            migrationBuilder.DropTable(
                name: "FlusModels");
        }
    }
}
