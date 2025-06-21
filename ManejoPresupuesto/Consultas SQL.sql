USE ManejoPresupuesto

GO

INSERT INTO Transacciones (FechaTransaccion, Monto, Nota, TipoTransaccionId, UsuarioId) 
       VALUES ('2025-06-18', 18000.50, 'Pago', 1, 'Jei')


go

SELECT * FROM Transacciones

SELECT * FROM Transacciones ORDER BY Monto 

SELECT * FROM Transacciones WHERE Monto IN (1500, 21000)


CREATE TABLE TipoOperaciones(
 IdTipo int Identity NOT NULL,
 Descripcion nvarchar(50) NOT NULL
)

