using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    RegisterDateTime = table.Column<DateTime>(nullable: false),
                    IsAdministrator = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsOperational = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChargeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    ShortDesc = table.Column<string>(nullable: true),
                    LongDesc = table.Column<string>(nullable: true),
                    Nemotecnico = table.Column<string>(nullable: true),
                    OfficialId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ChargeTypeCode = table.Column<string>(nullable: true),
                    VatRate = table.Column<double>(nullable: false),
                    IsVATCharge = table.Column<bool>(nullable: false),
                    IsBaseFare = table.Column<bool>(nullable: false),
                    IsWaterConsume = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargeType_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChargeType_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    ShortDesc = table.Column<string>(nullable: true),
                    LongDesc = table.Column<string>(nullable: true),
                    Nemotecnico = table.Column<string>(nullable: true),
                    OfficialId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ContractTypeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractType_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractType_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    ShortDesc = table.Column<string>(nullable: true),
                    LongDesc = table.Column<string>(nullable: true),
                    Nemotecnico = table.Column<string>(nullable: true),
                    OfficialId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    Acronym = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currency_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Currency_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    ShortDesc = table.Column<string>(nullable: true),
                    LongDesc = table.Column<string>(nullable: true),
                    Nemotecnico = table.Column<string>(nullable: true),
                    OfficialId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    PersonTypeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerType_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerType_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsGeneralTable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entity_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    RealFolio = table.Column<string>(nullable: true),
                    CadastralPlans = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    ExactAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estate_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estate_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    ShortDesc = table.Column<string>(nullable: true),
                    LongDesc = table.Column<string>(nullable: true),
                    Nemotecnico = table.Column<string>(nullable: true),
                    OfficialId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IdentificationTypeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentificationType_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentificationType_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Month",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    ShortDesc = table.Column<string>(nullable: true),
                    Nemotecnico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Month_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Month_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    ShortDesc = table.Column<string>(nullable: true),
                    LongDesc = table.Column<string>(nullable: true),
                    Nemotecnico = table.Column<string>(nullable: true),
                    OfficialId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ProductTypeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductType_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductType_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Charge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    ShortDesc = table.Column<string>(nullable: true),
                    LongDesc = table.Column<string>(nullable: true),
                    Nemotecnico = table.Column<string>(nullable: true),
                    OfficialId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ChargeCode = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ChargeTypeId = table.Column<int>(nullable: false),
                    CubicMeterFrom = table.Column<double>(nullable: false),
                    CubicMeterTo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charge_ChargeType_ChargeTypeId",
                        column: x => x.ChargeTypeId,
                        principalTable: "ChargeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Charge_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Charge_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FirstLastName = table.Column<string>(nullable: true),
                    SecondLastName = table.Column<string>(nullable: true),
                    PersonTypeId = table.Column<int>(nullable: false),
                    IdentificationTypeId = table.Column<int>(nullable: false),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_IdentificationType_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalTable: "IdentificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_CustomerType_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "CustomerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    MonthId = table.Column<int>(nullable: false),
                    MeasurementId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    ReadUserId = table.Column<string>(nullable: true),
                    ReadDate = table.Column<DateTime>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    MaxPaymentDate = table.Column<DateTime>(nullable: false),
                    MessageOfTheMonth = table.Column<string>(nullable: true),
                    PaymentPlace = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurement_Month_MonthId",
                        column: x => x.MonthId,
                        principalTable: "Month",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Measurement_SystemUser_ReadUserId",
                        column: x => x.ReadUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Measurement_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Measurement_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ContactName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Schedule = table.Column<string>(nullable: true),
                    ProductTypeId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonsByEstate",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    EstateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonsByEstate", x => new { x.EstateId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonsByEstate_Estate_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonsByEstate_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterMeter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: false),
                    BougthDate = table.Column<DateTime>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    CurrentRead = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterMeter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterMeter_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaterMeter_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaterMeter_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    PersonsByEstateEstateId = table.Column<int>(nullable: true),
                    PersonsByEstatePersonId = table.Column<int>(nullable: true),
                    PersonsId = table.Column<int>(nullable: false),
                    EstateId = table.Column<int>(nullable: false),
                    ContractTypeId = table.Column<int>(nullable: false),
                    MeterId = table.Column<int>(nullable: false),
                    EmissionDate = table.Column<DateTime>(nullable: false),
                    InitialMeterRead = table.Column<int>(nullable: false),
                    DoubleBasicCharge = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_ContractType_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_WaterMeter_MeterId",
                        column: x => x.MeterId,
                        principalTable: "WaterMeter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contract_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contract_PersonsByEstate_PersonsByEstateEstateId_PersonsByEstatePersonId",
                        columns: x => new { x.PersonsByEstateEstateId, x.PersonsByEstatePersonId },
                        principalTable: "PersonsByEstate",
                        principalColumns: new[] { "EstateId", "PersonId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    MeasurementId = table.Column<int>(nullable: false),
                    ContractId = table.Column<int>(nullable: false),
                    LastRead = table.Column<int>(nullable: false),
                    NewRead = table.Column<int>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipt_Measurement_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "Measurement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipt_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    ReceiptId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    VatAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptItem_Receipt_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptItem_SystemUser_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptItem_SystemUser_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Month",
                columns: new[] { "Id", "Nemotecnico", "RegisterDatime", "RegisterUserId", "ShortDesc", "UpdateDateTime", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, "ENERO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Enero", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "FEBRERO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Febrero", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "MARZO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marzo", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "ABRIL", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Abril", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, "MAYO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mayo", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, "JUNIO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Junio", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, "JULIO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Julio", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, "AGOSTO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Agosto", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, "SEPTIEMBRE", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Septiembre", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, "OCTUBRE", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Octubre", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, "NOVIEMBRE", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Noviembre", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, "DICIEMBRE", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diciembre", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Charge_ChargeTypeId",
                table: "Charge",
                column: "ChargeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_RegisterUserId",
                table: "Charge",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_UpdateUserId",
                table: "Charge",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeType_RegisterUserId",
                table: "ChargeType",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeType_UpdateUserId",
                table: "ChargeType",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ContractTypeId",
                table: "Contract",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_MeterId",
                table: "Contract",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_RegisterUserId",
                table: "Contract",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_UpdateUserId",
                table: "Contract",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_PersonsByEstateEstateId_PersonsByEstatePersonId",
                table: "Contract",
                columns: new[] { "PersonsByEstateEstateId", "PersonsByEstatePersonId" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractType_RegisterUserId",
                table: "ContractType",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractType_UpdateUserId",
                table: "ContractType",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_RegisterUserId",
                table: "Currency",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_UpdateUserId",
                table: "Currency",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerType_RegisterUserId",
                table: "CustomerType",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerType_UpdateUserId",
                table: "CustomerType",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_RegisterUserId",
                table: "Entity",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_UpdateUserId",
                table: "Entity",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_RegisterUserId",
                table: "Estate",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_UpdateUserId",
                table: "Estate",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentificationType_RegisterUserId",
                table: "IdentificationType",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentificationType_UpdateUserId",
                table: "IdentificationType",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_MonthId",
                table: "Measurement",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_ReadUserId",
                table: "Measurement",
                column: "ReadUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_RegisterUserId",
                table: "Measurement",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_UpdateUserId",
                table: "Measurement",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Month_RegisterUserId",
                table: "Month",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Month_UpdateUserId",
                table: "Month",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdentificationTypeId",
                table: "Person",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonTypeId",
                table: "Person",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_RegisterUserId",
                table: "Person",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_UpdateUserId",
                table: "Person",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonsByEstate_PersonId",
                table: "PersonsByEstate",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_RegisterUserId",
                table: "ProductType",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_UpdateUserId",
                table: "ProductType",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_ContractId",
                table: "Receipt",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_MeasurementId",
                table: "Receipt",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_RegisterUserId",
                table: "Receipt",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_UpdateUserId",
                table: "Receipt",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItem_ReceiptId",
                table: "ReceiptItem",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItem_RegisterUserId",
                table: "ReceiptItem",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItem_UpdateUserId",
                table: "ReceiptItem",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ProductTypeId",
                table: "Supplier",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_RegisterUserId",
                table: "Supplier",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_UpdateUserId",
                table: "Supplier",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeter_RegisterUserId",
                table: "WaterMeter",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeter_SupplierId",
                table: "WaterMeter",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeter_UpdateUserId",
                table: "WaterMeter",
                column: "UpdateUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charge");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Entity");

            migrationBuilder.DropTable(
                name: "ReceiptItem");

            migrationBuilder.DropTable(
                name: "ChargeType");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropTable(
                name: "ContractType");

            migrationBuilder.DropTable(
                name: "WaterMeter");

            migrationBuilder.DropTable(
                name: "PersonsByEstate");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Estate");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "IdentificationType");

            migrationBuilder.DropTable(
                name: "CustomerType");

            migrationBuilder.DropTable(
                name: "SystemUser");
        }
    }
}
