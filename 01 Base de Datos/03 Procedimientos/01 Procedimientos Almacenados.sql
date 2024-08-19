use DB_Distribuidora
go
/*-----------------------------------------------------------------------------------------------------------*/
if object_id('dbo.Usp_Tb_TipoProducto_Ins') is not null
  drop procedure dbo.Usp_Tb_TipoProducto_Ins
go

create procedure dbo.Usp_Tb_TipoProducto_Ins
  @Descripcion varchar(150)
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_TipoProducto_Inc "Pinol 350"
 
*/
begin 
  if not exists(select tp.Tb_Tp_Id from dbo.Tb_TipoProducto tp where tp.Tb_Tp_Descripcion=@Descripcion)
    begin
      insert into 
        dbo.Tb_TipoProducto  
        (Tb_Tp_Descripcion
        , Tb_Tp_Estatus)
      values 
        (@Descripcion
        ,1)
       
      select @@identity
    end
  else
    begin
      select 
        tp.Tb_Tp_Id 
      from 
        dbo.Tb_TipoProducto tp 
      where 
        tp.Tb_Tp_Descripcion=@Descripcion
    end
  
end
go

/*-----------------------------------------------------------------------------------------------------------*/
if object_id('dbo.Usp_Tb_TipoProducto_Act') is not null
  drop procedure dbo.Usp_Tb_TipoProducto_Act
go

create procedure dbo.Usp_Tb_TipoProducto_Act
  @Id int
  , @Descripcion varchar(150)
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_TipoProducto_Act 1,"Pinol 350Ml"
 
*/
begin 
  if exists(select tp.Tb_Tp_Id from dbo.Tb_TipoProducto tp where tp.Tb_Tp_Id=@Id)
    begin
      update dbo.Tb_TipoProducto 
       set
        Tb_Tp_Descripcion = @Descripcion
      where
        Tb_Tp_Id = @Id
       
      select [Id] = @Id
    end
  else
    begin
      select [Id] = 0
    end
  
end
go
/*-----------------------------------------------------------------------------------------------------------*/

if object_id('dbo.Usp_Tb_TipoProducto_Obt') is not null
  drop procedure dbo.Usp_Tb_TipoProducto_Obt
go

create procedure dbo.Usp_Tb_TipoProducto_Obt
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_TipoProducto_Obt 
 
*/
begin 
  declare
    @Activo bit
  set
    @Activo = 1
  
  select 
    [Id] = tp.Tb_Tp_Id 
    , [Descripcion] = tp.Tb_Tp_Descripcion
    , [Estatus] = tp.Tb_Tp_Estatus
  from 
    dbo.Tb_TipoProducto tp 
  where 
    tp.Tb_Tp_Estatus = @Activo
    
end
go


