
CREATE PROCEDURE [dbo].[AgregarVehiculos] 
    @Id AS UNIQUEIDENTIFIER,
    @IdModelo AS UNIQUEIDENTIFIER,
    @Placa AS VARCHAR(MAX),
    @Color AS VARCHAR(MAX),
    @Anio AS INT,
    @Precio AS DECIMAL(18,0),
    @CorreoPropietario AS VARCHAR(MAX),
    @TelefonoPropietario AS VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[Vehiculo]
        (
            [Id],
            [IdModelo],
            [Placa],
            [Color],
            [Anio],
            [Precio],
            [CorreoPropietario],
            [TelefonoPropietario]
        )
        VALUES
        (
            @Id,
            @IdModelo,
            @Placa,
            @Color,
            @Anio,
            @Precio,
            @CorreoPropietario,
            @TelefonoPropietario
        );

        COMMIT TRANSACTION;

        SELECT @Id;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END