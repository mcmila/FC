USE [Teste]
GO
IF OBJECT_ID('dbo.P_NOTA_FISCAL_ITEM') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.P_NOTA_FISCAL_ITEM
    IF OBJECT_ID('dbo.P_NOTA_FISCAL_ITEM') IS NOT NULL
        PRINT '<<< FALHA APAGANDO A PROCEDURE dbo.P_NOTA_FISCAL_ITEM >>>'
    ELSE
        PRINT '<<< PROCEDURE dbo.P_NOTA_FISCAL_ITEM APAGADA >>>'
END
go
SET QUOTED_IDENTIFIER ON
GO
SET NOCOUNT ON 
GO 
CREATE PROCEDURE P_NOTA_FISCAL_ITEM
(
	@pId int OUTPUT,
    @pIdNotaFiscal int,
    @pCfop varchar(5),
    @pTipoIcms varchar(20),
    @pBaseIcms decimal(18,5),
    @pAliquotaIcms decimal(18,5),
    @pValorIcms decimal(18,5),
    @pNomeProduto varchar(50),
    @pCodigoProduto varchar(20),
	@BaseIpi decimal(18,5),
	@ValorIpi decimal(18,5),
	@AliquotaIpi decimal(18,5),
	@Desconto decimal(18,5)
)
AS
BEGIN
	IF (@pId = 0)
	BEGIN 		
		INSERT INTO [dbo].[NotaFiscalItem]
           ([IdNotaFiscal]
           ,[Cfop]
           ,[TipoIcms]
           ,[BaseIcms]
           ,[AliquotaIcms]
           ,[ValorIcms]
           ,[NomeProduto]
           ,[CodigoProduto]
		   ,[BaseIpi]
		   ,[ValorIpi]
		   ,[AliquotaIpi]
		   ,[Desconto])
		VALUES
           (@pIdNotaFiscal,
			@pCfop,
			@pTipoIcms,
			@pBaseIcms,
			@pAliquotaIcms,
			@pValorIcms,
			@pNomeProduto,
			@pCodigoProduto,
			@BaseIpi,
			@ValorIpi,
			@AliquotaIpi,
			@Desconto)

		SET @pId = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE [dbo].[NotaFiscalItem]
		SET [IdNotaFiscal] = @pIdNotaFiscal
			,[Cfop] = @pCfop
			,[TipoIcms] = @pTipoIcms
			,[BaseIcms] = @pBaseIcms
			,[AliquotaIcms] = @pAliquotaIcms
			,[ValorIcms] = @pValorIcms
			,[NomeProduto] = @pNomeProduto
			,[CodigoProduto] = @pCodigoProduto
			,[BaseIpi] = @BaseIpi
		    ,[ValorIpi] = @ValorIpi
		    ,[AliquotaIpi] = @AliquotaIpi
			,[Desconto] = @Desconto
		 WHERE Id = @pId
	END	    
END
GO
GRANT EXECUTE ON dbo.P_NOTA_FISCAL_ITEM TO [public]
go
IF OBJECT_ID('dbo.P_NOTA_FISCAL_ITEM') IS NOT NULL
    PRINT '<<< PROCEDURE dbo.P_NOTA_FISCAL_ITEM CRIADA >>>'
ELSE
    PRINT '<<< FALHA NA CRIACAO DA PROCEDURE dbo.P_NOTA_FISCAL_ITEM >>>'
go