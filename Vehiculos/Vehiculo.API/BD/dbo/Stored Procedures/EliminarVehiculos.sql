CREATE PROCEDURE EliminarVehiculos 
	-- Add the parameters for the stored procedure here
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Begin transaction	
delete
FROM     Vehiculo 

WHERE   (Id = @Id)
select @Id
commit transaction
END