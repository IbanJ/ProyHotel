USE [AVAN_iban]
GO
/****** Object:  StoredProcedure [HOTEL].[numHabitaciones]    Script Date: 19/11/2019 13:25:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [HOTEL].[numHabitaciones]
@p_fechaEntrada date,
@p_fechaSalida date,
@p_tipoHabitacion tinyint,
@p_salida int OUTPUT
as
declare
	@v_countHabitacion smallint,
	@v_sumHabitacion smallint
begin
/**/

	IF @p_fechaSalida < @p_fechaEntrada
		set @p_salida = -1;
	set @v_countHabitacion =  (select isnull(count(tipoHabitacion),0)
								from HOTEL.reservas
								where tipoHabitacion=@p_tipoHabitacion)
	set @v_sumHabitacion = (select isnull(sum(numHabitaciones),0)
								from HOTEL.reservas
								where tipoHabitacion=1 
								and estado='activa'
								and fechaEntrada between @p_fechaEntrada and @p_fechaSalida
								or @p_fechaEntrada between FechaEntrada and FechaSalida)
		-- Sacar el numero de habitaciones restantes
		set @p_salida = @v_countHabitacion - @v_sumHabitacion;
end

