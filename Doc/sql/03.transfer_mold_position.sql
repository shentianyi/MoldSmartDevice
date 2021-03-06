/****** Script for SelectTopNRows command from SSMS  ******/
update UniqStorage set PositionId =(SELECT  PositionID  FROM  Position where PositionNR='NeoniMoldTransfer01')
where PositionId in(SELECT  PositionID  FROM  Position where PositionNR=@posi);
update UniqStorage set PositionId =(SELECT  top 1  PositionID  FROM  Position where PositionNR=@posi)
where UniqNR=@nr;
if (select [State] from Mold where MoldNR=@nr)=1
begin 
 insert into StorageRecord(StorageRecordNR,PositionId,Destination,[Date],Quantity,RecordType,TargetNR,OperatorId)
 values(@guid,(select top 1 PositionID from Position where PositionNR=@posi),@posi,GETDATE(),1,5,@nr,'DATA-ADMIN');
 update MoldLastRecord set StorageRecordNR=@guid where MoldNR=@nr;
end
