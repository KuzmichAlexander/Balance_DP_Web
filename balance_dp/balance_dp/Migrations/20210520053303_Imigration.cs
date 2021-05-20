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
                name: "BlastFurnaceGases",
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
                    table.PrimaryKey("PK_BlastFurnaceGases", x => x.ID);
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
                name: "CastIronElementsPercents",
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
                    table.PrimaryKey("PK_CastIronElementsPercents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COCKsAshes",
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
                    table.PrimaryKey("PK_COCKsAshes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COCKsCompositions",
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
                    table.PrimaryKey("PK_COCKsCompositions", x => x.ID);
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
                name: "InputZRModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    B9_CastIronConsuption = table.Column<float>(type: "REAL", nullable: false),
                    C9_FE = table.Column<float>(type: "REAL", nullable: false),
                    D9_Fe0 = table.Column<float>(type: "REAL", nullable: false),
                    E9_Fe2O3 = table.Column<float>(type: "REAL", nullable: false),
                    F9_SiO2 = table.Column<float>(type: "REAL", nullable: false),
                    G9_Al203 = table.Column<float>(type: "REAL", nullable: false),
                    H9_CaO = table.Column<float>(type: "REAL", nullable: false),
                    I9_Mgo = table.Column<float>(type: "REAL", nullable: false),
                    J9_P = table.Column<float>(type: "REAL", nullable: false),
                    K9_S = table.Column<float>(type: "REAL", nullable: false),
                    L9_MnO = table.Column<float>(type: "REAL", nullable: false),
                    M9_Zn = table.Column<float>(type: "REAL", nullable: false),
                    N9_Pmpp = table.Column<float>(type: "REAL", nullable: false),
                    O9_H20 = table.Column<float>(type: "REAL", nullable: false),
                    P9_TiO2 = table.Column<float>(type: "REAL", nullable: false),
                    Q9_Cr = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputZRModels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MaterialConsuptions",
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
                    table.PrimaryKey("PK_MaterialConsuptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Slags",
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
                    table.PrimaryKey("PK_Slags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Token = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZHRMs",
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
                    table.PrimaryKey("PK_ZHRMs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COCKsParamsPersents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    COCKsCompositionid = table.Column<int>(type: "INTEGER", nullable: false),
                    COCKsAshId = table.Column<int>(type: "INTEGER", nullable: false),
                    list1_C29_WaterCOCKs = table.Column<float>(type: "REAL", nullable: false),
                    list1_C30_FeoCOCKs = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCKsParamsPersents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COCKsParamsPersents_COCKsAshes_COCKsAshId",
                        column: x => x.COCKsAshId,
                        principalTable: "COCKsAshes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCKsParamsPersents_COCKsCompositions_COCKsCompositionid",
                        column: x => x.COCKsCompositionid,
                        principalTable: "COCKsCompositions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "InputZRM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    A9_Aglomerat2ID = table.Column<int>(type: "INTEGER", nullable: true),
                    A10_Aglomerat3ID = table.Column<int>(type: "INTEGER", nullable: true),
                    A11_Aglomerat4ID = table.Column<int>(type: "INTEGER", nullable: true),
                    A12_Aglomerat5ID = table.Column<int>(type: "INTEGER", nullable: true),
                    A13_AglomeratNotClearedID = table.Column<int>(type: "INTEGER", nullable: true),
                    A14_AglomeratYamaID = table.Column<int>(type: "INTEGER", nullable: true),
                    A15_Okat_SokolovID = table.Column<int>(type: "INTEGER", nullable: true),
                    A16_Okat_LebedID = table.Column<int>(type: "INTEGER", nullable: true),
                    A17_Okat_KachkanID = table.Column<int>(type: "INTEGER", nullable: true),
                    A18_Okat_MikhayID = table.Column<int>(type: "INTEGER", nullable: true),
                    A19_Welding_slagID = table.Column<int>(type: "INTEGER", nullable: true),
                    A20_KorolekID = table.Column<int>(type: "INTEGER", nullable: true),
                    A21_Domen_prisadID = table.Column<int>(type: "INTEGER", nullable: true),
                    A22_Ruda_Mn_NizgulID = table.Column<int>(type: "INTEGER", nullable: true),
                    A23_Ruda_Mn_JairemID = table.Column<int>(type: "INTEGER", nullable: true),
                    A24_Aglomeran_screeningID = table.Column<int>(type: "INTEGER", nullable: true),
                    A25_ReserveID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputZRM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A10_Aglomerat3ID",
                        column: x => x.A10_Aglomerat3ID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A11_Aglomerat4ID",
                        column: x => x.A11_Aglomerat4ID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A12_Aglomerat5ID",
                        column: x => x.A12_Aglomerat5ID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A13_AglomeratNotClearedID",
                        column: x => x.A13_AglomeratNotClearedID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A14_AglomeratYamaID",
                        column: x => x.A14_AglomeratYamaID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A15_Okat_SokolovID",
                        column: x => x.A15_Okat_SokolovID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A16_Okat_LebedID",
                        column: x => x.A16_Okat_LebedID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A17_Okat_KachkanID",
                        column: x => x.A17_Okat_KachkanID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A18_Okat_MikhayID",
                        column: x => x.A18_Okat_MikhayID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A19_Welding_slagID",
                        column: x => x.A19_Welding_slagID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A20_KorolekID",
                        column: x => x.A20_KorolekID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A21_Domen_prisadID",
                        column: x => x.A21_Domen_prisadID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A22_Ruda_Mn_NizgulID",
                        column: x => x.A22_Ruda_Mn_NizgulID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A23_Ruda_Mn_JairemID",
                        column: x => x.A23_Ruda_Mn_JairemID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A24_Aglomeran_screeningID",
                        column: x => x.A24_Aglomeran_screeningID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A25_ReserveID",
                        column: x => x.A25_ReserveID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputZRM_InputZRModels_A9_Aglomerat2ID",
                        column: x => x.A9_Aglomerat2ID,
                        principalTable: "InputZRModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InputIndicators",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CastIronElementsPercentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    CastIronID = table.Column<int>(type: "INTEGER", nullable: true),
                    BlastFurnaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    COCKsParamsPersentId = table.Column<int>(type: "INTEGER", nullable: false),
                    BlastFurnaceGasId = table.Column<int>(type: "INTEGER", nullable: false),
                    BlowingParamsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SlagId = table.Column<int>(type: "INTEGER", nullable: false),
                    ZHRMId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputIndicators", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InputIndicators_BlastFurnace_BlastFurnaceId",
                        column: x => x.BlastFurnaceId,
                        principalTable: "BlastFurnace",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputIndicators_BlastFurnaceGases_BlastFurnaceGasId",
                        column: x => x.BlastFurnaceGasId,
                        principalTable: "BlastFurnaceGases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputIndicators_BlowingParams_BlowingParamsId",
                        column: x => x.BlowingParamsId,
                        principalTable: "BlowingParams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputIndicators_CastIronElementsPercents_CastIronID",
                        column: x => x.CastIronID,
                        principalTable: "CastIronElementsPercents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputIndicators_COCKsParamsPersents_COCKsParamsPersentId",
                        column: x => x.COCKsParamsPersentId,
                        principalTable: "COCKsParamsPersents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputIndicators_Slags_SlagId",
                        column: x => x.SlagId,
                        principalTable: "Slags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputIndicators_ZHRMs_ZHRMId",
                        column: x => x.ZHRMId,
                        principalTable: "ZHRMs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputMaterials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FlusId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialConsuptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    InputZRHMsID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputMaterials", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InputMaterials_Flus_FlusId",
                        column: x => x.FlusId,
                        principalTable: "Flus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputMaterials_InputZRM_InputZRHMsID",
                        column: x => x.InputZRHMsID,
                        principalTable: "InputZRM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputMaterials_MaterialConsuptions_MaterialConsuptionId",
                        column: x => x.MaterialConsuptionId,
                        principalTable: "MaterialConsuptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    InputIndicatorsId = table.Column<int>(type: "INTEGER", nullable: false),
                    InputData2Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inputs_InputIndicators_InputIndicatorsId",
                        column: x => x.InputIndicatorsId,
                        principalTable: "InputIndicators",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inputs_InputMaterials_InputData2Id",
                        column: x => x.InputData2Id,
                        principalTable: "InputMaterials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COCKsParamsPersents_COCKsAshId",
                table: "COCKsParamsPersents",
                column: "COCKsAshId");

            migrationBuilder.CreateIndex(
                name: "IX_COCKsParamsPersents_COCKsCompositionid",
                table: "COCKsParamsPersents",
                column: "COCKsCompositionid");

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
                name: "IX_InputIndicators_BlastFurnaceGasId",
                table: "InputIndicators",
                column: "BlastFurnaceGasId");

            migrationBuilder.CreateIndex(
                name: "IX_InputIndicators_BlastFurnaceId",
                table: "InputIndicators",
                column: "BlastFurnaceId");

            migrationBuilder.CreateIndex(
                name: "IX_InputIndicators_BlowingParamsId",
                table: "InputIndicators",
                column: "BlowingParamsId");

            migrationBuilder.CreateIndex(
                name: "IX_InputIndicators_CastIronID",
                table: "InputIndicators",
                column: "CastIronID");

            migrationBuilder.CreateIndex(
                name: "IX_InputIndicators_COCKsParamsPersentId",
                table: "InputIndicators",
                column: "COCKsParamsPersentId");

            migrationBuilder.CreateIndex(
                name: "IX_InputIndicators_SlagId",
                table: "InputIndicators",
                column: "SlagId");

            migrationBuilder.CreateIndex(
                name: "IX_InputIndicators_ZHRMId",
                table: "InputIndicators",
                column: "ZHRMId");

            migrationBuilder.CreateIndex(
                name: "IX_InputMaterials_FlusId",
                table: "InputMaterials",
                column: "FlusId");

            migrationBuilder.CreateIndex(
                name: "IX_InputMaterials_InputZRHMsID",
                table: "InputMaterials",
                column: "InputZRHMsID");

            migrationBuilder.CreateIndex(
                name: "IX_InputMaterials_MaterialConsuptionId",
                table: "InputMaterials",
                column: "MaterialConsuptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_InputData2Id",
                table: "Inputs",
                column: "InputData2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_InputIndicatorsId",
                table: "Inputs",
                column: "InputIndicatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A10_Aglomerat3ID",
                table: "InputZRM",
                column: "A10_Aglomerat3ID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A11_Aglomerat4ID",
                table: "InputZRM",
                column: "A11_Aglomerat4ID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A12_Aglomerat5ID",
                table: "InputZRM",
                column: "A12_Aglomerat5ID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A13_AglomeratNotClearedID",
                table: "InputZRM",
                column: "A13_AglomeratNotClearedID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A14_AglomeratYamaID",
                table: "InputZRM",
                column: "A14_AglomeratYamaID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A15_Okat_SokolovID",
                table: "InputZRM",
                column: "A15_Okat_SokolovID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A16_Okat_LebedID",
                table: "InputZRM",
                column: "A16_Okat_LebedID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A17_Okat_KachkanID",
                table: "InputZRM",
                column: "A17_Okat_KachkanID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A18_Okat_MikhayID",
                table: "InputZRM",
                column: "A18_Okat_MikhayID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A19_Welding_slagID",
                table: "InputZRM",
                column: "A19_Welding_slagID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A20_KorolekID",
                table: "InputZRM",
                column: "A20_KorolekID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A21_Domen_prisadID",
                table: "InputZRM",
                column: "A21_Domen_prisadID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A22_Ruda_Mn_NizgulID",
                table: "InputZRM",
                column: "A22_Ruda_Mn_NizgulID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A23_Ruda_Mn_JairemID",
                table: "InputZRM",
                column: "A23_Ruda_Mn_JairemID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A24_Aglomeran_screeningID",
                table: "InputZRM",
                column: "A24_Aglomeran_screeningID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A25_ReserveID",
                table: "InputZRM",
                column: "A25_ReserveID");

            migrationBuilder.CreateIndex(
                name: "IX_InputZRM_A9_Aglomerat2ID",
                table: "InputZRM",
                column: "A9_Aglomerat2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inputs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "InputIndicators");

            migrationBuilder.DropTable(
                name: "InputMaterials");

            migrationBuilder.DropTable(
                name: "BlastFurnace");

            migrationBuilder.DropTable(
                name: "BlastFurnaceGases");

            migrationBuilder.DropTable(
                name: "BlowingParams");

            migrationBuilder.DropTable(
                name: "CastIronElementsPercents");

            migrationBuilder.DropTable(
                name: "COCKsParamsPersents");

            migrationBuilder.DropTable(
                name: "Slags");

            migrationBuilder.DropTable(
                name: "ZHRMs");

            migrationBuilder.DropTable(
                name: "Flus");

            migrationBuilder.DropTable(
                name: "InputZRM");

            migrationBuilder.DropTable(
                name: "MaterialConsuptions");

            migrationBuilder.DropTable(
                name: "COCKsAshes");

            migrationBuilder.DropTable(
                name: "COCKsCompositions");

            migrationBuilder.DropTable(
                name: "FlusModels");

            migrationBuilder.DropTable(
                name: "InputZRModels");
        }
    }
}
