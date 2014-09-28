 if not exists(select * from Position where WarehouseNR='UNIQ-WARE-001' and PositionNR='LeoniMoldTransfer01')
  insert into Position(PositionID,WarehouseNR,PositionNR,Capicity)
  values(NEWID(),'UNIQ-WARE-001','NeoniMoldTransfer01',1000000)
 