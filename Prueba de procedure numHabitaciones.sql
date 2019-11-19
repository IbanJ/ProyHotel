declare
@p_salida int
begin
exec HOTEL.numHabitaciones '2019-01-19','2019-01-21',1,@p_salida output
print @p_salida
end
