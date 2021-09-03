Delete From StationSet
Delete From StationDataSet
Delete From ApplianceSet
Delete From PostcodeDataSet
DBCC CHECKIDENT ('StationSet', RESEED, 0)
DBCC CHECKIDENT ('StationDataSet', RESEED, 0)
DBCC CHECKIDENT ('ApplianceSet', RESEED, 0);
DBCC CHECKIDENT ('PostcodeDataSet', RESEED, 0);


BULK INSERT StationSet
	FROM 'F:\2021\Monash\FIT5120 - Studio Project\Station.csv'
	WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
BULK INSERT StationDataSet
	FROM 'F:\2021\Monash\FIT5120 - Studio Project\StationData.csv'
	WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
BULK INSERT ApplianceSet
	FROM 'F:\2021\Monash\FIT5120 - Studio Project\Appliance.csv'
	WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
BULK INSERT PostcodeDataSet
	FROM 'F:\2021\Monash\FIT5120 - Studio Project\Station.csv'
	WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'

