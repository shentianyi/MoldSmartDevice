use ToolingManDB
go

--init data in Warehouse 0-uniq warehouse,1-batch warehouse
insert into Warehouse(WarehouseNR,Name,WarehouseType)
values('UNIQ-WARE-001','Î¨Ò»¼þ²Ö001',0);

 --init data in Position 
 insert into Position(PositionID,WarehouseNR,PositionNR,Capicity)
 values(NEWID(),'UNIQ-WARE-001','NeoniMoldPool01',1000000);
 
 -- insert into Position(PositionID,WarehouseNR,PositionNR,Capicity)
 --values(NEWID(),'UNIQ-WARE-001','NeoniMoldTransfer01',1000000);
 
 --init data in UniqStorage,PositionId
 --insert into UniqStorage(UniqStorageId,PositionId,Quantity)
 --values(NEWID(),
 --(select PositionID from Position where PositionNR='NeoniMoldTransfer01'),0);
 