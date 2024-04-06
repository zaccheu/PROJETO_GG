CREATE PROCEDURE PROC_INSERIR_CLIENTES(

@IdCliente INT,

@Documento VARCHAR(15),

@Nome VARCHAR(50),

@Sexo VARCHAR(1),

@Email VARCHAR(100),

@Telefone VARCHAR(11),

@Fax VARCHAR(11),

@UF VARCHAR(2)

)

AS

BEGIN

INSERT INTO Clientes (IdCliente, Documento, Nome, Sexo, Email, Telefone, Fax, UF)

VALUES(@IdCliente, @Documento, @Nome, @Sexo, @Email, @Telefone, @Fax, @UF)

END