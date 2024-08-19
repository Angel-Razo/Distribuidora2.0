If object_id('dbo.Tb_Producto') is not null
  drop table dbo.Tb_Producto
go

If object_id('dbo.Tb_TipoProducto') is not null
  drop table dbo.Tb_TipoProducto
go

Create table dbo.Tb_TipoProducto(
  Tb_Tp_Id int identity(1,1) primary key
  , Tb_Tp_Descripcion varchar(150)
  , Tb_Tp_Estatus bit)
go

If object_id('dbo.Tb_Proveedor') is not null
  drop table dbo.Tb_Proveedor
go

Create table dbo.Tb_Proveedor(
  Tb_Prov_Id int identity(1,1) primary key
  , Tb_Prov_Nombre varchar(150)
  , Tb_Prov_Estatus bit)
go



create table dbo.TB_Producto
  (Tb_Prod_Id int identity(1,1) primary key
  , Tb_Tp_Id_Fk int 
  , Tb_Prov_Id_Fk int
  , Tb_Prod_Clave varchar(150) 
  , Tb_Prod_Estatus bit
  , Tb_Prod_Precio decimal(10,2)
  , constraint Fk_TipoProducto foreign key(Tb_Tp_Id_Fk) references dbo.TB_TipoProducto(Tb_Tp_Id)
  , constraint Fk_Proveedor foreign key(Tb_Prov_Id_Fk) references dbo.TB_Proveedor(Tb_Prov_Id)
  )
go