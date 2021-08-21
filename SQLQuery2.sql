BULK INSERT StationDataSet
	FROM 'F:\2021\Monash\FIT5120 - Studio Project\StationData2.csv'
	WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
go

Delete From StationDataSet;
DBCC CHECKIDENT ('StationDataSet', RESEED, 0);