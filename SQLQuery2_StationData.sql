BULK INSERT StationData
	FROM 'C:\Users\mac\Downloads\StationData2.csv'
	WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO